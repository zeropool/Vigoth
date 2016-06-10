
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represent the Active Trades Web Response. 
    /// </summary>
    public class TradesResponse
    {
        public List<TradeData> trades;
        public string nextPage;
    }
#pragma warning restore 1591
}
