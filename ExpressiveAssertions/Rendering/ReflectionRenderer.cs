using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ExpressionToCodeLib;
using ExpressiveReflection;

namespace ExpressiveAssertions.Rendering{
    public class ReflectionRenderer : IObjectRenderer
    {
        public object Render(ObjectRenderingRequest req)
        {
            if (req?.RenderTarget is AnnotatedFormattable) {
                return req?.RenderTarget;
            }

            var target = req.RenderTarget;
            var members = target.GetType().GetMembers().Where(m=>m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);
            var result = new StringBuilder();

            result.Append("[");
            result.Append(ObjectToCode.ToCSharpFriendlyTypeName(target.GetType()));
            result.Append("]@{");

            foreach (var member in members) {
                result.Append('"');
                result.Append(member.Name);
                result.Append('"');
                result.Append('=');
                
                var value = Reflection.GetValue(member, target);
                var req2 = req.NewTarget(value);
                result.Append(req2.Render());
                result.Append(';');
            }
            result.Append("}");

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