using System.Diagnostics;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions {
    public class TraceLoggingAssertionTool : IAssertionTool
    {
        TraceLoggingAssertionTool() {}
        public static IAssertionTool Create() { return new TraceLoggingAssertionTool(); }
        
        public void Accept(AssertionFailure failure)
        {
          Trace.Write("Assertion Failure - ");
          Trace.WriteLine(failure.Message);
          if (failure.CombinedException != null) {
            Trace.WriteLine(failure.CombinedException.ToString());
          }
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
          Trace.Write("Assertion Success - ");
          Trace.WriteLine(assertionSuccess.Message);
          if (assertionSuccess.CombinedException != null) {
            Trace.WriteLine(assertionSuccess.CombinedException.ToString());
          }
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
          Trace.Write("Assertion Declared Failure - ");
          Trace.WriteLine(failure.Message);
          if (failure.CombinedException != null) {
            Trace.WriteLine(failure.CombinedException.ToString());
          }
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
          Trace.Write("Assertion Inconclusive - ");
          Trace.WriteLine(inconclusive.Message);
          if (inconclusive.CombinedException != null) {
            Trace.WriteLine(inconclusive.CombinedException.ToString());
          }
        }
    }
}
