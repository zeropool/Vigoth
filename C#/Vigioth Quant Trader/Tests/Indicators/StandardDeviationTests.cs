

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class StandardDeviationTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        [Test]
        public void ComputesCorrectly()
        {
            // Indicator output was compared against the following function in Julia
            // stdpop(v) = sqrt(sum((v - mean(v)).^2) / length(v))
            var std = new StandardDeviation(3);
            var reference = DateTime.MinValue;

            std.Update(reference.AddDays(1), 1m);
            Assert.AreEqual(0m, std.Current.Value);

            std.Update(reference.AddDays(2), -1m);
            Assert.AreEqual(1m, std.Current.Value);

            std.Update(reference.AddDays(3), 1m);
            Assert.AreEqual(0.942809041582063m, std.Current.Value);

            std.Update(reference.AddDays(4), -2m);
            Assert.AreEqual(1.24721912892465m, std.Current.Value);

            std.Update(reference.AddDays(5), 3m);
            Assert.AreEqual(2.05480466765633m, std.Current.Value);
        }

        [Test]
        public void ResetsProperly2()
        {
            var std = new StandardDeviation(3);
            std.Update(DateTime.Today, 1m);
            std.Update(DateTime.Today.AddSeconds(1), 5m);
            std.Update(DateTime.Today.AddSeconds(2), 1m);
            Assert.IsTrue(std.IsReady);

            std.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(std);
        }

        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new StandardDeviation(10);
        }

        protected override string TestFileName
        {
            get { return "spy_var.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "Var"; }
        }

        protected override Action<IndicatorBase<IndicatorDataPoint>, double> Assertion
        {
            get { return (indicator, expected) => Assert.AreEqual(Math.Sqrt(expected), (double)indicator.Current.Value, 1e-6); }
        }
    }
}
