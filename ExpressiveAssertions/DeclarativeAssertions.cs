using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class DeclarativeAssertions
    {
        public static void Fail(this IAssertionTool tool)
        {
            tool.Accept(new DeclaredFailure("{0}", new object[] { "Test Failed" }, null, null));
        }
        public static void Fail(this IAssertionTool tool, string msg)
        {
            tool.Accept(new DeclaredFailure("{0}", new object[] { msg }, null, null));
        }
        public static void Fail(this IAssertionTool tool, string msg, params object[] fmt)
        {
            tool.Accept(new DeclaredFailure(msg, fmt, null, null));
        }
        public static void Inconclusive(this IAssertionTool tool)
        {
            tool.Accept(new DeclaredInconclusive("{0}", new object[] { "Test Status Inconclusive" }, null, null));
        }
        public static void Inconclusive(this IAssertionTool tool, string msg)
        {
            tool.Accept(new DeclaredInconclusive("{0}", new object[] { msg }, null, null));
        }
        public static void Inconclusive(this IAssertionTool tool, string msg, params object[] fmt)
        {
            tool.Accept(new DeclaredInconclusive(msg, fmt, null, null));
        }
    }
}
