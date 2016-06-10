using System;
using System.Collections.Generic;
using NodaTime;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class ScheduleManager : IEventSchedule
    {
        private IEventSchedule _eventSchedule;
        private readonly SecurityManager _securities;
        private readonly object _eventScheduleLock = new object();
        private readonly List<ScheduledEvent> _preInitializedEvents;
        public DateRules DateRules { get; private set; }
        public TimeRules TimeRules { get; private set; }
        public ScheduleManager(SecurityManager securities, DateTimeZone timeZone)
        {
            _securities = securities;
            DateRules = new DateRules(securities);
            TimeRules = new TimeRules(securities, timeZone);
            _preInitializedEvents = new List<ScheduledEvent>();
        }
        internal void SetEventSchedule(IEventSchedule eventSchedule)
        {
            if (eventSchedule == null)
            {
                throw new ArgumentNullException("eventSchedule");
            }
            lock (_eventScheduleLock)
            {
                _eventSchedule = eventSchedule;
                foreach (var scheduledEvent in _preInitializedEvents)
                {
                    _eventSchedule.Add(scheduledEvent);
                }
            }
        }
        public void Add(ScheduledEvent scheduledEvent)
        {
            lock (_eventScheduleLock)
            {
                if (_eventSchedule != null)
                {
                    _eventSchedule.Add(scheduledEvent);
                }
                else
                {
                    _preInitializedEvents.Add(scheduledEvent);
                }
            }
        }
        public void Remove(string name)
        {
            lock (_eventScheduleLock)
            {
                if (_eventSchedule != null)
                {
                    _eventSchedule.Remove(name);
                }
                else
                {
                    _preInitializedEvents.RemoveAll(se => se.Name == name);
                }
            }
        }
        public ScheduledEvent On(IDateRule dateRule, ITimeRule timeRule, Action callback)
        {
            return On(dateRule, timeRule, (name, time) => callback());
        }
        public ScheduledEvent On(IDateRule dateRule, ITimeRule timeRule, Action<string, DateTime> callback)
        {
            var name = dateRule.Name + ": " + timeRule.Name;
            return On(name, dateRule, timeRule, callback);
        }
        public ScheduledEvent On(string name, IDateRule dateRule, ITimeRule timeRule, Action callback)
        {
            return On(name, dateRule, timeRule, (n, d) => callback());
        }
        public ScheduledEvent On(string name, IDateRule dateRule, ITimeRule timeRule, Action<string, DateTime> callback)
        {
            var dates = dateRule.GetDates(_securities.UtcTime.Date.AddDays(-1), Time.EndOfTime);
            var eventTimes = timeRule.CreateUtcEventTimes(dates);
            var scheduledEvent = new ScheduledEvent(name, eventTimes, callback);
            Add(scheduledEvent);
            return scheduledEvent;
        }
        #region Fluent Scheduling
        public IFluentSchedulingDateSpecifier Event()
        {
            return new FluentScheduledEventBuilder(this, _securities);
        }
        public IFluentSchedulingDateSpecifier Event(string name)
        {
            return new FluentScheduledEventBuilder(this, _securities, name);
        }
        #endregion
    }
}
