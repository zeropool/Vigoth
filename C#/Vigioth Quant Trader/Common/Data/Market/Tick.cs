using System;
using System.Globalization;
using System.IO;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Tick : BaseData
    {
        public TickType TickType = TickType.Trade;
        public int Quantity = 0;
        public string Exchange = "";
        public string SaleCondition = "";
        public bool Suspicious = false;
        public decimal BidPrice = 0;
        public decimal AskPrice = 0;
        public decimal LastPrice
        {
            get
            {
                return Value;
            }
        }
        public long BidSize = 0;
        public long AskSize = 0;
        public Tick()
        {
            Value = 0;
            Time = new DateTime();
            DataType = MarketDataType.Tick;
            Symbol = Symbol.Empty;
            TickType = TickType.Trade;
            Quantity = 0;
            Exchange = "";
            SaleCondition = "";
            Suspicious = false;
            BidSize = 0;
            AskSize = 0;
        }
        public Tick(Tick original) 
        {
            Symbol = original.Symbol;
            Time = new DateTime(original.Time.Ticks);
            Value = original.Value;
            BidPrice = original.BidPrice;
            AskPrice = original.AskPrice;
            Exchange = original.Exchange;
            SaleCondition = original.SaleCondition;
            Quantity = original.Quantity;
            Suspicious = original.Suspicious;
            DataType = MarketDataType.Tick;
            TickType = original.TickType;
            BidSize = original.BidSize;
            AskSize = original.AskSize;
        }
        public Tick(DateTime time, Symbol symbol, decimal bid, decimal ask)
        {
            DataType = MarketDataType.Tick;
            Time = time;
            Symbol = symbol;
            Value = (bid + ask) / 2;
            TickType = TickType.Quote;
            BidPrice = bid;
            AskPrice = ask;
        }
        public Tick(DateTime time, Symbol symbol, decimal last, decimal bid, decimal ask)
        {
            DataType = MarketDataType.Tick;
            Time = time;
            Symbol = symbol;
            Value = last;
            TickType = TickType.Quote;
            BidPrice = bid;
            AskPrice = ask;
        }
        public Tick(Symbol symbol, string line)
        {
            var csv = line.Split(',');
            DataType = MarketDataType.Tick;
            Symbol = symbol;
            Time = DateTime.ParseExact(csv[0], DateFormat.Forex, CultureInfo.InvariantCulture);
            Value = (BidPrice + AskPrice) / 2;
            TickType = TickType.Quote;
            BidPrice = Convert.ToDecimal(csv[1], CultureInfo.InvariantCulture);
            AskPrice = Convert.ToDecimal(csv[2], CultureInfo.InvariantCulture);
        }
        public Tick(Symbol symbol, string line, DateTime baseDate)
        {
            var csv = line.Split(',');
            DataType = MarketDataType.Tick;
            Symbol = symbol;
            Time = baseDate.Date.AddMilliseconds(csv[0].ToInt32());
            Value = csv[1].ToDecimal()/10000m;
            TickType = TickType.Trade;
            Quantity = csv[2].ToInt32();
            Exchange = csv[3].Trim();
            SaleCondition = csv[4];
            Suspicious = csv[5].ToInt32() == 1;
        }
        public Tick(SubscriptionDataConfig config, string line, DateTime date)
        {
            try
            {
                DataType = MarketDataType.Tick;
                const decimal scaleFactor = 10000m;
                switch (config.SecurityType)
                {
                    case SecurityType.Equity:
                    {
                        var csv = line.ToCsv(6);
                        Symbol = config.Symbol;
                        Time = date.Date.AddMilliseconds(csv[0].ToInt64()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
                        Value = config.GetNormalizedPrice(csv[1].ToDecimal() / scaleFactor);
                        TickType = TickType.Trade;
                        Quantity = csv[2].ToInt32();
                        if (csv.Count > 3)
                        {
                            Exchange = csv[3];
                            SaleCondition = csv[4];
                            Suspicious = (csv[5] == "1");
                        }
                        break;
                    }
                    case SecurityType.Forex:
                    case SecurityType.Cfd:
                    {
                        var csv = line.ToCsv(3);
                        Symbol = config.Symbol;
                        TickType = TickType.Quote;
                        Time = date.Date.AddMilliseconds(csv[0].ToInt64()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
                        BidPrice = csv[1].ToDecimal();
                        AskPrice = csv[2].ToDecimal();
                        Value = (BidPrice + AskPrice) / 2;
                        break;
                    }
                    case SecurityType.Option:
                    {
                        var csv = line.ToCsv(7);
                        TickType = config.TickType;
                        Time = date.Date.AddMilliseconds(csv[0].ToInt64()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
                        Symbol = config.Symbol;
                        if (TickType == TickType.Trade)
                        {
                            Value = config.GetNormalizedPrice(csv[1].ToDecimal()/scaleFactor);
                            Quantity = csv[2].ToInt32();
                            Exchange = csv[3];
                            SaleCondition = csv[4];
                            Suspicious = csv[5] == "1";
                        }
                        else
                        {
                            if (csv[1].Length != 0)
                            {
                                BidPrice = config.GetNormalizedPrice(csv[1].ToDecimal()/scaleFactor);
                                BidSize = csv[2].ToInt32();
                            }
                            if (csv[3].Length != 0)
                            {
                                AskPrice = config.GetNormalizedPrice(csv[3].ToDecimal()/scaleFactor);
                                AskSize = csv[4].ToInt32();
                            }
                            Exchange = csv[5];
                            Suspicious = csv[6] == "1";
                            if (BidPrice != 0)
                            {
                                if (AskPrice != 0)
                                {
                                    Value = (BidPrice + AskPrice)/2m;
                                }
                                else
                                {
                                    Value = BidPrice;
                                }
                            }
                            else
                            {
                                Value = AskPrice;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            if (isLiveMode)
            {
                return new Tick();
            }
            return new Tick(config, line, date);
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
        public override void Update(decimal lastTrade, decimal bidPrice, decimal askPrice, decimal volume, decimal bidSize, decimal askSize)
        {
            Value = lastTrade;
            BidPrice = bidPrice;
            AskPrice = askPrice;
            BidSize = (long) bidSize;
            AskSize = (long) askSize;
            Quantity = Convert.ToInt32(volume);
        }
        public bool IsValid()
        {
            return (TickType == TickType.Trade && LastPrice > 0.0m && Quantity > 0) ||
                   (TickType == TickType.Quote && AskPrice > 0.0m && AskSize > 0) ||
                   (TickType == TickType.Quote && BidPrice > 0.0m && BidSize > 0);
        }
        public override BaseData Clone()
        {
            return new Tick(this);
        }
    }    
}