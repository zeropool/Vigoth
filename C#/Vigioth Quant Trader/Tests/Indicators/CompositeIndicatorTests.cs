

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class CompositeIndicatorTests
    {
        [Test]
        public void CompositeIsReadyWhenBothAre()
        {
            var left = new Delay(1);
            var right = new Delay(2);
            var composite = new CompositeIndicator<IndicatorDataPoint>(left, right, (l, r) => l + r);

            left.Update(DateTime.Today.AddSeconds(0), 1m);
            right.Update(DateTime.Today.AddSeconds(0), 1m);
            Assert.IsFalse(composite.IsReady);
            Assert.IsFalse(composite.Left.IsReady);
            Assert.IsFalse(composite.Right.IsReady);

            left.Update(DateTime.Today.AddSeconds(1), 2m);
            right.Update(DateTime.Today.AddSeconds(1), 2m);
            Assert.IsFalse(composite.IsReady);
            Assert.IsTrue(composite.Left.IsReady);
            Assert.IsFalse(composite.Right.IsReady);

            left.Update(DateTime.Today.AddSeconds(2), 3m);
            right.Update(DateTime.Today.AddSeconds(2), 3m);
            Assert.IsTrue(composite.IsReady);
            Assert.IsTrue(composite.Left.IsReady);
            Assert.IsTrue(composite.Right.IsReady);

            left.Update(DateTime.Today.AddSeconds(3), 4m);
            right.Update(DateTime.Today.AddSeconds(3), 4m);
            Assert.IsTrue(composite.IsReady);
            Assert.IsTrue(composite.Left.IsReady);
            Assert.IsTrue(composite.Right.IsReady);
        }

        [Test]
        public void CallsDelegateCorrectly()
        {
            var left = new Identity("left");
            var right = new Identity("right");
            var composite = new CompositeIndicator<IndicatorDataPoint>(left, right, (l, r) =>
            {
                Assert.AreEqual(left, l);
                Assert.AreEqual(right, r);
                return l + r;
            });

            left.Update(DateTime.Today, 1m);
            right.Update(DateTime.Today, 1m);
            Assert.AreEqual(2m, composite.Current.Value);
        }

        [Test]
        public void ResetsProperly() {
            var left = new Maximum("left", 2);
            var right = new Minimum("right", 2);
            var composite = new CompositeIndicator<IndicatorDataPoint>(left, right, (l, r) => l + r);

            left.Update(DateTime.Today, 1m);
            right.Update(DateTime.Today,-1m);

            left.Update(DateTime.Today.AddDays(1), -1m);
            right.Update(DateTime.Today.AddDays(1), 1m);

            Assert.AreEqual(left.PeriodsSinceMaximum, 1);
            Assert.AreEqual(right.PeriodsSinceMinimum, 1);

            composite.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(composite);
            TestHelper.AssertIndicatorIsInDefaultState(left);
            TestHelper.AssertIndicatorIsInDefaultState(right);
            Assert.AreEqual(left.PeriodsSinceMaximum, 0);
            Assert.AreEqual(right.PeriodsSinceMinimum, 0);
        }
    }
}
