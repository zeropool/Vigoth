
using System;
namespace VigiothCapital.QuantTrader.Securities
{
    /// <summary>
    /// Represents a pending cash amount waiting for settlement time
    /// </summary>
    public class UnsettledCashAmount
    {
        /// <summary>
        /// The settlement time (in UTC)
        /// </summary>
        public DateTime SettlementTimeUtc { get; private set; }
        /// <summary>
        /// The currency symbol
        /// </summary>
        public string Currency { get; private set; }
        /// <summary>
        /// The amount of cash
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// Creates a new instance of the <see cref="UnsettledCashAmount"/> class
        /// </summary>
        public UnsettledCashAmount(DateTime settlementTimeUtc, string currency, decimal amount)
        {
            SettlementTimeUtc = settlementTimeUtc;
            Currency = currency;
            Amount = amount;
        }
    }
}
