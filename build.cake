var target = Argument("target", "Default");

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .Does(() =>
    {
    });

Task("Build")
    .Does(() =>
    {
		var buildSettings = new MSBuildSettings()
			.SetConfiguration("Release")
			.SetVerbosity(Verbosity.Minimal)
			.WithRestore();

        MSBuild("./AutoFixture.Optional.sln",  buildSettings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        MSTest("./AutoFixture.Optional.Tests/AutoFixture.Optional.Tests/bin/release/**/Optional.Tests.dll");
    });

Task("Pack")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .Does(() =>
    {
        Pack("AutoFixture.Optional", new [] { "netstandard2.0", "netcoreapp2.0" });
    });
    
RunTarget(target);

public void Pack(string projectName, string[] targets) 
{
	var buildSettings = new DotNetCoreMSBuildSettings()
			.WithProperty("NuspecFile", "../nuget/AutoFixture.Optional.nuspec")
			.WithProperty("NuspecBasePath", "bin/Release");
	var settings = new DotNetCorePackSettings
	{
		MSBuildSettings = buildSettings,
		Configuration = "Release",
		IncludeSource = true
	};
    DotNetCorePack("./AutoFixture.Optional/" + projectName + ".csproj", settings);
}