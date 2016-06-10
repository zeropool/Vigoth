

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Brokerages.Backtesting
{
    /// <summary>
    /// Factory type for the <see cref="BacktestingBrokerage"/>
    /// </summary>
    public class BacktestingBrokerageFactory : IBrokerageFactory
    {
        /// <summary>
        /// Gets the type of brokerage produced by this factory
        /// </summary>
        public Type BrokerageType
        {
            get { return typeof(BacktestingBrokerage); }
        }

        /// <summary>
        /// Gets the brokerage data required to run the IB brokerage from configuration
        /// </summary>
        /// <remarks>
        /// The implementation of this property will create the brokerage data dictionary required for
        /// running live jobs. See <see cref="IJobQueueHandler.NextJob"/>
        /// </remarks>
        public Dictionary<string, string> BrokerageData
        {
            get { return new Dictionary<string, string>(); }
        }

        /// <summary>
        /// Gets a new instance of the <see cref="InteractiveBrokersBrokerageModel"/>
        /// </summary>
        public IBrokerageModel BrokerageModel
        {
            get { return new InteractiveBrokersBrokerageModel(); }
        }

        /// <summary>
        /// Creates a new IBrokerage instance
        /// </summary>
        /// <param name="job">The job packet to create the brokerage for</param>
        /// <param name="algorithm">The algorithm instance</param>
        /// <returns>A new brokerage instance</returns>
        public IBrokerage CreateBrokerage(LiveNodePacket job, IAlgorithm algorithm)
        {
            return new BacktestingBrokerage(algorithm);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            // NOP
        }
    }
}
