namespace VigiothCapital.QuantTrader.Securities.Forex 
{
    public class ForexExchange : SecurityExchange
    {
        public override int TradingDaysPerYear
        {
            get { return 313; }
        }
        public ForexExchange()
            : base(MarketHoursDatabase.FromDataFolder().GetExchangeHours(Market.FXCM, null, SecurityType.Forex, TimeZones.NewYork))
        {
        }
        public ForexExchange(SecurityExchangeHours exchangeHours)
            : base(exchangeHours)
        {
        }
    }
}