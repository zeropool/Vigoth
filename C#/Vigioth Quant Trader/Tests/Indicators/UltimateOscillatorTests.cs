

using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class UltimateOscillatorTests : CommonIndicatorTests<TradeBar>
    {
        protected override IndicatorBase<TradeBar> CreateIndicator()
        {
            return new UltimateOscillator(7, 14, 28);
        }

        protected override string TestFileName
        {
            get { return "spy_ultosc.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "ULTOSC_7_14_28"; }
        }
    }
}
