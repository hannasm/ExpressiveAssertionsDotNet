using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressiveAssertions
{
    public static partial class ComparisonAssertions
    {
		public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, Expression<Func<uint>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, uint expected, Expression<Func<uint>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<uint>> expected, uint actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, uint expected, uint actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, uint expected, uint actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, uint expected, uint actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, uint expected, uint actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, uint expected, uint actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, uint expected, uint actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, Expression<Func<int>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, int expected, Expression<Func<int>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<int>> expected, int actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, int expected, int actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, int expected, int actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, int expected, int actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, int expected, int actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, int expected, int actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, int expected, int actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, Expression<Func<ulong>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, ulong expected, Expression<Func<ulong>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ulong>> expected, ulong actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, ulong expected, ulong actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, ulong expected, ulong actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, ulong expected, ulong actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, ulong expected, ulong actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, ulong expected, ulong actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, ulong expected, ulong actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, Expression<Func<long>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, long expected, Expression<Func<long>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<long>> expected, long actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, long expected, long actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, long expected, long actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, long expected, long actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, long expected, long actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, long expected, long actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, long expected, long actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, Expression<Func<string>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, string expected, Expression<Func<string>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<string>> expected, string actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, string expected, string actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, string expected, string actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, string expected, string actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, string expected, string actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, string expected, string actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, string expected, string actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, Expression<Func<short>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, short expected, Expression<Func<short>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<short>> expected, short actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, short expected, short actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, short expected, short actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, short expected, short actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, short expected, short actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, short expected, short actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, short expected, short actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, Expression<Func<ushort>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, ushort expected, Expression<Func<ushort>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<ushort>> expected, ushort actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, ushort expected, ushort actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, ushort expected, ushort actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, ushort expected, ushort actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, ushort expected, ushort actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, ushort expected, ushort actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, ushort expected, ushort actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, Expression<Func<byte>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, byte expected, Expression<Func<byte>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<byte>> expected, byte actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, byte expected, byte actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, byte expected, byte actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, byte expected, byte actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, byte expected, byte actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, byte expected, byte actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, byte expected, byte actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, Expression<Func<sbyte>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, sbyte expected, Expression<Func<sbyte>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<sbyte>> expected, sbyte actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, sbyte expected, sbyte actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, sbyte expected, sbyte actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, sbyte expected, sbyte actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, sbyte expected, sbyte actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, sbyte expected, sbyte actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, sbyte expected, sbyte actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Expression<Func<Guid>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Guid expected, Expression<Func<Guid>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Guid>> expected, Guid actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, Guid expected, Guid actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Guid expected, Guid actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Guid expected, Guid actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Guid expected, Guid actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Guid expected, Guid actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Guid expected, Guid actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, Expression<Func<DateTime>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, DateTime expected, Expression<Func<DateTime>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<DateTime>> expected, DateTime actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, DateTime expected, DateTime actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, DateTime expected, DateTime actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, DateTime expected, DateTime actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, DateTime expected, DateTime actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, DateTime expected, DateTime actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, DateTime expected, DateTime actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, Expression<Func<TimeSpan>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, Expression<Func<TimeSpan>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<TimeSpan>> expected, TimeSpan actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, TimeSpan expected, TimeSpan actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual)
        {
            tool.Check(expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual)
        {
            tool.Check(expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, object expected, Expression<Func<object>> actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a != b, null, msg, fmt);
        }
		
		public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(expected,()=> actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<object>> expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }

		public static void AreEqual(this IAssertionTool tool, object expected, object actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b);
        }
        public static void AreEqual(this IAssertionTool tool, object expected, object actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, object expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a == b, null, msg, fmt);
        }

		public static void AreNotEqual(this IAssertionTool tool, object expected, object actual)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b);
        }
        public static void AreNotEqual(this IAssertionTool tool, object expected, object actual, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, "{0}", msg);
        }
        public static void AreNotEqual(this IAssertionTool tool, object expected, object actual, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a != b, null, msg, fmt);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, Expression<Func<decimal>> actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, Expression<Func<decimal>> actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }

		public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<decimal>> expected, decimal actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, decimal expected, decimal actual, decimal epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, Expression<Func<double>> actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, double expected, Expression<Func<double>> actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }

		public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<double>> expected, double actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, double expected, double actual, double epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, double expected, double actual, double epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, double expected, double actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, double expected, double actual, double epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, double expected, double actual, double epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, double expected, double actual, double epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon, string msg)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Expression<Func<Single>> actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon, string msg)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Single expected, Expression<Func<Single>> actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }

		public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon, string msg)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Expression<Func<Single>> expected, Single actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
		
		public static void AreEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon);
        }
        public static void AreEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, "{0}", msg);
        }
        public static void AreEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b <= epsilon && a - b >= -epsilon, null, msg, fmt);
        }
		
		public static void AreNotEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {0}", epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon, string msg)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", msg, epsilon);
        }
        public static void AreNotEqual(this IAssertionTool tool, Single expected, Single actual, Single epsilon, string msg, params object[] fmt)
        {
            tool.Check(()=>expected, ()=>actual, (a, b) => a - b > epsilon || a - b < -epsilon, null, "with epsilon of {1} - {0}", string.Format(msg, fmt), epsilon);
        }
    }
}
