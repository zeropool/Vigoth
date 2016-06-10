

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash
    /// </summary>
    public class LimitFillRegressionAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Second);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public override void OnData(Slice data)
        {
            if (data.Bars.ContainsKey("SPY"))
            {
                if (Time.TimeOfDay.Ticks%TimeSpan.FromHours(1).Ticks == 0)
                {
                    bool goLong = Time < StartDate + TimeSpan.FromTicks((EndDate - StartDate).Ticks/2);
                    int negative = goLong ? 1 : -1;
                    LimitOrder("SPY", negative*10, data["SPY"].Price);
                }
            }
        }
    }
}