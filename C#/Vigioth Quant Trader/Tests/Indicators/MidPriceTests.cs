

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class MidPriceTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new MidPrice(5);
        }

        protected override string TestFileName
        {
            get { return "spy_midprice.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "MIDPRICE_5"; }
        }
    }
}
