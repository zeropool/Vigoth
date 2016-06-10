using System;
namespace VigiothCapital.QuantTrader.Data
{
    public interface IBaseData
    {
        MarketDataType DataType
        {
            get;
            set;
        }
        DateTime Time
        {
            get;
            set;
        }
        Symbol Symbol
        {
            get;
            set;
        }
        decimal Value
        {
            get;
            set;
        }
        decimal Price
        {
            get;
        }
        BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, DataFeedEndpoint datafeed);
        string GetSource(SubscriptionDataConfig config, DateTime date, DataFeedEndpoint datafeed);
        BaseData Clone();
    }     
}    
