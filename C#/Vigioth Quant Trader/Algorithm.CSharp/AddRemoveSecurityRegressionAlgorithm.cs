

using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash
    /// </summary>
    public class AddRemoveSecurityRegressionAlgorithm : QCAlgorithm
    {
        private DateTime lastAction;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data

            AddSecurity(SecurityType.Equity, "SPY");
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public void OnData(TradeBars data)
        {
            if (lastAction.Date == Time.Date) return;

            if (!Portfolio.Invested)
            {
                SetHoldings("SPY", 0.5);
                lastAction = Time;
            }
            if (Time.DayOfWeek == DayOfWeek.Tuesday)
            {
                AddSecurity(SecurityType.Equity, "AIG");
                AddSecurity(SecurityType.Equity, "BAC");
                lastAction = Time;
            }
            else if (Time.DayOfWeek == DayOfWeek.Wednesday)
            {
                SetHoldings("AIG", .25);
                SetHoldings("BAC", .25);
                lastAction = Time;
            }
            else if (Time.DayOfWeek == DayOfWeek.Thursday)
            {
                RemoveSecurity("BAC");
                RemoveSecurity("AIG");
                lastAction = Time;
            }
        }

        public override void OnOrderEvent(OrderEvent orderEvent)
        {
            if (orderEvent.Status == OrderStatus.Submitted)
            {
                Console.WriteLine(Time + ": Submitted: " + Transactions.GetOrderById(orderEvent.OrderId));
            }
            if (orderEvent.Status.IsFill())
            {
                Console.WriteLine(Time + ": Filled: " + Transactions.GetOrderById(orderEvent.OrderId));
            }
        }
    }
}