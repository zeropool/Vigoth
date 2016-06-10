

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class VolumeWeightedAveragePriceIndicatorTests
    {
        [Test]
        public void VWAPComputesCorrectly()
        {
            const int period = 4;
            const int volume = 100;
            var ind = new VolumeWeightedAveragePriceIndicator(period);
            var data = new[] {1m, 10m, 100m, 1000m, 10000m, 1234m, 56789m};

            var seen = new List<decimal>();
            for (int i = 0; i < data.Length; i++)
            {
                var datum = data[i];
                seen.Add(datum);
                ind.Update(new TradeBar(DateTime.Now.AddSeconds(i), "SPY", datum, datum, datum, datum, volume));
                // When volume is constant, VWAP is a simple moving average
                Assert.AreEqual(Enumerable.Reverse(seen).Take(period).Average(), ind.Current.Value);
            }
        }

        [Test]
        public void IsReadyAfterPeriodUpdates()
        {
            var ind = new VolumeWeightedAveragePriceIndicator(3);

            ind.Update(new TradeBar(DateTime.UtcNow, "SPY", 1m, 1m, 1m, 1m, 1));
            ind.Update(new TradeBar(DateTime.UtcNow, "SPY", 1m, 1m, 1m, 1m, 1));
            Assert.IsFalse(ind.IsReady);
            ind.Update(new TradeBar(DateTime.UtcNow, "SPY", 1m, 1m, 1m, 1m, 1));
            Assert.IsTrue(ind.IsReady);
        }

        [Test]
        public void ResetsProperly()
        {
            var ind = new VolumeWeightedAveragePriceIndicator(50);

            foreach (var data in TestHelper.GetTradeBarStream("spy_with_vwap.txt"))
            {
                ind.Update(data);
            }
            Assert.IsTrue(ind.IsReady);
            
            ind.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(ind);
            ind.Update(new TradeBar(DateTime.UtcNow, "SPY", 2m, 2m, 2m, 2m, 1));
            Assert.AreEqual(ind.Current.Value, 2m);
        }

        [Test]
        public void CompareAgainstExternalData()
        {
            var ind = new VolumeWeightedAveragePriceIndicator(50);
            TestHelper.TestIndicator(ind, "spy_with_vwap.txt", "Moving VWAP 50",
                (x, expected) => Assert.AreEqual(expected, (double)((VolumeWeightedAveragePriceIndicator)x).Current.Value, 1e-3));
            
        }
    }
}
