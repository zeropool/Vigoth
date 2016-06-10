

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class BalanceOfPowerTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new BalanceOfPower("BOP");
        }

        protected override string TestFileName
        {
            get { return "spy_bop.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "BOP"; }
        }
    }
}
