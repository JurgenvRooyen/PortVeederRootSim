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
    var buildDir = Directory("./build/dev/bin") + Directory(configuration);
    CleanDirectory(buildDir);
});

Task("Restore-NuGetPackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./PortVeederRootGaugeSimulator.sln");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./PortVeederRootGaugeSimulator.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Run-UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest();
});

Task("Publish-Full")
    .IsDependentOn("Run-UnitTests")
    .Does(() =>
{
    DotNetCorePublish("./PortVeederRootGaugeSimulator.sln");
});


Task("Publish-Minimal")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCorePublish("./PortVeederRootGaugeSimulator.sln");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-UnitTests");

Task("Publish")
.IsDependentOn("Publish-Full");

Task("PublishLean")
.IsDependentOn("Publish-Minimal");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);