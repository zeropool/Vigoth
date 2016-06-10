using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Benchmarks
{
    public class SecurityBenchmark : IBenchmark
    {
        private readonly Security _security;
        public SecurityBenchmark(Security security)
        {
            _security = security;
        }
        public decimal Evaluate(DateTime time)
        {
            return _security.Close;
        }
    }
}