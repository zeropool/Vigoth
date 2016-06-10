namespace VigiothCapital.QuantTrader.Securities
{
    public class PatternDayTradingMarginModel : SecurityMarginModel
    {
        private readonly decimal _closedMarginCorrectionFactor;
        public PatternDayTradingMarginModel()
            : this(2.0m, 4.0m)
        {
        }
        public PatternDayTradingMarginModel(decimal closedMarketLeverage, decimal openMarketLeverage)
            : base(openMarketLeverage)
        {
            _closedMarginCorrectionFactor = openMarketLeverage/closedMarketLeverage;
        }
        public override void SetLeverage(Security security, decimal leverage)
        {
        }
        protected override decimal GetInitialMarginRequirement(Security security)
        {
            return base.GetInitialMarginRequirement(security)*GetMarginCorrectionFactor(security);
        }
        protected override decimal GetMaintenanceMarginRequirement(Security security)
        {
            return base.GetMaintenanceMarginRequirement(security)*GetMarginCorrectionFactor(security);
        }
        private decimal GetMarginCorrectionFactor(Security security)
        {
            return security.Exchange.ExchangeOpen ? 1m : _closedMarginCorrectionFactor;
        }
    }
}
