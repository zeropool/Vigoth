
using System;
using System.Globalization;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.ToolBox.YahooDownloader
{
    class Program
    {
        /// <summary>
        /// Yahoo Downloader Toolbox Project For LEAN Algorithmic Trading Engine.
        /// Original by @chrisdk2015, tidied by @jaredbroad
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: YahooDownloader SYMBOLS RESOLUTION FROMDATE TODATE");
                Console.WriteLine("SYMBOLS = eg SPY,AAPL");
                Console.WriteLine("RESOLUTION = Daily");
                Console.WriteLine("FROMDATE = yyyymmdd");
                Console.WriteLine("TODATE = yyyymmdd");
                Environment.Exit(1);
            }

            try
            {
                // Load settings from command line
                var symbols = args[0].Split(',');
                var resolution = (Resolution)Enum.Parse(typeof(Resolution), args[1]);
                var startDate = DateTime.ParseExact(args[2], "yyyyMMdd", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(args[3], "yyyyMMdd", CultureInfo.InvariantCulture);

                // Load settings from config.json
                var dataDirectory = Config.Get("data-directory", "../../../Data");

                // Create an instance of the downloader
                const string market = Market.USA;
                var downloader = new YahooDataDownloader();

                foreach (var symbol in symbols)
                {
                    // Download the data
                    var symbolObject = Symbol.Create(symbol, SecurityType.Equity, market);
                    var data = downloader.Get(symbolObject, resolution, startDate, endDate);

                    // Save the data
                    var writer = new LeanDataWriter(resolution, symbolObject, dataDirectory);
                    writer.Write(data);
                }
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
    }
}
