using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveAssertions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public IAssertionTool _assert;

        [TestInitialize]
        public void Init()
        {
            _assert = new MSTest.MSTestAssertionTool();
        }

        [TestMethod]
        public void Test001()
        {
            _assert.Check(()=>10, () => 20, (x, y) => x == y, null, "Test");
        }

        [TestMethod]
        public void Test002()
        {
            _assert.Assert(()=> 10 == 20, null, "Test");
        }
        [TestMethod]
        public void Test003()
        {
            int i = 10;
            int j = 20;
            _assert.Assert(() => i == j, null, "Test");
        }
    }
}
