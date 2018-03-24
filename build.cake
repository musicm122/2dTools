#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#reference "tools/Cake.Standard.Unity.dll"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument ("target", "Default");
var configuration = Argument ("configuration", "Release");
var baseDir = ".bin";
//var exportPath = "./Assets";
//var unityPath = "";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/Example/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Unity")
.Does(() =>
{
    var projectPath = @"C:\Project\UnityGame";

    // Build for Windows (x86)
    UnityBuild(projectPath, UnityBuildPlayer.Windows, @"C:\Output\Game.exe");

    // Execute script method
    UnityExecuteMethod(projectPath, "Class.Method");

    // Export .unitypackage
    UnityExportPackage(projectPath, "Result.unitypackage", @"Assets\ToExport");

    // Import .unitypackage
    UnityExportPackage(projectPath, "Import.unitypackage");
});

RunTarget("Unity");


Task("ExportUnityPackage")
.Does(() =>
{
    //var projectPath = @"C:\Project\UnityGame";

    // Build for Windows (x86)
    //UnityBuild (projectPath, UnityBuildPlayer.Windows, @"C:\Output\Game.exe");

    // Execute script method
    //UnityExecuteMethod (projectPath, "Class.Method");

    // Export .unitypackage
    //UnityExportPackage (projectPath, "Result.unitypackage", @"Assets\ToExport");
    UnityExportPackage("ToolSet2d.unitypackage", @"Assets\Audio", @"Assets\Editor", @"Assets\Scripts", @"Assets\Scenes", @"Assets\Presets", @"Assets\Package");

    // Import .unitypackage
    //UnityExportPackage (projectPath, "Import.unitypackage");
});

Task("Install Dependencies").Does(() =>
{
    ChocolateyInstall ("unity");
});
Task("Clean")
.Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
.IsDependentOn("Clean")
.Does(() =>
{
    NuGetRestore("./src/Example.sln");
});

Task("Build")
.IsDependentOn("Restore-NuGet-Packages")
.Does(() =>
{
    if(IsRunningOnWindows())
    {
        // Use MSBuild
        MSBuild("./src/Example.sln", settings =>
                 settings.SetConfiguration(configuration));
    }
    else
    {
        // Use XBuild
        XBuild("./src/Example.sln", settings =>
                settings.SetConfiguration(configuration));
    }
});

Task("Run-Unit-Tests")
.IsDependentOn("Build")
.Does(() =>
{
    NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings
    {
        NoResults = true
    });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
.IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

//RunTarget (target);
RunTarget("ExportUnityPackage");