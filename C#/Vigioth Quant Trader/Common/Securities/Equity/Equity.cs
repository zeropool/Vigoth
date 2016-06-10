using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
namespace VigiothCapital.QuantTrader.Securities.Equity 
{
    public class Equity : Security
    {
        public const int DefaultSettlementDays = 3;
        public static readonly TimeSpan DefaultSettlementTime = new TimeSpan(8, 0, 0);
        public Equity(Symbol symbol, SecurityExchangeHours exchangeHours, Cash quoteCurrency, SymbolProperties symbolProperties)
            : base(symbol,
                quoteCurrency,
                symbolProperties,
                new EquityExchange(exchangeHours),
                new EquityCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new ConstantSlippageModel(0m),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(2m),
                new EquityDataFilter()
                )
        {
            Holdings = new EquityHolding(this);
        }
        public Equity(SecurityExchangeHours exchangeHours, SubscriptionDataConfig config, Cash quoteCurrency, SymbolProperties symbolProperties)
            : base(
                config,
                quoteCurrency,
                symbolProperties,
                new EquityExchange(exchangeHours),
                new EquityCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new ConstantSlippageModel(0m),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(2m),
                new EquityDataFilter()
                )
        {
            Holdings = new EquityHolding(this);
        }
    }
}
