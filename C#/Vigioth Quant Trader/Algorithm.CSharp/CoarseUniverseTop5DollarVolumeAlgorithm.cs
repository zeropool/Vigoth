

using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Data.UniverseSelection;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// In this algorithm we demonstrate how to use the coarse fundamental data to
    /// define a universe as the top dollar volume
    /// </summary>
    public class CoarseFundamentalTop5Algorithm : QCAlgorithm
    {
        private const int NumberOfSymbols = 5;

        // initialize our changes to nothing
        SecurityChanges _changes = SecurityChanges.None;

        public override void Initialize()
        {
            UniverseSettings.Resolution = Resolution.Daily;

            SetStartDate(2014, 01, 01);
            SetEndDate(2015, 01, 01);
            SetCash(50000);

            // this add universe method accepts a single parameter that is a function that
            // accepts an IEnumerable<CoarseFundamental> and returns IEnumerable<Symbol>
            AddUniverse(CoarseSelectionFunction);
        }

        // sort the data by daily dollar volume and take the top 'NumberOfSymbols'
        public static IEnumerable<Symbol> CoarseSelectionFunction(IEnumerable<CoarseFundamental> coarse)
        {
            // sort descending by daily dollar volume
            var sortedByDollarVolume = coarse.OrderByDescending(x => x.DollarVolume);

            // take the top entries from our sorted collection
            var top5 = sortedByDollarVolume.Take(NumberOfSymbols);

            // we need to return only the symbol objects
            return top5.Select(x => x.Symbol);
        }

        //Data Event Handler: New data arrives here. "TradeBars" type is a dictionary of strings so you can access it by symbol.
        public void OnData(TradeBars data)
        {
            // if we have no changes, do nothing
            if (_changes == SecurityChanges.None) return;

            // liquidate removed securities
            foreach (var security in _changes.RemovedSecurities)
            {
                if (security.Invested)
                {
                    Liquidate(security.Symbol);
                }
            }

            // we want 20% allocation in each security in our universe
            foreach (var security in _changes.AddedSecurities)
            {
                SetHoldings(security.Symbol, 0.2m);
            }

            _changes = SecurityChanges.None;
        }

        // this event fires whenever we have changes to our universe
        public override void OnSecuritiesChanged(SecurityChanges changes)
        {
            _changes = changes;
        }
    }
}