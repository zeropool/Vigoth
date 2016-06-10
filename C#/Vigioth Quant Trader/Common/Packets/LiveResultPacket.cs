using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Packets
{
    public class LiveResultPacket : Packet 
    {
        [JsonProperty(PropertyName = "iUserID")]
        public int UserId = 0;
        [JsonProperty(PropertyName = "iProjectID")]
        public int ProjectId = 0;
        [JsonProperty(PropertyName = "sSessionID")]
        public string SessionId = "";
        [JsonProperty(PropertyName = "sDeployID")]
        public string DeployId = "";
        [JsonProperty(PropertyName = "sCompileID")]
        public string CompileId = "";
        [JsonProperty(PropertyName = "oResults")]
        public LiveResult Results = new LiveResult();
        [JsonProperty(PropertyName = "dProcessingTime")]
        public double ProcessingTime = 0;
        public LiveResultPacket()
            : base(PacketType.LiveResult)
        { }
        public LiveResultPacket(string json)
            : base(PacketType.LiveResult)
        {
            try
            {
                var packet = JsonConvert.DeserializeObject<LiveResultPacket>(json);
                CompileId          = packet.CompileId;
                Channel            = packet.Channel;
                SessionId          = packet.SessionId;
                DeployId           = packet.DeployId;
                Type               = packet.Type;
                UserId             = packet.UserId;
                ProjectId          = packet.ProjectId;
                Results            = packet.Results;
                ProcessingTime     = packet.ProcessingTime;
            } 
            catch (Exception err)
            {
                Log.Trace("LiveResultPacket(): Error converting json: " + err);
            }
        }
        public LiveResultPacket(LiveNodePacket job, LiveResult results) 
            :base (PacketType.LiveResult)
        {
            try
            {
                SessionId = job.SessionId;
                CompileId = job.CompileId;
                DeployId = job.DeployId;
                Results = results;
                UserId = job.UserId;
                ProjectId = job.ProjectId;
                SessionId = job.SessionId;
                Channel = job.Channel;
            }
            catch (Exception err) {
                Log.Error(err);
            }
        }
    }    
    public class LiveResult
    {
        public Dictionary<string, Chart> Charts = new Dictionary<string, Chart>();
        public Dictionary<string, Holding> Holdings = new Dictionary<string, Holding>();
        public Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        public Dictionary<DateTime, decimal> ProfitLoss = new Dictionary<DateTime, decimal>();
        public Dictionary<string, string> Statistics = new Dictionary<string, string>();
        public Dictionary<string, string> RuntimeStatistics = new Dictionary<string, string>();
        public Dictionary<string, string> ServerStatistics = new Dictionary<string, string>();
        public LiveResult() 
        { }
        public LiveResult(Dictionary<string, Chart> charts, Dictionary<int, Order> orders, Dictionary<DateTime, decimal> profitLoss, Dictionary<string, Holding> holdings, Dictionary<string, string> statistics, Dictionary<string, string> runtime, Dictionary<string, string> serverStatistics = null)
        {
            Charts = charts;
            Orders = orders;
            ProfitLoss = profitLoss;
            Statistics = statistics;
            Holdings = holdings;
            RuntimeStatistics = runtime;
            ServerStatistics = serverStatistics ?? OS.GetServerStatistics();
        } 
    }
}    
