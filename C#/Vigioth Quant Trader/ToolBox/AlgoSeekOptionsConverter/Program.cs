

using System.IO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.ToolBox.AlgoSeekOptionsConverter
{
    public class Program
    {
        private const string LogFilePath = "AlgoSeekOptionsConverter.txt";

        static void Main()
        {
            var directory = "F:/Downloads/AlgoSeek/smaller";
            directory = "F:/AlgoSeek/20151224";
            var dataDirectory = "./Data";

            Log.LogHandler = new CompositeLogHandler(new ILogHandler[]
            {
                new ConsoleLogHandler(),
                new FileLogHandler(LogFilePath)
            });

            // first process tick/second/minute -- we'll do hour/daily at the end on a per symbol basis
            var parallelism = 4;
            var options = new ParallelOptions {MaxDegreeOfParallelism = parallelism};
            var resolutions = new[] {Resolution.Tick, Resolution.Minute, Resolution.Second, Resolution.Hour, Resolution.Daily};
            
            // for testing only process the smallest 2 files
            var files = Directory.EnumerateFiles(directory).OrderByDescending(x => new FileInfo(x).Length);
            Parallel.ForEach(files, options, file =>
            {
                Log.Trace("Begin tick/second/minute/hour/daily: " + file);

                var quotes = DataProcessor.Zip(dataDirectory, resolutions, TickType.Quote, true);
                var trades = DataProcessor.Zip(dataDirectory, resolutions, TickType.Trade, true);

                var streamProvider = StreamProvider.ForExtension(Path.GetExtension(file));
                if (!RawFileProcessor.Run(file, new[] {file}, streamProvider, new AlgoSeekOptionsParser(), quotes, trades))
                { 
                    return;
                }

                Log.Trace("Completed tick/second/minute/hour/daily: " + file);
            });
            
            Log.Trace("Begin compressing csv files");

            var root = Path.Combine(dataDirectory, "option", "usa");
            var fine =
                from res in new[] {Resolution.Tick, Resolution.Second, Resolution.Minute}
                let path = Path.Combine(root, res.ToLower())
                from sym in Directory.EnumerateDirectories(path)
                from dir in Directory.EnumerateDirectories(sym)
                select new DirectoryInfo(dir).FullName;

            var coarse =
                from res in new[] {Resolution.Hour, Resolution.Daily}
                let path = Path.Combine(root, res.ToLower())
                from dir in Directory.EnumerateDirectories(path)
                select new DirectoryInfo(dir).FullName;

            var all = fine.Union(coarse);

            Parallel.ForEach(all, dir =>
            {
                try
                {
                    // zip the contents of the directory and then delete the directory
                    Compression.ZipDirectory(dir, dir + ".zip", false);
                    Directory.Delete(dir, true);
                }
                catch (Exception err)
                {
                    Log.Error(err, "Zipping " + dir);
                }
            });
            
            Log.Trace("Finished processing directory: " + directory);
        }
    }
}
