using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Tooling {
    /// <summary>Black hole of assertions, consume and ignore any assertion data that ends up here</summmary>
    public class NullAssertionTool : IAssertionTool
    {
        NullAssertionTool() {}
        
        public void Accept(AssertionFailure failure)
        {
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
        }

        public static IAssertionTool Create() { return new NullAssertionTool();}
    }
}