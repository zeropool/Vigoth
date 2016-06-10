

using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash
    /// </summary>
    public class UniverseSelectionRegressionAlgorithm : QCAlgorithm
    {
        private HashSet<Symbol> _delistedSymbols = new HashSet<Symbol>(); 
        private SecurityChanges _changes;
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            UniverseSettings.Resolution = Resolution.Daily;

            SetStartDate(2014, 03, 22);  //Set Start Date
            SetEndDate(2014, 04, 07);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data

            // security that exists with no mappings
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Daily);
            // security that doesn't exist until half way in backtest (comes in as GOOCV)
            AddSecurity(SecurityType.Equity, "GOOG", Resolution.Daily);

            AddUniverse(coarse =>
            {
                // select the various google symbols over the period
                return from c in coarse
                       let sym = c.Symbol.Value
                       where sym == "GOOG" || sym == "GOOCV" || sym == "GOOAV" || sym == "GOOGL"
                       select c.Symbol;
            });
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (Transactions.OrdersCount == 0)
            {
                MarketOrder("SPY", 100);
            }

            foreach (var kvp in data.Delistings)
            {
                _delistedSymbols.Add(kvp.Key);
            }

            if (Time.Date == new DateTime(2014, 04, 07))
            {
                Liquidate();
                return;
            }

            if (_changes != null && _changes.AddedSecurities.All(x => data.Bars.ContainsKey(x.Symbol)))
            {
                foreach (var security in _changes.AddedSecurities)
                {
                    Console.WriteLine(Time + ": Added Security: " + security.Symbol);
                    MarketOnOpenOrder(security.Symbol, 100);
                }
                foreach (var security in _changes.RemovedSecurities)
                {
                    Console.WriteLine(Time + ": Removed Security: " + security.Symbol);
                    if (!_delistedSymbols.Contains(security.Symbol))
                    {
                        MarketOnOpenOrder(security.Symbol, -100);
                    }
                }
                _changes = null;
            }
        }

        #region Overrides of QCAlgorithm

        public override void OnSecuritiesChanged(SecurityChanges changes)
        {
            _changes = changes;
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

        #endregion
    }
}