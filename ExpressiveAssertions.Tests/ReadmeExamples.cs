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
    public class ReadmeExamples
    {
        // Render the assertion outcomes to the test result stream but do not actually fail a test based on any outcomes
        IAssertionTool assert = AssertionRendererTool.Create(
            CompositeAssertionTool.Create(
                TraceLoggingAssertionTool.Create(),
                NullAssertionTool.Create()
            )
        );

    
        [TestMethod]
        public void Test001()
        {
            int x = 10;

            assert.Check(() => x == 10); // success
            assert.Check(() => x == 20); // failure
        }
        [TestMethod]
        public void Test002()
        {

            int x = 10;

            assert.Check(() => x, () => 10, (a, b) => a == b); // success 
            assert.Check(() => x, () => 20, (a, b) => a == b); // success
        }
        [TestMethod]
        public void Test003()
        {
            var data = new[] {
                new { FieldOne = 10, FieldTwo = 100 },
                new { FieldOne = 30, FieldTwo = 900 },
                new { FieldOne = 2, FieldTwo = 4 },
            };

            using (assert.ContextPush())
            for (int i = 0; i < data.Length; i++)
            {
                assert.ContextSet("index", i.ToString());

                // fieldtwo must be square of fieldone
                assert.IsTrue(() => data[i].FieldOne * data[i].FieldOne == data[i].FieldTwo);
                // fieldone must be multiple of 10
                assert.IsTrue(() => data[i].FieldOne % 10 == 0);
            }
        }
    }
}
