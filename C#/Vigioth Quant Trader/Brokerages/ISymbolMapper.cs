

namespace VigiothCapital.QuantTrader.Brokerages
{
    /// <summary>
    /// Provides the mapping between Lean symbols and brokerage specific symbols.
    /// </summary>
    public interface ISymbolMapper
    {
        /// <summary>
        /// Converts a Lean symbol instance to a brokerage symbol
        /// </summary>
        /// <param name="symbol">A Lean symbol instance</param>
        /// <returns>The brokerage symbol</returns>
        string GetBrokerageSymbol(Symbol symbol);

        /// <summary>
        /// Converts a brokerage symbol to a Lean symbol instance
        /// </summary>
        /// <param name="brokerageSymbol">The brokerage symbol</param>
        /// <param name="securityType">The security type</param>
        /// <param name="market">The market</param>
        /// <returns>A new Lean Symbol instance</returns>
        Symbol GetLeanSymbol(string brokerageSymbol, SecurityType securityType, string market);
    }
}
