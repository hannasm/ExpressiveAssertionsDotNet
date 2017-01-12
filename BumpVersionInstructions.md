* Update README text to indicate current version
* Update Nuget Package Link in README.md
* Update source tag link in README.md
* Update Changelog at bottom of REAMDE.md
* Update Version Number in metadata.xml
* Update release notes in metadata.xml
* run 'powershell GenerateNugetPackages.ps1' from nuget package manager console inside visual studio (uses ENV.DTE stuff to build)
  * this should automatically update package.nuspec and sharedAssemblyInfo.cs and rebuild all release dlls
* commit all changes git at this point (so all versioning changes are included)
* run 'powershell PublishNugetPackages.ps1' from nuget package manager console inside visual studio (uses ENV.DTE stuff to build)
* create tag for release on github