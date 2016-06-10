
using VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType
{
#pragma warning disable 1591
    /// <summary>
    /// Represents an order on Oanda.
    /// </summary>
    public class Order : Response
    {
        public long id { get; set; }
		public string instrument { get; set; }
		public int units { get; set; }
		public string side { get; set; }
		public string type { get; set; }
        public string time { get; set; }
        public double price { get; set; }
        public double takeProfit { get; set; }
        public double stopLoss { get; set; }
        public string expiry { get; set; }
        public double upperBound { get; set; }
        public double lowerBound { get; set; }
        public int trailingStop { get; set; }
    }
#pragma warning restore 1591
}
