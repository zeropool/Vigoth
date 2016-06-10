
using System;
using System.Collections.Generic;
using System.Net;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using Newtonsoft.Json;
using System.Linq;

namespace VigiothCapital.QuantTrader.ToolBox.CryptoiqDownloader
{
    public class CryptoiqDownloader : IDataDownloader
    {
        private readonly string _exchange;
        private readonly decimal _scaleFactor;

        public CryptoiqDownloader(string exchange = "bitfinex", decimal scaleFactor = 1m)
        {
            _exchange = exchange;
            _scaleFactor = scaleFactor;
        }

        public IEnumerable<BaseData> Get(Symbol symbol, Resolution resolution, DateTime startUtc, DateTime endUtc)
        {
            if (resolution != Resolution.Tick)
            {
                throw new ArgumentException("Only tick data is currently supported.");
            }

            var hour = 1;
            var counter = startUtc;
            const string url = "http://cryptoiq.io/api/marketdata/ticker/{3}/{2}/{0}/{1}";

            while (counter <= endUtc)
            {
                while (hour < 24)
                {
                    using (var cl = new WebClient())
                    {
                        var request = string.Format(url, counter.ToString("yyyy-MM-dd"), hour, symbol.Value, _exchange);
                        var data = cl.DownloadString(request);

                        var mbtc = JsonConvert.DeserializeObject<List<CryptoiqBitcoin>>(data);
                        foreach (var item in mbtc.OrderBy(x => x.Time))
                        {
                            yield return new Tick
                            {
                                Time = item.Time,
                                Symbol = symbol,
                                Value = item.Last/_scaleFactor,
                                AskPrice = item.Ask/_scaleFactor,
                                BidPrice = item.Bid/_scaleFactor,
                                TickType = TickType.Quote
                            };
                        }
                        hour++;
                    }
                }
                counter = counter.AddDays(1);
                hour = 0;
            }
        }

    }
}