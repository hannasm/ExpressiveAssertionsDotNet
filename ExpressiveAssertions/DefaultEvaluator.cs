using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class DefaultEvaluator : IExpressionEvaluator
    {
        public void Eval(Expression<Action> target)
        {
            target.Compile()();
        }

        public T Eval<T>(Expression<Func<T>> target)
        {
            return target.Compile()();
        }

        public void Eval<T>(Expression<Action<T>> target, T val1)
        {
            target.Compile()(val1);
        }

        public T2 Eval<T1, T2>(Expression<Func<T1, T2>> target, T1 val)
        {
            return target.Compile()(val);
        }

        public void Eval<T1, T2>(Expression<Action<T1, T2>> target, T1 val1, T2 val2)
        {
            target.Compile()(val1, val2);
        }

        public T3 Eval<T1, T2, T3>(Expression<Func<T1, T2, T3>> target, T1 val1, T2 val2)
        {
            return target.Compile()(val1, val2);
        }

        public void Eval<T1, T2, T3>(Expression<Action<T1, T2, T3>> target, T1 val1, T2 val2, T3 val3)
        {
            target.Compile()(val1, val2, val3);
        }
    }
}
