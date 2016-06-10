

using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Commands;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Queues
{
    /// <summary>
    /// Provides an implementation of <see cref="ICommandQueueHandler"/> that never
    /// returns a command. This is useful for local console backtesting when we don't
    /// really want to issue commands
    /// </summary>
    public class EmptyCommandQueueHandler : ICommandQueueHandler
    {
        /// <summary>
        /// NOP
        /// </summary>
        /// <param name="job">unused</param>
        /// <param name="algorithm">The algorithm instance</param>
        public void Initialize(AlgorithmNodePacket job, IAlgorithm algorithm)
        {
        }

        /// <summary>
        /// Return empty enumerable.
        /// </summary>
        /// <returns>null</returns>
        public IEnumerable<ICommand> GetCommands()
        {
            return Enumerable.Empty<ICommand>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }
    }
}