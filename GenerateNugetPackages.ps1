remove-item ExpressiveReflection*.nupkg

msbuild ExpressiveAssertions/ExpressiveAssertions.csproj /p:Configuration=Release
msbuild ExpressiveAssertions.MSTest/ExpressiveAssertions.MSTest.csproj /p:Configuration=Release

nuget pack 'ExpressiveAssertions/Package.nuspec' -Symbol -Prop Configuration=Release
nuget pack 'ExpressiveAssertions.MSTest/Package.nuspec' -Symbol -Prop Configuration=Release

# vim: set expandtab ts=2 sw=2: 
