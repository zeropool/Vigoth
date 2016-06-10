using System;
using System.Globalization;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class QuoteBar : BaseData, IBar
    {
        private const decimal _scaleFactor = 1 / 10000m;
        public long LastBidSize { get; set; }
        public long LastAskSize { get; set; }
        public Bar Bid { get; set; }
        public Bar Ask { get; set; }
        public decimal Open
        {
            get
            {
                if (Bid != null && Ask != null)
                {
                    return (Bid.Open + Ask.Open) / 2m;
                }
                if (Bid != null)
                {
                    return Bid.Open;
                }
                if (Ask != null)
                {
                    return Ask.Open;
                }
                return 0m;
            }
        }
        public decimal High
        {
            get
            {
                if (Bid != null && Ask != null)
                {
                    return (Bid.High + Ask.High) / 2m;
                }
                if (Bid != null)
                {
                    return Bid.High;
                }
                if (Ask != null)
                {
                    return Ask.High;
                }
                return 0m;
            }
        }
        public decimal Low
        {
            get
            {
                if (Bid != null && Ask != null)
                {
                    return (Bid.Low + Ask.Low) / 2m;
                }
                if (Bid != null)
                {
                    return Bid.Low;
                }
                if (Ask != null)
                {
                    return Ask.Low;
                }
                return 0m;
            }
        }
        public decimal Close
        {
            get
            {
                if (Bid != null && Ask != null)
                {
                    return (Bid.Close + Ask.Close) / 2m;
                }
                if (Bid != null)
                {
                    return Bid.Close;
                }
                if (Ask != null)
                {
                    return Ask.Close;
                }
                return Value;
            }
        }
        public override DateTime EndTime
        {
            get { return Time + Period; }
            set { Period = value - Time; }
        }
        public TimeSpan Period { get; set; }
        public QuoteBar()
        {
            Symbol = Symbol.Empty;
            Time = new DateTime();
            Bid = new Bar();
            Ask = new Bar();
            Value = 0;
            Period = TimeSpan.FromMinutes(1);
            DataType = MarketDataType.QuoteBar;
        }
        public QuoteBar(DateTime time, Symbol symbol, IBar bid, long lastBidSize, IBar ask, long lastAskSize, TimeSpan? period = null)
        {
            Symbol = symbol;
            Time = time;
            Bid = bid == null ? null : new Bar(bid.Open, bid.High, bid.Low, bid.Close);
            Ask = ask == null ? null : new Bar(ask.Open, ask.High, ask.Low, ask.Close);
            if (Bid != null) LastBidSize = lastBidSize;
            if (Ask != null) LastAskSize = lastAskSize;
            Value = Close;
            Period = period ?? TimeSpan.FromMinutes(1);
            DataType = MarketDataType.QuoteBar;
        }
        public override void Update(decimal lastTrade, decimal bidPrice, decimal askPrice, decimal volume, decimal bidSize, decimal askSize)
        {
            if (Bid == null && bidPrice != 0) Bid = new Bar();
            if (Bid != null) Bid.Update(bidPrice);
            if (Ask == null && askPrice != 0) Ask = new Bar();
            if (Ask != null) Ask.Update(askPrice);
            if (bidSize > 0) 
            {
                LastBidSize = (long) bidSize;
            }
            if (askSize > 0)
            {
                LastAskSize = (long) askSize;
            }
            if (lastTrade != 0) Value = lastTrade;
            else if (askPrice != 0) Value = askPrice;
            else if (bidPrice != 0) Value = bidPrice;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var quoteBar = new QuoteBar
            {
                Period = config.Increment,
                Symbol = config.Symbol
            };
            var csv = line.ToCsv(10);
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Hour)
            {
                quoteBar.Time = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            else
            {
                quoteBar.Time = date.Date.AddMilliseconds(csv[0].ToInt32()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            if (csv[1].Length != 0 || csv[2].Length != 0 || csv[3].Length != 0 || csv[4].Length != 0)
            {
                quoteBar.Bid = new Bar
                {
                    Open = config.GetNormalizedPrice(csv[1].ToDecimal()*_scaleFactor),
                    High = config.GetNormalizedPrice(csv[2].ToDecimal()*_scaleFactor),
                    Low = config.GetNormalizedPrice(csv[3].ToDecimal()*_scaleFactor),
                    Close = config.GetNormalizedPrice(csv[4].ToDecimal()*_scaleFactor)
                };
                quoteBar.LastBidSize = csv[5].ToInt64();
            }
            else
            {
                quoteBar.Bid = null;
            }
            if (csv[6].Length != 0 || csv[7].Length != 0 || csv[8].Length != 0 || csv[9].Length != 0)
            {
                quoteBar.Ask = new Bar
                {
                    Open = config.GetNormalizedPrice(csv[6].ToDecimal()*_scaleFactor),
                    High = config.GetNormalizedPrice(csv[7].ToDecimal()*_scaleFactor),
                    Low = config.GetNormalizedPrice(csv[8].ToDecimal()*_scaleFactor),
                    Close = config.GetNormalizedPrice(csv[9].ToDecimal()*_scaleFactor)
                };
                quoteBar.LastAskSize = csv[10].ToInt64();
            }
            else
            {
                quoteBar.Ask = null;
            }
            quoteBar.Value = quoteBar.Close;
            return quoteBar;
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            if (isLiveMode)
            {
                return new SubscriptionDataSource(string.Empty, SubscriptionTransportMedium.LocalFile);
            }
            var source = LeanData.GenerateZipFilePath(Globals.DataFolder, config.Symbol, date, config.Resolution, config.TickType);
            if (config.SecurityType == SecurityType.Option)
            {
                source += "#" + LeanData.GenerateZipEntryName(config.Symbol, date, config.Resolution, config.TickType);
            }
            return new SubscriptionDataSource(source, SubscriptionTransportMedium.LocalFile, FileFormat.Csv);
        }
        public override BaseData Clone()
        {
            return new QuoteBar
            {
                Ask = Ask == null ? null : Ask.Clone(),
                Bid = Bid == null ? null : Bid.Clone(),
                LastAskSize = LastAskSize,
                LastBidSize = LastBidSize,
                Symbol = Symbol,
                Time = Time,
                Period = Period,
                Value = Value,
                DataType = DataType
            };
        }
    }
}
