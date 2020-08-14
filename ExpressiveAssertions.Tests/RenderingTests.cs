using System;
using System.Collections.Generic;
using System.Diagnostics;
using ExpressionToCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveAssertions.Tests {
    [TestClass] 
    public class RenderingTests : ExpressiveAssertionsFilesystemBackedTestBase { 
    
        [TestMethod]
        public void ReflectionRendererTest001() {
            var udt1 = new {
                TestField01 = 10
            };
            var udt2 = new {
                TestField01 = 20
            };            
 
            _introspective.ExpectAssertionFailureNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });

            _assert.AreEqual(udt1, udt2);
        }
        [TestMethod]
        public void ReflectionRendererTest002() {
            var udt1 = new {
                TestField01 = 10,
            };
            var udt2 = new {
                TestField01 = 10
            };            
 
            _introspective.ExpectAssertionSuccessNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });

            _assert.AreEqual(udt1, udt2);
        }

        [TestMethod]
        public void ReflectionRendererTest003() {

            var udt1 = new KeyValuePair<string,string>[] { KeyValuePair.Create("hello", "world") };
            var udt2 = new KeyValuePair<string,string>[] { KeyValuePair.Create("hello", "world") };

            _introspective.ExpectAssertionFailureNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });

            // this fails because it's doign reference equality
            _assert.AreEqual(udt1, udt2);

        }
    }
}