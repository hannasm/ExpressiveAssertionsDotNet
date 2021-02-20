# Versioning
This is version 0.11.0 of the expressive assertions library

This package is available from nuget at: https://www.nuget.org/packages/ExpressiveAssertions/0.11.0

The source for this release is available on github at: https://github.com/hannasm/ExpressiveAssertionsDotNet/releases/tag/0.11.0

# Definitions

> Expressive

Effectively conveying thought or feeling

> Assertion

A confident and forceful statement of fact or belief

> Expressive Assertions DotNet

Effective conveyances of facts about a DotNet program, particularly suited for use in automated / unit testing

# ExpressiveAssertionsDotNet
Flexible Assertion Library Leveraging the .NET Expression Tree Syntax. This library attempts to provide a robust, open
solution to assertions and unit testing for the .NET EcoSystem that is easily portable across different unit testing
frameworks.

This library is influenced by and in many ways similar to several other assertion libraries you may or may not be familiar with:

* PowerAssert.NET - https://github.com/PowerAssert/PowerAssert.Net
* PAssert from ExpressionToCode - https://github.com/EamonNerbonne/ExpressionToCode
* MSTest Assertion Library - https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.aspx

This library attempts to provide test framework portability by separating the API used for testing program correctness, 
from the underlying mechanism that communicates with the testing framework.

This library provides first class support for customizing the rendering of assertion into more meaningful formats than built in string rendering defaults.

This library provides first class support for inspecting and manipulating the assertion processing at multiple stages allowing for extreme control of the testing and verification process.

This library provides first class support for offloading unit test expectations to the filesystem.

The following native unit testing framwork implementations are currently implemented:

* MSTest via ExpressiveAssertions.MSTest - ExpressiveAssertions.MSTest.MSTestAssertionTool
* XUnit via ExpressiveAssertions.XUnit - ExpressiveAssertions.XUnit.XUnitTestAssertionTool

*(more are welcome, please contribute)*

# Usage
The core product is the IAssertionTool interface. Assertions are implemented through extension methods
built around this interface. 

```C#
using ExpressiveAssertions;

IAssertionTool assert = ExpressiveAssertions.Tooling.AssertionRendererTool.Create(
	ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
);
```

In this case, the assertion tool is setup to communicate with the MSTest unit testing framework and use the 
built in rendering system to provide detailed assertion messages. 

Assertions should be defined using lambdas if you want to reap all of the advantages of the expressive assertion pipeline. 
At it's simplest an assertion can be written using Check()
 
```C#
int x = 10;

assert.Check(()=>x == 10); // Success Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (10).
assert.Check(()=>x == 20); // Failure Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (20)

assert.Check(()=>x, ()=>10, (a,b)=>a==b); // Success Asserting a == b with 'a'= (10) and 'b'= (10). 
assert.Check(()=>x, ()=>10, (a,b)=>a==b); // Failure Asserting a == b with 'a'= (10) and 'b'= (20).
```

The outcome of a test is separate from the calculation of and comparisons conducted by the test itself. All assertions 
(both pass and fail), are first evaluated and then conveyed through the assertion outcome pipeline. This can enable
advanced testing scenarios such as evaluating multiple assertions before failure is reported (SoftAssertionTool) 
or reversable (AssertionInverterTool), filterable (IgnoreInconclusiveAssertionTool), and introspection (IntrospectiveAssertionTool).

The Check() method overloads on the IAssertionTool makeup the entirety of the core assertion functionality. 
Everything else assertion related is syntactic sugar for calling into the check method.

## MSTest Assertion Portability

A set of (syntactic sugar) assertion methods are provided that mostly correspond directly with the base MSTEst assertion library. 

Microsoft.VisualStudio.TestTools.UnitTesting.Assert:

