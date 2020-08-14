using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace ExpressiveAssertions.Tests {
    [TestClass]
    public class StringAssertionTests : ExpressiveAssertionsFilesystemBackedTestBase {
        [TestMethod]
        public void Test001() {
            _introspective.ExpectAssertionFailureNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });

            _assert.AreEqual("a", "a\0");
        }
    }
}