using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Securities
{
    [JsonConverter(typeof(MarketHoursDatabaseJsonConverter))]
    public class MarketHoursDatabase
    {
        private static MarketHoursDatabase _dataFolderMarketHoursDatabase;
        private static readonly object DataFolderMarketHoursDatabaseLock = new object();
        private readonly IReadOnlyDictionary<SecurityDatabaseKey, Entry> _entries;
        public static MarketHoursDatabase AlwaysOpen
        {
            get { return new AlwaysOpenMarketHoursDatabase(); }
        }
        public List<KeyValuePair<SecurityDatabaseKey,Entry>> ExchangeHoursListing
        {
            get { return _entries.ToList(); }
        }
        public MarketHoursDatabase(IReadOnlyDictionary<SecurityDatabaseKey, Entry> exchangeHours)
        {
            _entries = exchangeHours.ToDictionary();
        }
        private MarketHoursDatabase()
        {
        }
        public SecurityExchangeHours GetExchangeHours(SubscriptionDataConfig configuration, DateTimeZone overrideTimeZone = null)
        {
            if (configuration.SecurityType == SecurityType.Base && overrideTimeZone == null) overrideTimeZone = configuration.ExchangeTimeZone;
            return GetExchangeHours(configuration.Market, configuration.Symbol, configuration.SecurityType, overrideTimeZone);
        }
        public SecurityExchangeHours GetExchangeHours(string market, Symbol symbol, SecurityType securityType, DateTimeZone overrideTimeZone = null)
        {
            var stringSymbol = symbol == null ? string.Empty : symbol.Value;
            return GetEntry(market, stringSymbol, securityType, overrideTimeZone).ExchangeHours;
        }
        public DateTimeZone GetDataTimeZone(string market, Symbol symbol, SecurityType securityType)
        {
            var stringSymbol = symbol == null ? string.Empty : symbol.Value;
            return GetEntry(market, stringSymbol, securityType).DataTimeZone;
        }
        public static MarketHoursDatabase FromDataFolder()
        {
            lock (DataFolderMarketHoursDatabaseLock)
            {
                if (_dataFolderMarketHoursDatabase == null)
                {
                    var path = Path.Combine(Globals.DataFolder, "market-hours", "market-hours-database.json");
                    _dataFolderMarketHoursDatabase = FromFile(path);
                }
            }
            return _dataFolderMarketHoursDatabase;
        }
        public static MarketHoursDatabase FromFile(string path)
        {
            return JsonConvert.DeserializeObject<MarketHoursDatabase>(File.ReadAllText(path));
        }
        public virtual Entry GetEntry(string market, string symbol, SecurityType securityType, DateTimeZone overrideTimeZone = null)
        {
            Entry entry;
            var key = new SecurityDatabaseKey(market, symbol, securityType);
            if (!_entries.TryGetValue(key, out entry))
            {
                if (!_entries.TryGetValue(new SecurityDatabaseKey(market, null, securityType), out entry))
                {
                    if (securityType == SecurityType.Base)
                    {
                        if (overrideTimeZone == null)
                        {
                            overrideTimeZone = TimeZones.Utc;
                            Log.Error("MarketHoursDatabase.GetExchangeHours(): Custom data no time zone specified, default to UTC. " + key);
                        }
                        return new Entry(overrideTimeZone, SecurityExchangeHours.AlwaysOpen(overrideTimeZone));
                    }
                    Log.Error(string.Format("MarketHoursDatabase.GetExchangeHours(): Unable to locate exchange hours for {0}." + "Available keys: {1}", key, string.Join(", ", _entries.Keys)));
                    throw new ArgumentException("Unable to locate exchange hours for " + key);
                }
                if (overrideTimeZone != null && !entry.ExchangeHours.TimeZone.Equals(overrideTimeZone))
                {
                    return new Entry(overrideTimeZone, new SecurityExchangeHours(overrideTimeZone, entry.ExchangeHours.Holidays, entry.ExchangeHours.MarketHours));
                }
            }
            return entry;
        }
        public class Entry
        {
            public readonly DateTimeZone DataTimeZone;
            public readonly SecurityExchangeHours ExchangeHours;
            public Entry(DateTimeZone dataTimeZone, SecurityExchangeHours exchangeHours)
            {
                DataTimeZone = dataTimeZone;
                ExchangeHours = exchangeHours;
            }
        }
        class AlwaysOpenMarketHoursDatabase : MarketHoursDatabase
        {
            public override Entry GetEntry(string market, string symbol, SecurityType securityType, DateTimeZone overrideTimeZone = null)
            {
                var tz = overrideTimeZone ?? TimeZones.Utc;
                return new Entry(tz, SecurityExchangeHours.AlwaysOpen(tz));
            }
        }
    }
}
