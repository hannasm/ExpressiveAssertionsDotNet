using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.ExpressionEvaluator
{
    public interface IExpressionEvaluator
    {
        void Eval(Expression<Action> target);
        void Eval<T>(Expression<Action<T>> target, T val1);
        void Eval<T1,T2>(Expression<Action<T1,T2>> target, T1 val1, T2 val2);
        void Eval<T1, T2, T3>(Expression<Action<T1, T2, T3>> target, T1 val1, T2 val2, T3 val3);
        T Eval<T>(Expression<Func<T>> target);
        T2 Eval<T1, T2>(Expression<Func<T1, T2>> target, T1 val1);
        T3 Eval<T1, T2, T3>(Expression<Func<T1, T2, T3>> target, T1 val1, T2 val2);
    }
}
