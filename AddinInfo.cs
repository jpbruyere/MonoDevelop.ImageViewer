
using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin ("ImageViewer", 
        Namespace = "MonoDevelop",
        Version = MonoDevelop.BuildInfo.Version,
        Category = "IDE extensions")]

[assembly:AddinName ("MonoDevelop Image Viewer")]
[assembly:AddinDescription ("Provides images visualization facilities for MonoDevelop")]

[assembly:AddinDependency ("Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("Ide", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("Debugger", MonoDevelop.BuildInfo.Version)]
