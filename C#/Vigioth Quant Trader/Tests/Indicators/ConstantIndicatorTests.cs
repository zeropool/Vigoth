

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class ConstantIndicatorTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var cons = new ConstantIndicator<IndicatorDataPoint>("c", 1m);
            Assert.AreEqual(1m, cons.Current.Value);
            Assert.IsTrue(cons.IsReady);

            cons.Update(DateTime.Today, 3m);
            Assert.AreEqual(1m, cons.Current.Value);
        }

        [Test]
        public void ResetsProperly()
        {
            // constant reset should reset samples but the value should still be the same
            var cons = new ConstantIndicator<IndicatorDataPoint>("c", 1m);
            cons.Update(DateTime.Today, 3m);
            cons.Update(DateTime.Today.AddDays(1), 10m);

            cons.Reset();
            Assert.AreEqual(1m, cons.Current.Value);
            Assert.AreEqual(DateTime.MinValue, cons.Current.Time);
            Assert.AreEqual(0, cons.Samples);
        }
    }
}
