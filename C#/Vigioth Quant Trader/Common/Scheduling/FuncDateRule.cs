using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public class FuncDateRule : IDateRule
    {
        private readonly Func<DateTime, DateTime, IEnumerable<DateTime>> _getDatesFuntion;
        public FuncDateRule(string name, Func<DateTime, DateTime, IEnumerable<DateTime>> getDatesFuntion)
        {
            Name = name;
            _getDatesFuntion = getDatesFuntion;
        }
        public string Name
        {
            get; private set;
        }
        public IEnumerable<DateTime> GetDates(DateTime start, DateTime end)
        {
            return _getDatesFuntion(start, end);
        }
    }
}