

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators {
    [TestFixture]
    public class CommodityChannelIndexTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var cci = new CommodityChannelIndex(14);
            TestHelper.TestIndicator(cci, "spy_with_cci.txt", "Commodity Channel Index (CCI) 14", 1e-2);
        }

        [Test]
        public void ResetsProperly()
        {
            var cci = new CommodityChannelIndex(2);
            cci.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today,
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            Assert.IsFalse(cci.IsReady);
            cci.Update(new TradeBar
            {
                Symbol = Symbols.SPY,
                Time = DateTime.Today.AddSeconds(1),
                Open = 3m,
                High = 7m,
                Low = 2m,
                Close = 5m,
                Volume = 10
            });
            Assert.IsTrue(cci.IsReady);

            cci.Reset();
            TestHelper.AssertIndicatorIsInDefaultState(cci);
            TestHelper.AssertIndicatorIsInDefaultState(cci.TypicalPriceAverage);
            TestHelper.AssertIndicatorIsInDefaultState(cci.TypicalPriceMeanDeviation);
        }
    }
}