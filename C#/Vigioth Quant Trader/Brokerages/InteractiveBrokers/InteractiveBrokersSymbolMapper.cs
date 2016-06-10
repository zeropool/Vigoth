

using System;

namespace VigiothCapital.QuantTrader.Brokerages.InteractiveBrokers
{
    /// <summary>
    /// Provides the mapping between Lean symbols and InteractiveBrokers symbols.
    /// </summary>
    public class InteractiveBrokersSymbolMapper : ISymbolMapper
    {
        /// <summary>
        /// Converts a Lean symbol instance to an InteractiveBrokers symbol
        /// </summary>
        /// <param name="symbol">A Lean symbol instance</param>
        /// <returns>The InteractiveBrokers symbol</returns>
        public string GetBrokerageSymbol(Symbol symbol)
        {
            if (symbol == null || symbol == Symbol.Empty || string.IsNullOrWhiteSpace(symbol.Value))
                throw new ArgumentException("Invalid symbol: " + (symbol == null ? "null" : symbol.ToString()));

            if (symbol.ID.SecurityType != SecurityType.Forex &&
                symbol.ID.SecurityType != SecurityType.Equity &&
                symbol.ID.SecurityType != SecurityType.Option)
                throw new ArgumentException("Invalid security type: " + symbol.ID.SecurityType);

            if (symbol.ID.SecurityType == SecurityType.Forex && symbol.Value.Length != 6)
                throw new ArgumentException("Forex symbol length must be equal to 6: " + symbol.Value);

            return symbol.Value;
        }

        /// <summary>
        /// Converts an InteractiveBrokers symbol to a Lean symbol instance
        /// </summary>
        /// <param name="brokerageSymbol">The InteractiveBrokers symbol</param>
        /// <param name="securityType">The security type</param>
        /// <param name="market">The market</param>
        /// <returns>A new Lean Symbol instance</returns>
        public Symbol GetLeanSymbol(string brokerageSymbol, SecurityType securityType, string market)
        {
            if (string.IsNullOrWhiteSpace(brokerageSymbol))
                throw new ArgumentException("Invalid symbol: " + brokerageSymbol);

            if (securityType != SecurityType.Forex && securityType != SecurityType.Equity)
                throw new ArgumentException("Invalid security type: " + securityType);

            return Symbol.Create(brokerageSymbol, securityType, market);
        }
    }
}
