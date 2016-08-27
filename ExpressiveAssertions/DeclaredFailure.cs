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
        public DeclaredFailure(string message, object[] fmt, Exception external, Exception @internal, IEnumerable<KeyValuePair<string, string>> contextData) : 
            base(null, null, null, null, null, message, fmt, external, @internal, contextData)
        {
        }

        public override void Visit(IAssertionTool tool)
        {
            tool.Accept(this);
        }
    }
}