```C#

_assert.AreEqual(()=>1, ()=>2); // preferred
_assert.AreEqual(1, 2);

_assert.AreNotEqual(()=>1, ()=>2); // preferred
_assert.AreEqual(1,2);

_assert.AreNotSame(()=>1, ()=>2); // preferred
_assert.AreNotSame(1,2);

_assert.Fail();

_assert.Inconclusive();

_assert.IsTrue(()=>false); // preferred
_assert.IsTrue(false);

_assert.IsFalse(()=>true); // preferred
_assert.IsFalse();

_assert.IsInstanceOf<T>(()=>default(object)); // preferred
_assert.IsInstanceOf<T>(default(object)();
_assert.IsInstanceOf(typeof(T), ()=>default(object)); // preferred
_assert.IsInstanceOf(typeof(T), default(object)();

_assert.IsNotInstanceOf<T>(()=>default(object)); // preferred
_assert.IsNotInstanceOf<T>(default(object));
_assert.IsNotInstanceOf(typeof(T), ()=>default(object)); // preferred
_assert.IsNotInstanceOf(typeof(T), default(object)();

_assert.IsNull(()=>default(object)); // preferred
_assert.IsNull(default(object));

_assert.IsNotNull(()=>default(object)); // preferred
_assert.IsNotNull(default(object));

_assert.Throws<Exception>(()=>throw new Exception()); // preferred
```

All of these methods also support standard MSTest assertion messaging overloads including an extra format message, though generally this should be less 
commonly needed due to the advanced rendering features of ExpressiveAssertions.

```C#

_assert.AreEqual(()=>1, ()=>2, "Expected different universe");
_assert.AreEqual(()=>1, ()=>2, "Expected different universe where {1} = {2}", 1, 2);
```

## Collection Assertions
There are equivalent (better implementations of) features in the Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert class however they diverge in name and signature more substantially.

```C#

// CollectionAssert.AllItemsAreInstancesOfType()
_assert.Each(()=>collection, (a,e)=>a.IsInstanceOf<T>(()=>e)); // preferred
_assert.Each(()=>collection, (a,e)=>a.IsInstanceOf<T>(e));
_assert.Each(collection, (a,e)=>a.IsInstanceOf<T>(e));

// CollectionAssert.AllItemsAreNotNull()
_assert.Each(()=>collection, (a,e)=>a.IsNotNull(()=>e)); // preferred
_assert.Each(()=>collection, (a,e)=>a.IsNotNull(e));
_assert.Each(collection, (a,e)=>a.IsNotNull(e));

// CollectionAssert.AllItemsAreUnique()
_assert.EachIsDistinct(()=>collection); // preferred
_assert.EachIsDistinct(collection);

// CollectionAssert.AreEqual()
_assert.EachSorted(()=>collection1, ()=>collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2)); // preferred
_assert.EachSorted(collection1, ()=>collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));
_assert.EachSorted(()=>collection1, collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));
_assert.EachSorted(collection1, collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));

// CollectionAssert.AreEquivalent()
_assert.EachUnsorted(()=>collection1, ()=>collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2)); // preferred
_assert.EachUnsorted(collection1, ()=>collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));
_assert.EachUnsorted(()=>collection1, collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));
_assert.EachUnsorted(collection1, collection2, (a,e1,e2)=>a.AreEqual(()=>e1, ()=>e2));

// CollectionAssert.AreNotEqual()
_assert.EachSorted(()=>collection1, ()=>collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2)); // preferred
_assert.EachSorted(collection1, ()=>collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));
_assert.EachSorted(()=>collection1, collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));
_assert.EachSorted(collection1, collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));

// CollectionAssert.AreNotEquivalent()
_assert.EachUnsorted(()=>collection1, ()=>collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2)); // preferred
_assert.EachUnsorted(collection1, ()=>collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));
_assert.EachUnsorted(()=>collection1, collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));
_assert.EachUnsorted(collection1, collection2, (a,e1,e2)=>a.AreNotEqual(()=>e1, ()=>e2));

// CollectionAssert.Contains()
_assert.Check(()=>collection1.Any(a=>a == element));

// CollectionAssert.DoesNotContain()
_assert.Check(()=>!collection1.Any(a=>a == element));

// CollectionAssert.IsSubsetOf()
_assert.Check(()=>!collection1.Except(collection2).Any());

// CollectionAssert.IsNotSubsetOf()
_assert.Check(()=>collection1.Except(collection2).Any());
```

We are always on the lookout for other collection based assertions, especially when the Check() assertion is not providing sufficiently detailed messaging on failures (please contribute).

## String Assertions

There are equivalent (better implementations of) features in Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert class however they diverge in name and signature substantially.

