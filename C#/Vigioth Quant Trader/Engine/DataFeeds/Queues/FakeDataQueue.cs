

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
using Timer = System.Timers.Timer;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Queues
{
    /// <summary>
    /// This is an implementation of <see cref="IDataQueueHandler"/> used for testing
    /// </summary>
    public class FakeDataQueue : IDataQueueHandler
    {
        private int count;
        private readonly Random _random = new Random();

        private readonly Timer _timer;
        private readonly ConcurrentQueue<BaseData> _ticks;
        private readonly HashSet<Symbol> _symbols;
        private readonly object _sync = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataQueue"/> class to randomly emit data for each symbol
        /// </summary>
        public FakeDataQueue()
        {
            _ticks = new ConcurrentQueue<BaseData>();
            _symbols = new HashSet<Symbol>();
            
            // load it up to start
            PopulateQueue();
            PopulateQueue();
            PopulateQueue();
            PopulateQueue();
            
            _timer = new Timer
            {
                AutoReset = true,
                Enabled = true,
                Interval = 1000,
            };
            
            var lastCount = 0;
            var lastTime = DateTime.Now;
            _timer.Elapsed += (sender, args) =>
            {
                var elapsed = (DateTime.Now - lastTime);
                var ticksPerSecond = (count - lastCount)/elapsed.TotalSeconds;
                Console.WriteLine("TICKS PER SECOND:: " + ticksPerSecond.ToString("000000.0") + " ITEMS IN QUEUE:: " + _ticks.Count);
                lastCount = count;
                lastTime = DateTime.Now;
                PopulateQueue();
            };
        }

        /// <summary>
        /// Get the next ticks from the live trading data queue
        /// </summary>
        /// <returns>IEnumerable list of ticks since the last update.</returns>
        public IEnumerable<BaseData> GetNextTicks()
        {
            BaseData tick;
            while (_ticks.TryDequeue(out tick))
            {
                yield return tick;
                Interlocked.Increment(ref count);
            }
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
                lock (_sync)
                {
                    _symbols.Add(symbol);
                }
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
                lock (_sync)
                {
                    _symbols.Remove(symbol);
                }
            }
        }

        /// <summary>
        /// Pumps a bunch of ticks into the queue
        /// </summary>
        private void PopulateQueue()
        {
            List<Symbol> symbols;
            lock (_sync)
            {
                symbols = _symbols.ToList();
            }

            foreach (var symbol in symbols)
            {
                // emits 500k per second
                for (int i = 0; i < 500000; i++)
                {
                    _ticks.Enqueue(new Tick
                    {
                        Time = DateTime.Now,
                        Symbol = symbol,
                        Value = 10 + (decimal)Math.Abs(Math.Sin(DateTime.Now.TimeOfDay.TotalMinutes)),
                        TickType = TickType.Trade,
                        Quantity = _random.Next(10, (int)_timer.Interval)
                    });
                }
            }
        }
    }
}
