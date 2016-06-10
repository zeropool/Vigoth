using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Scheduling
{
    public interface ITimeRule
    {
        string Name { get; }
        IEnumerable<DateTime> CreateUtcEventTimes(IEnumerable<DateTime> dates);
    }
}