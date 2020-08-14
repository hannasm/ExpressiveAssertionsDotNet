using System;

namespace ExpressiveAssertions.Rendering {
    /// <summary>Objects that implement IFormattable should have some sort of reasonably well thought out ToString() representation and therefore 
    /// if we reach this renderer in the pipeline and have not yet produced a AnnotatedFormattable we convert the IFormattable to AnnotatedFormattable
    /// and this will block other renderers (like the reflection renderer) from running on it). </summary>
    public class FormattableRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
            var af = req?.RenderTarget as AnnotatedFormattable;
            if (af != null) {return af;}
            var fm = req.RenderTarget as IFormattable;
            if (fm != null) { return new AnnotatedFormattable(fm); }
            return req.RenderTarget;
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