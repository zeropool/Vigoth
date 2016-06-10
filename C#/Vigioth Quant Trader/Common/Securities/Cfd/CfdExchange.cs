namespace VigiothCapital.QuantTrader.Securities.Cfd
{
    public class CfdExchange : SecurityExchange
    {
        public override int TradingDaysPerYear
        {
            get { return 313; }
        }
        public CfdExchange(SecurityExchangeHours exchangeHours)
            : base(exchangeHours)
        {
        }
    }
}
