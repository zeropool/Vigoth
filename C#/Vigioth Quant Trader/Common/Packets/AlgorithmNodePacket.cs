using System.Collections.Generic;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class AlgorithmNodePacket : Packet
    {
        public AlgorithmNodePacket(PacketType type)
            : base(type)
        { }
        [JsonProperty(PropertyName = "iUserID")]
        public int UserId = 0;
        [JsonProperty(PropertyName = "iProjectID")]
        public int ProjectId = 0;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId
        {
            get
            {
                if (Type == PacketType.LiveNode)
                {
                    return ((LiveNodePacket)this).DeployId;
                }
                return ((BacktestNodePacket)this).BacktestId;
            }
        }
        [JsonProperty(PropertyName = "sSessionID")]
        public string SessionId = "";
        [JsonProperty(PropertyName = "sUserPlan")]
        public UserPlan UserPlan = UserPlan.Free;
        [JsonProperty(PropertyName = "eLanguage")]
        public Language Language = Language.CSharp;
        [JsonProperty(PropertyName = "sServerType")]
        public ServerType ServerType = ServerType.Server512;
        [JsonProperty(PropertyName = "sCompileID")]
        public string CompileId = "";
        [JsonProperty(PropertyName = "sVersion")]
        public string Version;
        [JsonProperty(PropertyName = "bRedelivered")]
        public bool Redelivered = false;
        [JsonProperty(PropertyName = "oAlgorithm")]
        public byte[] Algorithm = new byte[] { };
        [JsonProperty(PropertyName = "sRequestSource")]
        public string RequestSource = "WebIDE";
        [JsonProperty(PropertyName = "iMaxRamAllocation")]
        public int RamAllocation;
        [JsonProperty(PropertyName = "oControls")]
        public Controls Controls;
        [JsonProperty(PropertyName = "aParameters")]
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
    }    
}    
