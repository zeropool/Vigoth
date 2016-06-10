

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Ionic.Zip;
using Newtonsoft.Json.Linq;
using VigiothCapital.QuantTrader.Data.Auxiliary;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Util;
using Log = VigiothCapital.QuantTrader.Logging.Log;

namespace VigiothCapital.QuantTrader.ToolBox.CoarseUniverseGenerator
{
    public static class Program
    {
        private const string ExclusionsFile = "exclusions.txt";

        public static void Main(string[] args)
        {
            JToken jtoken;
            var config = JObject.Parse(File.ReadAllText("CoarseUniverseGenerator/config.json"));

            var ignoreMaplessSymbols = false;
            var updateMode = false;
            var updateTime = TimeSpan.Zero;
            if (config.TryGetValue("update-mode", out jtoken))
            {
                updateMode = jtoken.Value<bool>();
                if (config.TryGetValue("update-time-of-day", out jtoken))
                {
                    updateTime = TimeSpan.Parse(jtoken.Value<string>());
                }
            }

            var dataDirectory = Globals.DataFolder;
            if (config.TryGetValue("data-directory", out jtoken))
            {
                dataDirectory = jtoken.Value<string>();
            }

            if (config.TryGetValue("ignore-mapless", out jtoken))
            {
                ignoreMaplessSymbols = jtoken.Value<bool>();
            }

            do
            {
                ProcessEquityDirectories(dataDirectory, ignoreMaplessSymbols);
            }
            while (WaitUntilTimeInUpdateMode(updateMode, updateTime));
        }

        private static bool WaitUntilTimeInUpdateMode(bool updateMode, TimeSpan updateTime)
        {
            if (!updateMode) return false;

            var now = DateTime.Now;
            var timeUntilNextProcess = (now.Date.AddDays(1).Add(updateTime) - now);
            Thread.Sleep((int)timeUntilNextProcess.TotalMilliseconds);
            return true;
        }

        public static void ProcessEquityDirectories(string dataDirectory, bool ignoreMaplessSymbols)
        {
            var exclusions = ReadExclusionsFile(ExclusionsFile);

            var equity = Path.Combine(dataDirectory, "equity");
            foreach (var directory in Directory.EnumerateDirectories(equity))
            {
                var dailyFolder = Path.Combine(directory, "daily");
                var mapFileFolder = Path.Combine(directory, "map_files");
                var coarseFolder = Path.Combine(directory, "fundamental", "coarse");
                if (!Directory.Exists(coarseFolder))
                {
                    Directory.CreateDirectory(coarseFolder);
                }

                var lastProcessedDate = GetStartDate(coarseFolder);
                ProcessDailyFolder(dailyFolder, coarseFolder, MapFileResolver.Create(mapFileFolder), exclusions, ignoreMaplessSymbols, lastProcessedDate);
            }
        }

