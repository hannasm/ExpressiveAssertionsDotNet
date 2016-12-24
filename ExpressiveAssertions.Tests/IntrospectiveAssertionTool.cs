using ExpressiveAssertions.Data;
using ExpressiveAssertions.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tests
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
            }

            public readonly Type ExpectedAssertionType;
        }

        public IntrospectiveAssertionTool ExpectDeclaredFailureNext()
        {
            _expectations.Enqueue(new Expectation(typeof(DeclaredFailure)));
            return this;
        }

        public IntrospectiveAssertionTool ExpectInconclusiveNext()
        {
            _expectations.Enqueue(new Expectation(typeof(DeclaredInconclusive)));
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

        public void NoneOutstanding()
        {
            _inner.AreEqual(0, () => _expectations.Count, "There were 1 or more expected assertions which were not checked");
        }

        public void Accept(DeclaredFailure failure)
        {
            if (_expectations.Count < 1)
            {
                _inner.Fail("Unexpected assertion encountered with message: {0}", ShortAssertionRenderer.Render(failure));
            }

            var next = _expectations.Dequeue();

            _inner.AreEqual(() => next.ExpectedAssertionType, typeof(DeclaredFailure), "Expected assertion should be same type");
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
            if (_expectations.Count < 1)
            {
                _inner.Fail("Unexpected assertion encountered with message: {0}", ShortAssertionRenderer.Render(inconclusive));
            }

            var next = _expectations.Dequeue();

            _inner.AreEqual(() => next.ExpectedAssertionType, typeof(DeclaredInconclusive), "Expected assertion should be same type");
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            if (_expectations.Count < 1)
            {
                _inner.Fail("Unexpected assertion encountered with message: {0}", ShortAssertionRenderer.Render(assertionSuccess));
            }

            var next = _expectations.Dequeue();

            _inner.AreEqual(() => next.ExpectedAssertionType, typeof(AssertionSuccess), "Expected assertion should be same type");
        }

        public void Accept(AssertionFailure failure)
        {
            if (_expectations.Count < 1)
            {
                _inner.Fail("Unexpected assertion encountered with message: {0}", ShortAssertionRenderer.Render(failure));
            }

            var next = _expectations.Dequeue();

            _inner.AreEqual(() => next.ExpectedAssertionType, typeof(AssertionFailure), "Expected assertion should be same type");
        }
    }
}
