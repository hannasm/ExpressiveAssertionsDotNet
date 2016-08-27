using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static partial class ComparisonAssertions
    {
        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => object.Equals(a, b));
        }
        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual, string msg)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => object.Equals(a, b), null, msg, fmt);
        }

        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => !object.Equals(a, b));
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual, string msg)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => !object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, Expression<Func<T>> actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(expected, actual, (a, b) => !object.Equals(a, b), null, msg, fmt);
        }

        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual)
        {
            tool.Check(expected, actual, (a, b) => object.ReferenceEquals(a, b));
        }
        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => object.ReferenceEquals(a, b), null, msg, fmt);
        }

        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual)
        {
            tool.Check(expected, actual, (a, b) => !object.ReferenceEquals(a,b));
        }
        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => !object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => !object.ReferenceEquals(a, b), null, msg, fmt);
        }


        public static void AreEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual)
            where T : class
        {
            tool.Check(() => expected, actual, (a, b) => object.Equals(a,b));
        }
        public static void AreEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual, string msg)
            where T : class
        {
            tool.Check(() => expected, actual, (a, b) => object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(()=>expected, actual, (a, b) => object.Equals(a, b), null, msg, fmt);
        }

        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual)
            where T : class
        {
            tool.Check(() => expected, actual, (a, b) => !object.Equals(a, b));
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual, string msg)
            where T : class
        {
            tool.Check(() => expected, actual, (a, b) => !object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, Expression<Func<T>> actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(() => expected, actual, (a, b) => a != b, null, msg, fmt);
        }

        public static void AreSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual)
        {
            tool.Check(() => expected, actual, (a, b) => object.ReferenceEquals(a, b));
        }
        public static void AreSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(() => expected, actual, (a, b) => object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(() => expected, actual, (a, b) => object.ReferenceEquals(a, b), null, msg, fmt);
        }

        public static void AreNotSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual)
        {
            tool.Check(() => expected, actual, (a, b) => !object.ReferenceEquals(a, b));
        }
        public static void AreNotSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(() => expected, actual, (a, b) => !object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreNotSame(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(() => expected, actual, (a, b) => !object.ReferenceEquals(a, b), null, msg, fmt);
        }


        public static void AreEqual<T>(this IAssertionTool tool, T expected, T actual)
            where T : class
        {
            tool.Check(()=>expected, () => actual, (a, b) => object.Equals(a, b));
        }
        public static void AreEqual<T>(this IAssertionTool tool, T expected, T actual, string msg)
            where T : class
        {
            tool.Check(() => expected, () => actual, (a, b) => object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreEqual<T>(this IAssertionTool tool, T expected, T actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(() => expected, () => actual, (a, b) => object.Equals(a, b), null, msg, fmt);
        }

        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, T actual)
            where T : class
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.Equals(a, b));
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, T actual, string msg)
            where T : class
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, T expected, T actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.Equals(a, b), null, msg, fmt);
        }

        public static void AreSame(this IAssertionTool tool, object expected, object actual)
        {
            tool.Check(() => expected, () => actual, (a, b) => object.ReferenceEquals(a, b));
        }
        public static void AreSame(this IAssertionTool tool, object expected, object actual, string msg)
        {
            tool.Check(() => expected, () => actual, (a, b) => object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreSame(this IAssertionTool tool, object expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(() => expected, () => actual, (a, b) => object.ReferenceEquals(a, b), null, msg, fmt);
        }

        public static void AreNotSame(this IAssertionTool tool, object expected, object actual)
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.ReferenceEquals(a, b));
        }
        public static void AreNotSame(this IAssertionTool tool, object expected, object actual, string msg)
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreNotSame(this IAssertionTool tool, object expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(() => expected, () => actual, (a, b) => !object.ReferenceEquals(a, b), null, msg, fmt);
        }

        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => object.Equals(a, b));
        }
        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual, string msg)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => object.Equals(a, b), null, msg, fmt);
        }

        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => !object.Equals(a, b));
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual, string msg)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => !object.Equals(a, b), null, "{0}", msg);
        }
        public static void AreNotEqual<T>(this IAssertionTool tool, Expression<Func<T>> expected, T actual, string msg, params object[] fmt)
            where T : class
        {
            tool.Check(expected, () => actual, (a, b) => !object.Equals(a, b), null, msg, fmt);
        }

        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual)
        {
            tool.Check(expected, () => actual, (a, b) => object.ReferenceEquals(a, b));
        }
        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg)
        {
            tool.Check(expected, () => actual, (a, b) => object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(expected, () => actual, (a, b) => object.ReferenceEquals(a, b), null, msg, fmt);
        }

        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual)
        {
            tool.Check(expected, () => actual, (a, b) => !object.ReferenceEquals(a, b));
        }
        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg)
        {
            tool.Check(expected, () => actual, (a, b) => !object.ReferenceEquals(a, b), null, "{0}", msg);
        }
        public static void AreNotSame(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => !object.ReferenceEquals(a, b), null, msg, fmt);
        }
    }
}
