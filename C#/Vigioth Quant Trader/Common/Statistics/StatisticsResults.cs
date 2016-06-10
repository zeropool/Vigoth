
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Statistics
{
    /// <summary>
    /// The <see cref="StatisticsResults"/> class represents total and rolling statistics for an algorithm
    /// </summary>
    public class StatisticsResults
    {
        /// <summary>
        /// The performance of the algorithm over the whole period
        /// </summary>
        public AlgorithmPerformance TotalPerformance { get; private set; }
        /// <summary>
        /// The rolling performance of the algorithm over 1, 3, 6, 12 month periods
        /// </summary>
        public Dictionary<string, AlgorithmPerformance> RollingPerformances { get; private set; }
        /// <summary>
        /// Returns a summary of the algorithm performance as a dictionary
        /// </summary>
        public Dictionary<string, string> Summary { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsResults"/> class
        /// </summary>
        /// <param name="totalPerformance">The algorithm total performance</param>
        /// <param name="rollingPerformances">The algorithm rolling performances</param>
        /// <param name="summary">The summary performance dictionary</param>
        public StatisticsResults(AlgorithmPerformance totalPerformance, Dictionary<string, AlgorithmPerformance> rollingPerformances, Dictionary<string, string> summary)
        {
            TotalPerformance = totalPerformance;
            RollingPerformances = rollingPerformances;
            Summary = summary;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsResults"/> class
        /// </summary>
        public StatisticsResults()
        {
            TotalPerformance = new AlgorithmPerformance();
            RollingPerformances = new Dictionary<string, AlgorithmPerformance>();
            Summary = new Dictionary<string, string>();
        }
    }
}
