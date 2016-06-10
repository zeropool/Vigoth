using System;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class ZipEntryName : BaseData
    {
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var symbol = LeanData.ReadSymbolFromZipEntry(config.SecurityType, config.Resolution, line);
            return new ZipEntryName {Time = date, Symbol = symbol};
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            if (isLiveMode)
            {
                return new SubscriptionDataSource(string.Empty, SubscriptionTransportMedium.LocalFile);
            }
            var source = LeanData.GenerateZipFilePath(Globals.DataFolder, config.Symbol, date, config.Resolution, config.TickType);
            return new SubscriptionDataSource(source, SubscriptionTransportMedium.LocalFile, FileFormat.ZipEntryName);
        }
    }
}
