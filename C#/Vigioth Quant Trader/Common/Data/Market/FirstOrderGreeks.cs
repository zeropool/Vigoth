namespace VigiothCapital.QuantTrader.Data.Market
{
    public class FirstOrderGreeks
    {
        public decimal Delta
        {
            get; private set;
        }
        public decimal Vega
        {
            get; private set;
        }
        public decimal Theta
        {
            get; private set;
        }
        public decimal Rho
        {
            get; private set;
        }
        public decimal Lambda
        {
            get; private set;
        }
        public FirstOrderGreeks()
        {
        }
        public FirstOrderGreeks(decimal delta, decimal vega, decimal theta, decimal rho, decimal lambda)
        {
            Delta = delta;
            Vega = vega;
            Theta = theta;
            Rho = rho;
            Lambda = lambda;
        }
    }
}