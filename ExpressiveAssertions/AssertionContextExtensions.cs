using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class AssertionContextExtensions
    {
        public static IDisposable ContextPush(this IAssertionTool assert)
        {
            return assert.GetAssertionContext().Push();
        }
        public static IAssertionTool ContextSet(this IAssertionTool assert, string key, string value)
        {
            assert.GetAssertionContext().Set(key, value);
            return assert;
        }

        static ConditionalWeakTable<IAssertionTool, IAssertionContext> _CONTEXT = new ConditionalWeakTable<IAssertionTool, IAssertionContext>();
        public static IAssertionContext GetAssertionContext(this IAssertionTool assertTool)
        {
            IAssertionContext result;
            if (!_CONTEXT.TryGetValue(assertTool, out result))
            {
                _CONTEXT.Add(assertTool, result = new AssertionContext());
            }
            return result;
        }
        public static IAssertionTool SetAssertionContext(this IAssertionTool assertTool, IAssertionContext ctx)
        {
            IAssertionContext tmp;
            if (_CONTEXT.TryGetValue(assertTool, out tmp))
            {
                _CONTEXT.Remove(assertTool);
            }
            _CONTEXT.Add(assertTool, ctx);
            return assertTool;
        }
        public static IEnumerable<KeyValuePair<string, string>> GetContextData(this IAssertionTool assertTool) { return GetAssertionContext(assertTool).GetData(); }

    }
}
