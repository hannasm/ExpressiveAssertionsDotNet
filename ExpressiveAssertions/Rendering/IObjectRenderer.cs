using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Rendering {
  public  class ObjectRenderingContext {
    public readonly AssertionData Assertion;
    public readonly IObjectRenderer Renderer;

    public ObjectRenderingContext(AssertionData assertion, IObjectRenderer renderer)
    {
      Assertion = assertion;
      Renderer = renderer;
    }
  }
  public sealed class ObjectRenderingRequest : ObjectRenderingContext {
    public readonly object RenderTarget;

    public ObjectRenderingRequest(AssertionData assertion, IObjectRenderer renderer, object renderTarget)
      : base(assertion,renderer)
    {
      RenderTarget = renderTarget;
    }

    public ObjectRenderingRequest NewTarget(object renderTarget) {
      return new ObjectRenderingRequest(this.Assertion, this.Renderer, renderTarget);
    }
    public object Render() {
      return Renderer.Render(this);
    }
  }
  public interface IObjectRenderer {
    object Render(ObjectRenderingRequest req);
    object SaveState(ObjectRenderingContext context);
    void RestoreState(ObjectRenderingContext context, object state);
  }
}
