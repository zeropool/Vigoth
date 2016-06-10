namespace VigiothCapital.QuantTrader.Securities
{
    public interface ISecurityProvider
    {
        Security GetSecurity(Symbol symbol);
    }
    public static class SecurityProviderExtensions
    {
        public static decimal GetHoldingsQuantity(this ISecurityProvider provider, Symbol symbol)
        {
            var security = provider.GetSecurity(symbol);
            return security == null ? 0 : security.Holdings.Quantity;
        }
    }
}