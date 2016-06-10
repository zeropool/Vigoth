

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AverageTrueRangeTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var atr = new AverageTrueRange(14, MovingAverageType.Simple);
            TestHelper.TestIndicator(atr, "spy_atr.txt", "Average True Range 14");
        }

        [Test]
        public void ResetsProperly()
        {
            var atr = new AverageTrueRange(14, MovingAverageType.Simple);
            atr.Update(new TradeBar
            {
                Time = DateTime.Today,
                Open = 1m,
                High = 3m,
                Low = .5m,
                Close = 2.75m,
                Volume = 1234567890
            });

            atr.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(atr);
            TestHelper.AssertIndicatorIsInDefaultState(atr.TrueRange);
        }

        [Test]
        public void TrueRangePropertyIsReadyAfterOneSample()
        {
            var atr = new AverageTrueRange(14, MovingAverageType.Simple);
            Assert.IsFalse(atr.TrueRange.IsReady);

            atr.Update(new TradeBar
            {
                Time = DateTime.Today,
                Open = 1m,
                High = 3m,
                Low = .5m,
                Close = 2.75m,
                Volume = 1234567890
            });

            Assert.IsTrue(atr.TrueRange.IsReady);
        }
    }
}
