using System;

namespace ExpressiveAssertions.Rendering {
  /* <summary>
   * Wrap any object renderer with a new test defined by a lambda.
   * The renderer will not be executed unless both the new lambda passes and any
   * other tests that may be implemented by the renderer are validated
   * </summary>
   */
  public class ConditionalRenderingWrapper : IObjectRenderer {
    public ConditionalRenderingWrapper(Func<ObjectRenderingRequest, bool> test, IObjectRenderer renderer) {
      if (test == null) { throw new ArgumentNullException("test"); }
      if (renderer == null) { throw new ArgumentNullException("renderer"); }
      _renderer = renderer;
      _test = test;
    }
    readonly IObjectRenderer _renderer;
    readonly Func<ObjectRenderingRequest, bool> _test;

    public object Render(ObjectRenderingRequest req)
    {
      if (!_test(req)) { return req.RenderTarget; }

      return _renderer.Render(req);
    }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
           _renderer.RestoreState(context, state);
        }

        public object SaveState(ObjectRenderingContext context)
        {
          return _renderer.SaveState(context);
        }
  }
}
