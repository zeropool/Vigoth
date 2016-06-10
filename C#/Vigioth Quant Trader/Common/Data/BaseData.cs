using System;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data
{
    public abstract class BaseData : IBaseData
    {
        private MarketDataType _dataType = MarketDataType.Base;
        private DateTime _time;
        private Symbol _symbol = Symbol.Empty;
        private decimal _value;
        private bool _isFillForward;
        public MarketDataType DataType
        {
            get 
            {
                return _dataType;
            }
            set 
            {
                _dataType = value;
            }
        }
        public bool IsFillForward
        {
            get { return _isFillForward; }
        }
        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }
        public virtual DateTime EndTime
        {
            get { return _time; }
            set { _time = value; }
        }
        public Symbol Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public decimal Price
        {
            get 
            {
                return Value;
            }
        }
        public BaseData() 
        { 
        }
        public virtual BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var dataFeed = isLiveMode ? DataFeedEndpoint.LiveTrading : DataFeedEndpoint.Backtesting;
#pragma warning disable 618             
            return Reader(config, line, date, dataFeed);
#pragma warning restore 618
        }
        public virtual SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            var dataFeed = isLiveMode ? DataFeedEndpoint.LiveTrading : DataFeedEndpoint.Backtesting;
#pragma warning disable 618             
            var source = GetSource(config, date, dataFeed);
#pragma warning restore 618
            if (isLiveMode)
            {
                return new SubscriptionDataSource(source, SubscriptionTransportMedium.Rest);
            }
            var uri = new Uri(source, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri && !uri.IsLoopback)
            {
                return new SubscriptionDataSource(source, SubscriptionTransportMedium.RemoteFile);
            }
            return new SubscriptionDataSource(source, SubscriptionTransportMedium.LocalFile);
        }
        public void UpdateTrade(decimal lastTrade, long tradeSize)
        {
            Update(lastTrade, 0, 0, tradeSize, 0, 0);
        }
        public void UpdateQuote(decimal bidPrice, long bidSize, decimal askPrice, long askSize)
        {
            Update(0, bidPrice, askPrice, 0, bidSize, askSize);
        }
        public void UpdateBid(decimal bidPrice, long bidSize)
        {
            Update(0, bidPrice, 0, 0, bidSize, 0);
        }
        public void UpdateAsk(decimal askPrice, long askSize)
        {
            Update(0, 0, askPrice, 0, 0, askSize);
        }
        public virtual void Update(decimal lastTrade, decimal bidPrice, decimal askPrice, decimal volume, decimal bidSize, decimal askSize)
        {
            Value = lastTrade;
        }
        public BaseData Clone(bool fillForward)
        {
            var clone = Clone();
            clone._isFillForward = fillForward;
            return clone;
        }
        public virtual BaseData Clone()
        {
            return (BaseData) ObjectActivator.Clone((object)this);
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", Symbol, Value.ToString("C"));
        }
        [Obsolete("Reader(SubscriptionDataConfig, string, DateTime, DataFeedEndpoint) method has been made obsolete, use Reader(SubscriptionDataConfig, string, DateTime, bool) instead.")]
        public virtual BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, DataFeedEndpoint datafeed)
        {
            throw new InvalidOperationException("Please implement Reader(SubscriptionDataConfig, string, DateTime, bool) on your custom data type: " + GetType().Name);
        }
        [Obsolete("GetSource(SubscriptionDataConfig, DateTime, DataFeedEndpoint) method has been made obsolete, use GetSource(SubscriptionDataConfig, DateTime, bool) instead.")]
        public virtual string GetSource(SubscriptionDataConfig config, DateTime date, DataFeedEndpoint datafeed)
        {
            throw new InvalidOperationException("Please implement GetSource(SubscriptionDataConfig, DateTime, bool) on your custom data type: " + GetType().Name);
        }
    }
}