```C#

// StringAssert.Contains
_assert.Check(()=>string1.Contains(string2));

// StringAssert.DoesNotMatch()
_assert.Check(()=>!regex.IsMatch(string));

// StringAssert.Matches
_assert.Check(()=>Regex.IsMatch(string, pattern));
_assert.Check(()=>regexObject.IsMatch(string));

// StringAssert.DoesNotMatch
_assert.Check(()=>!Regex.IsMatch(string, pattern));
_assert.Check(()=>!regexObject.IsMatch(string));

// StringAssert.StartsWith
_assert.Check(()=>string1.StartsWith(string2));

// StringAssert.EndsWith
_assert.Check(()=>string1.EndsWith(string2));
```

Of course, these are all just adhoc checks, and they should provide fairly robust messaging. We are always on the lookout for use cases that can provide better messaging (please contribute). 

## FilesystemAssertionRepository
The FilesystemAssertionRepository can be used to offload unit test assertion constants to disk. This can be especially
useful in test suites where the asserted data is very verbose or may change frequently during normal development cycles.

The main idea is that you have your expected result, and your actual result. The actual result is calculated by the unit test during each
execution, while the expected result is hardcoded inside of your test as the benchmark to measure against.  So then file system assertion repository
enables us to read the expected result from disk instead instead of having to hardcode it inside of the source code. Going further,
it can be a substantial effort to create these expected result files on disk, and we want to make that process as easy as possible,
so we really want the actual (computed) result to be written to disk each time the test runs. The workflow becomes that we write and run the test, 
the test will fail, but we will generate the actual result file on disk. Now we can look through that file
and manually verify the data generated by the program matches our expectations. Once satisfied, the actual result file can be renamed to
the name of the expected filename instead and viola, your test is now passing.

This concept has served me very well writing compilers, documentation generators, code generators and serializers, and there
are a million other places where this can be useful. Manually verifying the files are correct and dilligently ensuring that your
expected results are good is key, but that is *always* the case. Putting the values in separate files simply adds a bit more abstraction
to that.

If the data you are asserting is small enough, and it changes infrequently enough in normal development, it might be advisable to avoid the extra writes
to disk becasue it can hamper the testing effort. However, once you start feeling encumbered by having to update your test expectations because
of minor inconsistencies with previous test results the FilesystemAssertionRepository begins to shine. It's quite easy to create a script
to 'accept' all of the generated files.

### FilesystemAssertionRepository - Usage
The filesystem assertion repository tool is accessed through your IAssertionTool just like other assertions. The methods you will
invoke are ExpectationFromDisk() and ActualToDisk(). These methods produce variables that you will use in the  place where your constant
would normally go.   Repeated 
calls to these methods increment a counter used in the filename, so repeated calls to these methods from the same unit test will produce unique 
filenames for each invocation in a given test.

Calls to ExpectationFromDisk() refer to the expected result. It must be called first (before ActualToDisk() is called). It will increment the counter
used to generate unique filenames.

Calls to ActualToDisk() refer to the actual result. It must be passed the actual calculated value. It does not increment the filename counter
and so must be called after ExepectationFromDisk() is called, and this enforces that the generated filenames for the two variables will correspond.

The test method below (pulled directly from the projects test suite), checks the message produced by the AssertionRendererTool. The filenames for 
expected and actual are being generated automatically by the call stack. This means you need to have your calls to ExpectationFromDisk() and 
ActualToDisk() in the same relative location in the stack. It also is important to note that the call to ExpectationFromDisk() must ocurr prior
to the call to ActualToDisk(). The filenames being used are generated sequentially (1,2,3,4)... for each test, and so the call to ExpectationFromDisk() 
advances the counter, the call to ActualToDisk() re-uses the same counter.

```C#
    [TestMethod]
    public void Test001() {
       _introspective.ExpectAssertionSuccessNext((t,d)=>{
         var expected = _assert.ExpectationFromDisk<string>();
         var actual =  _assert.ActualToDisk(d.Message);

         t.AreEqual(expected, actual);
       });

      _assert.AreEqual("hello world", "hello world");
    }
```

The filenames generated in this case end up as:
 * FilesystemAssertionRepositoryTests_Test001_b_3_0.1.actual
 * FilesystemAssertionRepositoryTests_Test001_b_3_0.1.expected

some of the messy naming is from the hidden class created by the compiler for the closure, special configuration options have also been set (more on that next).

