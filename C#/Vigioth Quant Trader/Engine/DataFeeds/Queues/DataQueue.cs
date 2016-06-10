

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Queues
{
    /// <summary>
    /// Live Data Queue is the cut out implementation of how to bind a custom live data source 
    /// </summary>
    public class LiveDataQueue : IDataQueueHandler
    {
        /// <summary>
        /// Desktop/Local doesn't support live data from this handler
        /// </summary>
        /// <returns>Tick</returns>
        public virtual IEnumerable<BaseData> GetNextTicks()
        {
            throw new NotImplementedException("VigiothCapital.QuantTrader.Queues.LiveDataQueue has not implemented live data.");
        }

        /// <summary>
        /// Desktop/Local doesn't support live data from this handler
        /// </summary>
        public virtual void Subscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            throw new NotImplementedException("VigiothCapital.QuantTrader.Queues.LiveDataQueue has not implemented live data.");
        }

        /// <summary>
        /// Desktop/Local doesn't support live data from this handler
        /// </summary>
        public virtual void Unsubscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            throw new NotImplementedException("VigiothCapital.QuantTrader.Queues.LiveDataQueue has not implemented live data.");
        }
    }
}
