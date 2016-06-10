using System;
namespace VigiothCapital.QuantTrader.Benchmarks
{
    public interface IBenchmark
    {
        decimal Evaluate(DateTime time);
    }
}
