using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace VigiothCapital.QuantTrader.Packets
{
    public class Packet
    {
        [JsonProperty(PropertyName = "eType")]
        public PacketType Type = PacketType.None;
        [JsonProperty(PropertyName = "sChannel")]
        public string Channel = "";
        public Packet(PacketType type)
        {
            Channel = "";
            Type = type;
        }
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PacketType
    {
        None,
        AlgorithmNode,
        AutocompleteWork,
        AutocompleteResult,
        BacktestNode,
        BacktestResult,
        BacktestWork,
        LiveNode,
        LiveResult,
        LiveWork,
        SecurityTypes,
        BacktestError,
        AlgorithmStatus,
        BuildWork,
        BuildSuccess,
        BuildError,
        RuntimeError,
        HandledError,
        Log,
        Debug,
        OrderEvent,
        Success,
        History,
        CommandResult,
        GitHubHook
    }
}
