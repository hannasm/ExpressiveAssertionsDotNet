using ExpressiveAssertions.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public class AssertionContext : IAssertionContext
    {
        Stack<HashSet<KeyValuePair<string, string>>> _data = new Stack<HashSet<KeyValuePair<string, string>>>();
        HashSet<Scope> _scopes = new HashSet<Scope>();
        Dictionary<HashSet<KeyValuePair<string, string>>, Scope> _scopeMap = new Dictionary<HashSet<KeyValuePair<string, string>>, Scope>();

        public AssertionContext()
        {
            Push();
        }

        class Scope : IDisposable
        {
            public Scope(AssertionContext parent, HashSet<KeyValuePair<string, string>> target)
            {
                _parent = parent;
                _target = target;
            }
            AssertionContext _parent;
            HashSet<KeyValuePair<string, string>> _target;
            public void Dispose()
            {
                if (!_parent._scopes.Contains(this)) { return; } // generate some sort of warning maybe?

                while (_parent._data.Peek() != _target)
                {
                    _parent.Pop();
                }

                _parent.Pop();
            }
        }
        class Comparer : IEqualityComparer<KeyValuePair<string, string>>, IComparer<KeyValuePair<string, string>>
        {
            public int Compare(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
            {
                return x.Key.CompareTo(y.Key);
            }

            public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
            {
                return x.Key.Equals(y.Key);
            }

            public int GetHashCode(KeyValuePair<string, string> obj)
            {
                return obj.Key.GetHashCode();
            }

            public static Comparer INSTANCE = new Comparer();
        }
        public IEnumerable<KeyValuePair<string, string>> GetData()
        {
            var result = new List<KeyValuePair<string, string>>();
            var cnt = _data.Count;
            foreach (var ele in _data.Select((e,i)=>new { e, i }))
            {
                foreach (var item in ele.e)
                {
                    result.Add(new KeyValuePair<string, string>("Depth " + (cnt - 1 - ele.i) + " - " + item.Key, item.Value));
                }
            }
            return result;
        }

        public void Pop()
        {
            if (_data.Count < 2)
            {
                throw new StateException("Currently at top level assertion context scope");
            }

            
            var data = _data.Pop();
            var scope = _scopeMap[data];
            _scopeMap.Remove(data);
            _scopes.Remove(scope);

            // we intentionally do not dispose the scope
            // disposing the scope calls this method and the only point of disposing the scope is to
            // get this method executed
        }

        public IDisposable Push()
        {
            var data = new HashSet<KeyValuePair<string, string>>(Comparer.INSTANCE);
            var scope = new Scope(this, data);

            _data.Push(data);
            _scopeMap.Add(data, scope);
            _scopes.Add(scope);

            return scope;
        }

        public void Set(string key, string value)
        {
            if (key == null) { throw new ArgumentNullException("key"); }

            var top = _data.Peek();
            var rec = new KeyValuePair<string, string>(key, value);

            if (top.Contains(rec)) { top.Remove(rec); }
            top.Add(rec);
        }
    }
}
