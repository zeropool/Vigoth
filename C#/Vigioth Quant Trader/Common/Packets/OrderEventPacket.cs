using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Packets
{
    public class OrderEventPacket : Packet
    {
        [JsonProperty(PropertyName = "oOrderEvent")]
        public OrderEvent Event;
        [JsonProperty(PropertyName = "sAlgorithmID")]
        public string AlgorithmId;
        public OrderEventPacket()
            : base (PacketType.OrderEvent)
        { }
        public OrderEventPacket(string algorithmId, OrderEvent eventOrder)
            : base(PacketType.OrderEvent)
        {
            AlgorithmId = algorithmId;
            Event = eventOrder;
        }
    }     
}    
