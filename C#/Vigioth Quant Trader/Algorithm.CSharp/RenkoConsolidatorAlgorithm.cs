

using System;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// This algorithm shows how to initialize and use the RenkoConsolidator
    /// </summary>
    public class RenkoConsolidatorAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initializes the algorithm state.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2012, 01, 01);
            SetEndDate(2013, 01, 01);

            AddSecurity(SecurityType.Equity, "SPY");

            // this is the simple constructor that will perform the renko logic to the Value
            // property of the data it receives.

            // break SPY into $2.5 renko bricks and send that data to our 'OnRenkoBar' method
            var renkoClose = new RenkoConsolidator(2.5m);
            renkoClose.DataConsolidated += (sender, consolidated) =>
            {
                // call our event handler for renko data
                HandleRenkoClose(consolidated);
            };

            // register the consolidator for updates
            SubscriptionManager.AddConsolidator("SPY", renkoClose);


            // this is the full constructor that can accept a value selector and a volume selector
            // this allows us to perform the renko logic on values other than Close, even computed values!

            // break SPY into (2*o + h + l + 3*c)/7
            var renko7bar = new RenkoConsolidator<TradeBar>(2.5m, x => (2*x.Open + x.High + x.Low + 3*x.Close)/7m, x => x.Volume);
            renko7bar.DataConsolidated += (sender, consolidated) =>
            {
                HandleRenko7Bar(consolidated);
            };

            // register the consolidator for updates
            SubscriptionManager.AddConsolidator("SPY", renko7bar);
        }

        /// <summary>
        /// We're doing our analysis in the OnRenkoBar method, but the framework verifies that this method exists, so we define it.
        /// </summary>
        public void OnData(TradeBars data)
        {
        }

        /// <summary>
        /// This function is called by our renkoClose consolidator defined in Initialize()
        /// </summary>
        /// <param name="data">The new renko bar produced by the consolidator</param>
        public void HandleRenkoClose(RenkoBar data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings(data.Symbol, 1.0);
            }
            Console.WriteLine("CLOSE - {0} - {1} {2}", data.Time.ToString("o"), data.Open, data.Close);
        }

        /// <summary>
        /// This function is called by our renko7bar onsolidator defined in Initialize()
        /// </summary>
        /// <param name="data">The new renko bar produced by the consolidator</param>
        public void HandleRenko7Bar(RenkoBar data)
        {
            Console.WriteLine("7BAR  - {0} - {1} {2}", data.Time.ToString("o"), data.Open, data.Close);
        }
    }
}
