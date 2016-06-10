using System;
namespace VigiothCapital.QuantTrader.Securities
{
    public class ImmediateSettlementModel : ISettlementModel
    {
        public void ApplyFunds(SecurityPortfolioManager portfolio, Security security, DateTime applicationTimeUtc, string currency, decimal amount)
        {
            portfolio.CashBook[currency].AddAmount(amount);
        }
    }
}
