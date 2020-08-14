namespace ExpressiveAssertions.Rendering {
    public class LiteralRenderer<T> : IObjectRenderer
    {
        public LiteralRenderer() {}
        public LiteralRenderer(string defaultFormat) {
          _df = defaultFormat;
        }
        public LiteralRenderer(string defaultFormat, string prefix, string suffix) {
          _df = defaultFormat;
          _prefix = prefix;
          _suffix = suffix;
        }
        readonly string _df;
        readonly string _prefix;
        readonly string _suffix;

        public object Render(ObjectRenderingRequest req)
        {
          if (!(req?.RenderTarget is T)) { return req?.RenderTarget; }
          return new AnnotatedFormattable(req.RenderTarget, _df, _prefix, _suffix);
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
