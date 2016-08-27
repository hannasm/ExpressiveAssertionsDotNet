using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Rendering
{
    public static class ShortAssertionRenderer
    {
        class ExpressionShortener : ExpressiveExpressionTrees.ExpressionVisitor {
            public ExpressionShortener(IEnumerable<string> names)
            {
                foreach (var name in names)
                {
                    _names.Add(name);
                }
            }
            public Expression Replace(Expression exp)
            {
                return this.Visit(exp);
            }

            HashSet<string> _names = new HashSet<string>();
            public List<object> Values = new List<object>();
            public List<ParameterExpression> Parameters = new List<ParameterExpression>();

            protected override Expression VisitMemberAccess(MemberExpression m)
            {
                var inner = (MemberExpression)base.VisitMemberAccess(m);

                var subject = inner.Expression as ParameterExpression;
                if (subject == null) { return inner; }

                var idx = Parameters.IndexOf(subject);
                if (idx < 0) { return inner; }

                var newName = subject.Name + "." + inner.Member.Name;
                ExpressiveReflection.MemberReflection mr = new ExpressiveReflection.MemberReflection();
                var newVal = mr.GetValue(m.Member, Values[idx]);

                var newParam = Expression.Parameter(m.Type, newName);
                Parameters[idx] = newParam;
                Values[idx] = newVal;

                return newParam;
            }

            protected override Expression VisitConstant(ConstantExpression c)
            {
                string typeName = TypeBasedParamterNameGenerator.GetName(c.Type, _names);

                var param = Expression.Parameter(c.Type, typeName);
                Parameters.Add(param);
                Values.Add(c.Value);

                return param;
            }
        }

        public static string Render(AssertionData data)
        {
            StringBuilder s = new StringBuilder();

            if (data.Assertion != null)
            {
                var replacer = new ExpressionShortener(data.ExpectedReference.Select(p => p.Name).Concat(data.ActualReference.Select(p => p.Name)));
                var exp = replacer.Replace(data.Assertion);


                s.Append("Asserting ");
                s.Append(ExpressionToCodeLib.ExpressionToCode.ToCode(exp));

                var refs = data.ExpectedReference.Zip(data.ExpectedData, (x, y) => new
                {
                    Parameter = x,
                    Value = y
                });
                refs = refs.Concat(data.ActualReference.Zip(data.ActualData, (x, y) => new
                {
                    Parameter = x,
                    Value = y
                }));
                refs = refs.Concat(replacer.Parameters.Zip(replacer.Values, (x, y) => new
                {
                    Parameter = x,
                    Value = y
                }));

                if (refs.Any())
                {
                    string prefix = " with '";
                    foreach (var @ref in refs)
                    {
                        s.Append(prefix);
                        s.Append(@ref.Parameter.Name);
                        s.Append("'= (");
                        s.Append(@ref.Value?.ToString() ?? "null");
                        s.Append(")");
                        prefix = " and '";
                    }
                    s.Append(".");
                }
            }

            if (!string.IsNullOrWhiteSpace(data.Message))
            {
                s.Append(" ");
                s.AppendFormat(data.Message, data.Format);
            }

            if (data.ContextData != null)
            {
                string prefix = " In the context having ";

                foreach (var d in data.ContextData)
                {
                    s.Append(prefix);
                    s.Append(d.Key);
                    s.Append("' with value '");
                    s.Append(d.Value);
                    s.Append("'.");

                    prefix = " ";
                }
            }

            if (data.CombinedException != null)
            {
                s.Append(" One or more exceptions were included.");
            }

            return s.ToString();
        }
    }
}
