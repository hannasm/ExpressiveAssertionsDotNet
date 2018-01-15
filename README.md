# Versioning
This is version 0.9.8 of the expressive assertions library

This package is available from nuget at: https://www.nuget.org/packages/ExpressiveAssertions/0.9.8

The source for this release is available on github at: https://github.com/hannasm/ExpressiveAssertionsDotNet/releases/tag/0.9.8

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

The following native unit testing framwork implementations are currently available:

* MSTest via ExpressiveAssertions.MSTest - ExpressiveAssertions.MSTest.MSTestAssertionTool

# Rendering
One of the main components that is being decoupled in this library is the rendering code. It is possible
to customize the experience of assertion failure in a variety of ways based on the use cases you are targeting.
In the simplest scenario one wants to throw an exception with a textual representation of an assertion
that has failed. In more complex scenarios, it may be desilrable to render obejct graphs, transport
assertion details to remote servers, or a variety of other interesting things.

As part of this design, the work of generating a human-readable textual representation
of an assertion is part of a separte component from the one which actually generates a 
test-framework specific exception signaling that an assertion has failed.

From a client / user perspective, a little extra work is necesarry to setup a chain of 
renders that delivers all the desired features.

When developing for this assertion library, it is necesarry to keep components stripped down to their minimum
feature set, and plan on using multiple components, and composition, to create complete and interesting
functionality.

# Usage
The core product is the IAssertionTool interface. Assertions are implemented through extension methods
built around this interface. 

```C#
using ExpressiveAssertions;

IAssertionTool assert = ExpressiveAssertions.Tooling.ShortAssertionRendererTool.Create(
	ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
);
```

In this case, the assertion tool is setup to use the MSTest specific implementation and also leverages the 
built in ShortAssertionRenderer to display assertions in a user-friendly, human readable format.

Fundamentally assertions are implemented on the principle of expression trees.  Any 'assertion' consists of a series of 
instructions to access one or more pieces of memory, and to compare the actual state of that memory region to the expected values. These
fundamental assertions are exposed through overloads of the method Check().

```C#
int x = 10;

assert.Check(()=>x == 10); // Success Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (10).
assert.Check(()=>x == 20); // Failure Asserting v_01.x == int32_01 with 'v_01.x'= (10) and 'int32_01'= (20)

assert.Check(()=>x, ()=>10, (a,b)=>a==b); // Success Asserting a == b with 'a'= (10) and 'b'= (10). 
assert.Check(()=>x, ()=>10, (a,b)=>a==b); // Failure Asserting a == b with 'a'= (10) and 'b'= (20).
```

The process of communicating the outcome of a test is handled separately from the actual testing. Exacting messaging can evolve 
on an implementation by implementation basis, and be adapted to unexpected new paradigms as needed.

> It's probably worth noting at this point, that all assertions (pass or fail), are communicated to the underlying 
> implementation, and ultimately can be provided to the testing framework. This can enable some more advanced analysis 
> of test quality (through gathering metrics on assertion quantity or quality). It is reccomended that implementations always provide 
> some mechanism for displaying the successful assertions, along with those that fail.

The Check() method overloadss on the IAssertionTool makeup the entirety of the core assertion functionality. 
Everything else is syntactic sugar for calling into these methods.

The set of built-in assertions includes most of those exposed by the MSTEst assertion library. Some additional assertions
are included for asserting data in ordered, and unordered collections. 

## Testing Context
The assertion tooling provides the concept of context which allows for tracking data about unit tests through different scopes.
This can be especially useful when defining many tests that pertain to specific objects, and implementing robust
tests over large data sets with hierarchical layouts. Context solves the problem of tracking the details of where in the testing
process an error occurs in the face of increasing complexity.

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

This test eventually fails on the third element, because 2 is not a multiple of 10. Included in the error messaging is the line: 

> 'Depth 1 - index' with value '2'.

This indicates at scope depth of 1, there is a context field defined called index, with the value 2. 
This kind of context information greatly simplifies tracking down issues on failed tests without needing to employ debuggers or
replay code.

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


# Tests
There is currently a very minimal collection of unit tests available. A more robust test suite is a pre-condition for this project
reaching it's 1.0.0 version release.

# Build Notes
This project has several dependencies which you can pull down automatically through nuget, or manualy at their project pages:

  * ExpressionToCode - https://github.com/EamonNerbonne/ExpressionToCode
  * ExpressiveReflection - https://github.com/hannasm/ExpressiveReflectionDotnet
  * ExpressiveExpressionTrees - https://github.com/hannasm/ExpressiveExpressionTreesDotNet

These assemblies provide features that are being used internally, but they are not exposed through the public API
making them perfect candidates for internalization, but this isn't easily available in dotnet core at this point in time.

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
