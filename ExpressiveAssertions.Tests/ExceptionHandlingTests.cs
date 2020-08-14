using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests
{
    [TestClass]
    public class ExceptionHandlingTests : ExpressiveAssertionsFilesystemBackedTestBase
    {    
        [TestInitialize]
        public override void Init() {
            base.Init();

            //ConfigureAutoAccept();
        }
        
        [TestMethod]
        public void Test001()
        {
            string value1 = null;

            _introspective.ExpectAssertionFailureNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });
      
            _assert.AreEqual(()=>"not null".ToUpper(), ()=>value1.ToUpper());
        }

        [TestMethod]
        public void Test002()
        {
            string value1 = null;
            string value2 = null;

            _introspective.ExpectAssertionFailureNext((a,d)=>{
                var expectedResult = _assert.ExpectationFromDisk<string>();
                var actualResult = _assert.ActualToDisk(d.Message);
                a.AreEqual(expectedResult, actualResult);
            });
            _assert.AreEqual(()=>value1.ToUpper(), ()=>value2.ToUpper());
        }
    }
}
