using System;

namespace ExpressiveAssertions.Rendering {
    public class TypeRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
            if (!(req?.RenderTarget is Type)) {
                return req?.RenderTarget;
            }

            return new AnnotatedFormattable(string.Format("[{0}]", ((Type)req.RenderTarget).FullName));
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