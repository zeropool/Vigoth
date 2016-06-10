

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class TrueRangeTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new TrueRange("TR");
        }

        protected override string TestFileName
        {
            get { return "spy_tr.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "TR"; }
        }
    }
}
