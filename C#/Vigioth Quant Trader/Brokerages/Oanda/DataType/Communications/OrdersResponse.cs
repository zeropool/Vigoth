
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represents the web response of the current active orders from Oanda.
    /// </summary>
    public class OrdersResponse
    {
        public List<Order> orders;
        public string nextPage;
    }
#pragma warning restore 1591
}
