
using System;
using System.Globalization;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.ToolBox.QuandlBitfinexDownloader
{
    class Program
    {
        /// <summary>
        /// Quandl Bitfinex Toolbox Project For LEAN Algorithmic Trading Engine.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Downloader FROMDATE APIKEY");
                Console.WriteLine("FROMDATE = yyyymmdd");
                Environment.Exit(1);
            }

            try
            {
                // Load settings from config.json
                var dataDirectory = Config.Get("data-directory", "../../../Data");
                var scaleFactor = Config.GetInt("bitfinex-scale-factor", 100);

                // Create an instance of the downloader
                const string market = Market.Bitfinex;
                var downloader = new QuandlBitfinexDownloader(args[1], scaleFactor);

                // Download the data
                var symbol = Symbol.Create("BTCUSD", SecurityType.Forex, market);
                var data = downloader.Get(symbol, Resolution.Daily, DateTime.ParseExact(args[0], "yyyyMMdd", CultureInfo.CurrentCulture), DateTime.UtcNow);

                // Save the data
                var writer = new LeanDataWriter(Resolution.Daily, symbol, dataDirectory, TickType.Quote);
                writer.Write(data);
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
    }
}
