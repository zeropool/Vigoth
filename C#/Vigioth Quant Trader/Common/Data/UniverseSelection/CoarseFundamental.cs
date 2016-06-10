using System;
using System.IO;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class CoarseFundamental : BaseData
    {
        public string Market { get; set; }
        public decimal DollarVolume { get; set; }
        public long Volume { get; set; }
        public override DateTime EndTime
        {
            get { return Time + VigiothCapital.QuantTrader.Time.OneDay; }
            set { Time = value - VigiothCapital.QuantTrader.Time.OneDay; }
        }
        public CoarseFundamental()
        {
            DataType = MarketDataType.Auxiliary;
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            var path = Path.Combine(Globals.DataFolder, "equity", config.Market, "fundamental", "coarse", date.ToString("yyyyMMdd") + ".csv");
            return new SubscriptionDataSource(path, SubscriptionTransportMedium.LocalFile, FileFormat.Csv);
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            try
            {
                var csv = line.Split(',');
                return new CoarseFundamental
                {
                    Symbol = new Symbol(SecurityIdentifier.Parse(csv[0]), csv[1]),
                    Time = date,
                    Market = config.Market,
                    Value = csv[2].ToDecimal(),
                    Volume = csv[3].ToInt64(),
                    DollarVolume = csv[4].ToDecimal()
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override BaseData Clone()
        {
            return new CoarseFundamental
            {
                Symbol = Symbol,
                Time = Time,
                DollarVolume = DollarVolume,
                Market = Market,
                Value = Value,
                Volume = Volume,
                DataType = MarketDataType.Auxiliary
            };
        }
        public static Symbol CreateUniverseSymbol(string market)
        {
            market = market.ToLower();
            var ticker = "qc-universe-coarse-" + market;
            var sid = SecurityIdentifier.GenerateEquity(SecurityIdentifier.DefaultDate, ticker, market);
            return new Symbol(sid, ticker);
        }
    }
}
