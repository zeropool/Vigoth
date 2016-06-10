

using System;
using Newtonsoft.Json;
using NodaTime;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    /// <summary>
    /// Custom data type that causes rest api calls
    /// </summary>
    public class RestApiBaseData : TradeBar
    {
        public static int ReaderCount = 0;
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            ReaderCount++;
            //[{"symbol":"SPY","time":1444271505,"alpha":1,"beta":2}]
            var array = JsonConvert.DeserializeObject<JsonSerialization[]>(line);
            if (array.Length > 0)
            {
                return array[0].ToBaseData(config.DataTimeZone, config.Increment, config.Symbol);
            }
            return null;
        }

        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            var remoteFileSource = @"https://www.quantconnect.com/live-test?type=rest&symbols=" + config.Symbol.Value;
            //remoteFileSource = @"http://beta.quantconnect.com/live-test?type=rest&symbols=" + config.Symbol.Value;
            return new SubscriptionDataSource(remoteFileSource, SubscriptionTransportMedium.Rest, FileFormat.Csv);
        }

        private class JsonSerialization
        {
            public string symbol;
            public double time;
            public double alpha;
            public double beta;

            public RestApiBaseData ToBaseData(DateTimeZone timeZone, TimeSpan period, Symbol sym)
            {
                var dateTime = VigiothCapital.QuantTrader.Time.UnixTimeStampToDateTime(time).ConvertFromUtc(timeZone).Subtract(period);
                return new RestApiBaseData
                {
                    Symbol = sym,
                    Time = dateTime,
                    EndTime = dateTime.Add(period),
                    Value = (decimal) alpha
                };
            }
        }
    }
}