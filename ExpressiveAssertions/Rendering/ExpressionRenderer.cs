using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Rendering {
    public class RenderedExpression : AnnotatedFormattable {
      public RenderedExpression(Expression exp, string rendering) : base(rendering) { this.Expression = exp; }
      public string Rendering { get { return this.ToString(); } }
      public readonly Expression Expression;
    }
    public class ExpressionRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
          var exp = req?.RenderTarget as Expression;
          if (exp == null) { return req?.RenderTarget; }

          return new RenderedExpression(
              exp, 
              ExpressionToCodeLib.ExpressionToCode.ToCode((Expression)req.RenderTarget)
          );
        }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
        }

        public object SaveState(ObjectRenderingContext context)
        {
            return null;
        }
    }

    public class ExpressionValueMappingRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
          var exp = req?.RenderTarget as Expression;
          if (exp == null) { return req?.RenderTarget; }

          var data = req.Assertion;
          var replacer = new ExpressionShortener(data.DataMappings.Select(kvp=>kvp.Key.Name));
          exp = replacer.Replace(exp);
          foreach (var mapping in replacer.Parameters.Zip(replacer.Values, (p,v)=>new { p, v})) {
            data.DataMappings.Add(new KeyValuePair<ParameterExpression, object>(mapping.p, mapping.v));
          }
          return exp;
        }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
        }

        public object SaveState(ObjectRenderingContext context)
        {
            return null;
        }
    }
}
