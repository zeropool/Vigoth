using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class HandledErrorPacket : Packet
    {
        [JsonProperty(PropertyName = "sMessage")]
        public string Message;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        [JsonProperty(PropertyName = "sStackTrace")]
        public string StackTrace;
        public HandledErrorPacket()
            : base (PacketType.HandledError)
        { }
        public HandledErrorPacket(string algorithmId, string message, string stacktrace = "")
            : base(PacketType.HandledError)
        {
            Message = message;
            AlgorithmId = algorithmId;
            StackTrace = stacktrace;
        }
    }    
}    
