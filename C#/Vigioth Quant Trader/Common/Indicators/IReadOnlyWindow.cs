using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Indicators
{
    public interface IReadOnlyWindow<out T> : IEnumerable<T>
    {
        int Size { get; }
        int Count { get; }
        decimal Samples { get; }
        T this[int i] { get; }
        bool IsReady { get; }
        T MostRecentlyRemoved { get; }
    }
}