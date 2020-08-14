using System.Text;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Rendering {
  public class StringLiteralRenderer : IObjectRenderer
  {
    public static void RenderChar(char c, StringBuilder literal) {
      switch (c) {
        case '\'': literal.Append(@"\'"); break;
        case '\"': literal.Append("\\\""); break;
        case '\\': literal.Append(@"\\"); break;
        case '\0': literal.Append(@"\0"); break;
        case '\a': literal.Append(@"\a"); break;
        case '\b': literal.Append(@"\b"); break;
        case '\f': literal.Append(@"\f"); break;
        case '\n': literal.Append(@"\n"); break;
        case '\r': literal.Append(@"\r"); break;
        case '\t': literal.Append(@"\t"); break;
        case '\v': literal.Append(@"\v"); break;
        default:
                   // ASCII printable character
                   if (c >= 0x20 && c <= 0x7e) {
                     literal.Append(c);
                     // As UTF16 escaped character
                   } else {
                     literal.Append(@"\u");
                     literal.Append(((int)c).ToString("x4"));
                   }
                   break;
      }
    }
    public static string RenderString(string input) {
      if (input == null) { return "~null~"; }

    	StringBuilder literal = new StringBuilder(input.Length + 2);
			literal.Append("\"");
			foreach (var c in input) {
        RenderChar(c, literal);
			}
			literal.Append("\"");
			return literal.ToString();
    }

		public object Render(ObjectRenderingRequest req) {
			return new AnnotatedFormattable(RenderString(req?.RenderTarget?.ToString()));
		}

        public void RestoreState(ObjectRenderingContext context, object state)
        {
        }

        public object SaveState(ObjectRenderingContext context)
        {
            return null;
        }
  }
  public class StringRenderer : IObjectRenderer
  {
    public object Render(ObjectRenderingRequest req)
    {
      if (!(req?.RenderTarget is string)) { return req.RenderTarget; }
      var result = StringLiteralRenderer.RenderString(req?.RenderTarget?.ToString());
      return new AnnotatedFormattable(result, null, "[string]", null);
    }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
        }

        public object SaveState(ObjectRenderingContext context)
        {
            return null;
        }
  }
  public class CharRenderer : IObjectRenderer
  {
    public object Render(ObjectRenderingRequest req)
    {
      if (!(req?.RenderTarget is char)) { return req.RenderTarget; }
      var c = (char)req.RenderTarget;
      var sb = new StringBuilder(16);
      StringLiteralRenderer.RenderChar(c, sb);
      return new AnnotatedFormattable(sb.ToString(), null, "[char]", null);
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
