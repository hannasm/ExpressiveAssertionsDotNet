# Versioning
This is version 0.9.1 of the expressive assertions library

This package is available from nuget at: https://www.nuget.org/packages/ExpressiveAssertions/0.9.1

The source for this release is available on github at: https://github.com/hannasm/ExpressiveAssertionsDotNet/releases/tag/0.9.1

# ExpressiveAssertionsDotNet
Flexible Assertion Library Leveraging the .NET Expression Tree Syntax. This library attempts to provide a robust, open
solution to assertions and unit testing for the .NET EcoSystem that is easily portable across different unit testing
frameworks.

This library is influenced by and in many ways similar to several other assertion libraries you may or may not be familiar with:

PowerAssert.NET - https://github.com/PowerAssert/PowerAssert.Net
PAssert from ExpressionToCode - https://github.com/EamonNerbonne/ExpressionToCode
MSTest Assertion Library - https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.aspx

This library attempts to provide portability in the form of creating an abstraction layer ontop of which suport for different
unit testing frameworks may provide custom implementations of the underlying assertion concepts.

The following native unit testing framwork implementations are currently available:

	* MSTest via ExpressiveAssertions.MSTest - ExpressiveAssertions.MSTest.MSTestAssertionTool

# Usage
The basis of all assertions are driven by the IAssertionTool interface. Assertions are exposed by means of extensions methods
built around this interface. An implementator of this interface will receive a expressive assertion definition, and is 
responsible for interpreting and evaluating that assertion.

```C#
using ExpressiveAssertions;

IAssertionTool tool = new ExpressiveAssertions.MSTest.MSTestAssertionTool();
```

In this case, the assert tool is setup to use the MSTest specific implementation.

Fundamentally assertions are implemented on the principle of expression trees.  Any 'assertion' consists of a series of 
instructions to access one or more pieces of memory, and to compare the expected state of that memory to the actual state. These
fundamental assertion are exposed through the methods Check() and Assert().

```C#
int x = 10;

tool.Assert(()=>x == 10); // Success Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (10).
tool.Assert(()=>x == 20); // Failure Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (20)

tool.Check(()=>x, ()=>10, (a,b)=>a==b); // Success Asserting a == b with 'a'= (10) and 'b'= (10). 
tool.Check(()=>x, ()=>10, (a,b)=>a==b); // Failure Asserting a == b with 'a'= (10) and 'b'= (20).
```

The rendering of the assertions messages are handled separately from the evaluation, and that is subject to change going forward.
It's worth noting at this point also, that every assertion (pass or fail) is rendered to the test log (via System.Diagnostics.Debug.WriteLine)
so that it's possible to evaluate the full coverage of the assertions in a test.

With the two fundamental pieces in place (the assertion tool, and the Check() and Assert() methods) there exist a vast, diverse,
and robust set of possiblities for assertions through the use of extension methods.

The set of built-in assertions is currently expected to fully mirror the set of methods exposed by the MSTEst assertion library
when this code reaches version 1.0. Additional assertion concepts may be provided at future times. The full list is easily exposed 
through intellisense and should be fairly simple to follow in the accompanying source files.


# Tests
At the current time, most of the unit tests are intentionally failing in this project, by the nature of wanting to assert
that the assertion code is behaving correctly. A more comprehensive test suite is expected at some point down the road though.

# Build Notes
The build for this project depends on ILMerge, and embeds several other assemblies using the /internalize flag. The 
embedded assemblies include:

  * ExpressionToCode - https://github.com/EamonNerbonne/ExpressionToCode
  * ExpressiveReflection - https://github.com/hannasm/ExpressiveReflectionDotnet
  * ExpressiveExpressionTrees - https://github.com/hannasm/ExpressiveExpressionTreesDotNet

These assemblies provide features that are being used internally, but their functionality is not exposed in any way externally as part
of an API, making them perfect candidates for the internalization. You should be able to safely consume this assembly without any risk 
of entering dependency hell.

# Licensing
This code is released on under an MIT license. 

This code uses parts of ExpressionToCode which is licensed under the Apache license. A copy of this license is included.

# Changelog
## 0.9.1
  * adding license files to nuget packages

## 0.9.0
  * initial release is beta / alpha and 