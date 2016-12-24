using ExpressiveAssertions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public interface IAssertionTool
    {
        void Accept(AssertionFailure failure);
        void Accept(AssertionSuccess assertionSuccess);
        void Accept(DeclaredFailure failure);
        void Accept(DeclaredInconclusive inconclusive);
    }
}
