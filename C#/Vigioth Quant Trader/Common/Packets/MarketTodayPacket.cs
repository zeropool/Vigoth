using System;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class MarketToday
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status = "";
        [JsonProperty(PropertyName = "premarket")]
        public MarketHours PreMarket;
        [JsonProperty(PropertyName = "open")]
        public MarketHours Open;
        [JsonProperty(PropertyName = "postmarket")]
        public MarketHours PostMarket;
        public MarketToday()
        { }
    }
    public class MarketHours
    {
        [JsonProperty(PropertyName = "start")]
        public DateTime Start;
        [JsonProperty(PropertyName = "end")]
        public DateTime End;
        public MarketHours(DateTime referenceDate, double defaultStart, double defaultEnd)
        {
            Start = referenceDate.Date.AddHours(defaultStart);
            End = referenceDate.Date.AddHours(defaultEnd);
            if (defaultEnd == 24)
            {
                End = End.AddTicks(-1);
            }
        }
    }
}
