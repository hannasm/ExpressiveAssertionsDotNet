using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Rendering 
{
    public class CyclePreventionRenderer : IObjectRenderer {
        public ConditionalWeakTable<AssertionData, HashSet<object>> _cycleDetector = new ConditionalWeakTable<AssertionData, HashSet<object>>();

        public object Render(ObjectRenderingRequest req)
        {
            var hash = _cycleDetector.GetOrCreateValue(req.Assertion);
            if (hash.Contains(req.RenderTarget)) {
                return new AnnotatedFormattable("~cycle detected~");
            } else {
                hash.Add(req.RenderTarget);
                return req.RenderTarget;
            }
        }

        public void RestoreState(ObjectRenderingContext context, object state)
        {
            _cycleDetector.AddOrUpdate(context.Assertion, (HashSet<object>)state);
        }

        public object SaveState(ObjectRenderingContext context)
        {
            var result = _cycleDetector.GetValue(context.Assertion, k=>new HashSet<object>());
            result = new HashSet<object>(result);
            return result;
        }
    }
}