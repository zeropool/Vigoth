using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface IVolatilityModel
    {
        decimal Volatility { get; }
        void Update(Security security, BaseData data);
    }
    public static class VolatilityModel
    {
        public static readonly IVolatilityModel Null = new NullVolatilityModel();
        private sealed class NullVolatilityModel : IVolatilityModel
        {
            public decimal Volatility { get; private set; }
            public void Update(Security security, BaseData data) { }
        }
    }
}