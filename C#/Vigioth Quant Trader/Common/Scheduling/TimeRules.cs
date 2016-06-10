using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class TimeRules
    {
        private DateTimeZone _timeZone;
        private readonly SecurityManager _securities;
        public TimeRules(SecurityManager securities, DateTimeZone timeZone)
        {
            _securities = securities;
            _timeZone = timeZone;
        }
        public void SetDefaultTimeZone(DateTimeZone timeZone)
        {
            _timeZone = timeZone;
        }
        public ITimeRule At(TimeSpan timeOfDay)
        {
            return At(timeOfDay, _timeZone);
        }
        public ITimeRule At(int hour, int minute, int second = 0)
        {
            return At(new TimeSpan(hour, minute, second), _timeZone);
        }
        public ITimeRule At(int hour, int minute, DateTimeZone timeZone)
        {
            return At(new TimeSpan(hour, minute, 0), timeZone);
        }
        public ITimeRule At(int hour, int minute, int second, DateTimeZone timeZone)
        {
            return At(new TimeSpan(hour, minute, second), timeZone);
        }
        public ITimeRule At(TimeSpan timeOfDay, DateTimeZone timeZone)
        {
            var name = string.Join(",", timeOfDay.TotalHours.ToString("0.##"));
            Func<IEnumerable<DateTime>, IEnumerable<DateTime>> applicator = dates =>
                from date in dates
                let localEventTime = date + timeOfDay
                let utcEventTime = localEventTime.ConvertToUtc(timeZone)
                select utcEventTime;
            return new FuncTimeRule(name, applicator);
        }
        public ITimeRule Every(TimeSpan interval)
        {
            var name = "Every " + interval.TotalMinutes.ToString("0.##") + " min";
            Func<IEnumerable<DateTime>, IEnumerable<DateTime>> applicator = dates => EveryIntervalIterator(dates, interval);
            return new FuncTimeRule(name, applicator);
        }
        public ITimeRule AfterMarketOpen(Symbol symbol, double minutesAfterOpen = 0, bool extendedMarketOpen = false)
        {
            var security = GetSecurity(symbol);
            var type = extendedMarketOpen ? "ExtendedMarketOpen" : "MarketOpen";
            var name = string.Format("{0}: {1} min after {2}", symbol, minutesAfterOpen.ToString("0.##"), type);
            var timeAfterOpen = TimeSpan.FromMinutes(minutesAfterOpen);
            Func<IEnumerable<DateTime>, IEnumerable<DateTime>> applicator = dates =>
                from date in dates
                where security.Exchange.DateIsOpen(date)
                let marketOpen = security.Exchange.Hours.GetNextMarketOpen(date, extendedMarketOpen)
                let localEventTime = marketOpen + timeAfterOpen
                let utcEventTime = localEventTime.ConvertToUtc(security.Exchange.TimeZone)
                select utcEventTime;
            return new FuncTimeRule(name, applicator);
        }
        public ITimeRule BeforeMarketClose(Symbol symbol, double minutesBeforeClose = 0, bool extendedMarketClose = false)
        {
            var security = GetSecurity(symbol);
            var type = extendedMarketClose ? "ExtendedMarketClose" : "MarketClose";
            var name = string.Format("{0}: {1} min before {2}", security.Symbol, minutesBeforeClose.ToString("0.##"), type);
            var timeBeforeClose = TimeSpan.FromMinutes(minutesBeforeClose);
            Func<IEnumerable<DateTime>, IEnumerable<DateTime>> applicator = dates =>
                from date in dates
                where security.Exchange.DateIsOpen(date)
                let marketClose = security.Exchange.Hours.GetNextMarketClose(date, extendedMarketClose)
                let localEventTime = marketClose - timeBeforeClose
                let utcEventTime = localEventTime.ConvertToUtc(security.Exchange.TimeZone)
                select utcEventTime;
            return new FuncTimeRule(name, applicator);
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
        private static IEnumerable<DateTime> EveryIntervalIterator(IEnumerable<DateTime> dates, TimeSpan interval)
        {
            foreach (var date in dates)
            {
                for (var time = TimeSpan.Zero; time < Time.OneDay; time += interval)
                {
                    yield return date + time;
                }
            }
        }
    }
}