using ExpressiveAssertions.Data;
using ExpressiveAssertions.ExpressionEvaluator;
using ExpressiveAssertions.Exceptions;
using System;
using System.Linq.Expressions;
using ExpressiveExpressionTrees;
namespace ExpressiveAssertions
{
    public static class BaseAssertions
    {
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
                assertTool.Accept(new AssertionFailure(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.ContextGetData()));
            }
            else
            {
                assertTool.Accept(new AssertionSuccess(test.Body, null, null, null, null, message, fmt, exc, internalError, assertTool.ContextGetData()));
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

            T1 expectedVal = default(T1); T2 actualVal = default(T2);
            EvaluatedExpressionException expectedException = null, actualException = null;

            // We are intentionally invokign the actual result first.
            // * This is very useful when you want the FilesystemAssertionRepository to automatically create expectations for your tests 
            try {
                actualVal = assertTool.GetExpressionEvaluator().Eval(actual1);
                actualVals = new object[] { actualVal };
                actualRefs = new[] { test.Parameters[1] };
            } catch (Exception eError) {
                actualException = new EvaluatedExpressionException(actual1, eError);
            }

            try {
                expectedVal = assertTool.GetExpressionEvaluator().Eval(expected1);
                expectedVals = new object[] { expectedVal };
                expectedRefs = new[] { test.Parameters[0] };
            } catch (Exception eError) {
                expectedException = new EvaluatedExpressionException(expected1, eError);
            }

            if (expectedException == null && actualException == null) {
              try {
                  result = assertTool.GetExpressionEvaluator().Eval(test, expectedVal, actualVal);
              } catch (Exception eError) {
                  internalError = new EvaluatedExpressionException(test, eError);
              }
            } else if (expectedException != null && actualException != null) {
              internalError = new AggregateException(expectedException, actualException);
            } else if (expectedException != null) {
              internalError = expectedException;
            } else if (actualException != null) {
              internalError = actualException;
            } else {
              throw new InvalidOperationException("This exception should be logically impossible to reach");
            }

            var finalExpression = Expression.Invoke(
                test,
                expected1.Body,
                actual1.Body
            );
            if (!result)
            {
                assertTool.Accept(new AssertionFailure(finalExpression, expectedRefs, expectedVals, actualRefs, actualVals, message, fmt, exc, internalError, assertTool.ContextGetData()));
            }
            else
            {
                assertTool.Accept(new AssertionSuccess(finalExpression, expectedRefs, expectedVals, actualRefs, actualVals, message, fmt, exc, internalError, assertTool.ContextGetData()));
            }
        }
    }
}
