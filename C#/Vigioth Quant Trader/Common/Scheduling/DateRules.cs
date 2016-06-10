using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class DateRules
    {
        private readonly SecurityManager _securities;
        public DateRules(SecurityManager securities)
        {
            _securities = securities;
        }
        public IDateRule On(int year, int month, int day)
        {
            var dates = new[] {new DateTime(year, month, day)};
            return new FuncDateRule(string.Join(",", dates.Select(x => x.ToShortDateString())), (start, end) => dates);
        }
        public IDateRule On(params DateTime[] dates)
        {
            dates = dates.Select(x => x.Date).ToArray();
            return new FuncDateRule(string.Join(",", dates.Select(x => x.ToShortDateString())), (start, end) => dates);
        }
        public IDateRule Every(params DayOfWeek[] days)
        {
            var hash = days.ToHashSet();
            return new FuncDateRule(string.Join(",", days), (start, end) => Time.EachDay(start, end).Where(date => hash.Contains(date.DayOfWeek)));
        }
        public IDateRule EveryDay()
        {
            return new FuncDateRule("EveryDay", Time.EachDay);
        }
        public IDateRule EveryDay(Symbol symbol)
        {
            var security = GetSecurity(symbol);
            return new FuncDateRule(symbol.ToString() + ": EveryDay", (start, end) => Time.EachTradeableDay(security, start, end));
        }
        public IDateRule MonthStart()
        {
            return new FuncDateRule("MonthStart", (start, end) => MonthStartIterator(null, start, end));
        }
        public IDateRule MonthStart(Symbol symbol)
        {
            return new FuncDateRule(symbol.ToString() + ": MonthStart", (start, end) => MonthStartIterator(GetSecurity(symbol), start, end));
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
        private static IEnumerable<DateTime> MonthStartIterator(Security security, DateTime start, DateTime end)
        {
            if (security == null)
            {
                foreach (var date in Time.EachDay(start, end))
                {
                    if (date.Day == 1) yield return date;
                }
                yield break;
            }
            var aMonthBeforeStart = start.AddMonths(-1);
            int lastMonth = aMonthBeforeStart.Month;
            foreach (var date in Time.EachTradeableDay(security, aMonthBeforeStart, end))
            {
                if (date.Month != lastMonth)
                {
                    if (date >= start)
                    {
                        yield return date;
                    }
                    lastMonth = date.Month;
                }
            }
        }
    }
}
