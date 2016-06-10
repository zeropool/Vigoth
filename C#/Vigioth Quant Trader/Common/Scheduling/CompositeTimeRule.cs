using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class CompositeTimeRule : ITimeRule
    {
        public readonly IReadOnlyList<ITimeRule> Rules;
        public CompositeTimeRule(params ITimeRule[] timeRules)
            : this((IEnumerable<ITimeRule>) timeRules)
        {
        }
        public CompositeTimeRule(IEnumerable<ITimeRule> timeRules)
        {
            Rules = timeRules.ToList();
        }
        public string Name
        {
            get { return string.Join(",", Rules.Select(x => x.Name)); }
        }
        public IEnumerable<DateTime> CreateUtcEventTimes(IEnumerable<DateTime> dates)
        {
            foreach (var date in dates)
            {
                var enumerable = new[] {date};
                var times = Rules.SelectMany(time => time.CreateUtcEventTimes(enumerable)).ToHashSet().OrderBy(x => x);
                foreach (var time in times)
                {
                    yield return time;
                }
            }
        }
    }
}
