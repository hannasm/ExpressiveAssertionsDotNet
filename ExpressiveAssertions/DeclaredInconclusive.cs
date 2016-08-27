﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class DeclaredInconclusive : AssertionData
    {
        public DeclaredInconclusive(string message, object[] fmt, Exception external, Exception @internal, IEnumerable<KeyValuePair<string, string>> contextData) : 
            base(null, null, null, null, null, message, fmt, external, @internal, contextData)
        {
        }

        public override void Visit(IAssertionTool tool)
        {
            tool.Accept(this);
        }
    }
}
