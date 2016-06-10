

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Logging;
using SevenZip;

namespace VigiothCapital.QuantTrader.ToolBox.DukascopyDownloader
{
    public class DukascopyDataDownloader : IDataDownloader
    {
        private readonly DukascopySymbolMapper _symbolMapper = new DukascopySymbolMapper();
        private const int DukascopyTickLength = 20;

        public bool HasSymbol(string symbol)
        {
            return _symbolMapper.IsKnownLeanSymbol(Symbol.Create(symbol, GetSecurityType(symbol), Market.Dukascopy));
        }

        public SecurityType GetSecurityType(string symbol)
        {
            return _symbolMapper.GetLeanSecurityType(symbol);
        }

        public IEnumerable<BaseData> Get(Symbol symbol, Resolution resolution, DateTime startUtc, DateTime endUtc)
        {
            if (!_symbolMapper.IsKnownLeanSymbol(symbol))
                throw new ArgumentException("Invalid symbol requested: " + symbol.Value);

            if (symbol.ID.SecurityType != SecurityType.Forex && symbol.ID.SecurityType != SecurityType.Cfd)
                throw new NotSupportedException("SecurityType not available: " + symbol.ID.SecurityType);

            if (endUtc < startUtc)
                throw new ArgumentException("The end date must be greater or equal to the start date.");

            DateTime date = startUtc;

            while (date <= endUtc)
            {
                var ticks = DownloadTicks(symbol, date);

                switch (resolution)
                {
                    case Resolution.Tick:
                        foreach (var tick in ticks)
                        {
                            yield return new Tick(tick.Time, symbol, tick.BidPrice, tick.AskPrice);
                        }
                        break;

                    case Resolution.Second:
                    case Resolution.Minute:
                    case Resolution.Hour:
                    case Resolution.Daily:
                        foreach (var bar in AggregateTicks(symbol, ticks, resolution.ToTimeSpan()))
                        {
                            yield return bar;
                        }
                        break;
                }

                date = date.AddDays(1);
            }
        }

        internal static IEnumerable<TradeBar> AggregateTicks(Symbol symbol, IEnumerable<Tick> ticks, TimeSpan resolution)
        {
            return 
                (from t in ticks
                 group t by t.Time.RoundDown(resolution)
                     into g
                     select new TradeBar
                     {
                         Symbol = symbol,
                         Time = g.Key,
                         Open = g.First().LastPrice,
                         High = g.Max(t => t.LastPrice),
                         Low = g.Min(t => t.LastPrice),
                         Close = g.Last().LastPrice
                     });
        }

        private IEnumerable<Tick> DownloadTicks(Symbol symbol, DateTime date)
        {
            var dukascopySymbol = _symbolMapper.GetBrokerageSymbol(symbol);
            var pointValue = _symbolMapper.GetPointValue(symbol);

            for (var hour = 0; hour < 24; hour++)
            {
                var timeOffset = hour * 3600000;

                var url = string.Format(@"http://www.dukascopy.com/datafeed/{0}/{1:D4}/{2:D2}/{3:D2}/{4:D2}h_ticks.bi5",
                    dukascopySymbol, date.Year, date.Month - 1, date.Day, hour);

                using (var client = new WebClient())
                {
                    byte[] bytes;
                    try
                    {
                        bytes = client.DownloadData(url);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception);
                        yield break;
                    }
                    if (bytes != null && bytes.Length > 0)
                    {
                        var ticks = AppendTicksToList(symbol, bytes, date, timeOffset, pointValue);
                        foreach (var tick in ticks)
                        {
                            yield return tick;
                        }
                    }
                }
            }
        }

        private static unsafe List<Tick> AppendTicksToList(Symbol symbol, byte[] bytesBi5, DateTime date, int timeOffset, double pointValue)
        {
            var ticks = new List<Tick>();

            using (var inStream = new MemoryStream(bytesBi5))
            {
                using (var outStream = new MemoryStream())
                {
                    SevenZipExtractor.DecompressStream(inStream, outStream, (int)inStream.Length, null);

                    byte[] bytes = outStream.GetBuffer();
                    int count = bytes.Length / DukascopyTickLength;

                    fixed (byte* pBuffer = &bytes[0])
                    {
                        uint* p = (uint*)pBuffer;

                        for (int i = 0; i < count; i++)
                        {
                            ReverseBytes(p); uint time = *p++;
                            ReverseBytes(p); uint ask = *p++;
                            ReverseBytes(p); uint bid = *p++;
                            p++; p++;

                            if (bid > 0 && ask > 0)
                            {
                                ticks.Add(new Tick(
                                    date.AddMilliseconds(timeOffset + time), 
                                    symbol, 
                                    Convert.ToDecimal(bid / pointValue), 
                                    Convert.ToDecimal(ask / pointValue)));
                            }
                        }
                    }
                }
            }

            return ticks;
        }

        private static unsafe void ReverseBytes(uint* p)
        {
            *p = (*p & 0x000000FF) << 24 | (*p & 0x0000FF00) << 8 | (*p & 0x00FF0000) >> 8 | (*p & 0xFF000000) >> 24;
        }

    }
}
