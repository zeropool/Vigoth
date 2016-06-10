
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represent the web response of the current price of active instruments from Oanda.
    /// </summary>
    public class PricesResponse
    {
        public long time;
        public List<Price> prices;
    }
#pragma warning restore 1591
}
