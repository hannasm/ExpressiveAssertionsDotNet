﻿using ExpressiveAssertions.ExpressionEvaluator;
using ExpressiveExpressionTrees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions
{
    public static class CollectionAssertions
    {
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection)
        {
            EveryIsDistinct(assertTool, () => collection, null, null);
        }
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg)
        {
            EveryIsDistinct(assertTool, () => collection, msg, null);
        }
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg, params object[] fmt)
        {
            EveryIsDistinct(assertTool, () => collection, msg, fmt);
        }
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp)
        {
            EveryIsDistinct(assertTool, collectionExp, null, null);
        }
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, string msg)
        {
            EveryIsDistinct(assertTool, collectionExp, msg, null);
        }
        public static void EveryIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, string msg, params object[] fmt)
        {
            EachIsDistinct(assertTool, collectionExp, msg, fmt);
        }

        public static void EachIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection)
        {
            EachIsDistinct(assertTool, () => collection, null, null);
        }
        public static void EachIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg)
        {
            EachIsDistinct(assertTool, () => collection, msg, null);
        }
        public static void EachIsDistinct<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg, params object[] fmt)
        {
            EachIsDistinct(assertTool, () => collection, msg, fmt);
        }
        public static void EachIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp)
        {
            EachIsDistinct(assertTool, collectionExp, null, null);
        }
        public static void EachIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, string msg)
        {
            EachIsDistinct(assertTool, collectionExp, msg, null);
        }
        public static void EachIsDistinct<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, string msg, params object[] fmt)
        {
            var set = new HashSet<T>();
            Func<IAssertionTool,T,bool> isDistinct = (assert,t)=>{
                if (set.Contains(t)) { return false; }
                set.Add(t);
                return true;
            };

            assertTool.Each(collectionExp, (assert,t)=>assert.IsTrue(()=>isDistinct(assert, t)), msg, fmt);
        }
        


        public static void Every<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action)
        {
            Each(assertTool, () => collection, action, null, null);
        }
        public static void Each<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action)
        {
            Each(assertTool, () => collection, action, null, null);
        }
        public static void Every<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action, string msg)
        {
            Each(assertTool, () => collection, action, msg, null);
        }
        public static void Each<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action, string msg)
        {
            Each(assertTool, () => collection, action, msg, null);
        }
        public static void Every<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action, string msg, params object[] fmt)
        {
            Each(assertTool, () => collection, action, msg, fmt);
        }
        public static void Each<T>(this IAssertionTool assertTool, IEnumerable<T> collection, Expression<Action<IAssertionTool, T>> action, string msg, params object[] fmt)
        {
            Each(assertTool, () => collection, action, msg, fmt);
        }
        public static void Every<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action)
        {
            Each(assertTool, collectionExp, action, null, null);
        }
        public static void Each<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action)
        {
            Each(assertTool, collectionExp, action, null, null);
        }
        public static void Every<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action, string msg)
        {
            Each(assertTool, collectionExp, action, msg, null);
        }
        public static void Each<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action, string msg)
        {
            Each(assertTool, collectionExp, action, msg, null);
        }
        public static void Every<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action, string msg, params object[] fmt)
        {
            Each(assertTool, collectionExp, action);
        }
        public static void Each<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collectionExp, Expression<Action<IAssertionTool, T>> action, string msg, params object[] fmt)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                msg = string.Empty;
                fmt = fmt ?? new object[] { };
            }
            else if (fmt == null)
            {
                fmt = new object[] { msg };
                msg = "{0}";
            }

            var evaluator = assertTool.GetExpressionEvaluator();
            var context = assertTool.ContextGet();

            using (context.Push())
            {
                context.Set("Message", string.Format(msg, fmt));

                var collection = evaluator.Eval(collectionExp);
                foreach (var ele in collection.Select((e, i) => new { e, i }))
                {
                    context.Set("Element Index", ele.i.ToString());

                    evaluator.Eval(action, assertTool, ele.e);
                }
            }
        }

        public static void Count<T>(this IAssertionTool assertTool, int expected, IEnumerable<T> collection)
        {
            assertTool.Count(() => expected, ()=>collection, null, null);
        }
        public static void Count<T>(this IAssertionTool assertTool, int expected, IEnumerable<T> collection, string msg)
        {
            assertTool.Count(() => expected, () => collection, "{0}", msg);
        }
        public static void Count<T>(this IAssertionTool assertTool, int expected, IEnumerable<T> collection, string msg, params object[] fmt)
        {
            assertTool.Count(() => expected, () => collection, msg, fmt);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, IEnumerable<T> collection)
        {
            assertTool.Count(expected, ()=>collection, null, null);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, IEnumerable<T> collection, string msg)
        {
            assertTool.Count(expected, () => collection, "{0}", msg);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, IEnumerable<T> collection, string msg, params object[] fmt)
        {
            assertTool.Count(expected, () => collection, msg, fmt);
        }
        public static void Count<T>(this IAssertionTool assertTool, int expected, Expression<Func<IEnumerable<T>>> collection)
        {
            assertTool.Count(()=>expected, collection, null, null);
        }
        public static void Count<T>(this IAssertionTool assertTool, int expected, Expression<Func<IEnumerable<T>>> collection, string msg)
        {
            assertTool.Count(()=>expected, collection, "{0}", msg);
        }
        public static void Count<T>(this IAssertionTool assertTool, int expected, Expression<Func<IEnumerable<T>>> collection, string msg, params object[] fmt)
        {
            assertTool.Count(() => expected, collection, msg, fmt);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, Expression<Func<IEnumerable<T>>> collection)
        {
            assertTool.Count(expected, collection, null, null);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, Expression<Func<IEnumerable<T>>> collection, string msg)
        {
            assertTool.Count(expected, collection, "{0}", msg);
        }
        public static void Count<T>(this IAssertionTool assertTool, Expression<Func<int>> expected, Expression<Func<IEnumerable<T>>> collection, string msg, params object[] fmt)
        {
            var xgr = new ExpressionGenerator();
            var eval = assertTool.GetExpressionEvaluator();
            var exp = xgr.FromFunc(collection, c => c.Count());
            assertTool.AreEqual(expected, exp, msg, fmt);
        }
        
        public static void IsEmpty<T>(this IAssertionTool assertTool, IEnumerable<T> collection)
        {
            assertTool.IsEmpty(() => collection, null, null);
        }
        public static void IsEmpty<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg)
        {
            assertTool.IsEmpty(() => collection, "{0}", msg);
        }
        public static void IsEmpty<T>(this IAssertionTool assertTool, IEnumerable<T> collection, string msg, params object[] fmt)
        {
            assertTool.IsEmpty(() => collection, msg, fmt);
        }
        public static void IsEmpty<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collection)
        {
            assertTool.IsEmpty(collection, null, null);
        }
        public static void IsEmpty<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collection, string msg)
        {
            assertTool.IsEmpty(collection, "{0}", msg);
        }
        public static void IsEmpty<T>(this IAssertionTool assertTool, Expression<Func<IEnumerable<T>>> collection, string msg, params object[] fmt)
        {
            var xgr = new ExpressionGenerator();
            var eval = assertTool.GetExpressionEvaluator();
            var exp = xgr.FromFunc(collection, c => c.Count());
            assertTool.AreEqual(0, exp, msg, fmt);
        }

    }
}
