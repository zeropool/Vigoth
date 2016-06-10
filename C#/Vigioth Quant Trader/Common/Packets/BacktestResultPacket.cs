using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Statistics;
namespace VigiothCapital.QuantTrader.Packets
{
    public class BacktestResultPacket : Packet 
    {
        [JsonProperty(PropertyName = "iUserID")]
        public int UserId = 0;
        [JsonProperty(PropertyName = "iProjectID")]
        public int ProjectId = 0;
        [JsonProperty(PropertyName = "sSessionID")]
        public string SessionId = "";
        [JsonProperty(PropertyName = "sBacktestID")]
        public string BacktestId = "";
        [JsonProperty(PropertyName = "sCompileID")]
        public string CompileId = "";
        [JsonProperty(PropertyName = "dtPeriodStart")]
        public DateTime PeriodStart = DateTime.Now;
        [JsonProperty(PropertyName = "dtPeriodFinish")]
        public DateTime PeriodFinish = DateTime.Now;
        [JsonProperty(PropertyName = "dtDateRequested")]
        public DateTime DateRequested = DateTime.Now;
        [JsonProperty(PropertyName = "dtDateFinished")]
        public DateTime DateFinished = DateTime.Now;
        [JsonProperty(PropertyName = "dProgress")]
        public decimal Progress = 0;
        [Obsolete("The RunMode property has been made obsolete and all backtests will be run in series mode.")]
        [JsonProperty(PropertyName = "eRunMode")]
        public RunMode RunMode = RunMode.Series;
        [JsonProperty(PropertyName = "sName")]
        public string Name = String.Empty;
        [JsonProperty(PropertyName = "oResults")]
        public BacktestResult Results = new BacktestResult();
        [JsonProperty(PropertyName = "dProcessingTime")]
        public double ProcessingTime = 0;
        [JsonProperty(PropertyName = "iTradeableDates")]
        public int TradeableDates = 0;
        public BacktestResultPacket()
            : base(PacketType.BacktestResult)
        { }
        public BacktestResultPacket(string json) 
            : base (PacketType.BacktestResult)
        {
            try
            {
                var packet = JsonConvert.DeserializeObject<BacktestResultPacket>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                CompileId          = packet.CompileId;
                Channel            = packet.Channel;
                PeriodFinish       = packet.PeriodFinish;
                PeriodStart        = packet.PeriodStart;
                Progress           = packet.Progress;
                SessionId          = packet.SessionId;
                BacktestId         = packet.BacktestId;
                Type               = packet.Type;
                UserId             = packet.UserId;
                DateFinished       = packet.DateFinished;
                DateRequested      = packet.DateRequested;
                Name               = packet.Name;
                ProjectId          = packet.ProjectId;
                Results            = packet.Results;
                ProcessingTime     = packet.ProcessingTime;
                TradeableDates     = packet.TradeableDates;
            } 
            catch (Exception err)
            {
                Log.Trace("BacktestResultPacket(): Error converting json: " + err);
            }
        }
        public BacktestResultPacket(BacktestNodePacket job, BacktestResult results, decimal progress = 1m)
            : base(PacketType.BacktestResult)
        {
            try
            {
                Progress = Math.Round(progress, 3);
                SessionId = job.SessionId;
                PeriodFinish = job.PeriodFinish;
                PeriodStart = job.PeriodStart;
                CompileId = job.CompileId;
                Channel = job.Channel;
                BacktestId = job.BacktestId;
                Results = results;
                Name = job.Name;
                UserId = job.UserId;
                ProjectId = job.ProjectId;
                SessionId = job.SessionId;
                TradeableDates = job.TradeableDates;
            }
            catch (Exception err) {
                Log.Error(err);
            }
        }
    }    
    public class BacktestResult
    {
        public IDictionary<string, Chart> Charts = new Dictionary<string, Chart>();
        public IDictionary<int, Order> Orders = new Dictionary<int, Order>();
        public IDictionary<DateTime, decimal> ProfitLoss = new Dictionary<DateTime, decimal>();
        public IDictionary<string, string> Statistics = new Dictionary<string, string>();
        public IDictionary<string, string> RuntimeStatistics = new Dictionary<string, string>();
        public Dictionary<string, AlgorithmPerformance> RollingWindow = new Dictionary<string, AlgorithmPerformance>();
        public AlgorithmPerformance TotalPerformance = null;
        public BacktestResult()
        {
        }
        public BacktestResult(IDictionary<string, Chart> charts, IDictionary<int, Order> orders, IDictionary<DateTime, decimal> profitLoss, IDictionary<string, string> statistics, Dictionary<string, AlgorithmPerformance> rollingWindow, AlgorithmPerformance totalPerformance = null)
        {
            Charts = charts;
            Orders = orders;
            ProfitLoss = profitLoss;
            Statistics = statistics;
            RollingWindow = rollingWindow;
            TotalPerformance = totalPerformance;
        }
    }
}    
