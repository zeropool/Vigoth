

using System;
using System.Collections.Generic;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class LogReturnTests
    {
        [Test]
        public void LOGRComputesCorrectly()
        {
            int period = 4;
            var logr = new LogReturn(period);
            var data = new[] { 1m, 10m, 100m, 1000m, 10000m, 1234m, 56789m };

            var seen = new List<decimal>();
            for (int i = 0; i < data.Length; i++)
            {
                var datum = data[i];
                var value0 = 0m;

                if (seen.Count >= 0 && seen.Count < period)
                    value0 = data[0];
                else if (seen.Count >= period)
                    value0 = data[i - period];

                var expected = (decimal)Math.Log((double)datum / (double)value0);

                seen.Add(datum);
                logr.Update(new IndicatorDataPoint(DateTime.Now.AddSeconds(i), datum));
                Assert.AreEqual(expected, logr.Current.Value);
            }
        }

        [Test]
        public void CompareAgainstExternalData()
        {
            var logr = new LogReturn(14);
            double epsilon = 1e-3;
            TestHelper.TestIndicator(logr, "spy_logr14.txt", "LOGR14", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var logr = new LogReturn(14);

            TestHelper.TestIndicatorReset(logr, "spy_logr14.txt");
        }
    }
}
