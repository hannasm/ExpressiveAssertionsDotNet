using System.Collections.Generic;
using System.Linq.Expressions;
namespace ExpressiveAssertions.Rendering
{
  public class ExpressionShortener : ExpressiveExpressionTrees.ExpressionVisitor {
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
}
