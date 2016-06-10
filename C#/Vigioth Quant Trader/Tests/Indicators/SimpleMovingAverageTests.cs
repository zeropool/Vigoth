

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class SimpleMovingAverageTests
    {
        [Test]
        public void SMAComputesCorrectly()
        {
            var sma = new SimpleMovingAverage(4);
            var data = new[] {1m, 10m, 100m, 1000m, 10000m, 1234m, 56789m};

            var seen = new List<decimal>();
            for (int i = 0; i < data.Length; i++)
            {
                var datum = data[i];
                seen.Add(datum);
                sma.Update(new IndicatorDataPoint(DateTime.Now.AddSeconds(i), datum));
                Assert.AreEqual(Enumerable.Reverse(seen).Take(sma.Period).Average(), sma.Current.Value);
            }
        }

        [Test]
        public void IsReadyAfterPeriodUpdates()
        {
            var sma = new SimpleMovingAverage(3);

            sma.Update(DateTime.UtcNow, 1m);
            sma.Update(DateTime.UtcNow, 1m);
            Assert.IsFalse(sma.IsReady);
            sma.Update(DateTime.UtcNow, 1m);
            Assert.IsTrue(sma.IsReady);
        }

        [Test]
        public void ResetsProperly()
        {
            var sma = new SimpleMovingAverage(3);

            foreach (var data in TestHelper.GetDataStream(4))
            {
                sma.Update(data);
            }
            Assert.IsTrue(sma.IsReady);
            
            sma.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(sma);
            TestHelper.AssertIndicatorIsInDefaultState(sma.RollingSum);
            sma.Update(DateTime.UtcNow, 2.0m);
            Assert.AreEqual(sma.Current.Value, 2.0m);
        }

        [Test]
        public void CompareAgainstExternalData()
        {
            var sma = new SimpleMovingAverage(14);
            TestHelper.TestIndicator(sma, "SMA14", 1e-2); // test file only has
        }
    }
}
