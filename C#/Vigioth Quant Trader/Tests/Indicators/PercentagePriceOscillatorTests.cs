

using NUnit.Framework;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Tests.Indicators
{
    [TestFixture]
    public class PercentagePriceOscillatorTests : CommonIndicatorTests<IndicatorDataPoint>
    {
        protected override IndicatorBase<IndicatorDataPoint> CreateIndicator()
        {
            return new PercentagePriceOscillator(5, 10);
        }

        protected override string TestFileName
        {
            get { return "spy_ppo.txt"; }
        }

        protected override string TestColumnName
        {
            get { return "PPO_5_10"; }
        }
    }
}
