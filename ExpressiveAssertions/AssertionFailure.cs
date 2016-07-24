using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class AssertionFailure : AssertionData
    {
        public AssertionFailure(Expression assertion, ParameterExpression[] expectedReferences, object[] expectedData, ParameterExpression[] actualReferences, object[] actualData, string message, object[] fmt, Exception external, Exception @internal) : base(assertion, expectedReferences, expectedData, actualReferences, actualData, message, fmt, external, @internal)
        {
        }
    }
}
