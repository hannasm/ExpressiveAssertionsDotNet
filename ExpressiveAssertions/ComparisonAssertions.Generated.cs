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
    }
}
