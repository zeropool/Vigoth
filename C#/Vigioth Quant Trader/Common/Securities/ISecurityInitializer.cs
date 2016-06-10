namespace VigiothCapital.QuantTrader.Securities
{
    public interface ISecurityInitializer
    {
        void Initialize(Security security);
    }
    public static class SecurityInitializer
    {
        public static readonly ISecurityInitializer Null = new NullSecurityInitializer();
        private sealed class NullSecurityInitializer : ISecurityInitializer
        {
            public void Initialize(Security security) { }
        }
    }
}