namespace VigiothCapital.QuantTrader.Securities.Equity
{
    public class EquityExchange : SecurityExchange
    {
        public override int TradingDaysPerYear
        {
            get { return 252; }
        }
        public EquityExchange()
            : base(MarketHoursDatabase.FromDataFolder().GetExchangeHours(Market.USA, null, SecurityType.Equity, TimeZones.NewYork))
        {
        }
        public EquityExchange(SecurityExchangeHours exchangeHours)
            : base(exchangeHours)
        {
        }
    }
}