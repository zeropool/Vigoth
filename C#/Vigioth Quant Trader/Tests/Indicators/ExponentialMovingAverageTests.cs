

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class ExponentialMovingAverageTests
    {
        [Test]
        public void EMAComputesCorrectly()
        {
            const int period = 4;
            decimal[] values = {1m, 10m, 100m, 1000m};
            const decimal expFactor = 2m/(1m + period);
            
            var ema4 = new ExponentialMovingAverage(period);

            decimal current = 0m;
            for (int i = 0; i < values.Length; i++)
            {
                ema4.Update(new IndicatorDataPoint(DateTime.UtcNow.AddSeconds(i), values[i]));
                if (i == 0)
                {
                    current = values[i];
                }
                else
                {
                    current = values[i]*expFactor + (1 - expFactor)*current;
                }
                Assert.AreEqual(current, ema4.Current.Value);
            }
        }

        [Test]
        public void ResetsProperly()
        {
            // ema reset is just setting the value and samples back to 0
            var ema = new ExponentialMovingAverage(3);

            foreach (var data in TestHelper.GetDataStream(5))
            {
                ema.Update(data);
            }
            Assert.IsTrue(ema.IsReady);
            Assert.AreNotEqual(0m, ema.Current.Value);
            Assert.AreNotEqual(0, ema.Samples);

            ema.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(ema);
        }

        [Test]
        public void ComparesAgainstExternalData()
        {
            var ema = new ExponentialMovingAverage(14);
            TestHelper.TestIndicator(ema, "spy_with_indicators.txt", "EMA14", TestHelper.AssertDeltaDecreases(2.5e-2));
        }
    }
}
