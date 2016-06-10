
using System.Collections.Generic;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    /// <summary>
    /// Represents the post order response from Oanda.
    /// </summary>
	public class PostOrderResponse : Response
	{
		public string instrument { get; set; }
		public string time { get; set; }
		public double? price { get; set; }

		public Order orderOpened { get; set; }
		public TradeData tradeOpened { get; set; }
		public List<Transaction> tradesClosed { get; set; }
		public Transaction tradeReduced { get; set; }
	}
#pragma warning restore 1591
}
