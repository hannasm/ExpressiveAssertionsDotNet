using ExpressiveAssertions.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public abstract class AssertionData
    {
        public AssertionData(Expression assertion, ParameterExpression[] expectedReferences, object[] expectedData, ParameterExpression[] actualReferences, object[] actualData, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<KeyValuePair<string, string>> contextData)
        {
            if (expectedReferences != null || expectedData != null)
            {
                if (expectedData == null) { throw new ArgumentNullException("expectedData"); }
                if (expectedReferences == null) { throw new ArgumentNullException("expectedReferences"); }
                if (expectedData.Length != expectedReferences.Length) { throw new DataMismatchException("expectedData and expectedReferences don't have matching counts"); }
            }
            if (actualReferences != null || actualData != null)
            {
                if (actualData == null) { throw new ArgumentNullException("actualData"); }
                if (actualReferences == null) { throw new ArgumentNullException("actualReferences"); }
                if (actualData.Length != actualReferences.Length) { throw new DataMismatchException("actualData and actualReferences don't have matching counts"); }
            }

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
            ContextData = contextData ?? Enumerable.Empty<KeyValuePair<string, string>>();
        }

        public abstract void Visit(IAssertionTool tool);

        public readonly string Message;
        public readonly object[] Format;
        public readonly Expression Assertion;
        public readonly Exception ExternalException;
        public readonly Exception InternalException;
        public readonly object[] ExpectedData;
        public readonly object[] ActualData;
        public readonly ParameterExpression[] ExpectedReference;
        public readonly ParameterExpression[] ActualReference;
        public readonly IEnumerable<KeyValuePair<string, string>> ContextData;

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
