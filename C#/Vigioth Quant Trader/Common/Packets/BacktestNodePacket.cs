using System;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class BacktestNodePacket : AlgorithmNodePacket
    {
        [JsonProperty(PropertyName = "sName")]
        public string Name = "";
        [JsonProperty(PropertyName = "sBacktestID")]
        public string BacktestId = "";
        [JsonProperty(PropertyName = "dtPeriodStart")]
        public DateTime PeriodStart = DateTime.Now;
        [JsonProperty(PropertyName = "dtPeriodFinish")]
        public DateTime PeriodFinish = DateTime.Now;
        [JsonProperty(PropertyName = "iTradeableDates")]
        public int TradeableDates = 0;
        [Obsolete("This property is no longer in use and will always default to series mode.")]
        [JsonProperty(PropertyName = "eRunMode")]
        public RunMode RunMode = RunMode.Series;
        public BacktestNodePacket() 
            : base(PacketType.BacktestNode)
        {
            Controls = new Controls
            {
                MinuteLimit = 500,
                SecondLimit = 100,
                TickLimit = 30
            };
        }
        public BacktestNodePacket(int userId, int projectId, string sessionId, byte[] algorithmData, decimal startingCapital, string name, UserPlan userPlan = UserPlan.Free) 
            : base (PacketType.BacktestNode)
        {
            UserId = userId;
            Algorithm = algorithmData;
            SessionId = sessionId;
            ProjectId = projectId;
            UserPlan = userPlan;
            Name = name;
            Language = Language.CSharp;
            Controls = new Controls
            {
                MinuteLimit = 500,
                SecondLimit = 100,
                TickLimit = 30
            };
        }
    }
}
