

using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    /// <summary>
    /// Provides an implementation of <see cref="IDataQueueHandler"/> that can be specified
    /// via a function
    /// </summary>
    public class FuncDataQueueHandler : IDataQueueHandler
    {
        private readonly object _lock = new object();
        private readonly HashSet<Symbol> _subscriptions = new HashSet<Symbol>();
        private readonly Func<FuncDataQueueHandler, IEnumerable<BaseData>> _getNextTicksFunction;

        /// <summary>
        /// Gets the subscriptions currently being managed by the queue handler
        /// </summary>
        public List<Symbol> Subscriptions
        {
            get { lock (_lock) return _subscriptions.ToList(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuncDataQueueHandler"/> class
        /// </summary>
        /// <param name="getNextTicksFunction">The functional implementation for the <see cref="GetNextTicks"/> function</param>
        public FuncDataQueueHandler(Func<FuncDataQueueHandler, IEnumerable<BaseData>> getNextTicksFunction)
        {
            _getNextTicksFunction = getNextTicksFunction;
        }

        /// <summary>
        /// Get the next ticks from the live trading data queue
        /// </summary>
        /// <returns>IEnumerable list of ticks since the last update.</returns>
        public IEnumerable<BaseData> GetNextTicks()
        {
            return _getNextTicksFunction(this);
        }

        /// <summary>
        /// Adds the specified symbols to the subscription
        /// </summary>
        /// <param name="job">Job we're subscribing for:</param>
        /// <param name="symbols">The symbols to be added keyed by SecurityType</param>
        public void Subscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                lock (_lock) _subscriptions.Add(symbol);
            }
        }

        /// <summary>
        /// Removes the specified symbols to the subscription
        /// </summary>
        /// <param name="job">Job we're processing.</param>
        /// <param name="symbols">The symbols to be removed keyed by SecurityType</param>
        public void Unsubscribe(LiveNodePacket job, IEnumerable<Symbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                lock (_lock) _subscriptions.Remove(symbol);
            }
        }
    }
}