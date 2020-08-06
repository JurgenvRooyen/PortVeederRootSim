#tool "nuget:?package=nuget.commandline&version=5.3.0"
#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    var buildDir = Directory("./src/Example/bin") + Directory(configuration);
    CleanDirectory(buildDir);
});

Task("Restore-NuGetPackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./PortVeederRootGaugeSimulator.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGetPackages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild(
          "./PortVeederRootGaugeSimulator.sln",
          settings => settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild(
          "./src/Example.sln",
          settings => settings.SetConfiguration(configuration));
    }
});

Task("Run-UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3(
        "./src/**/bin/" + configuration + "/*.Tests.dll",
        new NUnit3Settings
        {
            NoResults = true
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-UnitTests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);