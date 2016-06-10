using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class RuntimeErrorPacket : Packet
    {
        [JsonProperty(PropertyName = "sMessage")]
        public string Message;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        [JsonProperty(PropertyName = "sStackTrace")]
        public string StackTrace;
        public RuntimeErrorPacket()
            : base (PacketType.RuntimeError)
        { }
        public RuntimeErrorPacket(string algorithmId, string message, string stacktrace = "")
            : base(PacketType.RuntimeError)
        {
            Message = message;
            AlgorithmId = algorithmId;
            StackTrace = stacktrace;
        }
    }    
}    