        public static ICollection<string> ProcessDailyFolder(string dailyFolder, string coarseFolder, MapFileResolver mapFileResolver, HashSet<string> exclusions, bool ignoreMapless, DateTime startDate, Func<string, string> symbolResolver = null)
        {
            const decimal scaleFactor = 10000m;

            Log.Trace("Processing: {0}", dailyFolder);

            var start = DateTime.UtcNow;

            var symbols = 0;
            var maplessCount = 0;
            var dates = new HashSet<DateTime>();

            var writers = new Dictionary<string, StreamWriter>();

            var dailyFolderDirectoryInfo = new DirectoryInfo(dailyFolder).Parent;
            if (dailyFolderDirectoryInfo == null)
            {
                throw new Exception("Unable to resolve market for daily folder: " + dailyFolder);
            }
            var market = dailyFolderDirectoryInfo.Name.ToLower();

            foreach (var file in Directory.EnumerateFiles(dailyFolder))
            {
                try
                {
                    var symbol = Path.GetFileNameWithoutExtension(file);
                    if (symbol == null)
                    {
                        Log.Trace("CoarseGenerator.ProcessDailyFolder(): Unable to resolve symbol from file: {0}", file);
                        continue;
                    }

                    if (symbolResolver != null)
                    {
                        symbol = symbolResolver(symbol);
                    }

                    symbol = symbol.ToUpper();

                    if (exclusions.Contains(symbol))
                    {
                        Log.Trace("Excluded symbol: {0}", symbol);
                        continue;
                    }

                    ZipFile zip;
                    using (var reader = Compression.Unzip(file, out zip))
                    {
                        const decimal k = 2m / (30 + 1);

                        var seeded = false;
                        var runningAverageVolume = 0m;

                        var checkedForMapFile = false;

                        symbols++;
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var csv = line.Split(',');
                            var date = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture);
                            
                            if (date < startDate) continue;

                            if (ignoreMapless && !checkedForMapFile)
                            {
                                checkedForMapFile = true;
                                if (!mapFileResolver.ResolveMapFile(symbol, date).Any())
                                {
                                    maplessCount++;
                                    break;
                                }
                            }

                            var close = decimal.Parse(csv[4])/scaleFactor;
                            var volume = long.Parse(csv[5]);

                            runningAverageVolume = seeded
                                ? volume*k + runningAverageVolume*(1 - k)
                                : volume;

                            seeded = true;

                            var dollarVolume = close * runningAverageVolume;

                            var coarseFile = Path.Combine(coarseFolder, date.ToString("yyyyMMdd") + ".csv");
                            dates.Add(date);

                            var sid = SecurityIdentifier.GenerateEquity(SecurityIdentifier.DefaultDate, symbol, market);
                            var mapFile = mapFileResolver.ResolveMapFile(symbol, date);
                            if (!mapFile.IsNullOrEmpty())
                            {
                                sid = SecurityIdentifier.GenerateEquity(mapFile.FirstDate, mapFile.OrderBy(x => x.Date).First().MappedSymbol, market);
                            }
                            if (mapFile == null && ignoreMapless)
                            {
                                Log.Error(string.Format("CoarseGenerator.ProcessDailyFolder(): Unable to resolve map file for {0} as of {1}", symbol, date.ToShortDateString()));
                                continue;
                            }

                            var coarseFileLine = sid + "," + symbol + "," + close + "," + volume + "," + Math.Truncate(dollarVolume);

                            StreamWriter writer;
                            if (!writers.TryGetValue(coarseFile, out writer))
                            {
                                writer = new StreamWriter(new FileStream(coarseFile, FileMode.Create, FileAccess.Write, FileShare.Write));
                                writers[coarseFile] = writer;
                            }
                            writer.WriteLine(coarseFileLine);
                        }
                    }

                    if (symbols%1000 == 0)
                    {
                        Log.Trace("CoarseGenerator.ProcessDailyFolder(): Completed processing {0} symbols. Current elapsed: {1} seconds", symbols, (DateTime.UtcNow - start).TotalSeconds.ToString("0.00"));
                    }
                }
                catch (Exception err)
                {
                    Log.Error(err.ToString());
                }
            }

            Log.Trace("CoarseGenerator.ProcessDailyFolder(): Saving {0} coarse files to disk", dates.Count);

            foreach (var writer in writers)
            {
                writer.Value.Dispose();
            }

            var stop = DateTime.UtcNow;

            Log.Trace("CoarseGenerator.ProcessDailyFolder(): Processed {0} symbols into {1} coarse files in {2} seconds", symbols, dates.Count, (stop - start).TotalSeconds.ToString("0.00"));
            Log.Trace("CoarseGenerator.ProcessDailyFolder(): Excluded {0} mapless symbols.", maplessCount);

            return writers.Keys;
        }

        public static HashSet<string> ReadExclusionsFile(string exclusionsFile)
        {
            var exclusions = new HashSet<string>();
            if (File.Exists(exclusionsFile))
            {
                var excludedSymbols = File.ReadLines(exclusionsFile).Select(x => x.Trim()).Where(x => !x.StartsWith("#"));
                exclusions = new HashSet<string>(excludedSymbols, StringComparer.InvariantCultureIgnoreCase);
                Log.Trace("CoarseGenerator.ReadExclusionsFile(): Loaded {0} symbols into the exclusion set", exclusions.Count);
            }
            return exclusions;
        }

        public static DateTime GetStartDate(string coarseDirectory)
        {
            var lastProcessedDate = (
                from coarseFile in Directory.EnumerateFiles(coarseDirectory)
                let date = TryParseCoarseFileDate(coarseFile)
                where date != null
                select date.Value.AddDays(1)
                ).DefaultIfEmpty(DateTime.MinValue).Max();

            return lastProcessedDate;
        }

        private static DateTime? TryParseCoarseFileDate(string coarseFile)
        {
            try
            {
                var dateString = Path.GetFileNameWithoutExtension(coarseFile);
                return DateTime.ParseExact(dateString, "yyyyMMdd", null);
            }
            catch
            {
                return null;
            }
        }
    }
}
