using System;
using ExpressiveAssertions.ExpressionEvaluator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveAssertions.Tests
{
  [TestClass]
  public class DateTimeNormalizationEvaluatorTests {
    IntrospectiveAssertionTool _introspective;
    IAssertionTool _assert;

    [TestInitialize]
    public virtual void Init()
    {
      _assert = ExpressiveAssertions.Tooling.AssertionRendererTool.Create( 
        CompositeAssertionTool.Create(
          ExpressiveAssertions.Tooling.AssertionRendererTool.Create(
            TraceLoggingAssertionTool.Create()
          ),
          _introspective = new IntrospectiveAssertionTool(
            ExpressiveAssertions.Tooling.AssertionRendererTool.Create( 
              CompositeAssertionTool.Create(
                TraceLoggingAssertionTool.Create(),
                ExpressiveAssertions.MSTest.MSTestAssertionTool.Create()
              )
            )
          )
        )
      );

      var evaluator = new DateTimeNormalizationEvaluator(new DefaultEvaluator());
      _assert.SetExpressionEvaluator(evaluator);
    }
    [TestMethod]
    public void Test001() {
      var d1 = DateTimeNormalizationEvaluator.NormalizeDateTime(DateTime.Now);
      var d2 = new DateTime(d1.Ticks + 1);

      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>d1, ()=>d2);
    }
    [TestMethod]
    public void Test002() {
      var d1 = DateTimeNormalizationEvaluator.NormalizeDateTime(DateTime.Now);
      var d2 = new DateTime(d1.Ticks + TimeSpan.TicksPerMillisecond - 1);

      _introspective.ExpectAssertionSuccessNext();
      _assert.AreEqual(()=>d1, ()=>d2);
    }
    [TestMethod]
    public void Test003() {
      var d1 = DateTimeNormalizationEvaluator.NormalizeDateTime(DateTime.Now);
      var d2 = new DateTime(d1.Ticks + TimeSpan.TicksPerMillisecond);

      _introspective.ExpectAssertionSuccessNext();
      _assert.AreNotEqual(()=>d1, ()=>d2);
    }
    [TestMethod]
    public void Test004() {
      var d1 = DateTimeNormalizationEvaluator.NormalizeDateTime(DateTime.Now);
      var d2 = new DateTime(d1.Ticks - 1);

      _introspective.ExpectAssertionSuccessNext();
      _assert.AreNotEqual(()=>d1, ()=>d2);
    }
  }
}
