using System;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface ISettlementModel
    {
        void ApplyFunds(SecurityPortfolioManager portfolio, Security security, DateTime applicationTimeUtc, string currency, decimal amount);
    }
}
