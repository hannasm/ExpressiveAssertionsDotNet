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

        public void Accept(DeclaredFailure failure)
        {
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(failure.Message, failure.CombinedException);
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException(inconclusive.Message, inconclusive.CombinedException);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            Debug.WriteLine("Assert Succeeded - " + assertionSuccess.Message);
        }

        public void Accept(AssertionFailure failure)
        {
            var message = "Assert Failure - " + failure.Message;
            Debug.WriteLine(message);
            if (failure.CombinedException != null)
            {
                Debug.WriteLine(failure.CombinedException.ToString());
            }
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(message, failure.CombinedException);
        }
    }
}
