using System.Collections.Generic;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class SecurityTypesPacket : Packet
    {
        [JsonProperty(PropertyName = "aMarkets")]
        public List<SecurityType> Types = new List<SecurityType>();
        public string TypesCSV
        {
            get
            {
                var result = "";
                foreach (var type in Types)
                {
                    result += type + ",";
                }
                result = result.TrimEnd(',');
                return result.ToLower();
            }
        }
        public SecurityTypesPacket()
            : base (PacketType.SecurityTypes)
        { }
    }    
}    
