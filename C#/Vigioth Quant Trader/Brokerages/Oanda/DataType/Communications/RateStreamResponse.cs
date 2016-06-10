

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.DataType.Communications
{
#pragma warning disable 1591
    public class RateStreamResponse : IHeartbeat
    {
        public Heartbeat heartbeat;
        public Price tick;
        public bool IsHeartbeat()
        {
            return (heartbeat != null);
        }
    }
#pragma warning restore 1591
}
