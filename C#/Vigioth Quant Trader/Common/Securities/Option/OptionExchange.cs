namespace VigiothCapital.QuantTrader.Securities.Option
{
    public class OptionExchange : SecurityExchange
    {
        public override int TradingDaysPerYear
        {
            get { return 252; }
        }
        public OptionExchange(SecurityExchangeHours exchangeHours)
            : base(exchangeHours)
        {
        }
    }
}