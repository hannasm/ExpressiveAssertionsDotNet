using ExpressiveReflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using System.Text;

namespace ExpressiveAssertions.Tests {
  [TestClass]
  public class FilesystemAssertionRepositoryTests : ExpressiveAssertionsFilesystemBackedTestBase {
    [TestMethod]
    public void Test001() {
       _introspective.ExpectAssertionSuccessNext((t,d)=>{
         var expected = _assert.ExpectationFromDisk<string>();
         var actual =  _assert.ActualToDisk(d.Message);

         t.AreEqual(expected, actual);
       });

      _assert.AreEqual("hello world", "hello world");
    }

    [TestMethod]
    public void Test002() {
       _introspective.ExpectAssertionFailureNext((t,d)=>{
         var expected = _assert.ExpectationFromDisk<string>();
         var actual =  _assert.ActualToDisk(d.Message);

         t.AreEqual(expected, actual);
       });

      _assert.AreEqual("hello world 2", "hello world");
    }
    
    [TestMethod]
    public void Test003() {
       _introspective.ExpectAssertionFailureNext((t,d)=>{
         var expected = _assert.ExpectationFromDisk<string>();
         var actual =  _assert.ActualToDisk(d.Message);

         t.AreEqual(expected, actual);
       });
       
        // We are expecting the file on disk to have a value that doesn't match thje actual, like 'hello world 2"
      _assert.AreEqual(_assert.ExpectationFromDisk<string>(), _assert.ActualToDisk("hello world"));
    }

    [TestMethod]
    public void Test004() {
       _introspective.ExpectAssertionSuccessNext((t,d)=>{
         var expected = _assert.ExpectationFromDisk<string>();
         var actual =  _assert.ActualToDisk(d.Message);

         t.AreEqual(expected, actual);
       });

      _assert.AreEqual(_assert.ExpectationFromDisk<string>(), _assert.ActualToDisk("hello world"));
    }

    [TestMethod]
    public void Test100() {
      var testValue = "test value";
      var otherValue = "other value";
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.AreNotEqual(testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionExpectedSuffix(_assert));
      _assert.AreNotEqual(otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionExpectedSuffix(_introspective));

      FilesystemAssertionRepository.SetFilesystemAssertionExpectedSuffix(_assert, testValue);
      FilesystemAssertionRepository.SetFilesystemAssertionExpectedSuffix(_introspective, otherValue);

      _assert.AreEqual(()=>testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionExpectedSuffix(_assert));
      _assert.AreEqual(()=>otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionExpectedSuffix(_introspective));
    }
    [TestMethod]
    public void Test101() {
      var testValue = "test value";
      var otherValue = "other value";
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.AreNotEqual(testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionActualSuffix(_assert));
      _assert.AreNotEqual(otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionActualSuffix(_introspective));

      FilesystemAssertionRepository.SetFilesystemAssertionActualSuffix(_assert, testValue);
      FilesystemAssertionRepository.SetFilesystemAssertionActualSuffix(_introspective, otherValue);

      _assert.AreEqual(()=>testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionActualSuffix(_assert));
      _assert.AreEqual(()=>otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionActualSuffix(_introspective));
    }
    [TestMethod]
    public void Test102() {
      var testValue = "test value";
      var otherValue = "other value";
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.AreNotEqual(testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionRepositoryPath(_assert));
      _assert.AreNotEqual(otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionRepositoryPath(_introspective));

      FilesystemAssertionRepository.SetFilesystemAssertionRepositoryPath(_assert, testValue);
      FilesystemAssertionRepository.SetFilesystemAssertionRepositoryPath(_introspective, otherValue);

      _assert.AreEqual(()=>testValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionRepositoryPath(_assert));
      _assert.AreEqual(()=>otherValue, ()=>FilesystemAssertionRepository.GetFilesystemAssertionRepositoryPath(_introspective));
    }
    [TestMethod]
    public void Test103() {
      var testValue = 11;
      var otherValue = 35;
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.AreEqual(80, ()=>FilesystemAssertionRepository.GetFilesystemFilenameMaxLength(_assert));
      _assert.AreEqual(80, ()=>FilesystemAssertionRepository.GetFilesystemFilenameMaxLength(_introspective));

      FilesystemAssertionRepository.SetFilesystemFilenameMaxLength(_assert, testValue);
      FilesystemAssertionRepository.SetFilesystemFilenameMaxLength(_introspective, otherValue);

      _assert.AreEqual(()=>testValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameMaxLength(_assert));
      _assert.AreEqual(()=>otherValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameMaxLength(_introspective));
    }
    [TestMethod]
    public void Test104() {
      var testValue = "test value";
      var otherValue = "other value";
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.AreNotEqual(testValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameRemovePrefix(_assert));
      _assert.AreNotEqual(otherValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameRemovePrefix(_introspective));

      FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix(_assert, testValue);
      FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix(_introspective, otherValue);

      _assert.AreEqual(()=>testValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameRemovePrefix(_assert));
      _assert.AreEqual(()=>otherValue, ()=>FilesystemAssertionRepository.GetFilesystemFilenameRemovePrefix(_introspective));
    }

