using ExpressiveAssertions.Data;
using ExpressiveExpressionTrees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressiveAssertions
{
    public class IntrospectiveAssertionTool : IAssertionTool
    {
        Queue<Expectation> _expectations = new Queue<Expectation>();
        IAssertionTool _inner;

        public IntrospectiveAssertionTool(IAssertionTool inner)
        {
            _inner = inner;
        }

        class Expectation
        {
            public Expectation(Type expectedType)
            {
              ExpectedAssertionType = expectedType;
              DoTests = (t,e,d) => { return; };
            }

            public Expectation(Type expectedType, string message) : this(expectedType, ()=>message)
            {
            }
            public Expectation(Type expectedType, Expression<Func<string>> message)
            {
                ExpectedAssertionType = expectedType;
                DoTests = (tool, expectation, data) => {
                  tool.AreEqual(message, ()=>string.Format(data.FormatMessage, data.FormatArgs), "Assertion message did not match");
                };
            }

            public Expectation(Type expectedType, Action<IAssertionTool, AssertionData> test) : this(expectedType)
            {
              ExpectedAssertionType = expectedType;
              DoTests = (tool, expectation, data) => {
                test(tool, data);
              };
            }

            public readonly Type ExpectedAssertionType;
            public readonly Action<IAssertionTool, Expectation, AssertionData> DoTests;

            public void Check(IAssertionTool assert, AssertionData data) {
              DoTests(assert, this, data);
              assert.AreEqual(() => this.ExpectedAssertionType, data.GetType(), "Expected assertion should be same type");
            }
        }

        public IntrospectiveAssertionTool ExpectDeclaredFailureNext()
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredFailure)));
            return this;
        }

        public IntrospectiveAssertionTool ExpectInconclusiveNext()
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredInconclusive)));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionFailureNext()
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionFailure)));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionSuccessNext()
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionSuccess)));
            return this;
        }
        public IntrospectiveAssertionTool ExpectDeclaredFailureNext(Expression<Func<string>> message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredFailure), message));
            return this;
        }

        public IntrospectiveAssertionTool ExpectInconclusiveNext(Expression<Func<string>> message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredInconclusive), message));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionFailureNext(Expression<Func<string>> message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionFailure), message));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionSuccessNext(Expression<Func<string>> message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionSuccess), message));
            return this;
        }

        static Expression<Func<object>> LambdaToType<T>(Expression<Func<T>> expr) {
          var xgr = new ExpressionGenerator();
          var message2 = xgr.FromFunc(expr, m=>(object)m);
          return message2;
        }
        public IntrospectiveAssertionTool ExpectDeclaredFailureNext(Action<IAssertionTool, AssertionData> test)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredFailure), test));
            return this;
        }

        public IntrospectiveAssertionTool ExpectInconclusiveNext(Action<IAssertionTool, AssertionData> test)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredInconclusive), test));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionFailureNext(Action<IAssertionTool, AssertionData> test)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionFailure), test));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionSuccessNext(Action<IAssertionTool, AssertionData> test)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionSuccess), test));
            return this;
        }

        public IntrospectiveAssertionTool ExpectDeclaredFailureNext(string message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredFailure), message));
            return this;
        }

        public IntrospectiveAssertionTool ExpectInconclusiveNext(string message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionDeclaredInconclusive), message));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionFailureNext(string message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionFailure), message));
            return this;
        }
        public IntrospectiveAssertionTool ExpectAssertionSuccessNext(string message)
        {
            _expectations.Enqueue(new Expectation(typeof(AssertionSuccess), message));
            return this;
        }
        public void NoneOutstanding()
        {
            _inner.AreEqual(0, () => _expectations.Count, "There were 1 or more expected assertions which were not checked");
        }

        Expectation Dequeue(AssertionData data) {
            if (_expectations.Count < 1)
            {
                _inner.Fail("Unexpected assertion encountered with message: {0}", string.Format(data.FormatMessage, data.FormatArgs));
            }

            var next = _expectations.Dequeue();
            return next;
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
          var next = Dequeue(failure);
          next.Check(_inner, failure);
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
          var next = Dequeue(inconclusive);
          next.Check(_inner, inconclusive);
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
          var next = Dequeue(assertionSuccess);
          next.Check(_inner, assertionSuccess);
        }

        public void Accept(AssertionFailure failure)
        {
          var next = Dequeue(failure);
          next.Check(_inner, failure);
        }
    }
}
