using ExpressiveAssertions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Tooling
{
    public class SoftAssertionTool : IAssertionTool
    {
        public SoftAssertionTool(IAssertionTool parent)
        {
            var ctx = parent.ContextGet();
            this.ContextSet(ctx);
        }
        List<AssertionData> _memory = new List<AssertionData>();
        int failureCount = 0;
        int successCount = 0;
        int inconclusiveCount = 0;

        public int FailureCount { get { return failureCount; } }
        public int SuccessCount { get { return successCount; } }
        public int InconclusiveCount { get { return inconclusiveCount; } }
        public int Count { get { return _memory.Count; } }

        public void Accept(DeclaredFailure failure)
        {
            _memory.Add(failure);
            failureCount++;
        }

        public void Accept(DeclaredInconclusive inconclusive)
        {
            _memory.Add(inconclusive);
            inconclusiveCount++;
        }

        public void Accept(AssertionSuccess assertionSuccess)
        {
            _memory.Add(assertionSuccess);
            successCount++;
        }

        public void Accept(AssertionFailure failure)
        {
            _memory.Add(failure);
            failureCount++;
        }

        public void Reset()
        {
            _memory.Clear();
            failureCount = 0;
            successCount = 0;
            inconclusiveCount = 0;
        }

        public void ReplayAll(IAssertionTool tool, string msg, params object[] fmt)
        {
            this.ReplayWhere(tool, (x,i)=>true, msg, fmt);
        }

        public void ReplayWhere(IAssertionTool tool, Func<AssertionData, bool> condition, string msg, params object[] fmt)
        {
            this.ReplayWhere(tool, (x, i) => condition(x), msg, fmt);
        }

        public void ReplayWhere(IAssertionTool tool, Func<AssertionData,int, bool> condition, string msg, params object[] fmt)
        {
            List<Exception> errors = new List<Exception>();
            foreach (var d in _memory.Where(condition))
            {
                try
                {
                    d.Visit(tool);
                }
                catch (Exception eError)
                {
                    errors.Add(eError);
                }
            }

            if (errors.Any())
            {
                tool.Accept(new AssertionFailure(
                    null, null, null, null, null,
                    msg, fmt, new AggregateException("One or more errors ocurred while replaying assertion set", errors), null,
                    tool.ContextGetData()));
            }
        }
    }
}
