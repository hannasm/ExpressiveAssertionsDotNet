using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests {
  [TestClass]
  public class CollectionAssertionTests : ExpressiveAssertionsFilesystemBackedTestBase {

    [TestInitialize]
    public override void Init() {
      base.Init();

      //ConfigureAutoAccept();
    }

    [TestMethod]
    public void TestCount001() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };      
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, actual);
    }
    [TestMethod]
    public void TestCount002() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(expectedCount, actual, "with message");
    }
    [TestMethod]
    public void TestCount003() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(expectedCount, actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount011() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, actual);
    }
    [TestMethod]
    public void TestCount012() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(()=>expectedCount, actual, "with message");
    }
    [TestMethod]
    public void TestCount013() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(()=>expectedCount, actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount021() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount022() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount023() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      _assert.Count(expectedCount, ()=>actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount031() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      _assert.Count(()=>expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount032() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      _assert.Count(()=>expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount033() {
      var expectedCount = 3;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionSuccessNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      _assert.Count(()=>expectedCount, ()=>actual, "with {0} message", "format");
    }

    [TestMethod]
    public void TestCount101() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };
 
      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });

      _assert.Count(expectedCount, actual);
    }
    [TestMethod]
    public void TestCount102() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, actual, "with message");
    }
    [TestMethod]
    public void TestCount103() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount111() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, actual);
    }
    [TestMethod]
    public void TestCount112() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, actual, "with message");
    }
    [TestMethod]
    public void TestCount113() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount121() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount122() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount123() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(expectedCount, ()=>actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount131() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount132() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount133() {
      var expectedCount = 4;
      var actual = new [] { 1, 2, 3 };

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.AreEqual(expectedResult, actualResult);
      });
      
      _assert.Count(()=>expectedCount, ()=>actual, "with {0} message", "format");
    }
    
    [TestMethod]
    public void TestCount201() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });

      _assert.Count(expectedCount, actual);
    }
    [TestMethod]
    public void TestCount202() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(expectedCount, actual, "with message");
    }
    [TestMethod]
    public void TestCount203() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(expectedCount, actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount221() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount222() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount223() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(expectedCount, ()=>actual, "with {0} message", "format");
    }
    [TestMethod]
    public void TestCount231() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });
      
      _assert.Count(()=>expectedCount, ()=>actual);
    }
    [TestMethod]
    public void TestCount232() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);

      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });

      _assert.Count(()=>expectedCount, ()=>actual, "with message");
    }
    [TestMethod]
    public void TestCount233() {
      var expectedCount = 3;
      var actual = default(IEnumerable<int>);
      
      _introspective.ExpectAssertionFailureNext((a,d)=>{
        var expectedResult = _assert.ExpectationFromDisk<string>();
        var actualResult = _assert.ActualToDisk(d.Message);
        a.Check(expectedResult, actualResult, (expected, actual)=>actual.StartsWith(expected));
      });

      _assert.Count(()=>expectedCount, ()=>actual, "with {0} message", "format");
    }

    [TestMethod]
    public void TestUnique001() {
      var collection = new [] { 1,2,3,4,4 };

      foreach (var item in collection.Skip(1)) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionFailureNext();
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique002() {
      var collection = new [] { 1,2,2,3,4,4 };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          case 2:
          case 5:
            _introspective.ExpectAssertionFailureNext();
            break;

          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique003() {
      var collection = new [] { 1,2,3,4 };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique005() {
      var collection = new [] { 1,2,3,4,5,6,7,8 };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique006() {
      var collection = new [] { 1,1,1,2,3,4,5,6,7 };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          case 1:
          case 2:
            _introspective.ExpectAssertionFailureNext();
            break;

          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique007() {
      var collection = new [] { 1,2,3,4,5,6,7,7,7,7 };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          case 7: case 8: case 9:
            _introspective.ExpectAssertionFailureNext();
            break;

          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
    [TestMethod]
    public void TestUnique008() {
      var collection = new [] { 1,2,3,3,3,4,5,6,7, };

      for (int i = 0; i < collection.Length; i++) {
        switch (i) {
          case 3: case 4:
            _introspective.ExpectAssertionFailureNext();
            break;

          default:
            _introspective.ExpectAssertionSuccessNext();
            break;
        }
      }
      
      _assert.EachIsDistinct(()=>collection);
    }
  }
}
