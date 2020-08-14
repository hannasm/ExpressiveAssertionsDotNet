namespace ExpressiveAssertions.Rendering {
    public class NullRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
          if (req?.RenderTarget != null) { return req.RenderTarget; }
          return new AnnotatedFormattable("~null~");
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
