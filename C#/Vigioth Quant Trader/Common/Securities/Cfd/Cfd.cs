using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
namespace VigiothCapital.QuantTrader.Securities.Cfd
{
    public class Cfd : Security
    {
        public Cfd(SecurityExchangeHours exchangeHours, Cash quoteCurrency, SubscriptionDataConfig config, SymbolProperties symbolProperties)
            : base(config,
                quoteCurrency,
                symbolProperties,
                new CfdExchange(exchangeHours),
                new CfdCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new ConstantFeeModel(0),
                new SpreadSlippageModel(),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(50m),
                new CfdDataFilter()
                )
        {
            Holdings = new CfdHolding(this);
        }
        public Cfd(Symbol symbol, SecurityExchangeHours exchangeHours, Cash quoteCurrency, SymbolProperties symbolProperties)
            : base(symbol,
                quoteCurrency,
                symbolProperties,
                new CfdExchange(exchangeHours),
                new CfdCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new ConstantFeeModel(0),
                new SpreadSlippageModel(),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(50m),
                new CfdDataFilter()
                )
        {
            Holdings = new CfdHolding(this);
        }
        public decimal ContractMultiplier
        {
            get { return SymbolProperties.ContractMultiplier; }
        }
        public decimal PipSize
        {
            get { return SymbolProperties.PipSize; }
        }
    }
}
