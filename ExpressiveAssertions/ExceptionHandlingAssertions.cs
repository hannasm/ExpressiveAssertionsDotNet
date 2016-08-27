using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class ExceptionHandlingAssertions
    {
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Action> test)
        {
            assertTool.Throws<T>(test, null, null, null);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Action> test, string message)
        {
            assertTool.Throws<T>(test, null, "{0}", message);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Action> test, string message, params object[] fmt)
        {
            assertTool.Throws<T>(test, null, message, fmt);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Action> test, Exception exc, string message, params object[] fmt)
        {
            if (fmt == null) { fmt = new object[] { }; }
            if (fmt.Length <= 0)
            {
                fmt = new object[] { message };
                message = "{0}";
            }

            Exception internalError = null;
            try
            {
                assertTool.GetExpressionEvaluator().Eval(test);
            }
            catch (Exception eError)
            {
                internalError = eError;
            }

            if (internalError is T)
            {
                assertTool.Accept(new AssertionSuccess(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
            else
            {
                assertTool.Accept(new AssertionFailure(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
        }

        public static void Throws<T>(this IAssertionTool assertTool, Expression<Func<object>> test)
        {
            assertTool.Throws<T>(test, null, null, null);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Func<object>> test, string message)
        {
            assertTool.Throws<T>(test, null, "{0}", message);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Func<object>> test, string message, params object[] fmt)
        {
            assertTool.Throws<T>(test, null, message, fmt);
        }
        public static void Throws<T>(this IAssertionTool assertTool, Expression<Func<object>> test, Exception exc, string message, params object[] fmt)
        {
            if (fmt == null) { fmt = new object[] { }; }
            if (fmt.Length <= 0)
            {
                fmt = new object[] { message };
                message = "{0}";
            }
            
            Exception internalError = null;
            try
            {
                assertTool.GetExpressionEvaluator().Eval(test);
            }
            catch (Exception eError)
            {
                internalError = eError;
            }

            if (internalError is T)
            {
                assertTool.Accept(new AssertionSuccess(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
            else
            {
                assertTool.Accept(new AssertionFailure(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
        }
    }
}
