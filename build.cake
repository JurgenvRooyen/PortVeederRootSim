#tool "nuget:?package=nuget.commandline&version=5.3.0"
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool nuget:?package=NUnit.Extension.VSProjectLoader
#tool "nuget:?package=OpenCover"
#addin nuget:?package=Cake.Coverlet

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
    var publishDir = Directory("./PortVeederRootGaugeSim/bin");
    CleanDirectory(buildDir);
    CleanDirectory(publishDir);
    CleanDirectory("./SimulatorTest/TestResults");
    CleanDirectory("./PortVeederRootGaugeSimulatorBlackTesting/TestResults");
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
    var testSettings = new DotNetCoreTestSettings {
    };

    var coverletSettingsBB = new CoverletSettings {
        CollectCoverage = true,
        CoverletOutputFormat = CoverletOutputFormat.opencover,
        CoverletOutputDirectory = Directory("./PortVeederRootGaugeSimulatorBlackTesting/TestResults"),
        CoverletOutputName = $"coverage"
    };

    var coverletSettingsWB = new CoverletSettings {
        CollectCoverage = true,
        CoverletOutputFormat = CoverletOutputFormat.opencover,
        CoverletOutputDirectory = Directory("./SimulatorTest/TestResults"),
        CoverletOutputName = $"coverage"
    };

    DotNetCoreTest("./PortVeederRootGaugeSimulatorBlackTesting",testSettings,coverletSettingsBB);
    DotNetCoreTest("./SimulatorTest",testSettings,coverletSettingsWB);
});

Task("Publish-Minimal64")
    .IsDependentOn("Run-UnitTests")
    .Does(() =>
{
     var settings = new DotNetCorePublishSettings
    {
        Framework = "netcoreapp3.1",
        OutputDirectory = "./build/dev/bin/Release/x64",
        Runtime = "win-x64",
        PublishSingleFile = true,
        SelfContained = false,
        PublishReadyToRun = false
    };
    DotNetCorePublish("./PortVeederRootGaugeSim", settings);
});

Task("Publish-Minimal86")
    .IsDependentOn("Publish-Minimal64")
    .Does(() =>
{
     var settings = new DotNetCorePublishSettings
    {
        Framework = "netcoreapp3.1",
        OutputDirectory = "./build/dev/bin/Release/x86",
        Runtime = "win-x86",
        PublishSingleFile = true,
        SelfContained = false,
        PublishReadyToRun = false
    };
    DotNetCorePublish("./PortVeederRootGaugeSim", settings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-UnitTests");

Task("Publish")
    .IsDependentOn("Publish-Minimal86");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);