﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.TeamFoundation.Migration.BusinessModel;
using Microsoft.TeamFoundation.Migration.Toolkit.ServerDiff;
using MigrationTestLibrary;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.TeamFoundation.Migration.BusinessModel.WIT;
using TfsMigrationTestLibrary;
using Microsoft.TeamFoundation.Migration.EntityModel;

namespace TfsWitTest
{
    [TestClass]
    public abstract class TfsWITTestCaseBase : WITMigrationTestCaseBase
    {
        public const string FIELD_TITLE = "System.Title";
        public const string FIELD_DESCRIPTION = "System.Description";
        public const string FIELD_PRIORITY = "Microsoft.VSTS.Common.Priority";
        public const string FIELD_ITERATION_PATH = "System.IterationPath";
        public const string FIELD_AREA_PATH  = "System.AreaPath";
        public const string FIELD_ASSIGNEDTO = "System.AssignedTo";
        
        protected override string TestProjectName
        {
            get
            {
                return "TfsWITTest";
            }
        }

        protected ITfsWITTestCaseAdapter TfsSourceAdapter
        {
            get
            {
                return (ITfsWITTestCaseAdapter)SourceAdapter;
            }
        }

        protected ITfsWITTestCaseAdapter TfsTargetAdapter
        {
            get
            {
                return (ITfsWITTestCaseAdapter)TargetAdapter;
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
 	        base.Initialize();
        }   

        protected int QueryMirroredWorkItemID(int sourceWorkItemID)
        {
            Guid migrationSourceId = new Guid(Configuration.SessionGroup.Sessions.Session[0].LeftMigrationSourceUniqueId);
            String mirroredWorkItemId = TryGetTargetItemId(sourceWorkItemID.ToString(), migrationSourceId);

            int id;
            if (int.TryParse(mirroredWorkItemId, out id))
            {
                return id;
            }
            else
            {
                return -1;
            }
        }

        internal WitDiffResult GetDiffResult()
        {
            ServerDiffEngine diff = new ServerDiffEngine(Guid.Empty, false, true, SessionTypeEnum.WorkItemTracking);
            WITDiffComparer witDiffComparer = new WITDiffComparer(diff);
            diff.RegisterDiffComparer(witDiffComparer);

            // Add additional fields for which different values should not cause a failure because
            // the tests are configured such that these will be different
            HashSet<string> fieldsToIgnore = new HashSet<string>();
            fieldsToIgnore.Add("System.AreaPath");
            fieldsToIgnore.Add("System.IterationPath");

            bool allContentsMatch = witDiffComparer.VerifyContentsMatch(null, null, fieldsToIgnore, fieldsToIgnore);
            WitDiffResult result = witDiffComparer.DiffResult;

            Trace.TraceInformation("==============  Result ===================");
            Trace.TraceInformation("Work Item count: {0}", result.WorkItemCount);
            Trace.TraceInformation("#Attachments mismatch: {0}", result.AttachmentMismatchCount);
            Trace.TraceInformation("#Links mismatch: {0}", result.LinkMismatchCount);
            Trace.TraceInformation("#Content mismatch: {0}", result.ContentMismatchCount);
            Trace.TraceInformation("All contents match: {0}", allContentsMatch);

            return result;
        }

        internal override WitDiffResult VerifySyncResult()
        {
            WitDiffResult result = GetDiffResult();

            Assert.AreEqual(0, result.AttachmentMismatchCount, "# of attachments mismatch");
            Assert.AreEqual(0, result.LinkMismatchCount, "# of links mismatch");
            Assert.AreEqual(0, result.ContentMismatchCount, "content mismatch");

            return result;
        }

        internal void VerifySyncResult(WitDiffResult diffResult, List<string> ignoreFieldNames)
        {
            Assert.AreEqual(0, diffResult.AttachmentMismatchCount, "# of attachments mismatch");
            Assert.AreEqual(0, diffResult.LinkMismatchCount, "# of links mismatch");
            
            foreach (WitDiffPair pair in diffResult.WitDiffPairs)
            {
                int fieldMismatchCount = 0;
                foreach (WitDiffField f in pair.DiffFields)
                {
                    if (Contains(ignoreFieldNames, f.FieldName))
                    {
                        Trace.TraceInformation("Ignore field mismatch: {0}", f.FieldName);
                        fieldMismatchCount++;
                    }
                }
                Assert.AreEqual(pair.DiffFields.Count, fieldMismatchCount);
            }

            Trace.TraceInformation("Content match!");
        }

        protected void SetWitSessionCustomSetting(Configuration config, WITSessionCustomSetting customSetting)
        {
            customSetting.SessionConfig = config.SessionGroup.Sessions.Session[0];
            customSetting.Update();
        }

        #region private methods
        private WorkItemStore GetWorkItemStore(string serverUrl)
        {
            Trace.TraceInformation("Connecting to '{0}'", serverUrl);
            TeamFoundationServer tfs = new TeamFoundationServer(serverUrl);
            WorkItemStore wi = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
            Trace.TraceInformation("Connected to '{0}'", serverUrl);

            return wi;
        }

        private bool Contains(List<string> ignoreFieldNames, string fieldName)
        {
            foreach (string name in ignoreFieldNames)
            {
                if (name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
