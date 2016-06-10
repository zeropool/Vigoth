

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class WindowIdentityTests
    {
        [Test]
        public void WindowIdentityComputesCorrectly()
        {
            var indicator = new WindowIdentity(4);
            var data = new[] {1m, 10m, 100m, 1000m, 10000m, 1234m, 56789m};

            var seen = new List<decimal>();
            for (int i = 0; i < data.Length; i++)
            {
                var datum = data[i];
                seen.Add(datum);
                indicator.Update(new IndicatorDataPoint(DateTime.Now.AddSeconds(i), datum));
                Assert.AreEqual(seen.LastOrDefault(), indicator.Current.Value);
            }
        }

        [Test]
        public void IsReadyAfterPeriodUpdates()
        {
            var indicator = new WindowIdentity(3);

            indicator.Update(DateTime.UtcNow, 1m);
            indicator.Update(DateTime.UtcNow, 1m);
            Assert.IsFalse(indicator.IsReady);
            indicator.Update(DateTime.UtcNow, 1m);
            Assert.IsTrue(indicator.IsReady);
        }

        [Test]
        public void ResetsProperly()
        {
            var indicator = new WindowIdentity(3);

            foreach (var data in TestHelper.GetDataStream(4))
            {
                indicator.Update(data);
            }
            Assert.IsTrue(indicator.IsReady);
            
            indicator.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(indicator);
            indicator.Update(DateTime.UtcNow, 2.0m);
            Assert.AreEqual(indicator.Current.Value, 2.0m);
        }

        [Test]
        public void CompareAgainstExternalData()
        {
            var indicator = new WindowIdentity(14);
            TestHelper.TestIndicator(indicator, "Close", 1e-2); // test file only has
        }
    }
}
