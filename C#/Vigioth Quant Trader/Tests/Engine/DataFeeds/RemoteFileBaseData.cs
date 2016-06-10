

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Tests.Engine.DataFeeds
{
    /// <summary>
    /// Custom data type that uses a remote file download
    /// </summary>
    public class RemoteFileBaseData : BaseData
    {
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var csv = line.Split(',');
            if (csv[1].ToLower() != config.Symbol.ToString().ToLower())
            {
                // this row isn't for me
                return null;
            }

            var time = VigiothCapital.QuantTrader.Time.UnixTimeStampToDateTime(double.Parse(csv[0])).ConvertFromUtc(config.DataTimeZone).Subtract(config.Increment);
            return new RemoteFileBaseData
            {
                Symbol = config.Symbol,
                Time = time,
                EndTime = time.Add(config.Increment),
                Value = decimal.Parse(csv[3])

            };
        }

        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            // this file is only a few seconds worth of data, so it's quick to download
            var remoteFileSource = @"http://www.quantconnect.com/live-test?type=file&symbols=" + config.Symbol.Value;
            remoteFileSource = @"http://beta.quantconnect.com/live-test?type=file&symbols=" + config.Symbol.Value;
            return new SubscriptionDataSource(remoteFileSource, SubscriptionTransportMedium.RemoteFile, FileFormat.Csv);
        }
    }
}