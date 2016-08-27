using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class SortedCollectionAssertions
    {
        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, ()=>expected, () => actual, action, null, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, () => expected, () => actual, action, null, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, () => expected, () => actual, action, msg, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, () => expected, () => actual, action, msg, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, () => expected, () => actual, action, msg, fmt);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, () => expected, () => actual, action, msg, fmt);
        }
        
        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, () => expected, actual, action, null, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, () => expected, actual, action, null, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, () => expected, actual, action, msg, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, () => expected, actual, action, msg, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, () => expected, actual, action, msg, fmt);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, () => expected, actual, action, msg, fmt);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, expected, () => actual, action, null, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, expected, () => actual, action, null, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, expected, () => actual, action, msg, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, expected, () => actual, action, msg, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, expected, () => actual, action, msg, fmt);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, expected, () => actual, action, msg, fmt);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, expected, actual, action, null, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachSorted(assertTool, expectedExp, actualExp, action, null, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, expected, actual, action, msg, null);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachSorted(assertTool, expectedExp, actualExp, action, msg, null);
        }

        public static void EverySorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachSorted(assertTool, expected, actual, action, msg, fmt);
        }
        public static void EachSorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                msg = string.Empty;
                fmt = fmt ?? new object[] { };
            }
            else if (fmt == null)
            {
                fmt = new object[] { msg };
                msg = "{0}";
            }

            var evaluator = assertTool.GetExpressionEvaluator();
            var context = assertTool.GetAssertionContext();

            var expected = evaluator.Eval(expectedExp);
            var actual = evaluator.Eval(actualExp);

            using (var eenum = expected.GetEnumerator())
            using (var aenum = actual.GetEnumerator())
            {
                int i;
                bool enext=false, anext = false;
                using (context.Push())
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        context.Set("Message", string.Format(msg, fmt));
                    }

                    for (i = 0; (enext = eenum.MoveNext()) && (anext = aenum.MoveNext()); i++)
                    {
                        context.Set("Element Index", i.ToString());

                        evaluator.Eval(action, assertTool, eenum.Current, aenum.Current);
                    }
                }
                if (enext != anext)
                {
                    int c = i;
                    if (enext)
                    {
                        while (eenum.MoveNext()) { c++; }
                        assertTool.AreEqual(c, i, "Element Count Doesn't Match. " + msg, fmt);
                    }
                    else
                    {
                        while (aenum.MoveNext()) { c++; }
                        assertTool.AreEqual(i, c, "Element Count Doesn't Match. " + msg, fmt);
                    }
                }
            }
        }
    }
}
