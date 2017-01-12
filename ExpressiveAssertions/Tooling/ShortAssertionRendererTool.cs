using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAssertions.Data;
using ExpressiveAssertions.Rendering;

namespace ExpressiveAssertions.Tooling
{
    public class ShortAssertionRendererTool : IAssertionTool
    {
        readonly IAssertionTool _inner;
        ShortAssertionRendererTool(IAssertionTool inner)
        {
            _inner = inner;
        }
        public void Accept(DeclaredFailure failure)
        {
            _inner.Accept(new DeclaredFailure(
                "{0}", new object[] { ShortAssertionRenderer.Render(failure) }, 
                failure.ExternalException, failure.InternalException, 
                failure.ContextData
            ));
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
            _inner.Accept(new DeclaredInconclusive(
                "{0}", new object[] { ShortAssertionRenderer.Render(inconclusive) }, 
                inconclusive.ExternalException, inconclusive.InternalException, 
                inconclusive.ContextData
            ));
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            _inner.Accept(new AssertionSuccess(
                assertionSuccess.Assertion,
                assertionSuccess.ExpectedReference,
                assertionSuccess.ExpectedData,
                assertionSuccess.ActualReference,
                assertionSuccess.ActualData,
                "{0}", new object[] { ShortAssertionRenderer.Render(assertionSuccess) }, 
                assertionSuccess.ExternalException, assertionSuccess.InternalException, 
                assertionSuccess.ContextData
            ));
        }

        public void Accept(AssertionFailure failure)
        {
            _inner.Accept(new AssertionFailure(
                failure.Assertion,
                failure.ExpectedReference,
                failure.ExpectedData,
                failure.ActualReference,
                failure.ActualData,
                "{0}", new object[] { ShortAssertionRenderer.Render(failure) }, 
                failure.ExternalException, failure.InternalException, failure.ContextData
            ));
        }

        public static IAssertionTool Create(IAssertionTool inner)
        {
            return new ShortAssertionRendererTool(inner);
        }
    }
}
