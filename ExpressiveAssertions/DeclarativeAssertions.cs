using ExpressiveAssertions.Data;
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
            tool.Accept(new AssertionDeclaredFailure("{0}", new object[] { "Test Failed" }, tool.ContextGetData()));
        }
        public static void Fail(this IAssertionTool tool, string msg)
        {
            tool.Accept(new AssertionDeclaredFailure("{0}", new object[] { msg }, tool.ContextGetData()));
        }
        public static void Fail(this IAssertionTool tool, string msg, params object[] fmt)
        {
            tool.Accept(new AssertionDeclaredFailure(msg, fmt, tool.ContextGetData()));
        }
        public static void Inconclusive(this IAssertionTool tool)
        {
            tool.Accept(new AssertionDeclaredInconclusive("{0}", new object[] { "Test Status Inconclusive" }, tool.ContextGetData()));
        }
        public static void Inconclusive(this IAssertionTool tool, string msg)
        {
            tool.Accept(new AssertionDeclaredInconclusive("{0}", new object[] { msg }, tool.ContextGetData()));
        }
        public static void Inconclusive(this IAssertionTool tool, string msg, params object[] fmt)
        {
            tool.Accept(new AssertionDeclaredInconclusive(msg, fmt, tool.ContextGetData()));
        }
    }
}
