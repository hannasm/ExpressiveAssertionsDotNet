using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class AssertionData
    {
        public AssertionData(Expression assertion, ParameterExpression[] expectedReferences, object[] expectedData, ParameterExpression[] actualReferences, object[] actualData, string message, object[] fmt, Exception external, Exception @internal)
        {
            Contract.Requires(assertion != null, "assertion != null");
            Contract.Requires(expectedReferences?.Length == expectedData?.Length, "each expected data point has crresponding reference");
            Contract.Requires(actualReferences?.Length == actualData?.Length, "each actual data point has crresponding reference");

            Message = message;
            Format = fmt;
            ExternalException = external;
            if (@internal != null)
            {
                InternalException = new IncompleteAssertionException(@internal);
            }
            Assertion = assertion;
            ExpectedData = expectedData ?? new object[0];
            ExpectedReference = expectedReferences ?? new ParameterExpression[0];
            ActualData = actualData ?? new object[0];
            ActualReference = actualReferences ?? new ParameterExpression[0];
        }

        public readonly string Message;
        public readonly object[] Format;
        public readonly Expression Assertion;
        public readonly Exception ExternalException;
        public readonly Exception InternalException;
        public readonly object[] ExpectedData;
        public readonly object[] ActualData;
        public readonly ParameterExpression[] ExpectedReference;
        public readonly ParameterExpression[] ActualReference;

        public Exception CombinedException
        {
            get
            {
                if (ExternalException != null && InternalException != null)
                {
                    return new AggregateException("Both internal error and external error were reported during assertion", InternalException, ExternalException);
                }
                else if (ExternalException != null)
                {
                    return ExternalException;
                }
                else
                {
                    return InternalException;
                }
            }
        }
    }
}
