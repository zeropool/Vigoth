
using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Statistics
{
    /// <summary>
    /// The <see cref="AlgorithmPerformance"/> class is a wrapper for <see cref="TradeStatistics"/> and <see cref="PortfolioStatistics"/>
    /// </summary>
    public class AlgorithmPerformance
    {
        /// <summary>
        /// The algorithm statistics on closed trades
        /// </summary>
        public TradeStatistics TradeStatistics { get; private set; }
        /// <summary>
        /// The algorithm statistics on portfolio
        /// </summary>
        public PortfolioStatistics PortfolioStatistics { get; private set; }
        /// <summary>
        /// The list of closed trades
        /// </summary>
        public List<Trade> ClosedTrades { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlgorithmPerformance"/> class
        /// </summary>
        /// <param name="trades">The list of closed trades</param>
        /// <param name="profitLoss">Trade record of profits and losses</param>
        /// <param name="equity">The list of daily equity values</param>
        /// <param name="listPerformance">The list of algorithm performance values</param>
        /// <param name="listBenchmark">The list of benchmark values</param>
        /// <param name="startingCapital">The algorithm starting capital</param>
        public AlgorithmPerformance(
            List<Trade> trades,
            SortedDictionary<DateTime, decimal> profitLoss,
            SortedDictionary<DateTime, decimal> equity,
            List<double> listPerformance,
            List<double> listBenchmark, 
            decimal startingCapital)
        {
            TradeStatistics = new TradeStatistics(trades);
            PortfolioStatistics = new PortfolioStatistics(profitLoss, equity, listPerformance, listBenchmark, startingCapital);
            ClosedTrades = trades;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlgorithmPerformance"/> class
        /// </summary>
        public AlgorithmPerformance()
        {
            TradeStatistics = new TradeStatistics();
            PortfolioStatistics = new PortfolioStatistics();
            ClosedTrades = new List<Trade>();
        }
    }
}
