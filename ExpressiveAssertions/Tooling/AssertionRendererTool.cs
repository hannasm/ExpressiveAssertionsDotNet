using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAssertions.Data;
using ExpressiveAssertions.Rendering;

namespace ExpressiveAssertions.Tooling
{
    public class AssertionRendererTool : IAssertionTool
    {
        readonly IAssertionTool _inner;
        readonly IObjectRenderer _renderer;
        AssertionRendererTool(IObjectRenderer renderer, IAssertionTool inner)
        {
            _inner = inner;
            _renderer = renderer;
        }

        public object Render(AssertionData data) {
            var renderReq = new ObjectRenderingRequest(data, _renderer, data);
            var rendering = _renderer.Render(renderReq);
            return rendering;
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
            _inner.Accept(new AssertionDeclaredFailure(failure, 
                "{0}", new object[] { Render(failure) }
            ));
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
            _inner.Accept(new AssertionDeclaredInconclusive(
                  inconclusive,
                "{0}", new object[] { Render(inconclusive) }
           ));
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            _inner.Accept(new AssertionSuccess(
                assertionSuccess,
                "{0}", new object[] { Render(assertionSuccess) }
            ));
        }

        public void Accept(AssertionFailure failure)
        {
            _inner.Accept(new AssertionFailure(
                failure,
                "{0}", new object[] { Render(failure) }
            ));
        }

        public static IAssertionTool Create(IObjectRenderer renderer, IAssertionTool inner)
        {
            return new AssertionRendererTool(renderer, inner);
        }
        public static IAssertionTool Create(IAssertionTool inner)
        {
            var renderer = new DefaultRenderingStack();
            return new AssertionRendererTool(renderer, inner);
        }
    }
}
