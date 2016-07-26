using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class TypeAssertions
    {
        public static void IsInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr)
        {
            assert.Check(() => typeof(T), expr, (a, b) => a.IsAssignableFrom(b.GetType()));
        }
        public static void IsInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr, string msg)
        {
            assert.Check(() => typeof(T), expr, (a, b) => a.IsAssignableFrom(b.GetType()), null, "{0}", msg);
        }
        public static void IsInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr, string msg, params object[] args)
        {
            assert.Check(() => typeof(T), expr, (a, b) => a.IsAssignableFrom(b.GetType()), null, msg, args);
        }
        public static void IsNotInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr)
        {
            assert.Check(() => typeof(T), expr, (a, b) => !a.IsAssignableFrom(b.GetType()));
        }
        public static void IsNotInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr, string msg)
        {
            assert.Check(() => typeof(T), expr, (a, b) => !a.IsAssignableFrom(b.GetType()), null, "{0}", msg);
        }
        public static void IsNotInstanceOf<T>(this IAssertionTool assert, Expression<Func<object>> expr, string msg, params object[] args)
        {
            assert.Check(() => typeof(T), expr, (a, b) => !a.IsAssignableFrom(b.GetType()), null, msg, args);
        }
    }
}
