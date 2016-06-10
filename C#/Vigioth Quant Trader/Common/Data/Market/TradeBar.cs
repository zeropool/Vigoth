using System;
using System.Globalization;
using System.IO;
using System.Threading;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class TradeBar : BaseData, IBar
    {
        private const decimal _scaleFactor = 1/10000m;
        private int _initialized;
        private decimal _open;
        private decimal _high;
        private decimal _low;
        public long Volume { get; set; }
        public decimal Open
        {
            get { return _open; }
            set
            {
                Initialize(value);
                _open = value;
            }
        }
        public decimal High
        {
            get { return _high; }
            set
            {
                Initialize(value);
                _high = value;
            }
        }
        public decimal Low
        {
            get { return _low; }
            set
            {
                Initialize(value);
                _low = value;
            }
        }
        public decimal Close
        {
            get { return Value; }
            set
            {
                Initialize(value);
                Value = value;
            }
        }
        public override DateTime EndTime
        {
            get { return Time + Period; }
            set { Period = value - Time; } 
        }
        public TimeSpan Period { get; set; }
        public TradeBar()
        {
            Symbol = Symbol.Empty;
            DataType = MarketDataType.TradeBar;
            Period = TimeSpan.FromMinutes(1);
        }
        public TradeBar(TradeBar original)
        {
            DataType = MarketDataType.TradeBar;
            Time = new DateTime(original.Time.Ticks);
            Symbol = original.Symbol;
            Value = original.Close;
            Open = original.Open;
            High = original.High;
            Low = original.Low;
            Close = original.Close;
            Volume = original.Volume;
            Period = original.Period;
            _initialized = 1;
        }
        public TradeBar(DateTime time, Symbol symbol, decimal open, decimal high, decimal low, decimal close, long volume, TimeSpan? period = null)
        {
            Time = time;
            Symbol = symbol;
            Value = close;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Period = period ?? TimeSpan.FromMinutes(1);
            DataType = MarketDataType.TradeBar;
            _initialized = 1;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode) 
        {
            if (line == null)
            {
                return null;
            }
            if (isLiveMode)
            {
                return new TradeBar();
            }
            try
            {
                switch (config.SecurityType)
                {
                    case SecurityType.Equity:
                        return ParseEquity<TradeBar>(config, line, date);
                    case SecurityType.Forex:
                        return ParseForex<TradeBar>(config, line, date);
                    case SecurityType.Cfd:
                        return ParseCfd<TradeBar>(config, line, date);
                    case SecurityType.Option:
                        return ParseOption<TradeBar>(config, line, date);
                }
            }
            catch (Exception err)
            {
                Log.Error(err, "SecurityType: " + config.SecurityType + " Line: " + line);
            }
            return new TradeBar{Symbol = config.Symbol, Period = config.Increment};
        }
        public static TradeBar Parse(SubscriptionDataConfig config, string line, DateTime baseDate)
        {
            switch (config.SecurityType)
            {
                case SecurityType.Equity:
                    return ParseEquity(config, line, baseDate);
                case SecurityType.Forex:
                    return ParseForex(config, line, baseDate);
                case SecurityType.Cfd:
                    return ParseCfd(config, line, baseDate);
            }
            return null;
        }
        public static T ParseEquity<T>(SubscriptionDataConfig config, string line, DateTime date)
            where T : TradeBar, new()
        {
            var tradeBar = new T
            {
                Symbol = config.Symbol,
                Period = config.Increment
            };
            var csv = line.ToCsv(6);
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Hour)
            {
                tradeBar.Time = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            else
            {
                tradeBar.Time = date.Date.AddMilliseconds(csv[0].ToInt32()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            tradeBar.Open = config.GetNormalizedPrice(csv[1].ToDecimal()*_scaleFactor);
            tradeBar.High = config.GetNormalizedPrice(csv[2].ToDecimal()*_scaleFactor);
            tradeBar.Low = config.GetNormalizedPrice(csv[3].ToDecimal()*_scaleFactor);
            tradeBar.Close = config.GetNormalizedPrice(csv[4].ToDecimal()*_scaleFactor);
            tradeBar.Volume = csv[5].ToInt64();
            return tradeBar;
        }
        public static TradeBar ParseEquity(SubscriptionDataConfig config, string line, DateTime date)
        {
            return ParseEquity<TradeBar>(config, line, date);
        }
        public static T ParseForex<T>(SubscriptionDataConfig config, string line, DateTime date)
            where T : TradeBar, new()
        {
            var tradeBar = new T
            {
                Symbol = config.Symbol,
                Period = config.Increment
            };
            var csv = line.ToCsv(5);
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Hour)
            {
                tradeBar.Time = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            else
            {
                tradeBar.Time = date.Date.AddMilliseconds(csv[0].ToInt32()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            tradeBar.Open = csv[1].ToDecimal();
            tradeBar.High = csv[2].ToDecimal();
            tradeBar.Low = csv[3].ToDecimal();
            tradeBar.Close = csv[4].ToDecimal();
            return tradeBar;
        }
        public static TradeBar ParseForex(SubscriptionDataConfig config, string line, DateTime date)
        {
            return ParseForex<TradeBar>(config, line, date);
        }
        public static T ParseCfd<T>(SubscriptionDataConfig config, string line, DateTime date)
            where T : TradeBar, new()
        {
            return ParseForex<T>(config, line, date);
        }
        public static TradeBar ParseCfd(SubscriptionDataConfig config, string line, DateTime date)
        {
            return ParseCfd<TradeBar>(config, line, date);
        }
        public static T ParseOption<T>(SubscriptionDataConfig config, string line, DateTime date)
            where T : TradeBar, new()
        {
            var tradeBar = new T
            {
                Period = config.Increment,
                Symbol = config.Symbol
            };
            var csv = line.ToCsv(6);
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Hour)
            {
                tradeBar.Time = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            else
            {
                tradeBar.Time = date.Date.AddMilliseconds(csv[0].ToInt32()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            tradeBar.Open = config.GetNormalizedPrice(csv[1].ToDecimal() * _scaleFactor);
            tradeBar.High = config.GetNormalizedPrice(csv[2].ToDecimal() * _scaleFactor);
            tradeBar.Low = config.GetNormalizedPrice(csv[3].ToDecimal() * _scaleFactor);
            tradeBar.Close = config.GetNormalizedPrice(csv[4].ToDecimal() * _scaleFactor);
            tradeBar.Volume = csv[5].ToInt64();
            return tradeBar;
        }
        public static TradeBar ParseOption(SubscriptionDataConfig config, string line, DateTime date)
        {
            return ParseOption<TradeBar>(config, line, date);
        }
        public override void Update(decimal lastTrade, decimal bidPrice, decimal askPrice, decimal volume, decimal bidSize, decimal askSize)
        {
            Initialize(lastTrade);
            if (lastTrade > High) High = lastTrade;
            if (lastTrade < Low) Low = lastTrade;
            Volume += Convert.ToInt32(volume);
            Close = lastTrade;
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
            return (BaseData)MemberwiseClone();
        }
        private void Initialize(decimal value)
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 0)
            {
                _open = value;
                _low = value;
                _high = value;
            }
        }
    }
}
