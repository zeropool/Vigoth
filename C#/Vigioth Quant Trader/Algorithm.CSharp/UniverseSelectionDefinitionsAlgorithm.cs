

using System;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Data.UniverseSelection;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// This algorithm shows some of the various helper methods available
    /// when defining universes
    /// </summary>
    public class UniverseSelectionDefinitionsAlgorithm : QCAlgorithm
    {
        private SecurityChanges _changes = SecurityChanges.None;

        public override void Initialize()
        {
            // subscriptions added via universe selection will have this resolution
            UniverseSettings.Resolution = Resolution.Hour;
            // force securities to remain in the universe for a minimm of 30 minutes
            UniverseSettings.MinimumTimeInUniverse = TimeSpan.FromMinutes(30);

            SetStartDate(2013, 10, 07);
            SetEndDate(2013, 10, 11);
            SetCash(100*1000);

            // add universe for the top 50 stocks by dollar volume
            AddUniverse(Universe.DollarVolume.Top(50));

            // add universe for the bottom 50 stocks by dollar volume
            AddUniverse(Universe.DollarVolume.Bottom(50));

            // add universe for the 90th dollar volume percentile
            AddUniverse(Universe.DollarVolume.Percentile(90));

            // add universe for stocks between the 70th and 80th dollar volume percentile
            AddUniverse(Universe.DollarVolume.Percentile(70, 80));
        }

        public void OnData(TradeBars data)
        {
            if (_changes == SecurityChanges.None) return;

            // liquidate securities that fell out of our universe
            foreach (var security in _changes.RemovedSecurities)
            {
                if (security.Invested)
                {
                    Liquidate(security.Symbol);
                }
            }

            // invest in securities just added to our universe
            foreach (var security in _changes.AddedSecurities)
            {
                if (!security.Invested)
                {
                    MarketOrder(security.Symbol, 10);
                }
            }

            _changes = SecurityChanges.None;
        }

        public override void OnSecuritiesChanged(SecurityChanges changes)
        {
            _changes = changes;
        }
    }
}
