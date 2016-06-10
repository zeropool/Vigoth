

using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;
using VigiothCapital.QuantTrader.Parameters;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    public class ParameterizedAlgorithm : QCAlgorithm
    {
        // we place attributes on top of our fields or properties that should receive
        // their values from the job. The values 100 and 200 are just default values that
        // or only used if the parameters do not exist
        [Parameter("ema-fast")]
        public int FastPeriod = 100;

        [Parameter("ema-slow")]
        public int SlowPeriod = 200;

        public ExponentialMovingAverage Fast;
        public ExponentialMovingAverage Slow;

        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);
            SetEndDate(2013, 10, 11);
            SetCash(100*1000);

            AddSecurity(SecurityType.Equity, "SPY");

            Fast = EMA("SPY", FastPeriod);
            Slow = EMA("SPY", SlowPeriod);
        }

        public void OnData(TradeBars data)
        {
            // wait for our indicators to ready
            if (!Fast.IsReady || !Slow.IsReady) return;

            if (Fast > Slow*1.001m)
            {
                SetHoldings("SPY", 1);
            }
            else if (Fast < Slow*0.999m)
            {
                Liquidate("SPY");
            }
        }
    }
}
