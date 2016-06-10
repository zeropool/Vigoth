

using System;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// MACD Example Algorithm
    /// </summary>
    public class MACDTrendAlgorithm : QCAlgorithm
    {
        private DateTime previous;
        private MovingAverageConvergenceDivergence macd;
        private string Symbol = "SPY";

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2009, 01, 01);
            SetEndDate(2015, 01, 01);

            AddSecurity(SecurityType.Equity, Symbol);

            // define our daily macd(12,26) with a 9 day signal
            macd = MACD(Symbol, 9, 26, 9, MovingAverageType.Exponential, Resolution.Daily);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public void OnData(TradeBars data)
        {
            // only once per day
            if (previous.Date == Time.Date) return;

            if (!macd.IsReady) return;

            var holding = Portfolio[Symbol];

            decimal signalDeltaPercent = (macd - macd.Signal)/macd.Fast;
            var tolerance = 0.0025m;

            // if our macd is greater than our signal, then let's go long
            if (holding.Quantity <= 0 && signalDeltaPercent > tolerance) // 0.01%
            {
                // longterm says buy as well
                SetHoldings(Symbol, 1.0);
            }
            // of our macd is less than our signal, then let's go short
            else if (holding.Quantity >= 0 && signalDeltaPercent < -tolerance)
            {
                Liquidate(Symbol);
            }

            // plot both lines
            Plot("MACD", macd, macd.Signal);
            Plot(Symbol, "Open", data[Symbol].Open);
            Plot(Symbol, macd.Fast, macd.Slow);

            previous = Time;
        }
    }
}