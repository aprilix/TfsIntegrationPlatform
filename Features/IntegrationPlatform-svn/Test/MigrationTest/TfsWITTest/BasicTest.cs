﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Migration.BusinessModel;
using Microsoft.TeamFoundation.Migration.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MigrationTestLibrary;
using MigrationTestLibrary.Conflict;
using Microsoft.TeamFoundation.Migration.Toolkit.ServerDiff;

namespace TfsWitTest
{
    /// <summary>
    /// WIT basic tests
    /// </summary>
    [TestClass]
    public class BasicTest : TfsWITTestCaseBase
    {
        ///<summary>
        /// Establish context
        /// Once we verify that this test case is successful, 
        /// we can skip context sync in other test cases to speed up
        ///</summary>
        [TestMethod(), Priority(1), Owner("hykwon")]
        [Description("Establish context")]
        public void EstablishContextTest()
        {
            // TODO: 
            // Change to one way + 'one way context sync'
            TestEnvironment.WorkFlowType = new WorkFlowType();
            TestEnvironment.WorkFlowType.DirectionOfFlow = DirectionOfFlow.Unidirectional;
            TestEnvironment.WorkFlowType.Frequency = Frequency.ContinuousManual;
            TestEnvironment.WorkFlowType.SyncContext = SyncContext.Unidirectional;

            RunAndNoValidate();

            // verify there's no conflicts raised           
            ConflictResolver conflictResolver = new ConflictResolver(Configuration);
            List<RTConflict> conflicts = conflictResolver.GetConflicts();
            Assert.AreEqual(0, conflicts.Count, "There should be no conflicts");
        }

        ///<summary>
        /// Migrate a work item
        ///</summary>
        [TestMethod(), Priority(1), Owner("hykwon")]
        [Description("Migrate a work item")]
        public void BasicWorkItemTest()
        {
            TestEnvironment.CustomActions += new MigrationTestEnvironment.Customize(ConfigCustomizer.CustomActions_DisableContextSync);

            // add a work item on source side
            string title = string.Format("{0} {1}", TestContext.TestName, DateTime.Now.ToString("HH'_'mm'_'ss"));
            
            int workitemId = SourceAdapter.AddWorkItem("Bug", title, "description1");

            RunAndNoValidate();

            // verify there's no conflicts raised           
            ConflictResolver conflictResolver = new ConflictResolver(Configuration);
            List<RTConflict> conflicts = conflictResolver.GetConflicts();
            Assert.AreEqual(0, conflicts.Count, "There should be no conflicts");

            // verify sync result 
            WitDiffResult result = GetDiffResult();

            // ignore Area/Iteration path mismatches
            VerifySyncResult(result, new List<string> { "System.IterationPath", "System.AreaPath" });
        }
    }
}
