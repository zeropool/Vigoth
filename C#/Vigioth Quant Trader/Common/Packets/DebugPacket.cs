using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class DebugPacket : Packet
    {
        [JsonProperty(PropertyName = "sMessage")]
        public string Message;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        [JsonProperty(PropertyName = "sCompileID")]
        public string CompileId;
        [JsonProperty(PropertyName = "iProjectID")]
        public int ProjectId;
        [JsonProperty(PropertyName = "bToast")]
        public bool Toast;
        public DebugPacket()
            : base (PacketType.Debug)
        { }
        public DebugPacket(int projectId, string algorithmId, string compileId, string message, bool toast = false)
            : base(PacketType.Debug)
        {
            ProjectId = projectId;
            Message = message;
            CompileId = compileId;
            AlgorithmId = algorithmId;
            Toast = toast;
        }
    }    
}    
