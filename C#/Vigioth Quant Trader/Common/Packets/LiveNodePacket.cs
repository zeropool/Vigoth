using System.Collections.Generic;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class LiveNodePacket : AlgorithmNodePacket 
    {
        [JsonProperty(PropertyName = "sDeployID")]
        public string DeployId = "";
        [JsonProperty(PropertyName = "sBrokerage")]
        public string Brokerage = "";
        [JsonProperty(PropertyName = "aBrokerageData")]
        public Dictionary<string, string> BrokerageData = new Dictionary<string, string>();
        public LiveNodePacket() 
            : base(PacketType.LiveNode)
        {
            Controls = new Controls
            {
                MinuteLimit = 50,
                SecondLimit = 25,
                TickLimit = 15
            };
        }
    }    
}    
