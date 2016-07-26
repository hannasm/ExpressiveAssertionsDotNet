using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class DeclaredInconclusive : AssertionData
    {
        public DeclaredInconclusive(string message, object[] fmt, Exception external, Exception @internal) : 
            base(null, null, null, null, null, message, fmt, external, @internal)
        {
        }
    }
}