Calls to these methods automatically generate filenames based on the call stack (the name of the method which invokes the call). If multiple
tests invoke the same method, and that method calls ExpectationFromDisk() or ActualToDisk(), the generated filename will no longer be unique (in the default configuration).
To deal with this, configure the filename generator to use a unique path, prefix or suffix, for each test, and *then* uniqueness can always be guaranteed (more on this later).

### FilesystemAssertionRepository - Configuration

The best practice would be to configure your filesystem assertion repository to use at least one of a unique path, or a unique filename prefix, for each tests. This means that your unit
tests must configure the repository in a [TestInitializeAttribute] or similar with the name of your test (which will often be provided by your unit testing framework in a framework specific way).
 
Ther are a number of configuration options which will be necesarry to configure the usage of FilesystemAssertionRepository to meet large project testing needs.

  * FilesystemAssertionRepoisotry.SetFilesystemAssertionExpectedSuffix() - passing a suffix to this method will change the filesystem extension appended to generated filenames for expected results. No '.' is appended automatically, so that should be included in the suffix argument if that is desired. If no suffix is configured the default is '.expected'
  * FilesystemAssertionRepository.SetFilesystemAssertionActualSuffix() - passing a suffix to this method will change the filesystem extension appended to generated filenames for the actual results. No '.' is appended automatically, so that should be include3d in the suffix argument if that is desired. if no suffix is configured the default is '.actual'
  * FilesystemAssertionRepository.SetFilesystemAssertionRepositoryPath() - passing a relative or absolute path to this method will configure the destination path for all files produced. Paths that do not exist on disk will be created if possible. Generally unit test frameworks run from a consistent place within the source control filesystem and relative paths can be used to place assertion filesystem data in a place that can be maintained within source control as well.
  * FilesystemAssertionRepository.SetFilesystemAssertionFilenamePRefix() - passing a prefix to this method in the form of a path and/or filename prefix will adjust the final generate filename. This can be especially useful to configure a unique directory for each unit test, or provide a filename prefix for those tests. This component does not undergo name sanitization and you may wish to consider calling FilesystemAssertionRepository.SanitizeFilename() if you suspect sanitization is going to become required based on the strategy for construction a prefix.
  * FilesystemAssertionRepository.SetFilesystemFilenameMaxLength() - this configures the maximum length of the generated part of the filename, before unique identifer, path, and prefixes / suffixes are appended. The default value is 80 characters which should produce very verbose and descriptive names, but could potentially exercise the large filename handling capabilities of some systems. Passing in a shorter maximum length increases the likelihood of filename conflicts unless other configuration such as filesystem path and test prefixes are being used.
  * FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix() - passing in a prefix here results in a prefix being removed from the generated filename. Filenames are generated based on the fully qualified classname of the code which invoked the FilesystemAssertionRepository which includes namespaces. The intended usage for this option is to remove superfluous namespaces from showing up in the generated filenames. For example in the ExpressiveAssertions unit test the remove prefix is set to 'ExpressiveAssertions.Tests'.
  
### FilesystemAssertionRepository - Tips

It's been mentioned before but it's worth saying again, you *must* be vigilant ensuring expectations coming from the filesystem are correct. When you have expectations on disk, and your test results change, it's essential to review those changes before updating the file. When you are setting up expectations on disk, you must be sure those expectations are correct 

So without further ado...

You can configure many tests to automatically accept the generated test output by configuring the actual suffix to match the expceted suffix. This trick only works for assertions that depend on the expected result and actual result to be equal, so if you limit your tests to AreEqual() / GreaterThanEqual() / LessThanEqual() / StartsWith() / EndsWith() / etc... you will be fine to take advantage of this technique. This can be very useful if you need to manage large numbers of test expectations changing. If you have existing expectations you can use a diff to help in verifying the output. It also can be useful to use this while writing new tests, assuming you are carefully reviewing the generated output for correctness afterwards. 
```C#
FilesystemAssertionRepository.ConfigureFilesystemAssertionAutoAccept(_assert);
```

See below for one approach to configuring your filesystem structure for a unit test suite in MSTest. All assertion expectations
will be placed in a folder called 'assertions' in the project root. A subdirectory will be created for each testClass, and
a subdirectory under that will be created for each test. 

