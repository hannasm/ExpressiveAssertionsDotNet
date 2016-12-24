using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests
{
    [TestClass]
    public class BaseAssertionTests
    {
        IntrospectiveAssertionTool _assert;

        [TestInitialize]
        public virtual void Init()
        {
            _assert = new IntrospectiveAssertionTool(ExpressiveAssertions.MSTest.MSTestAssertionTool.Create());
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            // this should be called by each test on it's own for the best 'error reporting experience'
            _assert.NoneOutstanding();
        }

        [TestMethod]
        public void Test001()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false);

            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test002()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true);

            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test003()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false, new Exception("Test"));
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test004()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, new Exception("Test"));
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test005()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false, "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test006()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test007()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false, "{0}", "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test008()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, "{0}", "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test009()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false, new Exception("TEST"), "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test010()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, new Exception("TEST"), "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test011()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => false, new Exception("TEST"), "{0}", "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test012()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, new Exception("TEST"), "{0}", "ABCD");
            _assert.NoneOutstanding();
        }

        [TestMethod]
        public void Test013()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, ()=>false, (l,r)=>false, new Exception("TEST"), "{0}", "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test014()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true, new Exception("TEST"), "{0}", "ABCD");
            _assert.NoneOutstanding();
        }

        [TestMethod]
        public void Test015()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, () => false, (l, r) => false, "{0}", "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test016()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true, "{0}", "ABCD");
            _assert.NoneOutstanding();
        }

        [TestMethod]
        public void Test017()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, () => false, (l, r) => false, "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test018()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true, "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test019()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, () => false, (l, r) => false, new Exception("TEST"), "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test020()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true, new Exception("TEST"), "ABCD");
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test021()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, () => false, (l, r) => false, new Exception("TEST"));
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test022()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true, new Exception("TEST"));
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test023()
        {
            _assert.ExpectAssertionFailureNext();
            _assert.Check(() => true, () => false, (l, r) => false);
            _assert.NoneOutstanding();
        }
        [TestMethod]
        public void Test024()
        {
            _assert.ExpectAssertionSuccessNext();
            _assert.Check(() => true, () => false, (l, r) => true);
            _assert.NoneOutstanding();
        }
    }
}
