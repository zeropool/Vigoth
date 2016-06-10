

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MaximumTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new Maximum(5);
        }

        protected override string TestFileName
        {
            get { return "spy_max.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "MAX_5"; }
        }

        [Test]
        public void ComputesCorrectly()
        {
            var max = new Maximum(3);

            var reference = DateTime.MinValue;

            max.Update(reference.AddDays(1), 1m);
            Assert.AreEqual(1m, max.Current.Value);
            Assert.AreEqual(0, max.PeriodsSinceMaximum);

            max.Update(reference.AddDays(2), -1m);
            Assert.AreEqual(1m, max.Current.Value);
            Assert.AreEqual(1, max.PeriodsSinceMaximum);

            max.Update(reference.AddDays(3), 0m);
            Assert.AreEqual(1m, max.Current.Value);
            Assert.AreEqual(2, max.PeriodsSinceMaximum);

            max.Update(reference.AddDays(4), -2m);
            Assert.AreEqual(0m, max.Current.Value);
            Assert.AreEqual(1, max.PeriodsSinceMaximum);

            max.Update(reference.AddDays(5), -2m);
            Assert.AreEqual(0m, max.Current.Value);
            Assert.AreEqual(2, max.PeriodsSinceMaximum);
        }

        [Test]
        public void ComputesCorrectly2()
        {
            const int period = 5;
            var max = new Maximum(period);

            Assert.AreEqual(0m, max.Current.Value);

            // test an increasing stream of data
            for (int i = 0; i < period; i++)
            {
                max.Update(DateTime.Now.AddDays(i), i);
                Assert.AreEqual(i, max.Current.Value);
                Assert.AreEqual(0, max.PeriodsSinceMaximum);
            }

            // test a decreasing stream of data
            for (int i = 0; i < period; i++)
            {
                max.Update(DateTime.Now.AddDays(period + i), period - i - 1);
                Assert.AreEqual(period - 1, max.Current.Value);
                Assert.AreEqual(i, max.PeriodsSinceMaximum);
            }

            Assert.AreEqual(max.Period, max.PeriodsSinceMaximum + 1);
        }

        [Test]
        public void ResetsProperly()
        {
            var max = new Maximum(3);
            max.Update(DateTime.Today, 1m);
            max.Update(DateTime.Today.AddSeconds(1), 2m);
            max.Update(DateTime.Today.AddSeconds(2), 1m);
            Assert.IsTrue(max.IsReady);

            max.Reset();
            Assert.AreEqual(0, max.PeriodsSinceMaximum);
            TestHelper.AssertIndicatorIsInDefaultState(max);
        }
    }
}