It's useful to remove the common namespace so paths are less verbose. The triple '..' subdirectory places the assertions in a subfolder 
of the unit test project (at least in the environments it's been tested in). Sanitizing the classname and test name folders prevents 
other inconvenient characters from appearing in your filesystem.

```C#
var commonNamespace = "ExpressiveAssertions.Tests";
var mstestTestContext = TestContext;

FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix(_assert, commonNamespace);
var assertPath = System.IO.Path.Combine("..", "..", "..", "assertions", 
  FilesystemAssertionRepository.SanitizeFilename(_assert, mstestTestContext.FullyQualifiedTestClassName), 
  FilesystemAssertionRepository.SanitizeFilename(_assert, mstestTestContext.TestName)
);
```

It's not required that you use the ActualToDisk() feature; if you find yourself in certain situations where you don't benefit from writing that
calculated data to the filesystem, you can continue using ExpectedFromDisk() just as easily without also calling ActualToDisk().

## Testing Context
The assertion tooling provides the concept of context which allows for tracking data about unit tests through scopes.
This can be especially useful when defining many tests that pertain to specific objects, and implementing robust
tests over large data sets with hierarchical layouts. Context solves the problem of tracking the details of where in the testing
process an error occurs in the face of high data volume.

```C#
var data = new[] {
	new { FieldOne = 10, FieldTwo = 100 },
	new { FieldOne = 30, FieldTwo = 900 },
	new { FieldOne = 2, FieldTwo = 4 },
};

using (assert.ContextPush())
for (int i =0; i < data.Length; i++) {
	assert.ContextSet("index", i.ToString());
	
	// fieldtwo must be square of fieldone
	assert.IsTrue(()=>data[i].FieldOne * data[i].FieldOne == data[i].FieldTwo );
	// fieldone must be multiple of 10
	assert.IsTrue(()=>data[i].FieldOne % 10 == 0);
}
```

This test eventually fails on the third element, because 2 is not a multiple of 10. Included in the messaging will be a line: 

> [Depth=1] index = [string]"2".

This additional context field index, defined by the test, tracks which element in the array is being processed, and also indicates 
that the failed assertion ocurred in the third iteration of the loop. This kind of context information greatly simplifies tracking 
down issues on failed tests without needing to employ debuggers or replay code.

## Soft assertions
An assertion tool implementation called SoftAssertionTool enables for capturing multiple assertions, gathering statistics on their outcomes, 
and then even selectively replaying those assertions on another assertion tool at another point in time. This soft assertion tooling
can be used to implement some interesting concepts such as multiple assertions before failure, or more generally conditionally failing
and passing a test based on the nature of the assertions that are made.

One example of this is included in the unordered collection assertions. In the unordered assertions, we need to check that for two collections,
there is a positive correspondence between each element. We need to safely test our assertion conditions against many elements, 
and ignore any assertion failures that occur so long as we find that one correspondence exists between each element in both collections. As soon as
(and only if) any element is found that does not have a positive correspondence, all bets are off and we need to have a yardsale of all 
the different checks that were made while coming to such a conclusion.

## Trace Logging Assertions
An assertion tool implementation called TraceLoggingAssertionTool is provided that writes all assertions, both success, inconclusive and failures
to the System.Diagnostics.Trace component. The MSTest assertion library will capture this data and it can be included in the resulting log files
or displayed in the console. The TraceLoggingAssertionTool does not generate errors or otherwise result in test failure, it is just a messenger
and another assertion tool is required to communicate failures to the assertion framework.

```C#
IAssertionTool assert = ExpressiveAssertions.Tooling.AssertionRendererTool.Create(
	CompositeAssertionTool.Create(
    new TraceLoggingAssertionTool(),
    ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
  )
);
```

## Composition
An assertion tool implementation called CompositeAssertionTool is provided that allows assertion data to be mulitplexed to multiple assertion
tools.


## Filtering
A set of filtering assertion tools are provided to filter out assertions based on their type. 

    * IgnoreInconclusiveAssertionTool will filter out all inconclusive errors which may be useful if the inconclusive assertions are causing failure
    * IgnoreDeclaredFailureAssertionTool will filter out all declared failures found in tests, which differ from the test failure in being invariant failures when certain code is reached, and may sometimes be worth ignoring

# Rendering
The expressions being asserted on may be rendered to generate highly detailed and useful outputs (though sometimes also overwhelming to the uninitiated). The rendering pipeline
produces a rendering of the assertion code that is evaluated, and it evaluates the variables, fields, methods at each step in that evaluated code to give further indications of what data
manipulations may have been ocurring in the assertion. The data being rendered, manipulated, and tested may not always be built-in
types or may require different formatting than whatever 'built-in' rendering is available, and so the rendering pipeline is designed to accomodate 
this need for robust rendering of both user defined and built-in types.

With no rendering included in the unit tests, no messaging will be displayed. The AssertionRendererTool must be included in the assertion pipeline in order
to get any messaging functionality. The AssertionRendererTool collects the data from the assertion, and uses an ExpressiveAssertions.Rendering.IObjectRenderer to turn 
the data into a human readable message.

There is a built in rendering pipeline that includes everything you need to render built-in and many user defined data types. Simply creating an AssertionRendererTool as shown in this document uses that default pipeline and you can go on making assertions without further consideration of how the rendering pipeline is working.

## Rendering Features
* where possible the type name is enclosed in brackets '[' / ']'.  such as [string]
* any null is annotated with tilde characters and will be easily identifiable '~null~'
* Dates are rendered with the "O" format specifier, and timespans with the "G" specifier so that important details like the fractional second components are shown by default
* strings and character data renders render ascii printable characters as expected, and other characters use escape codes, including special characters as control characters, spaces, nul, etc...
* all format specifiers included with custom messaging undergo rendering
* collections and complex types are rendered using annotations similar to powershell syntax. An array is annotated with '@(' and ')'. A hash table (key value pairs) are annotated with '@{' and '}'. 

## Rendering customization
You can completely replace the built-in rendering stack or make small tweaks and/or additions based on your requirements. The process is too complex to cover completely here. The rendering engine is defined by the DefaultRendereringStack class, and that should be a reasonable starting point for learning how to customize things. In general a renderer should return an object of type AnnotatedFormattable if they wish to halt further renderers 

### AssertionRendererTool
The base interface for the rendering pipeline is the AssertionRendererTool. It is the only built-in rendering component but if desired a completely alternative rendering mechanism could be used instead (if you need this, you can use it as an example). The assertion renderer makes use of an IObjectRenderer interface to generate a simple textual representation of the assertion data.

```C#
var renderingStack = new DefaultRendereringStack(); // this argument could be omitted, and it would be used as the default
var assertionRenderer = AssertionRendererTool.Create(renderingStack, MSTestAssertionTool.Create());
```

### IObjectRenderer, AnnotatedFormattable and the Rendering Pipeline
The IObjectRenderer defines a generic interface for a method Render() which converts one object into another object. The annotated formattable is a data type which preserves all formattable chracteristics of an object but also allows customization of the rendered output for the purposes of usage in an assertion specific context. The rendering pipeline is constructed in such a way that a single ObjectRenderingRequest is initiated containing the AssertionData, and the pipeline uses many specialized components to render the pieces of that one object and compose a final output. Generally speaking of these specialized components is intended to convert a data type into an AnnotatedFormattable. The special annotated formattable type generally ensures other rendering components won't attempt to modify the rendered output and can short-circuit the rendering process.  

The rendering process iteslf is defined with the use of layered RendererCollections. The RendererCollection simply iterates a list of IObjectRenderer and attempts to render the given object with each of them. The RendererCollection is also an IObjectRenderer and can be nested inside other RendererCollection instances.

There is support for many built-in data types with some special formatting approaches being used to provide better messaging than the defaults provided by the .NET ecosystem.

It is possible to inject custom formatters into the rendering pipeline, as well as remove or redefine the pipeline as needed. This can be especially useful to render custom types which may not have a useful ToString() or IFormattable implementation but which you will be using frequently in assertion code. In such cases a LambdaRenderer can be a useful tool to create shorthand renders.

```C#
class MyCustomType {
  public override ToString() {
    return "my_custom_type";
  }
}

renderingStack.Push(req=>{
  if (!(req?.RenderTarget is MyCustomType)) { return req?.RenderTarget; }

  var render = req.RenderTarget.ToString().ToUpper();
  return new AnnotatedFormattable(render);
});
```

The lambda above first checks that the object being rendered implements a user defiend type MyCustomType and skips rendering if it does not. If the render target is of type MyCustomType it returns ToString().ToUpper(). Your own implementations will likely be more interesting.

It is also possible to perform recursive rendering from within a component. This recursion is useful for collections and rendering complex user defined types because you can simply rely on the already built-in rendering components to handle anything that doesn't absolutely need to be customized.

```C#
class MyCustomType2 {
  public string FieldOne;
  public Exception ExampleException;
}

renderingStack.Push(req=>{
  var target = req?.RenderTarget as MyCustomType2;
  if (target == null) { return req?.RenderTarget; }
  
  var s = new StringBuilder();

  s.Append("[MyCustomType2]@{");
  s.Append("FieldOne=");
  s.Append(req.NewTarget(target.FieldOne).Render());
  s.Append(",");
  s.Append("FieldTwo=");
  s.Append(req.NewTarget(target.ExampleException).Render());

  return new AnnotatedFormattable(s.ToString());
});
```

The built-in rendering stack comes pre-enabled with cycle detection to prevent the same object from being rendered multiple times (which would create infinite loops and stack overflows). In custom rendering scenarios it might be possible to create a layer on-top of the default rendering stack which does not undergo cycle detection if that was desirable in some circumstances, or the cycle detection can be disabled by calling RendererCollection.DisableCyclePreventer() but there is a higher risk of infinite loops and stack overflows to be triggered if this is disabled.

A full list of the supported renderers available can be found in the ExpressiveAssertions.Rendering namespace and if you find something is missing please feel free to contribute.

# Expression Evaluators
It is possible to inspect the assertion code before it is executed, potentially making modifications to it. This is a fairly advanced feature and often times would be better solved with rewriting your assertions but there are cases where it is the perfect tool. It is also worth bearing in mind that assertions that do not use a preferred syntax may not be eligible for rewriting by expression evaluators because of certain technical details involved.

## DefaultEvaluator
This is the evaluator that you get by default, it compiles an expression tree to a delegate. Nothing fancy is going on here. It actually is pretty expensive performance wise to do this, but the benefits are worth it.

## DateTimeNormalizationEvaluator
The DateTimeNormalizationEvaluator finds any usages of the DateTime type in assertions and normalizes those dates at the millisecond level. This addresses what may be perhaps a fairly rare, but also very inconvenient issue where two timestamps are captured in such a way that they are supposed to be equal, but due to the extremely high resolution of the timers involved, they end up being at the exact same millisecond, but at slightly different nanosecond signatures.

It might also be worth observing that, the default string format for dates, does not render sub-millisecond components so if you hit this error in other unit testing frameworks you may see a message indicating that your two dates are not equal, but they also are printed with the exact same date in the log. 

```C#
      var evaluator = new DateTimeNormalizationEvaluator(new DefaultEvaluator());
      _assert.SetExpressionEvaluator(evaluator);
```

# Tests
There is currently a minimal collection of unit tests. The expressive assertion library code is able to assert its own behavior using the introspetive assertion tool. A more robust test suite is a pre-condition for this project reaching it's 1.0.0 version number.

# Build Notes
This project has several dependencies which you can pull down automatically through nuget, or manualy at their project pages:

  * ExpressionToCode - https://github.com/EamonNerbonne/ExpressionToCode
  * ExpressiveReflection - https://github.com/hannasm/ExpressiveReflectionDotnet
  * ExpressiveExpressionTrees - https://github.com/hannasm/ExpressiveExpressionTreesDotNet

These assemblies provide features that are being used internally, but are not actually exposed through public API and would be
perfect candidate for the ILMerge internalize feature, but so far it doesn't appear internalize is avilable for dotnet core projects.

## T4 Templating
We are using some home-brew msbuild targets for handling t4 templating. It depends on mono.texttemplating and uses what
hopefully is a valid way of finding the appropriate executable. It currently suffers from an issue with the
text templating files not being picked up on first run. The first time a text templating file is processed, a new .cs file
is being created, and msbuild will not see / compile that new file. The solution is to just compile a second time

# Licensing
This code is released on under an MIT license. 

This code uses parts of ExpressionToCode which is licensed under the Apache license.

# Changelog

[For Release Notes See Here](ExpressiveAssertions.ReleaseNotes.md)
