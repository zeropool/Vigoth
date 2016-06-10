using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Orders.Fees;
using VigiothCapital.QuantTrader.Orders.Fills;
using VigiothCapital.QuantTrader.Orders.Slippage;
namespace VigiothCapital.QuantTrader.Securities.Forex 
{
    public class Forex : Security
    {
        public Forex(SecurityExchangeHours exchangeHours, Cash quoteCurrency, SubscriptionDataConfig config, SymbolProperties symbolProperties)
            : base(config,
                quoteCurrency,
                symbolProperties,
                new ForexExchange(exchangeHours),
                new ForexCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new SpreadSlippageModel(),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(50m),
                new ForexDataFilter()
                )
        {
            Holdings = new ForexHolding(this);
            string baseCurrencySymbol, quoteCurrencySymbol;
            DecomposeCurrencyPair(config.Symbol.Value, out baseCurrencySymbol, out quoteCurrencySymbol);
            BaseCurrencySymbol = baseCurrencySymbol;
        }
        public Forex(Symbol symbol, SecurityExchangeHours exchangeHours, Cash quoteCurrency, SymbolProperties symbolProperties)
            : base(symbol,
                quoteCurrency,
                symbolProperties,
                new ForexExchange(exchangeHours),
                new ForexCache(),
                new SecurityPortfolioModel(),
                new ImmediateFillModel(),
                new InteractiveBrokersFeeModel(),
                new SpreadSlippageModel(),
                new ImmediateSettlementModel(),
                Securities.VolatilityModel.Null,
                new SecurityMarginModel(50m),
                new ForexDataFilter()
                )
        {
            Holdings = new ForexHolding(this);
            string baseCurrencySymbol, quoteCurrencySymbol;
            DecomposeCurrencyPair(symbol.Value, out baseCurrencySymbol, out quoteCurrencySymbol);
            BaseCurrencySymbol = baseCurrencySymbol;
        }
        public string BaseCurrencySymbol { get; private set; }
        public static void DecomposeCurrencyPair(string currencyPair, out string baseCurrency, out string quoteCurrency)
        {
            if (currencyPair == null || currencyPair.Length != 6)
            {
                throw new ArgumentException("Currency pairs must be exactly 6 characters: " + currencyPair);
            }
            baseCurrency = currencyPair.Substring(0, 3);
            quoteCurrency = currencyPair.Substring(3);
        }
    }
}
