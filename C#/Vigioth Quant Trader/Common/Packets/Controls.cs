using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class Controls
    {
        [JsonProperty(PropertyName = "iMinuteLimit")]
        public int MinuteLimit;
        [JsonProperty(PropertyName = "iSecondLimit")]
        public int SecondLimit;
        [JsonProperty(PropertyName = "iTickLimit")]
        public int TickLimit;
        public Controls()
        {
            MinuteLimit = 500;
            SecondLimit = 100;
            TickLimit = 30;
        }
    }
}
