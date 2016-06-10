

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class AccumulationDistributionOscillatorTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new AccumulationDistributionOscillator(3, 10);
        }

        protected override string TestFileName
        {
            get { return "spy_ad_osc.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "AdOsc_3_10"; }
        }
    }
}
