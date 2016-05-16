﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.TeamFoundation.Converters.Utility {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CQConverter.Utility.CommonResource", typeof(CommonResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analysis completed.
        /// </summary>
        internal static string AnalysisCompleted {
            get {
                return ResourceManager.GetString("AnalysisCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analysis failed.
        /// </summary>
        internal static string AnalysisFailed {
            get {
                return ResourceManager.GetString("AnalysisFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analysis Report.
        /// </summary>
        internal static string AnalysisReportTitle {
            get {
                return ResourceManager.GetString("AnalysisReportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copyright © Microsoft Corporation.  All Rights Reserved.
        ///This code released under the terms of the
        ///Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
        ///.
        /// </summary>
        internal static string CopyRightMessage {
            get {
                return ResourceManager.GetString("CopyRightMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Work Item TFS ID {0}: Modified the attachment file {1} write time to {2} because the original time was corrupt..
        /// </summary>
        internal static string CorruptFileDateTime {
            get {
                return ResourceManager.GetString("CorruptFileDateTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: The drive {0} is out of space. Please perform a disk clean up on the drive to continue..
        /// </summary>
        internal static string DiskFull {
            get {
                return ResourceManager.GetString("DiskFull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ..
        /// </summary>
        internal static string DisplayProgressIndicator {
            get {
                return ResourceManager.GetString("DisplayProgressIndicator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown or Duplicated switch {0}.
        /// </summary>
        internal static string DuplicatedArgument {
            get {
                return ResourceManager.GetString("DuplicatedArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {{Total Errors {0}}} ERROR: {1}.
        /// </summary>
        internal static string ErrorStart {
            get {
                return ResourceManager.GetString("ErrorStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to write to file {0}. This could be due drive being out of space or network issue. Please take corrective action and press any key to continue.
        ///
        ///.
        /// </summary>
        internal static string ErrorWritingFileRetry {
            get {
                return ResourceManager.GetString("ErrorWritingFileRetry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60035: Unable to open file {0}. {1}.
        /// </summary>
        internal static string FileAccessError {
            get {
                return ResourceManager.GetString("FileAccessError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60036: Unable to open the file {0} specified in {1}. {2}.
        /// </summary>
        internal static string FileAccessSchemaError {
            get {
                return ResourceManager.GetString("FileAccessSchemaError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to write to file {0}. Error {1}.
        /// </summary>
        internal static string FileWriteError {
            get {
                return ResourceManager.GetString("FileWriteError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60037: Unrecognized command: {0}.
        /// </summary>
        internal static string InvalidArgument {
            get {
                return ResourceManager.GetString("InvalidArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value {0} specified in the node {1} in the converter configuration file {2} was not recognized as a valid Boolean value. Please use the values True or False..
        /// </summary>
        internal static string InvalidBoolean {
            get {
                return ResourceManager.GetString("InvalidBoolean", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Migration completed..
        /// </summary>
        internal static string MigrationCompleted {
            get {
                return ResourceManager.GetString("MigrationCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Migration failed..
        /// </summary>
        internal static string MigrationFailed {
            get {
                return ResourceManager.GetString("MigrationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Migration Report.
        /// </summary>
        internal static string MigrationReportTitle {
            get {
                return ResourceManager.GetString("MigrationReportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing switch {0}.
        /// </summary>
        internal static string MissingArgument {
            get {
                return ResourceManager.GetString("MissingArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60093: Node {0} not found in file {1}..
        /// </summary>
        internal static string NodeNotFound {
            get {
                return ResourceManager.GetString("NodeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to *.
        /// </summary>
        internal static string PasswordEchoChar {
            get {
                return ResourceManager.GetString("PasswordEchoChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The process is unable to complete the requested action because it is terminating..
        /// </summary>
        internal static string ProcessAborting {
            get {
                return ResourceManager.GetString("ProcessAborting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Process Incomplete.
        /// </summary>
        internal static string ProcessIncomplete {
            get {
                return ResourceManager.GetString("ProcessIncomplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to open or read standard input. Please verify that you are not redirecting standard input stream and try again..
        /// </summary>
        internal static string StandardInputError {
            get {
                return ResourceManager.GetString("StandardInputError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60070: Unable to connect to the Team Foundation Server: &apos;{0}&apos;. Please ensure that the Team Foundation Server exists and try again..
        /// </summary>
        internal static string TfsConnectFailure {
            get {
                return ResourceManager.GetString("TfsConnectFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60071: Your user account does not have permission to connect to the Team Foundation Server &apos;{0}&apos;. Please contact your Team Foundation Server administrator and request that the appropriate permission be added to your account..
        /// </summary>
        internal static string TfsNotAuthorized {
            get {
                return ResourceManager.GetString("TfsNotAuthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60040: Unable to create error file {0}. - {1}..
        /// </summary>
        internal static string UnableToCreateErrorFile {
            get {
                return ResourceManager.GetString("UnableToCreateErrorFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The application is unable to handle exception: {0}.
        /// </summary>
        internal static string UnhandledException {
            get {
                return ResourceManager.GetString("UnhandledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing input for the switch {0}.
        /// </summary>
        internal static string ValueCannotBeNull {
            get {
                return ResourceManager.GetString("ValueCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60094: Validation failed for file &apos;{0}&apos;. Error: {1}.
        /// </summary>
        internal static string XmlFileValidationFailed {
            get {
                return ResourceManager.GetString("XmlFileValidationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF60095: Validation failed for file &apos;{0}&apos;. Line: {1}, Col: {2}, Error: {3}.
        /// </summary>
        internal static string XmlSchemaValidationFailed {
            get {
                return ResourceManager.GetString("XmlSchemaValidationFailed", resourceCulture);
            }
        }
    }
}