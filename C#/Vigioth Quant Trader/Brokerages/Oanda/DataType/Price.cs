
namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType
{
#pragma warning disable 1591
    /// <summary>
    /// Represents the Price object creating Orders for each instrument.
    /// </summary>
    public class Price
    {
        public enum State
        {
            Default,
            Increasing,
            Decreasing
        };

        public string instrument { get; set; }
        public string time;
        public double bid { get; set; }
        public double ask { get; set; }
	    public string status;
        public State state = State.Default;

	    public void update( Price update )
        {
            if ( this.bid > update.bid )
            {
                state = State.Decreasing;
            }
            else if ( this.bid < update.bid )
            {
                state = State.Increasing;
            }
            else
            {
                state = State.Default;
            }

            this.bid = update.bid;
            this.ask = update.ask;
            this.time = update.time;
        }
    }
#pragma warning restore 1591
}
