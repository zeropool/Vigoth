using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class LogPacket : Packet
    {
        [JsonProperty(PropertyName = "sMessage")]
        public string Message;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        public LogPacket()
            : base (PacketType.Log)
        { }
        public LogPacket(string algorithmId, string message)
            : base(PacketType.Log)
        {
            Message = message;
            AlgorithmId = algorithmId;
        }
    }    
}    
