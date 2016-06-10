

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MeanAbsoluteDeviationTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            // Indicator output was compared against the octave code:
            // mad = @(v) mean(abs(v - mean(v)));
            var std = new MeanAbsoluteDeviation(3);
            var reference = DateTime.MinValue;

            std.Update(reference.AddDays(1), 1m);
            Assert.AreEqual(0m, std.Current.Value);

            std.Update(reference.AddDays(2), -1m);
            Assert.AreEqual(1m, std.Current.Value);

            std.Update(reference.AddDays(3), 1m);
            Assert.AreEqual(0.888888888888889m, Decimal.Round(std.Current.Value, 15));

            std.Update(reference.AddDays(4), -2m);
            Assert.AreEqual(1.111111111111111m, Decimal.Round(std.Current.Value, 15));

            std.Update(reference.AddDays(5), 3m);
            Assert.AreEqual(1.777777777777778m, Decimal.Round(std.Current.Value, 15));
        }

        [Test]
        public void ResetsProperly()
        {
            var std = new MeanAbsoluteDeviation(3);
            std.Update(DateTime.Today, 1m);
            std.Update(DateTime.Today.AddSeconds(1), 2m);
            std.Update(DateTime.Today.AddSeconds(1), 1m);
            Assert.IsTrue(std.IsReady);

            std.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(std);
            TestHelper.AssertIndicatorIsInDefaultState(std.Mean);
        }
    }
}
