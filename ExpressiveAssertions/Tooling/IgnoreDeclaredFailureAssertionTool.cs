using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Tooling
{
    /// <summary>
    /// Any declared failures are ignored (treated as a success essentially)
    /// </summary>
    public class IgnoreDeclaredFailureAssertionTool : IAssertionTool
    {
        IAssertionTool _inner;
        public IgnoreDeclaredFailureAssertionTool(IAssertionTool inner)
        {
            _inner = inner;
        }
        public void Accept(AssertionDeclaredFailure failure)
        {
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
            _inner.Accept(inconclusive);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            _inner.Accept(assertionSuccess);
        }

        public void Accept(AssertionFailure failure)
        {
            _inner.Accept(failure);
        }
    }
}
