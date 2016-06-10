
namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType
{
#pragma warning disable 1591
    /// <summary>
    /// Represents a single event when subscribed to the streaming events.
    /// </summary>
	public class Event : IHeartbeat
	{
		public Heartbeat heartbeat { get; set; }
		public Transaction transaction { get; set; }
		public bool IsHeartbeat()
		{
			return (heartbeat != null);
		}
	}
#pragma warning restore 1591
}
