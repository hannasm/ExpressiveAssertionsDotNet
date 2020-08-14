using System;
using ExpressionToCodeLib;

namespace ExpressiveAssertions.Rendering {
    public class EnumRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
          if (!typeof(Enum).IsAssignableFrom(req.GetType())) {
            return req.RenderTarget;
          }
          return new AnnotatedFormattable(req.RenderTarget, "G", "[" + ObjectToCode.ToCSharpFriendlyTypeName(req.RenderTarget.GetType()) + "]", null);
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