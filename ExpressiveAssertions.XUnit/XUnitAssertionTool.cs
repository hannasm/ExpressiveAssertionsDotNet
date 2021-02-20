using ExpressiveAssertions.Data;
using ExpressiveAssertions.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.XUnit
{
    public class XUnitAssertionTool : IAssertionTool
    {
        XUnitAssertionTool() { }

        public static IAssertionTool Create()
        {
            return new XUnitAssertionTool();
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
            throw new Exception(failure.Message, failure.CombinedException);
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
            throw new Exception("$XunitDynamicSkip$" + inconclusive.Message, inconclusive.CombinedException);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
        }

        public void Accept(AssertionFailure failure)
        {
            throw new Exception(failure.Message, failure.CombinedException);
        }
    }
}
