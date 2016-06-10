

using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Brokerages.Backtesting;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Brokerages.Paper
{
    /// <summary>
    /// Paper Trading Brokerage
    /// </summary>
    public class PaperBrokerage : BacktestingBrokerage
    {
        private readonly LiveNodePacket _job;

        /// <summary>
        /// Creates a new PaperBrokerage
        /// </summary>
        /// <param name="algorithm">The algorithm under analysis</param>
        /// <param name="job">The job packet</param>
        public PaperBrokerage(IAlgorithm algorithm, LiveNodePacket job) 
            : base(algorithm, "Paper Brokerage")
        {
            _job = job;
        }

        /// <summary>
        /// Gets the current cash balance for each currency held in the brokerage account
        /// </summary>
        /// <returns>The current cash balance for each currency available for trading</returns>
        public override List<Cash> GetCashBalance()
        {
            string value;
            if (_job.BrokerageData.TryGetValue("project-paper-equity", out value))
            {
                // remove the key, we really only want to return the cached value on the first request
                _job.BrokerageData.Remove("project-paper-equity");
                return new List<Cash>{new Cash("USD", decimal.Parse(value), 1)};
            }

            // if we've already begun running, just return the current state
            return Algorithm.Portfolio.CashBook.Values.ToList();
        }
    }
}
