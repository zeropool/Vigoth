

using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.UniverseSelection;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// This algorithm shows how you can handle universe selection in anyway you like,
    /// at any time you like. This algorithm has a list of 10 stocks that it rotates
    /// through every hour.
    /// </summary>
    public class UserDefinedUniverseAlgorithm : QCAlgorithm
    {
        private static readonly IReadOnlyList<string> Symbols = new List<string>
        {
            "SPY", "GOOG", "IBM", "AAPL", "MSFT", "CSCO", "ADBE", "WMT",
        };

        public override void Initialize()
        {
            UniverseSettings.Resolution = Resolution.Hour;

            SetStartDate(2015, 01, 01);
            SetEndDate(2015, 12, 01);

            AddUniverse("my-universe-name", Resolution.Hour, time =>
            {
                var hour = time.Hour;
                var index = hour%Symbols.Count;
                return new List<string> {Symbols[index]};
            });
        }

        public override void OnData(Slice slice)
        {
        }

        public override void OnSecuritiesChanged(SecurityChanges changes)
        {
            foreach (var removed in changes.RemovedSecurities)
            {
                if (removed.Invested)
                {
                    Liquidate(removed.Symbol);
                }
            }

            foreach (var added in changes.AddedSecurities)
            {
                SetHoldings(added.Symbol, 1/(decimal)changes.AddedSecurities.Count);
            }
        }
    }
}
