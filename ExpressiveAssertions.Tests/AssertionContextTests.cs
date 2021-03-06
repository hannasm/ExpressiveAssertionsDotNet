﻿using ExpressiveAssertions.Exceptions;
using ExpressiveAssertions.Tooling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests
{
    [TestClass]
    public class AssertionContextTests
    {
        IAssertionTool assert = AssertionRendererTool.Create(ExpressiveAssertions.MSTest.MSTestAssertionTool.Create());

        [TestMethod]
        public void Test001()
        {
            var ac = new AssertionContext();
        }

        [TestMethod]
        public void Test002()
        {
            var ac = new AssertionContext();

            assert.Throws<StateException>(() => ac.Pop());
        }

        [TestMethod]
        public void Test003()
        {
            var ac = new AssertionContext();

            ac.Set("abc", "def");

            var values = ac.GetData();
            assert.AreEqual(1, () => values.Count());
            assert.AreEqual(new
            {
                Key = "abc",
                Value = "def",
                Depth = 0
            }, () => values.Select(kvp => new
            {
                Key = kvp.Key,
                Value = kvp.Value,
                Depth = kvp.Depth
            }).Single());

            ac.Set("abc", "ghi");

            var values2 = ac.GetData();
            assert.AreEqual(1, () => values2.Count());
            assert.AreEqual(new
            {
                Key = "abc",
                Value = "ghi",
                Depth = 0
            }, () => values2.Select(kvp => new
            {
                Key = kvp.Key,
                Value = kvp.Value,
                Depth = kvp.Depth
            }).Single());
        }

        [TestMethod]
        public void Test004()
        {
            var ac = new AssertionContext();

            ac.Set("abc", "def");

            IDisposable s1;
            using (s1 = ac.Push())
            {
                ac.Set("ghi", "jkl");

                var values = ac.GetData();
                assert.AreEqual(2, () => values.Count());
                assert.EveryUnsorted((new[] {
                        new
                        {
                            Key = "abc",
                            Value = "def",
                            Depth = 0
                        }, new {
                            Key = "ghi",
                            Value = "jkl",
                            Depth = 1,
                        }
                }).AsEnumerable(), () => values.Select(kvp => new
                {
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Depth = kvp.Depth
                }).AsEnumerable(), (t, a, b) => t.AreEqual(a, b));
            }

            // intentionally dispose s1 ag ain here, this shouldn't cause any problems
            s1.Dispose();

            var values2 = ac.GetData();
            assert.AreEqual(1, () => values2.Count());
            assert.EveryUnsorted((new[] {
                        new
                        {
                            Key = "abc",
                            Value = "def",
                            Depth = 0
                        }
                }).AsEnumerable(), () => values2.Select(kvp => new
                {
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Depth = kvp.Depth
                }).AsEnumerable(), (t, a, b) => t.AreEqual(a, b));
        }

        [TestMethod]
        public void Test005()
        {
            var ac = new AssertionContext();

            assert.Throws<ArgumentNullException>(() => ac.Set(null, "anyvaluehere"));
        }

        [TestMethod]
        public void Test006()
        {
            var ac = new AssertionContext();

            ac.Set("abc", "def");

            IDisposable s2;
            using (var s1 = ac.Push())
            {
                ac.Set("ghi", "jkl");

                s2 = ac.Push();

                ac.Set("mno", "pqr");

                var values = ac.GetData();
                assert.AreEqual(3, () => values.Count());
                assert.EveryUnsorted((new[] {
                        new
                        {
                            Key = "abc",
                            Value = "def",
                            Depth = 0,
                        }, new {
                            Key = "ghi",
                            Value = "jkl",
                            Depth = 1,
                        }, new {
                            Key = "mno",
                            Value = "pqr",
                            Depth = 2
                        }
                }).AsEnumerable(), () => values.Select(kvp => new
                {
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Depth = kvp.Depth
                }).AsEnumerable(), (t, a, b) => t.AreEqual(a, b));

                // in this test, we intentionally are not disposing s2 at this point so that when we dispose s1, we can exercise the 'multi-level-rollback functionality
                // s2.Dispose()
            }

            // we now intentionally dispose s2 after it has been 'rolled back' by another and ensure that no errors occur from that either
            s2.Dispose();

            var values2 = ac.GetData();
            assert.AreEqual(1, () => values2.Count());
            assert.EveryUnsorted((new[] {
                        new
                        {
                            Key = "abc",
                            Value = "def",
                            Depth = 0
                        }
                }).AsEnumerable(), () => values2.Select(kvp => new
                {
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Depth = kvp.Depth
                }).AsEnumerable(), (t, a, b) => t.AreEqual(a, b));
        }


    }
}
