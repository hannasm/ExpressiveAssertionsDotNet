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
