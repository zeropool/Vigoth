namespace VigiothCapital.QuantTrader.Securities
{
    public class AccountEvent
    {
        public decimal CashBalance { get; private set; }
        public string CurrencySymbol { get; private set; }
        public AccountEvent(string currencySymbol, decimal cashBalance)
        {
            CashBalance = cashBalance;
            CurrencySymbol = currencySymbol;
        }
        public override string ToString()
        {
            return string.Format("Account {0} Balance: {1}", CurrencySymbol, CashBalance.ToString("0.00"));
        }
    }
}
