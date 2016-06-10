using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class FuncTimeRule : ITimeRule
    {
        private readonly Func<IEnumerable<DateTime>, IEnumerable<DateTime>> _createUtcEventTimesFunction;
        public FuncTimeRule(string name, Func<IEnumerable<DateTime>, IEnumerable<DateTime>> createUtcEventTimesFunction)
        {
            Name = name;
            _createUtcEventTimesFunction = createUtcEventTimesFunction;
        }
        public string Name
        {
            get; private set;
        }
        public IEnumerable<DateTime> CreateUtcEventTimes(IEnumerable<DateTime> dates)
        {
            return _createUtcEventTimesFunction(dates);
        }
    }
}