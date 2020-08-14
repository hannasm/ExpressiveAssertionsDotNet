using System;

namespace ExpressiveAssertions.Rendering {
    public class DelegateRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
            var del = req?.RenderTarget as Delegate;
            if (del == null) { return req?.RenderTarget; }

            return new AnnotatedFormattable(string.Format("[{0}]", del.Method.ToString()));
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