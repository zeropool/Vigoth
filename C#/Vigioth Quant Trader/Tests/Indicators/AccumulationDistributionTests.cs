

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AccumulationDistributionTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new AccumulationDistribution("AD");
        }

        protected override string TestFileName
        {
            get { return "spy_ad.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "AD"; }
        }
    }
}
