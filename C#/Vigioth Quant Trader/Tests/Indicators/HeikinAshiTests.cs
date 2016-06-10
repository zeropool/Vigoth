

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class HeikinAshiTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new HeikinAshi();
        }

        protected override string TestFileName
        {
            get { return "spy_heikin_ashi.txt"; }
        }

        protected override string TestColumnName
        {
            get { return ""; }
        }

        [Test]
        public override void ComparesAgainstExternalData()
        {
            TestHelper.TestIndicator(new HeikinAshi(), TestFileName, "HA_Open", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Open.Current.Value, 1e-3));
            TestHelper.TestIndicator(new HeikinAshi(), TestFileName, "HA_High", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).High.Current.Value, 1e-3));
            TestHelper.TestIndicator(new HeikinAshi(), TestFileName, "HA_Low", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Low.Current.Value, 1e-3));
            TestHelper.TestIndicator(new HeikinAshi(), TestFileName, "HA_Close", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Close.Current.Value, 1e-3));
        }

        [Test]
        public override void ComparesAgainstExternalDataAfterReset()
        {
            var indicator = new HeikinAshi();
            for (var i = 1; i <= 2; i++)
            {
                TestHelper.TestIndicator(indicator, TestFileName, "HA_Open", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Open.Current.Value, 1e-3));
                indicator.Reset();
                TestHelper.TestIndicator(indicator, TestFileName, "HA_High", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).High.Current.Value, 1e-3));
                indicator.Reset();
                TestHelper.TestIndicator(indicator, TestFileName, "HA_Low", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Low.Current.Value, 1e-3));
                indicator.Reset();
                TestHelper.TestIndicator(indicator, TestFileName, "HA_Close", (ind, expected) => Assert.AreEqual(expected, (double)((HeikinAshi)ind).Close.Current.Value, 1e-3));
                indicator.Reset();
            }
        }
    }
}
