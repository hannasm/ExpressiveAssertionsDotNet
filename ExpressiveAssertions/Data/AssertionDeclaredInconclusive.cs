﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Data
{
    public class AssertionDeclaredInconclusive : AssertionData
    {
        public AssertionDeclaredInconclusive(AssertionData dataSource) : base(dataSource)
        {
        }

        public AssertionDeclaredInconclusive(AssertionData dataSource, string message, object[] format) : base(dataSource, message, format)
        {
        }

        public AssertionDeclaredInconclusive(string message, object[] fmt, IEnumerable<ContextItem> contextData) : base(null, message, fmt, null, null, contextData)
        {
        }
        public AssertionDeclaredInconclusive(Expression assertion, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData) : base(assertion, message, fmt, external, @internal, contextData)
        {
        }

        public AssertionDeclaredInconclusive(Expression assertion, IEnumerable<ParameterExpression> expectedReferences, IEnumerable<ParameterExpression> actualReferences, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData, IEnumerable<KeyValuePair<ParameterExpression, object>> dataMappings) : base(assertion, expectedReferences, actualReferences, message, fmt, external, @internal, contextData, dataMappings)
        {
        }

        public AssertionDeclaredInconclusive(Expression assertion, ParameterExpression[] expectedReferences, object[] expectedData, ParameterExpression[] actualReferences, object[] actualData, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData) : base(assertion, expectedReferences, expectedData, actualReferences, actualData, message, fmt, external, @internal, contextData)
        {
        }

        public override void Visit(IAssertionTool tool)
        {
            tool.Accept(this);
        }
    }
}
