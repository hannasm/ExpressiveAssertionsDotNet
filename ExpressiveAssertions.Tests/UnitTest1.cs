using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

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
            _assert.Check(()=> 10 == 20, null, "Test");
        }
        [TestMethod]
        public void Test003()
        {
            int i = 10;
            int j = 20;
            _assert.Check(() => i == j, null, "Test");
        }

        class Visitor {
            public void Accept(VisitableOne one) { Debug.WriteLine("Accept Visitable One"); }
            public void Accept(VisitableTwo two) { Debug.WriteLine("Accept Visitable Two"); }
            public void Accept(VisitableBase @base) { Debug.WriteLine("Accept Visitable Base"); }
    }
        class VisitableBase
        {
            public virtual void Visit(Visitor v)
            {
                v.Accept(this);
            }
        }
        class VisitableOne : VisitableBase
        {
        }
        class VisitableTwo : VisitableBase
        {
            public override void Visit(Visitor v)
            {
                v.Accept(this);
            }
        }

        [TestMethod]
        public void Test004()
        {
            var b = new VisitableBase();
            var o = new VisitableOne();
            var t = new VisitableTwo();
            var v = new Visitor();

            b.Visit(v);
            o.Visit(v);
            t.Visit(v);
        }

    }
}
