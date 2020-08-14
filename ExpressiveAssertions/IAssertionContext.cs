using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public interface IAssertionContext
    {
        IDisposable Push();
        void Pop();

        IEnumerable<ContextItem> GetData();
        ContextItem GetData(string key);
        void Set(string key, string value);
    }
}
