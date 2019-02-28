using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests
{
    [TestClass]
    public class ExceptionHandlingTests
    {
        IAssertionTool assert = ExpressiveAssertions.Tooling.ShortAssertionRendererTool.Create(
            ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
        );
    
        [TestMethod]
        public void Test001()
        {
            string value1 = null;

            assert.AreEqual(()=>"not null".ToUpper(), ()=>value1.ToUpper());
        }

        [TestMethod]
        public void Test002()
        {
            string value1 = null;
            string value2 = null;

            assert.AreEqual(()=>value1.ToUpper(), ()=>value2.ToUpper());
        }
    }
}