    [TestMethod]
    public void Test105(){ 
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>1, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>1, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>1, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>1, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>2, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>2, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>2, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>2, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>3, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>4, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>5, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>6, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.AdvanceFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>7, ()=>FilesystemAssertionRepository.GetFilesystemAssertionCount(_assert));
    }

    static string ExtractFilename<T>(Expression<Func<T>> exp) {
      var methodCall = (MethodCallExpression)exp.Body;
      var closureMember = ((MemberExpression)methodCall.Arguments[0]);
      var closureObject = ((ConstantExpression)closureMember.Expression).Value;
      
      var filename = Reflection.GetValue(closureMember.Member, closureObject) as String;

      return filename;
    }

    [TestMethod]
    public void Test200() {
      FilesystemAssertionRepository.SetFilesystemAssertionRepositoryPath(_assert, string.Empty);
      var baseFilename = FilesystemAssertionRepository.GenerateTestFilename(_assert);
      var expectedSuffix = FilesystemAssertionRepository.GetFilesystemAssertionExpectedSuffix(_assert);
      var actualSuffix = FilesystemAssertionRepository.GetFilesystemAssertionActualSuffix(_assert);

      var expected01 = _assert.ExpectationFromDisk<string>();
      var actual01a = _assert.ActualToDisk("actual01a");
      var actual01b = _assert.ActualToDisk("actual01b");

      var expected02 = _assert.ExpectationFromDisk<string>();
      var actual02a = _assert.ActualToDisk("actual02a");
      var actual02b = _assert.ActualToDisk("actual02b");

      var expected03 = _assert.ExpectationFromDisk<string>();
      var actual03a = _assert.ActualToDisk("actual03a");
      var actual03b = _assert.ActualToDisk("actual03b");

      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>baseFilename + ".1" + expectedSuffix,  ()=>ExtractFilename(expected01));
      _assert.AreEqual(()=>baseFilename + ".1" + actualSuffix,  ()=>ExtractFilename(actual01a));
      _assert.AreEqual(()=>baseFilename + ".1" + actualSuffix,  ()=>ExtractFilename(actual01b));

      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>baseFilename + ".2" + expectedSuffix,  ()=>ExtractFilename(expected02));
      _assert.AreEqual(()=>baseFilename + ".2" + actualSuffix,  ()=>ExtractFilename(actual02a));
      _assert.AreEqual(()=>baseFilename + ".2" + actualSuffix,  ()=>ExtractFilename(actual02b));

      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>baseFilename + ".3" + expectedSuffix,  ()=>ExtractFilename(expected03));
      _assert.AreEqual(()=>baseFilename + ".3" + actualSuffix,  ()=>ExtractFilename(actual03a));
      _assert.AreEqual(()=>baseFilename + ".3" + actualSuffix,  ()=>ExtractFilename(actual03b));
    }

    [TestMethod]
    public void Test300() {
      var tests = new [] {
        new { O = "ABCDEFGHIJKLMNMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890", F="ABCDEFGHIJKLMNMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890" },
        new { O = "hello.world.test", F="hello_world_test" },
        new { O = "hello-world-test", F="hello_world_test" },
        new { O = "hello world test", F="hello_world_test" },
        new { O = "hello_world_test", F="hello_world_test" },
        new { O = "hello[world[test", F="hello_world_test" },
        new { O = "hello]world]test", F="helloworldtest" },
        new { O = "hello[world]test", F="hello_world_test" },
        new { O = "test()abcdefg", F="test_abcdefg" },
        new { O = "(a,b,c,d)", F="a.b.c.d" },
        new { O = "test(a,b,c,d)", F="test_a.b.c.d_" },
      };

      foreach (var test in tests) {
        _introspective.ExpectAssertionSuccessNext();
        _assert.AreEqual(()=>test.F, ()=>FilesystemAssertionRepository.SanitizeFilename(_assert, test.O));
      }
    }

    [TestMethod]
    public void Test301() {
      FilesystemAssertionRepository.SetFilesystemFilenameRemovePrefix(_assert, "ExpressiveAssertions.Tests.");

      var tests = new [] {
        new { O = "ExpressiveAssertions.Tests", F="ExpressiveAssertions_Tests" },
        new { O = "ExpressiveAssertions.Tests.", F="" },
        new { O = "ExpressiveAssertions.Tests.Test01", F="Test01" },
        new { O = "ExpressiveAssertions.Tests.Test01(a,b,c)", F="Test01_a.b.c_" },
      };

      foreach (var test in tests) {
        _introspective.ExpectAssertionSuccessNext();
        _assert.AreEqual(()=>test.F, ()=>FilesystemAssertionRepository.SanitizeFilename(_assert, test.O));
      }
    }

    [TestMethod]
    public void Test302() {
      FilesystemAssertionRepository.SetFilesystemFilenameMaxLength(_assert, 4);

      var tests = new [] {
        new { O = "a", F="a" },
        new { O = "ab", F="ab" },
        new { O = "abc", F="abc" },
        new { O = "abcd", F="abcd" },
        new { O = "abcde", F="bcde" },
        new { O = "abcdef", F="cdef" },
        new { O = "abcdefg", F="defg" },
        new { O = "abcdefgh", F="efgh" },
      };

      foreach (var test in tests) {
        _introspective.ExpectAssertionSuccessNext();
        _assert.AreEqual(()=>test.F, ()=>FilesystemAssertionRepository.SanitizeFilename(_assert, test.O));
      }
    }

    [TestMethod]
    public void Test303() {
      var tests = new [] {
        new { O = "((abcd))", F="abcd" },
        new { O = "((abcd))", F="abcd" },
        new { O = "{{abcd}}", F="abcd" },
        new { O = "<<abcd>>", F="abcd" },
        new { O = "[[abcd]]", F="abcd" },
        new { O = "test((abcd))", F="test_abcd_" },
        new { O = "test{{abcd}}", F="test_abcd_" },
        new { O = "test<<abcd>>", F="test_abcd_" },
        new { O = "test[[abcd]]", F="test_abcd_" },
      };

      foreach (var test in tests) {
        _introspective.ExpectAssertionSuccessNext();
        _assert.AreEqual(()=>test.F, ()=>FilesystemAssertionRepository.SanitizeFilename(_assert, test.O));
      }
    }

    [TestMethod]
    public void TestFilterBytes001()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[0][];

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < bytes.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>bytes, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes002()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world")
      };

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < bytes.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>bytes, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes003()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world")
      };

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < bytes.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>bytes, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes004()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < bytes.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>bytes, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    


    [TestMethod]
    public void TestFilterBytes011()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hello")
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes012()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("hola world")
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes013()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes(" world");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes014()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }



    [TestMethod]
    public void TestFilterBytes022()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("hello"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes023()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes(" world");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes024()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes033()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("hello"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes034()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("hello"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes044()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes("hello"),
      };
      var expected = Encoding.UTF8.GetBytes(" world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }


    [TestMethod]
    public void TestFilterBytes015()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes016()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes017()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes018()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }



    [TestMethod]
    public void TestFilterBytes026()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes027()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes028()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes037()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes038()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes048()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes("world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }


    [TestMethod]
    public void TestFilterBytes055()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes056()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes057()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("hello ");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes058()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("world"),
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello ");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }



    [TestMethod]
    public void TestFilterBytes066()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("llo wor"),
      };
      var expected = Encoding.UTF8.GetBytes("held");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes067()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("llo wor"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("held");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes068()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("llo wor"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("held");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes077()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("llo wor"),
      };
      var expected = Encoding.UTF8.GetBytes("held");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes078()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("llo wor"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("held");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes088()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes("llo wor"),
      };
      var expected = Encoding.UTF8.GetBytes("held");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }


    [TestMethod]
    public void TestFilterBytes061()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes(" "),
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes062()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes(" "),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes063()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes(" "),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes072()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes(" "),
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes073()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes(" "),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes083()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes(" "),
      };
      var expected = Encoding.UTF8.GetBytes("helloworld");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }



    [TestMethod]
    public void TestFilterBytes166()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("h"),
      };
      var expected = Encoding.UTF8.GetBytes("ello world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes167()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("h"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("ello world");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes168()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("h"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("ello world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes177()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("h"),
      };
      var expected = Encoding.UTF8.GetBytes("ello world");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes178()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("h"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("ello world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes188()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes("h"),
      };
      var expected = Encoding.UTF8.GetBytes("ello world");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }


    [TestMethod]
    public void TestFilterBytes161()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("d"),
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes162()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("d"),
        Encoding.UTF8.GetBytes("aloha world")
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes163()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("d"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

    [TestMethod]
    public void TestFilterBytes172()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("d"),
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");
      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);
      
      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes173()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("d"),
        Encoding.UTF8.GetBytes("howdy world"),
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }
    [TestMethod]
    public void TestFilterBytes183()
    {
      var bytes = Encoding.UTF8.GetBytes("hello world");
      var filters = new byte[][] {
        Encoding.UTF8.GetBytes("hola world"),
        Encoding.UTF8.GetBytes("aloha world"),
        Encoding.UTF8.GetBytes("howdy world"),
        Encoding.UTF8.GetBytes("d"),
      };
      var expected = Encoding.UTF8.GetBytes("hello worl");

      var result = FilesystemAssertionRepository.FilterBytes(bytes, filters);

      for (int i = 0; i < expected.Length;i++) {
        _introspective.ExpectAssertionSuccessNext();
      }
      _introspective.ExpectAssertionSuccessNext();
      
      _assert.EachSorted(()=>expected, ()=>result, (t,a,b)=>t.AreEqual(()=>a, ()=>b));
    }

  }
}
