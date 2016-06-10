

using System;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash
    /// </summary>
    public class MarketOnOpenOnCloseAlgorithm : QCAlgorithm
    {
        private bool submittedMarketOnCloseToday;
        private Security security;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Second, fillDataForward: true, extendedMarketHours: true);

            security = Securities["SPY"];
        }

        private DateTime last = DateTime.MinValue;

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public void OnData(TradeBars data)
        {
            if (Time.Date != last.Date) // each morning submit a market on open order
            {
                submittedMarketOnCloseToday = false;
                MarketOnOpenOrder("SPY", 100);
                last = Time;
            }
            if (!submittedMarketOnCloseToday && security.Exchange.ExchangeOpen) // once the exchange opens submit a market on close order
            {
                submittedMarketOnCloseToday = true;
                MarketOnCloseOrder("SPY", -100);
            }
        }

        public override void OnOrderEvent(OrderEvent fill)
        {
            var order = Transactions.GetOrderById(fill.OrderId);
            Console.WriteLine(Time + " - " + order.Type + " - " + fill.Status + ":: " + fill);
        }
    }
}