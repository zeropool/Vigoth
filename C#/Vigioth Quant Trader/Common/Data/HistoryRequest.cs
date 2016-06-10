using System;
using NodaTime;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Data
{
    public class HistoryRequest
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public Symbol Symbol { get; set; }
        public SecurityExchangeHours ExchangeHours { get; set; }
        public Resolution Resolution { get; set; }
        public Resolution? FillForwardResolution { get; set; }
        public bool IncludeExtendedMarketHours { get; set; }
        public Type DataType { get; set; }
        public SecurityType SecurityType { get; set; }
        public DateTimeZone TimeZone { get; set; }
        public string Market { get; set; }
        public bool IsCustomData { get; set; }
        public HistoryRequest()
        {
            StartTimeUtc = EndTimeUtc = DateTime.UtcNow;
            Symbol = Symbol.Empty;
            ExchangeHours = SecurityExchangeHours.AlwaysOpen(TimeZones.NewYork);
            Resolution = Resolution.Minute;
            FillForwardResolution = Resolution.Minute;
            IncludeExtendedMarketHours = false;
            DataType = typeof (TradeBar);
            SecurityType = SecurityType.Equity;
            TimeZone = TimeZones.NewYork;
            Market = VigiothCapital.QuantTrader.Market.USA;
            IsCustomData = false;
        }
        public HistoryRequest(DateTime startTimeUtc, 
            DateTime endTimeUtc,
            Type dataType,
            Symbol symbol,
            SecurityType securityType,
            Resolution resolution,
            string market,
            SecurityExchangeHours exchangeHours,
            Resolution? fillForwardResolution,
            bool includeExtendedMarketHours,
            bool isCustomData
            )
        {
            StartTimeUtc = startTimeUtc;
            EndTimeUtc = endTimeUtc;
            Symbol = symbol;
            ExchangeHours = exchangeHours;
            Resolution = resolution;
            FillForwardResolution = fillForwardResolution;
            IncludeExtendedMarketHours = includeExtendedMarketHours;
            DataType = dataType;
            SecurityType = securityType;
            Market = market;
            IsCustomData = isCustomData;
            TimeZone = exchangeHours.TimeZone;
        }
        public HistoryRequest(SubscriptionDataConfig config, SecurityExchangeHours hours, DateTime startTimeUtc, DateTime endTimeUtc)
        {
            StartTimeUtc = startTimeUtc;
            EndTimeUtc = endTimeUtc;
            Symbol = config.Symbol;
            ExchangeHours = hours;
            Resolution = config.Resolution;
            FillForwardResolution = config.FillDataForward ? config.Resolution : (Resolution?) null;
            IncludeExtendedMarketHours = config.ExtendedMarketHours;
            DataType = config.Type;
            SecurityType = config.SecurityType;
            Market = config.Market;
            IsCustomData = config.IsCustomData;
            TimeZone = config.DataTimeZone;
        }
    }
}
