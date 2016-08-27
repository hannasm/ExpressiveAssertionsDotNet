using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class BaseAssertions
    {
        static ConditionalWeakTable<IAssertionTool, IExpressionEvaluator> _EVALUATORS = new ConditionalWeakTable<IAssertionTool, IExpressionEvaluator>();
        public static IExpressionEvaluator GetExpressionEvaluator(this IAssertionTool assertTool)
        {
            IExpressionEvaluator result;
            if (!_EVALUATORS.TryGetValue(assertTool, out result))
            {
                _EVALUATORS.Add(assertTool, result = new DefaultEvaluator());
            }
            return result;
        }
        public static IAssertionTool SetExpressionEvaluator(this IAssertionTool assertTool, IExpressionEvaluator eval)
        {
            IExpressionEvaluator tmp;
            if (_EVALUATORS.TryGetValue(assertTool, out tmp))
            {
                _EVALUATORS.Remove(assertTool);
            }
            _EVALUATORS.Add(assertTool, eval);
            return assertTool;
        }
        public static void Check(this IAssertionTool assertTool, Expression<Func<bool>> test)
        {
            assertTool.Check(test, null, null, null);
        }
        public static void Check(this IAssertionTool assertTool, Expression<Func<bool>> test, Exception exc)
        {
            assertTool.Check(test, exc, null);
        }
        public static void Check(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg)
        {
            assertTool.Check(test, null, "{0}", msg);
        }
        public static void Check(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg, params object[] fmt)
        {
            assertTool.Check(test, null, msg, fmt);
        }
        public static void Check(this IAssertionTool assertTool, Expression<Func<bool>> test, Exception exc, string message, params object[] fmt)
        {
            if (fmt == null) { fmt = new object[] { }; }
            if (fmt.Length <= 0)
            {
                fmt = new object[] { message };
                message = "{0}";
            }

            bool result = false;
            Exception internalError = null;
            try
            {
                result = assertTool.GetExpressionEvaluator().Eval(test);
            }
            catch (Exception eError)
            {
                internalError = eError;
            }

            if (!result)
            {
                assertTool.Accept(new AssertionFailure(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
            else
            {
                assertTool.Accept(new AssertionSuccess(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
        }

        public static void Check<T1, T2>(this IAssertionTool assertTool, Expression<Func<T1>> expected1, Expression<Func<T2>> actual1, Expression<Func<T1, T2, bool>> test)
        {
            assertTool.Check(expected1, actual1, test, null, null, null);
        }
        public static void Check<T1, T2>(this IAssertionTool assertTool, Expression<Func<T1>> expected1, Expression<Func<T2>> actual1, Expression<Func<T1, T2, bool>> test, Exception exc)
        {
            assertTool.Check(expected1, actual1, test, exc, null, null);
        }
        public static void Check<T1, T2>(this IAssertionTool assertTool, Expression<Func<T1>> expected1, Expression<Func<T2>> actual1, Expression<Func<T1, T2, bool>> test, string msg)
        {
            assertTool.Check(expected1, actual1, test, null, "{0}", msg);
        }
        public static void Check<T1, T2>(this IAssertionTool assertTool, Expression<Func<T1>> expected1, Expression<Func<T2>> actual1, Expression<Func<T1, T2, bool>> test, string msg, params object[] fmt)
        {
            assertTool.Check(expected1, actual1, test, null, msg, fmt);
        }
        public static void Check<T1,T2>(this IAssertionTool assertTool, Expression<Func<T1>> expected1, Expression<Func<T2>> actual1, Expression<Func<T1, T2, bool>> test, Exception exc, string message, params object[] fmt)
        {
            if (fmt == null) { fmt = new object[] { }; }
            if (fmt.Length <= 0)
            {
                fmt = new object[] { message };
                message = "{0}";
            }

            bool result = false;
            Exception internalError = null;
            object[] actualVals = null;
            object[] expectedVals = null;
            ParameterExpression[] expectedRefs = null;
            ParameterExpression[] actualRefs = null;

            try
            {
                var expectedVal = assertTool.GetExpressionEvaluator().Eval(expected1);
                var actualVal = assertTool.GetExpressionEvaluator().Eval(actual1);
                result = assertTool.GetExpressionEvaluator().Eval(test, expectedVal, actualVal);

                expectedVals = new object[] { expectedVal };
                expectedRefs = new[] { test.Parameters[0] };

                actualVals = new object[] { actualVal };
                actualRefs = new[] { test.Parameters[1] };
            }
            catch (Exception eInternal)
            {
                internalError = eInternal;
            }

            if (!result)
            {
                assertTool.Accept(new AssertionFailure(test.Body, expectedRefs, expectedVals, actualRefs, actualVals, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
            else
            {
                assertTool.Accept(new AssertionSuccess(test.Body, expectedRefs, expectedVals, actualRefs, actualVals, message, fmt, exc, internalError, assertTool.GetContextData()));
            }
        }
    }
}
