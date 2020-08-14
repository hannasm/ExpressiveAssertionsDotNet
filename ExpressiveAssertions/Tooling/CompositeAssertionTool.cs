using ExpressiveAssertions.Data;

namespace ExpressiveAssertions {
    public class CompositeAssertionTool : IAssertionTool
    {
      IAssertionTool[] _tools;

      public static IAssertionTool Create(params IAssertionTool[] tool) {
        return new CompositeAssertionTool(tool);
      }

      CompositeAssertionTool(IAssertionTool[] tools)
      {
          this._tools = tools;
      }

      public void Accept(AssertionFailure failure)
      {
        foreach (var tool in _tools) {
          tool.Accept(failure);
        }
      }

      public void Accept(AssertionSuccess assertionSuccess)
      {
        foreach (var tool in _tools) {
          tool.Accept(assertionSuccess);
        }
      }

      public void Accept(AssertionDeclaredFailure failure)
      {
        foreach (var tool in _tools) {
          tool.Accept(failure);
        }
      }

      public void Accept(AssertionDeclaredInconclusive inconclusive)
      {
        foreach (var tool in _tools) {
          tool.Accept(inconclusive);
        }
      }
    }
}
