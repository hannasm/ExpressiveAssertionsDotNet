using System;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Rendering
{
  public class LambdaRenderer : IObjectRenderer {
    public readonly Func<ObjectRenderingRequest, bool> Test;
    public readonly Func<ObjectRenderingRequest, object> Render;

    public LambdaRenderer(Func<ObjectRenderingRequest, bool> test, Func<ObjectRenderingRequest, object> render)
    {
        Test = test;
        Render = render;
    }

    object IObjectRenderer.Render(ObjectRenderingRequest req)
    {
      if (!Test(req)) { return req.RenderTarget; }

      return Render(req);
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
