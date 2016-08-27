using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class TrueFalseAssertions
    {
        public static void IsTrue(this IAssertionTool assertTool, Expression<Func<bool>> test)
        {
            assertTool.Check(test);
        }
        public static void IsTrue(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg)
        {
            assertTool.Check(test,msg);
        }
        public static void IsTrue(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg, params object[] fmt)
        {
            assertTool.Check(test, msg, fmt);
        }
        public static void IsFalse(this IAssertionTool assertTool, Expression<Func<bool>> test)
        {
            test = Expression.Lambda<Func<bool>>(Expression.Not(test.Body));

            assertTool.Check(test);
        }
        public static void IsFalse(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg)
        {
            test = Expression.Lambda<Func<bool>>(Expression.Not(test.Body));

            assertTool.Check(test, msg);
        }
        public static void IsFalse(this IAssertionTool assertTool, Expression<Func<bool>> test, string msg, params object[] fmt)
        {
            test = Expression.Lambda<Func<bool>>(Expression.Not(test.Body));

            assertTool.Check(test, msg, fmt);
        }
    }
}
