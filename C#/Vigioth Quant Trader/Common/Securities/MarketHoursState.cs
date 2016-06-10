using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace VigiothCapital.QuantTrader.Securities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MarketHoursState
    {
        [EnumMember(Value = "closed")]
        Closed,
        [EnumMember(Value = "premarket")]
        PreMarket,
        [EnumMember(Value = "market")]
        Market,
        [EnumMember(Value = "postmarket")]
        PostMarket
    }
}