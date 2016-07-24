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
        public T Eval<T>(Expression<Func<T>> target)
        {
            return target.Compile()();
        }

        public T2 Eval<T1, T2>(Expression<Func<T1, T2>> target, T1 val)
        {
            return target.Compile()(val);
        }

        public T3 Eval<T1, T2, T3>(Expression<Func<T1, T2, T3>> target, T1 val1, T2 val2)
        {
            return target.Compile()(val1, val2);
        }
    }
}
