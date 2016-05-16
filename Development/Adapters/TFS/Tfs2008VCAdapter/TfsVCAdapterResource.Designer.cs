﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.TeamFoundation.Migration.Tfs2008VCAdapter {
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
    internal class TfsVCAdapterResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TfsVCAdapterResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.TeamFoundation.Migration.Tfs2008VCAdapter.TfsVCAdapterResource", typeof(TfsVCAdapterResource).Assembly);
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
        ///   Looks up a localized string similar to (Edited by {0}).
        /// </summary>
        internal static string AuthorFallbackNote {
            get {
                return ResourceManager.GetString("AuthorFallbackNote", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The branch operation cannot be migrated as the branch parent {0};c{1} is not migrated..
        /// </summary>
        internal static string BranchParentVersionNotFound {
            get {
                return ResourceManager.GetString("BranchParentVersionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to cannot be deleted because it is not empty..
        /// </summary>
        internal static string CantDeleteNonEmptyDirPath {
            get {
                return ResourceManager.GetString("CantDeleteNonEmptyDirPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checkin failed for unknown reason.
        /// </summary>
        internal static string CheckinFailedForUnknownReason {
            get {
                return ResourceManager.GetString("CheckinFailedForUnknownReason", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A compatibility problem was found when trying to migrate between VS2005 SP1 client and VS2008 server. Please upgrade your client to VS2008 and resume the migration.
        /// </summary>
        internal static string ClientNotCompatible {
            get {
                return ResourceManager.GetString("ClientNotCompatible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Migration toolkit does not support VS2005 RTM. Please upgrade the client and server to VS2005 SP1 and resume the migration..
        /// </summary>
        internal static string ClientNotSupported {
            get {
                return ResourceManager.GetString("ClientNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conflicts shelved in {0}.
        /// </summary>
        internal static string ConflictShelvesetCreated {
            get {
                return ResourceManager.GetString("ConflictShelvesetCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No containing folder found for item at path &apos;{0}&apos;.
        /// </summary>
        internal static string ContainingFolderNotFound {
            get {
                return ResourceManager.GetString("ContainingFolderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find root DiffItem for path: {0}.
        /// </summary>
        internal static string CouldNotFindRootDiffItem {
            get {
                return ResourceManager.GetString("CouldNotFindRootDiffItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Migrated by TFS Migration Toolkit.
        /// </summary>
        internal static string DefaultCommentModifier {
            get {
                return ResourceManager.GetString("DefaultCommentModifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The deleted item {0} does not exist..
        /// </summary>
        internal static string DeletedItemNotFound {
            get {
                return ResourceManager.GetString("DeletedItemNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot determine the correct item on path {0} to undelete.  The latest deleted version will be undeleted..
        /// </summary>
        internal static string DeletedVersionNotFound {
            get {
                return ResourceManager.GetString("DeletedVersionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Delete it manually..
        /// </summary>
        internal static string DeleteNonEmptyDirPathManually {
            get {
                return ResourceManager.GetString("DeleteNonEmptyDirPathManually", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: Change action is not supported..
        /// </summary>
        internal static string ErrorUnsupportedChangeAction {
            get {
                return ResourceManager.GetString("ErrorUnsupportedChangeAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to create label &apos;{0}&apos;: {1}.
        /// </summary>
        internal static string ExceptionCreatingLabel {
            get {
                return ResourceManager.GetString("ExceptionCreatingLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The lastProcessedChangeItemId argument (&apos;{0}&apos;) is not in the correct format..
        /// </summary>
        internal static string InvalidChangeItemIdFormat {
            get {
                return ResourceManager.GetString("InvalidChangeItemIdFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided TFS server path is invalid. It exceeds the maximum length of 260 characters: {0}.
        /// </summary>
        internal static string InvalidServerPath_260Limit {
            get {
                return ResourceManager.GetString("InvalidServerPath_260Limit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided TFS server path is invalid.  It contains a segment that begins with a dollar sign: {0}.
        /// </summary>
        internal static string InvalidServerPath_DollarSegment {
            get {
                return ResourceManager.GetString("InvalidServerPath_DollarSegment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided TFS server path is invalid.  It must begin with &quot;$/&quot;: {0}.
        /// </summary>
        internal static string InvalidServerPath_MustStartWithDollarSlash {
            get {
                return ResourceManager.GetString("InvalidServerPath_MustStartWithDollarSlash", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided TFS server path was null or empty..
        /// </summary>
        internal static string InvalidServerPath_NullOrEmpty {
            get {
                return ResourceManager.GetString("InvalidServerPath_NullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided TFS server path is invalid. It uses the incorrect slash direction (\ instead of /): {0}.
        /// </summary>
        internal static string InvalidServerPath_WrongSlashes {
            get {
                return ResourceManager.GetString("InvalidServerPath_WrongSlashes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified snap shot start point string &apos;{0}&apos; is in a wrong format..
        /// </summary>
        internal static string InvalidSnapShotString {
            get {
                return ResourceManager.GetString("InvalidSnapShotString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The merge operation cannot be migrated as item {0};c{1} is not migrated..
        /// </summary>
        internal static string MergeVersionNotFound {
            get {
                return ResourceManager.GetString("MergeVersionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to pend the {0} action from {1} to {2}.
        /// </summary>
        internal static string MultiItemActionFailed {
            get {
                return ResourceManager.GetString("MultiItemActionFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The snapshot changeset {0} is not a valid changeset number..
        /// </summary>
        internal static string PathSnapShotFormatError {
            get {
                return ResourceManager.GetString("PathSnapShotFormatError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The server item path cannot be null or empty..
        /// </summary>
        internal static string ServerItemIsNullOrEmpty {
            get {
                return ResourceManager.GetString("ServerItemIsNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Compatibility Error: Successful migration requires a server version of 2005 SP1 or later. Please install SP1 on your server and resume migration..
        /// </summary>
        internal static string ServerNotCompatible {
            get {
                return ResourceManager.GetString("ServerNotCompatible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to pend the {0} action to {1}.
        /// </summary>
        internal static string SingleItemActionFailed {
            get {
                return ResourceManager.GetString("SingleItemActionFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Merge action of deleted item {0} was skipped..
        /// </summary>
        internal static string SkipDeletedMerge {
            get {
                return ResourceManager.GetString("SkipDeletedMerge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Skipped missing item. {0} is missing from the target system.
        /// </summary>
        internal static string SkipMissingItem {
            get {
                return ResourceManager.GetString("SkipMissingItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The TFS version control item &quot;{0}&quot; does not exist..
        /// </summary>
        internal static string TfsItemMissing {
            get {
                return ResourceManager.GetString("TfsItemMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The migration engine is unable to resolve a conflict where two changes have the same source item: {0}.
        /// </summary>
        internal static string TwoChangesWithSameSource {
            get {
                return ResourceManager.GetString("TwoChangesWithSameSource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The migration engine is unable to resolve a conflict where two changes have the same target item: {0}.
        /// </summary>
        internal static string TwoChangesWithSameTarget {
            get {
                return ResourceManager.GetString("TwoChangesWithSameTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected number of items were returned.  Expected {0} but received {1}..
        /// </summary>
        internal static string UnexpectedNumberOfItems {
            get {
                return ResourceManager.GetString("UnexpectedNumberOfItems", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unknown change type has been encountered while processing {0};{1}: {2}.
        /// </summary>
        internal static string UnknownChangeTypeDuringAnalysis {
            get {
                return ResourceManager.GetString("UnknownChangeTypeDuringAnalysis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No version control mapping was found for the item {0}.
        /// </summary>
        internal static string VCMappingMissing {
            get {
                return ResourceManager.GetString("VCMappingMissing", resourceCulture);
            }
        }
    }
}
