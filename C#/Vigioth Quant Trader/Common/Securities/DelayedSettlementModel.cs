using System;
namespace VigiothCapital.QuantTrader.Securities
{
    public class DelayedSettlementModel : ISettlementModel
    {
        private readonly int _numberOfDays;
        private readonly TimeSpan _timeOfDay;
        public DelayedSettlementModel(int numberOfDays, TimeSpan timeOfDay)
        {
            _numberOfDays = numberOfDays;
            _timeOfDay = timeOfDay;
        }
        public void ApplyFunds(SecurityPortfolioManager portfolio, Security security, DateTime applicationTimeUtc, string currency, decimal amount)
        {
            if (amount > 0)
            {
                portfolio.UnsettledCashBook[currency].AddAmount(amount);
                var settlementDate = applicationTimeUtc.ConvertFromUtc(security.Exchange.TimeZone).Date;
                for (var i = 0; i < _numberOfDays; i++)
                {
                    settlementDate = settlementDate.AddDays(1);
                    if (!security.Exchange.Hours.IsDateOpen(settlementDate))
                        i--;
                }
                var settlementTimeUtc = settlementDate.Add(_timeOfDay).ConvertToUtc(security.Exchange.Hours.TimeZone);
                portfolio.AddUnsettledCashAmount(new UnsettledCashAmount(settlementTimeUtc, currency, amount));
            }
            else
            {
                portfolio.CashBook[currency].AddAmount(amount);
            }
        }
    }
}
