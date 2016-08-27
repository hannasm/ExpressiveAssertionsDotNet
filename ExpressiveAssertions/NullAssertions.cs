using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class NullAssertions
    {
        public static void IsNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected == actual);
        }
        public static void IsNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test, string msg)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected == actual, msg);
        }
        public static void IsNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test, string msg, params object[] fmt)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected == actual, msg, fmt);
        }
        public static void IsNotNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected != actual);
        }
        public static void IsNotNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test, string msg)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected != actual, msg);
        }
        public static void IsNotNull<T>(this IAssertionTool assertTool, Expression<Func<T>> test, string msg, params object[] fmt)
            where T : class
        {
            assertTool.Check<T, T>(() => null, test, (expected, actual) => expected != actual, msg, fmt);
        }
    }
}
