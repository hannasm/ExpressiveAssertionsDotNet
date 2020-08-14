using ExpressiveAssertions.Data;
using ExpressiveAssertions.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.MSTest
{
    public class MSTestAssertionTool : IAssertionTool
    {
        MSTestAssertionTool() { }

        public static IAssertionTool Create()
        {
            return new MSTestAssertionTool();
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(
                failure.Message, failure.CombinedException);
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException(
                inconclusive.Message, inconclusive.CombinedException);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
        }

        public void Accept(AssertionFailure failure)
        {
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(failure.Message, failure.CombinedException);
        }
    }
}
