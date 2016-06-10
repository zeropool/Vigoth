
namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType
{
#pragma warning disable 1591
    /// <summary>
    /// Represent a Position in Oanda.
    /// </summary>
    public class Position
    {
        public string side { get; set; }
        public string instrument { get; set; }
        public int units { get; set; }
        public double avgPrice { get; set; }
    }
#pragma warning restore 1591
}
