using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
namespace VigiothCapital.QuantTrader.Securities.Option
{
    public class Option : Security
    {
        public const int DefaultSettlementDays = 1;
        public static readonly TimeSpan DefaultSettlementTime = new TimeSpan(8, 0, 0);
        public Option(SecurityExchangeHours exchangeHours, SubscriptionDataConfig config, Cash quoteCurrency, SymbolProperties symbolProperties)
            : base(config,
                quoteCurrency,
                symbolProperties,
                new OptionExchange(exchangeHours),
                new OptionCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new SpreadSlippageModel(),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(2m),
                new OptionDataFilter()
                )
        {
            PriceModel = new CurrentPriceOptionPriceModel();
            ContractFilter = new StrikeExpiryOptionFilter(-5, 5, TimeSpan.Zero, TimeSpan.FromDays(35));
        }
        public Security Underlying
        {
            get; set;
        }
        public IOptionPriceModel PriceModel
        {
            get; set;
        }
        public IDerivativeSecurityFilter ContractFilter
        {
            get; set;
        }
        public void SetFilter(int minStrike, int maxStrike)
        {
            SetFilter(minStrike, maxStrike, TimeSpan.Zero, TimeSpan.FromDays(35));
        }
        public void SetFilter(int minStrike, int maxStrike, TimeSpan minExpiry, TimeSpan maxExpiry)
        {
            ContractFilter = new StrikeExpiryOptionFilter(minStrike, maxStrike, minExpiry, maxExpiry);
        }
    }
}
