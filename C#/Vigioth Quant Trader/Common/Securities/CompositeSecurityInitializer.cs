namespace VigiothCapital.QuantTrader.Securities
{
    public class CompositeSecurityInitializer : ISecurityInitializer
    {
        private readonly ISecurityInitializer[] _initializers;
        public CompositeSecurityInitializer(params ISecurityInitializer[] initializers)
        {
            _initializers = initializers;
        }
        public void Initialize(Security security)
        {
            foreach (var initializer in _initializers)
            {
                initializer.Initialize(security);
            }
        }
    }
}