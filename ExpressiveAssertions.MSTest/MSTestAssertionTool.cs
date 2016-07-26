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
        public void Accept(DeclaredFailure failure)
        {
            var message = ShortAssertionRenderer.Render(failure);
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(message, failure.CombinedException);
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
            var message = ShortAssertionRenderer.Render(inconclusive);
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException(message, inconclusive.CombinedException);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            var message = ShortAssertionRenderer.Render(assertionSuccess);
            Debug.WriteLine("Success " + message);
        }

        public void Accept(AssertionFailure failure)
        {
            var message = "Failure " + ShortAssertionRenderer.Render(failure);
            throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(message, failure.CombinedException);
        }
    }
}
