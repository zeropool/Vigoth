

using System;
using System.Collections.Generic;
using System.IO;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.ToolBox.AlgoSeekOptionsConverter;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Provides an implementation of <see cref="IStreamParser"/> that reads files in the lean format
    /// </summary>
    public class LeanParser : IStreamParser
    {
        /// <summary>
        /// Parses the specified input stream into an enumerable of data
        /// </summary>
        /// <param name="source">The source file corresponding the the stream</param>
        /// <param name="stream">The input stream to be parsed</param>
        /// <returns>An enumerable of base data</returns>
        public IEnumerable<BaseData> Parse(string source, Stream stream)
        {
            var pathComponents = LeanDataPathComponents.Parse(source);
            var tickType = pathComponents.Filename.ToLower().Contains("_trade")
                ? TickType.Trade
                : TickType.Quote;

            var dataType = GetDataType(pathComponents.SecurityType, pathComponents.Resolution, tickType);
            var factory = (BaseData) Activator.CreateInstance(dataType);
            
            // ignore time zones here, i.e, we're going to emit data in the data time zone
            var config = new SubscriptionDataConfig(dataType, pathComponents.Symbol, pathComponents.Resolution, TimeZones.Utc, TimeZones.Utc, false, true, false);
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return factory.Reader(config, line, pathComponents.Date, false);
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        private Type GetDataType(SecurityType securityType, Resolution resolution, TickType tickType)
        {
            if (resolution == Resolution.Tick)
            {
                return typeof (Tick);
            }

            switch (securityType)
            {
                case SecurityType.Base:
                case SecurityType.Equity:
                case SecurityType.Cfd:
                case SecurityType.Forex:
                    return typeof (TradeBar);

                case SecurityType.Option:
                    if (tickType == TickType.Trade) return typeof (TradeBar);
                    if (tickType == TickType.Quote) return typeof (QuoteBar);
                    break;
            }
            var parameters = string.Join(" | ", securityType, resolution, tickType);
            throw new NotImplementedException("LeanParser.GetDataType does has not yet implemented: " + parameters);
        }
    }
}