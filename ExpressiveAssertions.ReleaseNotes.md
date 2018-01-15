    * 0.9.8 - upgrade to netstandard 2.0 
    * 0.9.7 - addition of AssertionInverterTool to treat all success as failure and all failure as success
    * 0.9.7 - addition of IgnoreDeclaredFailureAssertionTool which will ignore any declared failure assertions
    * 0.9.7 - addition of IgnoreInconclsuiveAssertionTool which will ignore any inconclusive assertions
    * 0.9.6 - fix bug with mstest handling of assertion messages
    * 0.9.5 - fix bug in short assertion renderer causing all failed assertions to be marked as success
    * 0.9.4 - fixed another nuget packaging bug
    * 0.9.3 - added some tests on the base assertions
    * 0.9.3 - refactored a number of specialized / internally focused classes to separate namespaces to limit clutter in the primary namespace
    * 0.9.3 - cleaned up some documentation in README.md
    * 0.9.3 - nuget package now qualifies the readme as README_ExpressiveAssertions.md instead of just README.md
    * 0.9.3 - MSTest assertion no longer renders assertions automatically, you must specifically chain it with a renderer assertion (such as the builtin ShortAssertionRendererTool)
    * 0.9.2 - better error reporting in the mstest driver
    * 0.9.2 - started removing code contracts stuff because they don't report error messages the way i want
    * 0.9.2 - Renamed the Assert() method to be just another overload of Check() instead
    * 0.9.2 - Add the concept of context data including api methods for using It
    * 0.9.2 - updates to generic AreEqual and AreNotEqual to use object.Equals() for proper equality checking in case of anonymous types
    * 0.9.2 - new assertions nfor IsInstanceof() / IsNotInstanceOf()
    * 0.9.2 - add initial suite of assertions for collection types
    * 0.9.2 - new assertions for IsNull() / IsNotNull()
    * 0.9.2 - new assertions for IsTrue() / IsFalse()
    * 0.9.2 - new assertions for Throws()
    * 0.9.2 - add SoftAssertionTool
    * 0.9.2 - unit testing for assertion context code
    * 0.9.1 - add license files to nuget package
    * 0.9.0 - this is the initial release, and is a beta / alpha version with some incomplete / missing features
