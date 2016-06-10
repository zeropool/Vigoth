

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MoneyFlowIndexTests
    {
        [Test]
        public void ComparesAgainstExternalData()
        {
            var mfi = new MoneyFlowIndex(20);
            TestHelper.TestIndicator(mfi, "spy_mfi.txt", "Money Flow Index 20");
        }

        [Test]
        public void TestTradeBarsWithNoVolume()
        {
            var mfi = new MoneyFlowIndex(3);
            foreach (var data in TestHelper.GetDataStream(4))
            {
                var tradeBar = new TradeBar
                {
                    Open = data.Value,
                    Close = data.Value,
                    High = data.Value,
                    Low = data.Value,
                    Volume = 0
                };
                mfi.Update(tradeBar);
            }

            Assert.AreEqual(mfi.Current.Value, 100.0m);
        }

        [Test]
        public void ResetsProperly()
        {
            var mfi = new MoneyFlowIndex(3);
            foreach (var data in TestHelper.GetDataStream(4))
            {
                var tradeBar = new TradeBar
                {
                    Open = data.Value,
                    Close = data.Value,
                    High = data.Value,
                    Low = data.Value,
                    Volume = Decimal.ToInt64(data.Value)
                };
                mfi.Update(tradeBar);
            }
            Assert.IsTrue(mfi.IsReady);
            Assert.IsTrue(mfi.PositiveMoneyFlow.IsReady);
            Assert.IsTrue(mfi.NegativeMoneyFlow.IsReady);
            Assert.AreNotEqual(mfi.PreviousTypicalPrice, 0.0m);

            mfi.Reset();

            Assert.AreEqual(mfi.PreviousTypicalPrice, 0.0m);
            TestHelper.AssertIndicatorIsInDefaultState(mfi);
            TestHelper.AssertIndicatorIsInDefaultState(mfi.PositiveMoneyFlow);
            TestHelper.AssertIndicatorIsInDefaultState(mfi.NegativeMoneyFlow);
        }
    }
}