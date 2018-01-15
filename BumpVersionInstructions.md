* Update README text to indicate current version
* Update Nuget Package Link in README.md
* Update source tag link in README.md
* Update Changelog in ExpressiveAssertions.ReleaseNotes.md
* Update Version Number in ExpressiveAssertions.VersionNumber.metadata
* Running dotnet build or dotnet pack will both generate the nuspec file (which should be checked in)
* commit all changes git at this point (so all versioning changes are included)
* run dotnet pack -c Release / dotnet nuget push to package and publish to nuget.org
* create tag for release on github
