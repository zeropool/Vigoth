
namespace VigiothCapital.QuantTrader.Securities
{
    /// <summary>
    /// Represents common properties for a specific security, uniquely identified by market, symbol and security type
    /// </summary>
    public class SymbolProperties
    {
        /// <summary>
        /// The description of the security
        /// </summary>
        public string Description
        {
            get; 
            private set;
        }
        /// <summary>
        /// The quote currency of the security
        /// </summary>
        public string QuoteCurrency
        {
            get; 
            private set;
        }
        /// <summary>
        /// The contract multiplier for the security
        /// </summary>
        public decimal ContractMultiplier
        {
            get; 
            private set;
        }
        /// <summary>
        /// The pip size (tick size) for the security
        /// </summary>
        public decimal PipSize
        {
            get; 
            private set;
        }
        /// <summary>
        /// Creates an instance of the <see cref="SymbolProperties"/> class
        /// </summary>
        public SymbolProperties(string description, string quoteCurrency, decimal contractMultiplier, decimal pipSize)
        {
            Description = description;
            QuoteCurrency = quoteCurrency;
            ContractMultiplier = contractMultiplier;
            PipSize = pipSize;
        }
        /// <summary>
        /// Gets a default instance of the <see cref="SymbolProperties"/> class for the specified <paramref name="quoteCurrency"/>
        /// </summary>
        /// <param name="quoteCurrency">The quote currency of the symbol</param>
        /// <returns>A default instance of the<see cref="SymbolProperties"/> class</returns>
        public static SymbolProperties GetDefault(string quoteCurrency)
        {
            return new SymbolProperties("", quoteCurrency.ToUpper(), 1, 0.01m);
        }
    }
}
