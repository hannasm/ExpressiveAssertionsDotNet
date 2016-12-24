using ExpressiveAssertions.ExpressionEvaluator;
using ExpressiveAssertions.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class UnsortedCollectionAssertions
    {
        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, ()=>expected, () => actual, action, null, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, () => expected, () => actual, action, null, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, () => expected, () => actual, action, msg, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, () => expected, () => actual, action, msg, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, () => expected, () => actual, action, msg, fmt);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, () => expected, () => actual, action, msg, fmt);
        }
        
        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, () => expected, actual, action, null, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, () => expected, actual, action, null, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, () => expected, actual, action, msg, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, () => expected, actual, action, msg, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, () => expected, actual, action, msg, fmt);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, IEnumerable<T> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, () => expected, actual, action, msg, fmt);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, expected, () => actual, action, null, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, expected, () => actual, action, null, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, expected, () => actual, action, msg, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, expected, () => actual, action, msg, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, expected, () => actual, action, msg, fmt);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, IEnumerable<T> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, expected, () => actual, action, msg, fmt);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, expected, actual, action, null, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action)
        {
            EachUnsorted(assertTool, expectedExp, actualExp, action, null, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, expected, actual, action, msg, null);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action, string msg)
        {
            EachUnsorted(assertTool, expectedExp, actualExp, action, msg, null);
        }

        public static void EveryUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expected, Expression<Func<IEnumerable<T>>> actual, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
        {
            EachUnsorted(assertTool, expected, actual, action, msg, fmt);
        }
        public static void EachUnsorted<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> expectedExp, Expression<Func<IEnumerable<T>>> actualExp, Expression<Action<IAssertionTool, T, T>> action, string msg, params object[] fmt)
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
            var context = assertTool.ContextGet();

            var expected = new Queue<T>(evaluator.Eval(expectedExp));
            var actual = evaluator.Eval(actualExp).ToList();

            var innerTool = new SoftAssertionTool(assertTool);
            int expectedIndex = 0;
            int lastValidElement = -1;
            using (context.Push())
            {
                while (expected.Any())
                {
                    var eCurrent = expected.Dequeue();
                    context.Set("Expected Index", expectedIndex++.ToString());

                    innerTool.Reset();

                    int i, n;
                    for (i = 0, n = actual.Count; i < n; i++)
                    {
                        int errors = innerTool.FailureCount;
                        int inconclusive = innerTool.InconclusiveCount;
                        int count = innerTool.Count;

                        context.Set("Actual Index", i.ToString());

                        evaluator.Eval(action, innerTool, eCurrent, actual[i]);

                        if (innerTool.FailureCount == errors &&
                            innerTool.InconclusiveCount == inconclusive)
                        {
                            innerTool.ReplayWhere(assertTool, (d,eidx) => eidx >= count, "If this assert fails it is an internal error in the assertion libray");
                            actual.RemoveAt(i);
                            lastValidElement = expectedIndex;
                            break;
                        }
                    }

                    if (i >= n && n > 0)
                    {
                        innerTool.ReplayAll(assertTool, "No matching element found");

                        throw new InvalidOperationException("We should have thrown an assertion failure error in the prior call");
                    }
                }
            }
            
            if (lastValidElement != expectedIndex)
            {
                assertTool.AreEqual(expectedIndex, actual.Count, "Element count mismatch");
                throw new InvalidOperationException("We should have thrown an assertion failure error in the prior call (2)");
            }
        }
    }
}
