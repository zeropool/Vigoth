using System;
using System.Linq;
using NodaTime;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class FluentScheduledEventBuilder : IFluentSchedulingDateSpecifier, IFluentSchedulingRunnable
    {
        private IDateRule _dateRule;
        private ITimeRule _timeRule;
        private Func<DateTime, bool> _predicate;
        private readonly string _name;
        private readonly ScheduleManager _schedule;
        private readonly SecurityManager _securities;
        public FluentScheduledEventBuilder(ScheduleManager schedule, SecurityManager securities, string name = null)
        {
            _name = name;
            _schedule = schedule;
            _securities = securities;
        }
        private FluentScheduledEventBuilder SetTimeRule(ITimeRule rule)
        {
            if (_timeRule == null)
            {
                _timeRule = rule;
                return this;
            }
            var compositeTimeRule = _timeRule as CompositeTimeRule;
            if (compositeTimeRule != null)
            {
                var rules = compositeTimeRule.Rules;
                _timeRule = new CompositeTimeRule(rules.Concat(new[] { rule }));
                return this;
            }
            _timeRule = new CompositeTimeRule(_timeRule, rule);
            return this;
        }
        #region DateRules and TimeRules delegation
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.Every(params DayOfWeek[] days)
        {
            _dateRule = _schedule.DateRules.Every(days);
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.EveryDay()
        {
            _dateRule = _schedule.DateRules.EveryDay();
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.EveryDay(Symbol symbol)
        {
            _dateRule = _schedule.DateRules.EveryDay(symbol);
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.MonthStart()
        {
            _dateRule = _schedule.DateRules.MonthStart();
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.MonthStart(Symbol symbol)
        {
            _dateRule = _schedule.DateRules.MonthStart(symbol);
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.Where(Func<DateTime, bool> predicate)
        {
            _predicate = _predicate == null
                ? predicate
                : (time => _predicate(time) && predicate(time));
            return this;
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.At(TimeSpan timeOfDay)
        {
            return SetTimeRule(_schedule.TimeRules.At(timeOfDay));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.AfterMarketOpen(Symbol symbol, double minutesAfterOpen, bool extendedMarketOpen)
        {
            return SetTimeRule(_schedule.TimeRules.AfterMarketOpen(symbol, minutesAfterOpen, extendedMarketOpen));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.BeforeMarketClose(Symbol symbol, double minuteBeforeClose, bool extendedMarketClose)
        {
            return SetTimeRule(_schedule.TimeRules.BeforeMarketClose(symbol, minuteBeforeClose, extendedMarketClose));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.Every(TimeSpan interval)
        {
            return SetTimeRule(_schedule.TimeRules.Every(interval));
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingTimeSpecifier.Where(Func<DateTime, bool> predicate)
        {
            _predicate = _predicate == null
                ? predicate
                : (time => _predicate(time) && predicate(time));
            return this;
        }
        ScheduledEvent IFluentSchedulingRunnable.Run(Action callback)
        {
            return ((IFluentSchedulingRunnable)this).Run((name, time) => callback());
        }
        ScheduledEvent IFluentSchedulingRunnable.Run(Action<DateTime> callback)
        {
            return ((IFluentSchedulingRunnable)this).Run((name, time) => callback(time));
        }
        ScheduledEvent IFluentSchedulingRunnable.Run(Action<string, DateTime> callback)
        {
            var name = _name ?? _dateRule.Name + ": " + _timeRule.Name;
            var dates = _dateRule.GetDates(_securities.UtcTime.Date.AddDays(-1), Time.EndOfTime);
            var eventTimes = _timeRule.CreateUtcEventTimes(dates);
            if (_predicate != null)
            {
                eventTimes = eventTimes.Where(_predicate);
            }
            var scheduledEvent = new ScheduledEvent(name, eventTimes, callback);
            _schedule.Add(scheduledEvent);
            return scheduledEvent;
        }
        IFluentSchedulingRunnable IFluentSchedulingRunnable.Where(Func<DateTime, bool> predicate)
        {
            _predicate = _predicate == null
                ? predicate
                : (time => _predicate(time) && predicate(time));
            return this;
        }
        IFluentSchedulingRunnable IFluentSchedulingRunnable.DuringMarketHours(Symbol symbol, bool extendedMarket)
        {
            var security = GetSecurity(symbol);
            Func<DateTime, bool> predicate = time =>
            {
                var localTime = time.ConvertFromUtc(security.Exchange.TimeZone);
                return security.Exchange.IsOpenDuringBar(localTime, localTime, extendedMarket);
            };
            _predicate = _predicate == null
                ? predicate
                : (time => _predicate(time) && predicate(time));
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.On(int year, int month, int day)
        {
            _dateRule = _schedule.DateRules.On(year, month, day);
            return this;
        }
        IFluentSchedulingTimeSpecifier IFluentSchedulingDateSpecifier.On(params DateTime[] dates)
        {
            _dateRule = _schedule.DateRules.On(dates);
            return this;
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.At(int hour, int minute, int second)
        {
            return SetTimeRule(_schedule.TimeRules.At(hour, minute, second));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.At(int hour, int minute, DateTimeZone timeZone)
        {
            return SetTimeRule(_schedule.TimeRules.At(hour, minute, 0, timeZone));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.At(int hour, int minute, int second, DateTimeZone timeZone)
        {
            return SetTimeRule(_schedule.TimeRules.At(hour, minute, second, timeZone));
        }
        IFluentSchedulingRunnable IFluentSchedulingTimeSpecifier.At(TimeSpan timeOfDay, DateTimeZone timeZone)
        {
            return SetTimeRule(_schedule.TimeRules.At(timeOfDay, timeZone));
        }
        private Security GetSecurity(Symbol symbol)
        {
            Security security;
            if (!_securities.TryGetValue(symbol, out security))
            {
                throw new Exception(symbol.ToString() + " not found in portfolio. Request this data when initializing the algorithm.");
            }
            return security;
        }
        #endregion
    }
    public interface IFluentSchedulingDateSpecifier
    {
        IFluentSchedulingTimeSpecifier Where(Func<DateTime, bool> predicate);
        IFluentSchedulingTimeSpecifier On(int year, int month, int day);
        IFluentSchedulingTimeSpecifier On(params DateTime[] dates);
        IFluentSchedulingTimeSpecifier Every(params DayOfWeek[] days);
        IFluentSchedulingTimeSpecifier EveryDay();
        IFluentSchedulingTimeSpecifier EveryDay(Symbol symbol);
        IFluentSchedulingTimeSpecifier MonthStart();
        IFluentSchedulingTimeSpecifier MonthStart(Symbol symbol);
    }
    public interface IFluentSchedulingTimeSpecifier
    {
        IFluentSchedulingTimeSpecifier Where(Func<DateTime, bool> predicate);
        IFluentSchedulingRunnable At(int hour, int minute, int second = 0);
        IFluentSchedulingRunnable At(int hour, int minute, DateTimeZone timeZone);
        IFluentSchedulingRunnable At(int hour, int minute, int second, DateTimeZone timeZone);
        IFluentSchedulingRunnable At(TimeSpan timeOfDay, DateTimeZone timeZone);
        IFluentSchedulingRunnable At(TimeSpan timeOfDay);
        IFluentSchedulingRunnable Every(TimeSpan interval);
        IFluentSchedulingRunnable AfterMarketOpen(Symbol symbol, double minutesAfterOpen = 0, bool extendedMarketOpen = false);
        IFluentSchedulingRunnable BeforeMarketClose(Symbol symbol, double minuteBeforeClose = 0, bool extendedMarketClose = false);
    }
    public interface IFluentSchedulingRunnable : IFluentSchedulingTimeSpecifier
    {
        new IFluentSchedulingRunnable Where(Func<DateTime, bool> predicate);
        IFluentSchedulingRunnable DuringMarketHours(Symbol symbol, bool extendedMarket = false);
        ScheduledEvent Run(Action callback);
        ScheduledEvent Run(Action<DateTime> callback);
        ScheduledEvent Run(Action<string, DateTime> callback);
    }
}