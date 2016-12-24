using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.ExpressionEvaluator
{
    public static class ExpressionEvaluatorExtensions
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
    }
}
