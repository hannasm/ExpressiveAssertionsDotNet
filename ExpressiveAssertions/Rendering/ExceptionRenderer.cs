using System;
using ExpressionToCodeLib;

namespace ExpressiveAssertions.Rendering
{
    public class ExceptionRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
          if (!(req?.RenderTarget is Exception)) {
            return req?.RenderTarget;
          }
          return new AnnotatedFormattable(req.RenderTarget.ToString(), null, "[" + ObjectToCode.ToCSharpFriendlyTypeName(req.RenderTarget.GetType()) + "]", null);
        }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
        }

        public object SaveState(ObjectRenderingContext context)
        {
            return null;
        }
    }
}