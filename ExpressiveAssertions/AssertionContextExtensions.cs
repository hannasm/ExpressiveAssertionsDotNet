﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ExpressiveAssertions
{
    public static class AssertionContextExtensions
    {
        public static IDisposable ContextPush(this IAssertionTool assert)
        {
            return assert.ContextGet().Push();
        }
        public static IAssertionTool ContextSet(this IAssertionTool assert, string key, string value)
        {
            assert.ContextGet().Set(key, value);
            return assert;
        }

        static ConditionalWeakTable<IAssertionTool, IAssertionContext> _CONTEXT = new ConditionalWeakTable<IAssertionTool, IAssertionContext>();
        public static IAssertionContext ContextGet(this IAssertionTool assertTool)
        {
            IAssertionContext result;
            if (!_CONTEXT.TryGetValue(assertTool, out result))
            {
                _CONTEXT.Add(assertTool, result = new AssertionContext());
            }
            return result;
        }
        public static IAssertionTool ContextSet(this IAssertionTool assertTool, IAssertionContext ctx)
        {
            IAssertionContext tmp;
            if (_CONTEXT.TryGetValue(assertTool, out tmp))
            {
                _CONTEXT.Remove(assertTool);
            }
            _CONTEXT.Add(assertTool, ctx);
            return assertTool;
        }
        public static IEnumerable<ContextItem> ContextGetData(this IAssertionTool assertTool) { return ContextGet(assertTool).GetData(); }
        public static ContextItem ContextGetData(this IAssertionTool assertTool, string key) { 
          var ctx = ContextGet(assertTool);
          return ctx.GetData(key);
        }

    }
}
