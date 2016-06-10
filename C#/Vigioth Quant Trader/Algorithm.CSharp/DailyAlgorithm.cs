

using System;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// Uses daily data and a simple moving average cross to place trades and an ema for stop placement
    /// </summary>
    public class DailyAlgorithm : QCAlgorithm
    {
        private DateTime lastAction;
        private MovingAverageConvergenceDivergence macd;
        private ExponentialMovingAverage ema;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 01, 01);  //Set Start Date
            SetEndDate(2014, 01, 01);    //Set End Date
            SetCash(100000);             //Set Strategy Cash

            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "IBM", Resolution.Hour);
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Daily);

            macd = MACD("SPY", 12, 26, 9, MovingAverageType.Wilders, Resolution.Daily, Field.Close);
            ema = EMA("IBM", 15*6, Resolution.Hour, Field.SevenBar);

            Securities["IBM"].SetLeverage(1.0m);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public void OnData(TradeBars data)
        {
            if (!macd.IsReady) return;
            if (!data.ContainsKey("IBM")) return;
            if (lastAction.Date == Time.Date) return;
            lastAction = Time;

            var holding = Portfolio["SPY"];
            if (holding.Quantity <= 0 && macd > macd.Signal && data["IBM"].Price > ema)
            {
                SetHoldings("IBM", 0.25m);
            }
            else if (holding.Quantity >= 0 && macd < macd.Signal && data["IBM"].Price < ema)
            {
                SetHoldings("IBM", -0.25m);
            }
        }
    }
}