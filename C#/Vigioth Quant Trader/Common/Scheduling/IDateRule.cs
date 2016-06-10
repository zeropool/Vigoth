using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public interface IDateRule
    {
        string Name { get; }
        IEnumerable<DateTime> GetDates(DateTime start, DateTime end);
    }
}