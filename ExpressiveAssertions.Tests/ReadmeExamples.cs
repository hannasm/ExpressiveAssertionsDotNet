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
        IAssertionTool tool = new MSTest.MSTestAssertionTool();
    
        [TestMethod]
        public void Test001()
        {
            int x = 10;

            tool.Assert(() => x == 10); // success
            tool.Assert(() => x == 20); // failure
        }
        [TestMethod]
        public void Test002()
        {

            int x = 10;

            tool.Check(() => x, () => 10, (a, b) => a == b); // success 
            tool.Check(() => x, () => 20, (a, b) => a == b); // success
        }
    }
}
