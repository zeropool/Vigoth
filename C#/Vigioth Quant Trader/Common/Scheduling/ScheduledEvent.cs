using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class ScheduledEvent : IDisposable
    {
        public static readonly TimeSpan SecurityEndOfDayDelta = TimeSpan.FromMinutes(10);
        public static readonly TimeSpan AlgorithmEndOfDayDelta = TimeSpan.FromMinutes(2);
        private bool _needsMoveNext;
        private bool _endOfScheduledEvents;
        private readonly string _name;
        private readonly Action<string, DateTime> _callback;
        private readonly IEnumerator<DateTime> _orderedEventUtcTimes;
        public event Action<string, DateTime> EventFired;
        public bool Enabled
        {
            get; set;
        }
        internal bool IsLoggingEnabled
        {
            get; set;
        }
        public DateTime NextEventUtcTime
        {
            get { return _endOfScheduledEvents ? DateTime.MaxValue : _orderedEventUtcTimes.Current; }
        }
        public string Name
        {
            get { return _name; }
        }
        public ScheduledEvent(string name, DateTime eventUtcTime, Action<string, DateTime> callback = null)
            : this(name, new[] { eventUtcTime }.AsEnumerable().GetEnumerator(), callback)
        {
        }
        public ScheduledEvent(string name, IEnumerable<DateTime> orderedEventUtcTimes, Action<string, DateTime> callback = null)
            : this(name, orderedEventUtcTimes.GetEnumerator(), callback)
        {
        }
        public ScheduledEvent(string name, IEnumerator<DateTime> orderedEventUtcTimes, Action<string, DateTime> callback = null)
        {
            _name = name;
            _callback = callback;
            _orderedEventUtcTimes = orderedEventUtcTimes;
            _endOfScheduledEvents = !_orderedEventUtcTimes.MoveNext();
            Enabled = true;
        }
        internal void Scan(DateTime utcTime)
        {
            if (_endOfScheduledEvents)
            {
                return;
            }
            do
            {
                if (_needsMoveNext)
                {
                    if (!_orderedEventUtcTimes.MoveNext())
                    {
                        if (IsLoggingEnabled)
                        {
                            Log.Trace(string.Format("ScheduledEvent.{0}: Completed scheduled events.", Name));
                        }
                        _endOfScheduledEvents = true;
                        return;
                    }
                    if (IsLoggingEnabled)
                    {
                        Log.Trace(string.Format("ScheduledEvent.{0}: Next event: {1} UTC", Name, _orderedEventUtcTimes.Current.ToString(DateFormat.UI)));
                    }
                }
                if (utcTime >= _orderedEventUtcTimes.Current)
                {
                    if (IsLoggingEnabled)
                    {
                        Log.Trace(string.Format("ScheduledEvent.{0}: Firing at {1} UTC Scheduled at {2} UTC", Name,
                            utcTime.ToString(DateFormat.UI),
                            _orderedEventUtcTimes.Current.ToString(DateFormat.UI))
                            );
                    }
                    OnEventFired(_orderedEventUtcTimes.Current);
                    _needsMoveNext = true;
                }
                else
                {
                    _needsMoveNext = false;
                }
            }
            while (_needsMoveNext);
        }
        internal void SkipEventsUntil(DateTime utcTime)
        {
            if (utcTime < _orderedEventUtcTimes.Current) return;
            while (_orderedEventUtcTimes.MoveNext())
            {
                if (utcTime <= _orderedEventUtcTimes.Current)
                {
                    _needsMoveNext = false;
                    if (IsLoggingEnabled)
                    {
                        Log.Trace(string.Format("ScheduledEvent.{0}: Skipped events before {1}. Next event: {2}", Name,
                            utcTime.ToString(DateFormat.UI),
                            _orderedEventUtcTimes.Current.ToString(DateFormat.UI)
                            ));
                    }
                    return;
                }
            }
            if (IsLoggingEnabled)
            {
                Log.Trace(string.Format("ScheduledEvent.{0}: Exhausted event stream during skip until {1}", Name,
                    utcTime.ToString(DateFormat.UI)
                    ));
            }
            _endOfScheduledEvents = true;
        }
        void IDisposable.Dispose()
        {
            _orderedEventUtcTimes.Dispose();
        }
        protected void OnEventFired(DateTime triggerTime)
        {
            if (!Enabled) return;
            if (_callback != null)
            {
                _callback(_name, _orderedEventUtcTimes.Current);
            }
            var handler = EventFired;
            if (handler != null) handler(_name, triggerTime);
        }
    }
}
