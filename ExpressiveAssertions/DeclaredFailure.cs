using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class DeclaredFailure : AssertionData
    {
        public DeclaredFailure(string message, object[] fmt, Exception external, Exception @internal) : 
            base(null, null, null, null, null, message, fmt, external, @internal)
        {
        }
    }
}
