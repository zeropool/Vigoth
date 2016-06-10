using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace VigiothCapital.QuantTrader.Packets
{
    public class AlgorithmStatusPacket : Packet
    {
        [JsonProperty(PropertyName = "eStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AlgorithmStatus Status;
        [JsonProperty(PropertyName = "sChartSubscription")]
        public string ChartSubscription;
        [JsonProperty(PropertyName = "sMessage")]
        public string Message;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        [JsonProperty(PropertyName = "iProjectID")]
        public int ProjectId;
        [JsonProperty(PropertyName = "sChannelStatus")]
        public string ChannelStatus;
        public AlgorithmStatusPacket()
            : base(PacketType.AlgorithmStatus)
        {
        }
        public AlgorithmStatusPacket(string algorithmId, int projectId, AlgorithmStatus status, string message = "")
            : base (PacketType.AlgorithmStatus)
        {
            Status = status;
            ProjectId = projectId;
            AlgorithmId = algorithmId;
            Message = message;
        }   
    }
}
