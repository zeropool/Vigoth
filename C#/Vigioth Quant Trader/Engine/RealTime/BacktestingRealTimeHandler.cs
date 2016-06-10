

using System;
using System.Collections.Concurrent;
using System.Linq;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Scheduling;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Engine.RealTime
{
    /// <summary>
    /// Psuedo realtime event processing for backtesting to simulate realtime events in fast forward.
    /// </summary>
    public class BacktestingRealTimeHandler : IRealTimeHandler
    {
        private IAlgorithm _algorithm;
        private IResultHandler _resultHandler;
        // initialize this immediately since the Initialzie method gets called after IAlgorithm.Initialize,
        // so we want to be ready to accept events as soon as possible
        private readonly ConcurrentDictionary<string, ScheduledEvent> _scheduledEvents = new ConcurrentDictionary<string, ScheduledEvent>();

        /// <summary>
        /// Flag indicating the hander thread is completely finished and ready to dispose.
        /// </summary>
        public bool IsActive
        {
            // this doesn't run as its own thread
            get { return false; }
        }

        /// <summary>
        /// Intializes the real time handler for the specified algorithm and job
        /// </summary>
        public void Setup(IAlgorithm algorithm, AlgorithmNodePacket job, IResultHandler resultHandler, IApi api) 
        {
            //Initialize:
            _algorithm = algorithm;
            _resultHandler =  resultHandler;

            // create events for algorithm's end of tradeable dates
            Add(ScheduledEventFactory.EveryAlgorithmEndOfDay(_algorithm, _resultHandler, _algorithm.StartDate, _algorithm.EndDate, ScheduledEvent.AlgorithmEndOfDayDelta));

            // set up the events for each security to fire every tradeable date before market close
            foreach (var security in _algorithm.Securities.Values.Where(x => x.IsInternalFeed()))
            {
                Add(ScheduledEventFactory.EverySecurityEndOfDay(_algorithm, _resultHandler, security, algorithm.StartDate, _algorithm.EndDate, ScheduledEvent.SecurityEndOfDayDelta));
            }

            foreach (var scheduledEvent in _scheduledEvents)
            {
                // zoom past old events
                scheduledEvent.Value.SkipEventsUntil(algorithm.UtcTime);
                // set logging accordingly
                scheduledEvent.Value.IsLoggingEnabled = Log.DebuggingEnabled;
            }
        }
        
        /// <summary>
        /// Normally this would run the realtime event monitoring. Backtesting is in fastforward so the realtime is linked to the backtest clock.
        /// This thread does nothing. Wait until the job is over.
        /// </summary>
        public void Run()
        {
        }

        /// <summary>
        /// Adds the specified event to the schedule
        /// </summary>
        /// <param name="scheduledEvent">The event to be scheduled, including the date/times the event fires and the callback</param>
        public void Add(ScheduledEvent scheduledEvent)
        {
            if (_algorithm != null)
            {
                scheduledEvent.SkipEventsUntil(_algorithm.UtcTime);
            }

            _scheduledEvents[scheduledEvent.Name] = scheduledEvent;
            if (Log.DebuggingEnabled)
            {
                scheduledEvent.IsLoggingEnabled = true;
            }
        }

        /// <summary>
        /// Removes the specified event from the schedule
        /// </summary>
        /// <param name="name">The name of the event to remove</param>
        public void Remove(string name)
        {
            ScheduledEvent scheduledEvent;
            _scheduledEvents.TryRemove(name, out scheduledEvent);
        }

        /// <summary>
        /// Set the time for the realtime event handler.
        /// </summary>
        /// <param name="time">Current time.</param>
        public void SetTime(DateTime time)
        {
            // poke each event to see if it has fired, be sure to invoke these in time order
            foreach (var scheduledEvent in _scheduledEvents)//.OrderBy(x => x.Value.NextEventUtcTime))
            {
                scheduledEvent.Value.Scan(time);
            }
        }

        /// <summary>
        /// Stop the real time thread
        /// </summary>
        public void Exit()
        {
            // this doesn't run as it's own thread, so nothing to exit
        }
    }
}