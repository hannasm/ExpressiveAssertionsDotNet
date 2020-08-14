using System;
using System.Linq.Expressions;
using ExpressiveExpressionTrees;

namespace ExpressiveAssertions.ExpressionEvaluator
{
    public class DateTimeNormalizationEvaluator : IExpressionEvaluator
    {
        IExpressionEvaluator _parent;

        public DateTimeNormalizationEvaluator(IExpressionEvaluator parent) {
          _parent = parent;
        }

        public static DateTime NormalizeDateTime(DateTime dateTime) {
          return NormalizeDateTime((DateTime?)dateTime).Value;
        }

        public static DateTime? NormalizeDateTime(DateTime? dateTime) {
          if (!dateTime.HasValue) { return null; }
          
          var offset = dateTime.Value.Ticks % TimeSpan.TicksPerMillisecond;
          if (offset != 0) {
            return new DateTime(dateTime.Value.Ticks - offset);
          }
          return dateTime;
        }

        public class DateNormalizer : ExpressiveExpressionTrees.ExpressionVisitor {
          ExpressionGenerator _xgr = new ExpressionGenerator();

          protected override Expression Visit(Expression node) {
            var exp = base.Visit(node);

            if (exp == null) {return null;}
            if (exp.Type == typeof(DateTime)) {
              exp = _xgr.WithoutType(_xgr.FromFunc(
                _xgr.WithType<DateTime>(exp),
                d=>NormalizeDateTime(d)
              ));
            } else if (exp.Type == typeof(DateTime?)) {
              exp = _xgr.WithoutType(_xgr.FromFunc(
                _xgr.WithType<DateTime?>(exp),
                d=>NormalizeDateTime(d)
              ));
            } 

            return exp;
          }

          public static Expression<T> Normalize<T>(Expression<T> exp) {
            var visitor = new DateNormalizer();

            return (Expression<T>)visitor.Visit(exp);
          }
        }
        public void Eval(Expression<Action> target)
        {
          _parent.Eval(DateNormalizer.Normalize(target));
        }

        public T Eval<T>(Expression<Func<T>> target)
        {
          return _parent.Eval(DateNormalizer.Normalize(target));
        }

        public void Eval<T>(Expression<Action<T>> target, T val1)
        {
          _parent.Eval(DateNormalizer.Normalize(target), val1);
        }

        public T2 Eval<T1, T2>(Expression<Func<T1, T2>> target, T1 val)
        {
          return _parent.Eval(DateNormalizer.Normalize(target), val);
        }

        public void Eval<T1, T2>(Expression<Action<T1, T2>> target, T1 val1, T2 val2)
        {
          _parent.Eval(DateNormalizer.Normalize(target), val1, val2);
        }

        public T3 Eval<T1, T2, T3>(Expression<Func<T1, T2, T3>> target, T1 val1, T2 val2)
        {
          return _parent.Eval(DateNormalizer.Normalize(target), val1, val2);
        }

        public void Eval<T1, T2, T3>(Expression<Action<T1, T2, T3>> target, T1 val1, T2 val2, T3 val3)
        {
          _parent.Eval(DateNormalizer.Normalize(target), val1, val2, val3);
        }
    }
}
