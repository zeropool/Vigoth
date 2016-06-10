using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NodaTime;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Data
{
    public class SubscriptionDataConfig : IEquatable<SubscriptionDataConfig>
    {
        private Symbol _symbol;
        private string _mappedSymbol;
        private readonly SecurityIdentifier _sid;
        public readonly Type Type;
        public readonly SecurityType SecurityType;
        public Symbol Symbol
        {
            get { return _symbol; }
        }
        public readonly TickType TickType;
        public readonly Resolution Resolution;
        public readonly TimeSpan Increment;
        public readonly bool FillDataForward;
        public readonly bool ExtendedMarketHours;
        public readonly bool IsInternalFeed;
        public readonly bool IsCustomData;
        public decimal SumOfDividends;
        public DataNormalizationMode DataNormalizationMode = DataNormalizationMode.Adjusted;
        public decimal PriceScaleFactor;
        public string MappedSymbol
        {
            get { return _mappedSymbol; }
            set
            {
                _mappedSymbol = value;
                _symbol = new Symbol(_sid, value);
            }
        }
        public readonly string Market;
        public readonly DateTimeZone DataTimeZone;
        public readonly DateTimeZone ExchangeTimeZone;
        public readonly HashSet<IDataConsolidator> Consolidators;
        public readonly bool IsFilteredSubscription;
        public SubscriptionDataConfig(Type objectType,
            Symbol symbol,
            Resolution resolution,
            DateTimeZone dataTimeZone,
            DateTimeZone exchangeTimeZone,
            bool fillForward,
            bool extendedHours,
            bool isInternalFeed,
            bool isCustom = false,
            TickType? tickType = null,
            bool isFilteredSubscription = true)
        {
            if (objectType == null) throw new ArgumentNullException("objectType");
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (dataTimeZone == null) throw new ArgumentNullException("dataTimeZone");
            if (exchangeTimeZone == null) throw new ArgumentNullException("exchangeTimeZone");
            Type = objectType;
            SecurityType = symbol.ID.SecurityType;
            Resolution = resolution;
            _sid = symbol.ID;
            FillDataForward = fillForward;
            ExtendedMarketHours = extendedHours;
            PriceScaleFactor = 1;
            MappedSymbol = symbol.Value;
            IsInternalFeed = isInternalFeed;
            IsCustomData = isCustom;
            Market = symbol.ID.Market;
            DataTimeZone = dataTimeZone;
            ExchangeTimeZone = exchangeTimeZone;
            IsFilteredSubscription = isFilteredSubscription;
            Consolidators = new HashSet<IDataConsolidator>();
            if (!tickType.HasValue)
            {
                TickType = TickType.Trade;
                if (SecurityType == SecurityType.Forex || SecurityType == SecurityType.Cfd || SecurityType == SecurityType.Option)
                {
                    TickType = TickType.Quote;
                }
            }
            else
            {
                TickType = tickType.Value;
            }
            switch (resolution)
            {
                case Resolution.Tick:
                    Increment = TimeSpan.FromSeconds(0);
                    FillDataForward = false;
                    break;
                case Resolution.Second:
                    Increment = TimeSpan.FromSeconds(1);
                    break;
                case Resolution.Minute:
                    Increment = TimeSpan.FromMinutes(1);
                    break;
                case Resolution.Hour:
                    Increment = TimeSpan.FromHours(1);
                    break;
                case Resolution.Daily:
                    Increment = TimeSpan.FromDays(1);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Unexpected Resolution: " + resolution);
            }
        }
        public SubscriptionDataConfig(SubscriptionDataConfig config,
            Type objectType = null,
            Symbol symbol = null,
            Resolution? resolution = null,
            DateTimeZone dataTimeZone = null,
            DateTimeZone exchangeTimeZone = null,
            bool? fillForward = null,
            bool? extendedHours = null,
            bool? isInternalFeed = null,
            bool? isCustom = null,
            TickType? tickType = null,
            bool? isFilteredSubscription = null)
            : this(
            objectType ?? config.Type,
            symbol ?? config.Symbol,
            resolution ?? config.Resolution,
            dataTimeZone ?? config.DataTimeZone, 
            exchangeTimeZone ?? config.ExchangeTimeZone,
            fillForward ?? config.FillDataForward,
            extendedHours ?? config.ExtendedMarketHours,
            isInternalFeed ?? config.IsInternalFeed,
            isCustom ?? config.IsCustomData,
            tickType ?? config.TickType,
            isFilteredSubscription ?? config.IsFilteredSubscription
            )
        {
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal GetNormalizedPrice(decimal price)
        {
            switch (DataNormalizationMode)
            {
                case DataNormalizationMode.Raw:
                    return price;
                case DataNormalizationMode.Adjusted:
                case DataNormalizationMode.SplitAdjusted:
                    return price*PriceScaleFactor;
                case DataNormalizationMode.TotalReturn:
                    return (price*PriceScaleFactor) + SumOfDividends;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public bool Equals(SubscriptionDataConfig other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _sid.Equals(other._sid) && Type == other.Type 
                && TickType == other.TickType 
                && Resolution == other.Resolution
                && FillDataForward == other.FillDataForward 
                && ExtendedMarketHours == other.ExtendedMarketHours 
                && IsInternalFeed == other.IsInternalFeed
                && IsCustomData == other.IsCustomData 
                && DataTimeZone.Equals(other.DataTimeZone) 
                && ExchangeTimeZone.Equals(other.ExchangeTimeZone)
                && IsFilteredSubscription == other.IsFilteredSubscription;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubscriptionDataConfig) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _sid.GetHashCode();
                hashCode = (hashCode*397) ^ Type.GetHashCode();
                hashCode = (hashCode*397) ^ (int) TickType;
                hashCode = (hashCode*397) ^ (int) Resolution;
                hashCode = (hashCode*397) ^ FillDataForward.GetHashCode();
                hashCode = (hashCode*397) ^ ExtendedMarketHours.GetHashCode();
                hashCode = (hashCode*397) ^ IsInternalFeed.GetHashCode();
                hashCode = (hashCode*397) ^ IsCustomData.GetHashCode();
                hashCode = (hashCode*397) ^ DataTimeZone.GetHashCode();
                hashCode = (hashCode*397) ^ ExchangeTimeZone.GetHashCode();
                hashCode = (hashCode*397) ^ IsFilteredSubscription.GetHashCode();
                return hashCode;
            }
        }
        public static bool operator ==(SubscriptionDataConfig left, SubscriptionDataConfig right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SubscriptionDataConfig left, SubscriptionDataConfig right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return Symbol.ToString() + "," + MappedSymbol + "," + Resolution;
        }
    }
}
