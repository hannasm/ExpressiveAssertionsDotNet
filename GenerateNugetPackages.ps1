$scriptPath = split-path $SCRIPT:MyInvocation.MyCommand.Path -parent;
& (join-path $scriptPath 'GenerateAssemblyInfo.ps1') $scriptPath;

& (join-path $scriptPath 'UpdateNugetPackageIfNeeded.ps1') $scriptPath (join-path $scriptPath 'ExpressiveAssertions')
& (join-path $scriptPath 'UpdateNugetPackageIfNeeded.ps1') $scriptPath (join-path $scriptPath 'ExpressiveAssertions.MSTest')

if (!(get-command 'Get-Project' -errorAction SilentlyContinue)) {
	throw ('this script is intended to be run from the nuget package manager console inside visual studio which has access to visual studio DTE');
}

$project = Get-Project | select -First 1
$build = $dte.Solution.SolutionBuild;
if (!$dte.Solution.SolutionBuild) {
	throw ('unable to locate solution build component from visual studio environment');
}

$oldCfg = $dte.Solution.SolutionBuild.ActiveConfiguration
$newCfg = $dte.Solution.SolutionBuild.SolutionConfigurations | where {$_.Name -eq 'Release'}
$newCfg.Activate();

$build.Clean($true);
$build.Build($true);

nuget pack 'ExpressiveAssertions/Package.nuspec' -Symbol -Prop Configuration=Release
nuget pack 'ExpressiveAssertions.MSTest/Package.nuspec' -Symbol -Prop Configuration=Release

$oldCfg.Activate();

# vim: set expandtab ts=2 sw=2: