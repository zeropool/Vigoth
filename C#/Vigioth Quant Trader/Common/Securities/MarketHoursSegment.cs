using System;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Securities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MarketHoursSegment
    {
        [JsonProperty("start")]
        public TimeSpan Start { get; private set; }
        [JsonProperty("end")]
        public TimeSpan End { get; private set; }
        [JsonProperty("state")]
        public MarketHoursState State { get; private set; }
        public MarketHoursSegment(MarketHoursState state, TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
            State = state;
        }
        public static MarketHoursSegment OpenAllDay()
        {
            return new MarketHoursSegment(MarketHoursState.Market, TimeSpan.Zero, Time.OneDay);
        }
        public static MarketHoursSegment ClosedAllDay()
        {
            return new MarketHoursSegment(MarketHoursState.Closed, TimeSpan.Zero, Time.OneDay);
        }
        public bool Contains(TimeSpan time)
        {
            return time >= Start && time < End;
        }
        public bool Overlaps(TimeSpan start, TimeSpan end)
        {
            return Start < end && End > start;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}-{2}", State, Start, End);
        }
    }
}