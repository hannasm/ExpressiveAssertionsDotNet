using ExpressiveAssertions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tooling
{
    /// <summary>
    /// Any inconclusive results are ignored (treated as a success essentially)
    /// </summary>
    public class IgnoreInconclusiveAssertionTool : IAssertionTool
    {
        IAssertionTool _inner;
        public IgnoreInconclusiveAssertionTool(IAssertionTool inner)
        {
            _inner = inner;
        }
        public void Accept(DeclaredFailure failure)
        {
            _inner.Accept(failure);
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
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
