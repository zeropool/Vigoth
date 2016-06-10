using System;
namespace VigiothCapital.QuantTrader.Securities
{
    public class FuncSecurityInitializer : ISecurityInitializer
    {
        private readonly Action<Security> _initializer;
        public FuncSecurityInitializer(Action<Security> initializer)
        {
            _initializer = initializer;
        }
        public void Initialize(Security security)
        {
            _initializer(security);
        }
    }
}
