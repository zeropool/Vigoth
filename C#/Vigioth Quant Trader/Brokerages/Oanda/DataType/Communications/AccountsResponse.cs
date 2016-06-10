
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represents the web response when querying the list of accounts belong to one Oanda user.
    /// </summary>
    public class AccountsResponse
    {
        public List<Account> accounts;
	
    }
#pragma warning restore 1591
}
