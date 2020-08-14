using ExpressiveAssertions.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace ExpressiveAssertions.Rendering
{
    public class AnnotationDataRenderer : IObjectRenderer
    {
        static object RenderObject(AssertionData data, object obj, IObjectRenderer renderer) {
          var req = new ObjectRenderingRequest(data, renderer, obj);

          // we pretty much are only doing this to clear out the cycle detector betweeen rendering different components
          var state = renderer.SaveState(req);
          try {
            return renderer.Render(req);
          } finally {
              renderer.RestoreState(req, state);
          }
        }

        public sealed class UnknownType {}

        public object Render(ObjectRenderingRequest req)
        {
            var data = req?.RenderTarget as AssertionData;
            if (data == null) { return req?.RenderTarget; }

            var objectRenderer = req.Renderer;

            var s = new StringBuilder();

            if (data.Assertion != null)
            {
                s.AppendLine();
                s.Append(data.GetType().Name);
                s.Append(' ');
                s.Append(RenderObject(data, data.Assertion, objectRenderer));

                string prefix = Environment.NewLine + " with ";
                var mappings = data.DataMappings.ToArray();
                foreach (var @ref in mappings)
                {
                    var type = @ref.Value?.GetType() ?? typeof(UnknownType) ;
                    s.Append(prefix);
                    s.Append(RenderObject(data, Expression.Parameter(type, @ref.Key.Name), objectRenderer));
                    s.Append(" = ");
                    s.Append(RenderObject(data, @ref.Value, objectRenderer));
                    prefix = Environment.NewLine +  " and ";
                }

                s.Append(".");
            }

            if (!string.IsNullOrWhiteSpace(data.FormatMessage))
            {
                s.AppendLine();
                s.Append(" Message: ");
                s.AppendFormat(data.FormatMessage, data.FormatArgs.Select(f=>RenderObject(data, f, objectRenderer)).ToArray());
            }

            if (data.ContextData != null)
            {
                string prefix =  Environment.NewLine + " With context data ";

                foreach (var d in data.ContextData)
                {
                    s.Append(prefix);
                    s.AppendFormat("[Depth={0}] ", d.Depth);
                    s.Append(d.Key);
                    s.Append(" = ");
                    s.Append(RenderObject(data, d.Value, objectRenderer));
                    s.Append(".");

                    prefix = Environment.NewLine +  " And context data ";
                }
            }

            if (data.CombinedException != null)
            {
                s.AppendLine();
                s.Append(" One or more exceptions were included. ");
                s.Append(RenderObject(data, data.CombinedException, objectRenderer));
            }

            s.AppendLine();
            
            return new AnnotatedFormattable(s.ToString());
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
