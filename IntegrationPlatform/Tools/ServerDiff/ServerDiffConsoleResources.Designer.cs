﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerDiff {
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
    internal class ServerDiffConsoleResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServerDiffConsoleResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ServerDiff.ServerDiffConsoleResources", typeof(ServerDiffConsoleResources).Assembly);
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
        ///   Looks up a localized string similar to The file specified by the /ForceSyncFile option must have a &quot;.csv&quot; extension..
        /// </summary>
        internal static string ForceSyncFileRequiresCsvExtension {
            get {
                return ResourceManager.GetString("ForceSyncFileRequiresCsvExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ///
        ///ServerDiff vc [/Session:&lt;sessionUniqueId&gt;]
        ///              [/LeftVersion:&lt;version&gt; /RightVersion:&lt;version&gt;] 
        ///              [/NoContentComparison] [/Verbose]
        ///
        ///Compares the version control files in two servers that are particating in a 
        ///migration or sync session.
        ///
        ////Session (or /s): Specifies the Guid of a Session that should be used as the
        ///                  basic for the comparison.
        ///                  If the /session argument is not supplied, the most recently 
        ///                  started versi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ServerDiffUsage {
            get {
                return ResourceManager.GetString("ServerDiffUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value provided for the /Session argument is not a valid Guid: {0}.
        /// </summary>
        internal static string SessionArgIsNotGuid {
            get {
                return ResourceManager.GetString("SessionArgIsNotGuid", resourceCulture);
            }
        }
    }
}
