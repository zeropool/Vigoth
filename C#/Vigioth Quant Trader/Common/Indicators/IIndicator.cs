using System;
using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Indicators
{
    public interface IIndicator<T> : IComparable<IIndicator<T>>, IComparable
        where T : BaseData
    {
        event IndicatorUpdatedHandler Updated;
        string Name { get; }
        bool IsReady { get; }
        IndicatorDataPoint Current { get; }
        long Samples { get; }
        bool Update(T input);
        void Reset();
    }
}