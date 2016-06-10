

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MinimumTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new Minimum(5);
        }

        protected override string TestFileName
        {
            get { return "spy_min.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "MIN_5"; }
        }

        [Test]
        public void ComputesCorrectly()
        {
            var min = new Minimum(3);

            var reference = DateTime.UtcNow;

            min.Update(reference, 1m);
            Assert.AreEqual(1m, min.Current.Value);
            Assert.AreEqual(0, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(1), 2m);
            Assert.AreEqual(1m, min.Current.Value);
            Assert.AreEqual(1, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(2), -1m);
            Assert.AreEqual(-1m, min.Current.Value);
            Assert.AreEqual(0, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(3), 2m);
            Assert.AreEqual(-1m, min.Current.Value);
            Assert.AreEqual(1, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(4), 0m);
            Assert.AreEqual(-1m, min.Current.Value);
            Assert.AreEqual(2, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(5), 3m);
            Assert.AreEqual(0m, min.Current.Value);
            Assert.AreEqual(1, min.PeriodsSinceMinimum);

            min.Update(reference.AddDays(6), 2m);
            Assert.AreEqual(0m, min.Current.Value);
            Assert.AreEqual(2, min.PeriodsSinceMinimum);
        }

        [Test]
        public void ResetsProperly()
        {
            var min = new Minimum(3);
            min.Update(DateTime.Today, 1m);
            min.Update(DateTime.Today.AddSeconds(1), 2m);
            min.Update(DateTime.Today.AddSeconds(2), 1m);
            Assert.IsTrue(min.IsReady);

            min.Reset();
            Assert.AreEqual(0, min.PeriodsSinceMinimum);
            TestHelper.AssertIndicatorIsInDefaultState(min);
        }
    }
}
