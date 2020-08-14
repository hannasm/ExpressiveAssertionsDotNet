using System.Collections;
using System.Text;
using ExpressionToCodeLib;

namespace ExpressiveAssertions.Rendering {
    public class CollectionRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
            IEnumerable obj = req?.RenderTarget as IEnumerable;
            if (obj == null) { return req?.RenderTarget; }

            var prefix = "";
            var result = new StringBuilder();
            result.Append("[");
            result.Append(ObjectToCode.ToCSharpFriendlyTypeName(obj.GetType()));
            result.Append("]@(");
            foreach (var rec in obj) {
                var req2 = req.NewTarget(rec);
                result.Append(prefix);
                result.Append(req2.Render());
                prefix = ",";
            }
            result.Append(")");

            return new AnnotatedFormattable(result.ToString());
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