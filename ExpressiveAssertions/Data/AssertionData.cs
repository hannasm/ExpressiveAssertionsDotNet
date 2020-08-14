using ExpressiveAssertions.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Data
{
    public abstract class AssertionData
    {
        // <summary>Constructs assertion with no special expected / actual data mappings</summary>
        public AssertionData(Expression assertion, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData)
          :this(assertion, null, null, null, null, message, fmt, external, @internal, contextData)
        {}

        // <summary>Base constructor for defining assertion data from assertion methods</summary>
        public AssertionData(Expression assertion, ParameterExpression[] expectedReferences, object[] expectedData, ParameterExpression[] actualReferences, object[] actualData, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData)
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

            FormatMessage = message;
            FormatArgs = fmt ?? new object[0];
            ExternalException = external;
            if (@internal != null)
            {
                InternalException = new IncompleteAssertionException(@internal);
            }
            Assertion = assertion;

            if (expectedReferences == null) {
              expectedReferences = new ParameterExpression[0];
            }
            ExpectedReference = new HashSet<ParameterExpression>(expectedReferences);
            if (expectedData == null) { expectedData = new object[0]; }

            if (actualReferences == null) {
              actualReferences = new ParameterExpression[0];
            }
            ActualReference = new HashSet<ParameterExpression>(actualReferences);
            if (actualData == null) { actualData = new object[0]; }

            ContextData = new List<ContextItem>(contextData ?? Enumerable.Empty<ContextItem>());
            var refs = expectedReferences.Zip(expectedData, (x, y) => new
            {
                Parameter = x,
                Value = y
            });
            refs = refs.Concat(actualReferences.Zip(actualData, (x, y) => new
            {
                Parameter = x,
                Value = y
            }));
            DataMappings = refs.Select(m=>new KeyValuePair<ParameterExpression,object>(m.Parameter, m.Value)).ToList();
        }

        // <summary>clone assertion data from another assertion</summary>
        public AssertionData(AssertionData dataSource) 
          : this(dataSource.Assertion,dataSource.ExpectedReference,dataSource.ActualReference, dataSource.FormatMessage, dataSource.FormatArgs, dataSource.ExternalException, dataSource.InternalException, dataSource.ContextData, dataSource.DataMappings)
        {}

        // <summary>clone assertion data from another assertion, assign new message and format args</summary>
        public AssertionData(AssertionData dataSource, string message, object[] format) 
          : this(dataSource.Assertion,dataSource.ExpectedReference,dataSource.ActualReference, message, format, dataSource.ExternalException, dataSource.InternalException, dataSource.ContextData, dataSource.DataMappings)
        {}

        // <summary>direct assignment for all fields of assertion data, this probably should be hidden but go ahead and use at your own risk</summary>
        public AssertionData(Expression assertion, IEnumerable<ParameterExpression> expectedReferences, IEnumerable<ParameterExpression> actualReferences, string message, object[] fmt, Exception external, Exception @internal, IEnumerable<ContextItem> contextData, IEnumerable<KeyValuePair<ParameterExpression,object>> dataMappings) {
          this.Assertion = assertion;
          this.FormatMessage = message;
          this.FormatArgs = fmt ?? new object[0];
          this.ContextData = new List<ContextItem>(contextData);
          this.ExpectedReference = new HashSet<ParameterExpression>(expectedReferences);
          this.ActualReference = new HashSet<ParameterExpression>(actualReferences);
          this.DataMappings = new List<KeyValuePair<ParameterExpression,object>>(dataMappings);
          this.ExternalException = external;
          this.InternalException = @internal;
        }

        public abstract void Visit(IAssertionTool tool);

        public string Message {
          get {
            return string.Format(FormatMessage, FormatArgs);
          }
        }
        public readonly string FormatMessage;
        public readonly object[] FormatArgs;
        public readonly Expression Assertion;

        // These are mutable collections that can be modified by a rendering component to add or alter
        // the data being displayed
        public readonly List<ContextItem> ContextData;
        public readonly HashSet<ParameterExpression> ExpectedReference;
        public readonly HashSet<ParameterExpression> ActualReference;
        public readonly List<KeyValuePair<ParameterExpression,object>> DataMappings;

        public readonly Exception ExternalException;
        public readonly Exception InternalException;
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
