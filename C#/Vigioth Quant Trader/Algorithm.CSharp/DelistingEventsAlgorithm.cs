

using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Showcases the delisting event of QCAlgorithm
    /// </summary>
    /// <remarks>
    /// The data for this algorithm isn't in the github repo, so this will need to be run on the QC site
    /// </remarks>
    public class DelistingEventsAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2007, 05, 16);  //Set Start Date
            SetEndDate(2007, 05, 25);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "AAA", Resolution.Daily);
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Daily);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (Transactions.OrdersCount == 0)
            {
                SetHoldings("AAA", 1);
                Debug("Purchased Stock");
            }

            foreach (var kvp in data.Bars)
            {
                var symbol = kvp.Key;
                var tradeBar = kvp.Value;
                Console.WriteLine("OnData(Slice): {0}: {1}: {2}", Time, symbol, tradeBar.Close.ToString("0.00"));
            }

            // the slice can also contain delisting data: data.Delistings in a dictionary string->Delisting
        }

        public void OnData(Delistings data)
        {
            foreach (var kvp in data)
            {
                var symbol = kvp.Key;
                var delisting = kvp.Value;
                if (delisting.Type == DelistingType.Warning)
                {
                    Console.WriteLine("OnData(Delistings): {0}: {1} will be delisted at end of day today.", Time, symbol);
                }
                if (delisting.Type == DelistingType.Delisted)
                {
                    Console.WriteLine("OnData(Delistings): {0}: {1} has been delisted.", Time, symbol);
                }
            }
        }

        public override void OnOrderEvent(OrderEvent orderEvent)
        {
            Console.WriteLine("OnOrderEvent(OrderEvent): {0}: {1}", Time, orderEvent);
        }
    }
}
