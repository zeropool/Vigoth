using System;
namespace VigiothCapital.QuantTrader.Benchmarks
{
    public class FuncBenchmark : IBenchmark
    {
        private readonly Func<DateTime, decimal> _benchmark;
        public FuncBenchmark(Func<DateTime, decimal> benchmark)
        {
            if (benchmark == null)
            {
                throw new ArgumentNullException("benchmark");
            }
            _benchmark = benchmark;
        }
        public decimal Evaluate(DateTime time)
        {
            return _benchmark(time);
        }
    }
}