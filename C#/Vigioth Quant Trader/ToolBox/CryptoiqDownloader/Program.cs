
using System;
using System.Globalization;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.ToolBox.CryptoiqDownloader
{
    class Program
    {
        /// <summary>
        /// Cryptoiq Downloader Toolbox Project For LEAN Algorithmic Trading Engine.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                args = new [] { args[0], DateTime.UtcNow.ToString("yyyyMMdd"), args[1], args[2] };
            }
            else if (args.Length < 4)
            {
                Console.WriteLine("Usage: CryptoiqDownloader FROMDATE TODATE EXCHANGE SYMBOL");
                Console.WriteLine("FROMDATE = yyyymmdd");
                Console.WriteLine("TODATE = yyyymmdd");
                Environment.Exit(1);
            }

            try
            {
                // Load settings from command line
                var startDate = DateTime.ParseExact(args[0], "yyyyMMdd", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(args[1], "yyyyMMdd", CultureInfo.InvariantCulture);

                // Load settings from config.json
                var dataDirectory = Config.Get("data-directory", "../../../Data");
                var scaleFactor = Config.GetValue("bitfinex-scale-factor", 1m);

                // Create an instance of the downloader
                const string market = Market.Bitfinex;
                var downloader = new CryptoiqDownloader(args[2], scaleFactor);

                // Download the data
                var symbolObject = Symbol.Create(args[3], SecurityType.Forex, market);
                var data = downloader.Get(symbolObject, Resolution.Tick, startDate, endDate);

                // Save the data
                var writer = new LeanDataWriter(Resolution.Tick, symbolObject, dataDirectory, TickType.Quote);
                writer.Write(data);
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
    }
}