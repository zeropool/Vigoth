
using System.Linq;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides useful infrastructure methods to the <see cref="Security"/> class.
    /// These are added in this way to avoid mudding the class's public API
    /// </summary>
    public static class SecurityExtensions
    {
        /// <summary>
        /// Determines if all subscriptions for the security are internal feeds
        /// </summary>
        public static bool IsInternalFeed(this Security security)
        {
            return security.Subscriptions.All(x => x.IsInternalFeed);
        }
    }
}
