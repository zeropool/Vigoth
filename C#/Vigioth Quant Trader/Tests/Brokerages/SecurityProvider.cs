


using System.Collections.Generic;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Brokerages
{
    /// <summary>
    /// Provides a test implementation of a security provider
    /// </summary>
    public class SecurityProvider : ISecurityProvider
    {
        private readonly Dictionary<Symbol, Security> _securities;

        public SecurityProvider(Dictionary<Symbol, Security> securities)
        {
            _securities = securities;
        }

        public SecurityProvider()
        {
            _securities = new Dictionary<Symbol, Security>();
        }

        public Security this[Symbol symbol]
        {
            get { return _securities[symbol]; }
            set { _securities[symbol] = value; }
        }

        public Security GetSecurity(Symbol symbol)
        {
            Security holding;
            _securities.TryGetValue(symbol, out holding);
            return holding;
        }

        public bool TryGetValue(Symbol symbol, out Security security)
        {
            return _securities.TryGetValue(symbol, out security);
        }
    }
}