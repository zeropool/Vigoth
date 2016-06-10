

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Engine;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Tests
{
    /// <summary>
    /// Provides methods for running an algorithm and testing it's performance metrics
    /// </summary>
    public static class AlgorithmRunner
    {
        static AlgorithmRunner()
        {
            // delete the regression.log file, since we turned debug output on it can grow pretty quickly
            try { System.IO.File.Delete("regression.log"); } catch {  }
        }

        public static void RunLocalBacktest(string algorithm, Dictionary<string, string> expectedStatistics, Language language)
        {
            var statistics = new Dictionary<string, string>();

            Composer.Instance.Reset();

            try
            {
                // set the configuration up
                Config.Set("algorithm-type-name", algorithm);
                Config.Set("live-mode", "false");
                Config.Set("environment", "");
                Config.Set("messaging-handler", "VigiothCapital.QuantTrader.Messaging.Messaging");
                Config.Set("job-queue-handler", "VigiothCapital.QuantTrader.Queues.JobQueue");
                Config.Set("api-handler", "VigiothCapital.QuantTrader.Api.Api");
                Config.Set("result-handler", "VigiothCapital.QuantTrader.Engine.Results.BacktestingResultHandler");
                Config.Set("algorithm-language", language.ToString());
                Config.Set("algorithm-location", "VigiothCapital.QuantTrader.Algorithm." + language + ".dll");

                var debugEnabled = Log.DebuggingEnabled;

                var logHandlers = new ILogHandler[] {new ConsoleLogHandler(), new FileLogHandler("regression.log", false)};
                using (Log.LogHandler = new CompositeLogHandler(logHandlers))
                using (var algorithmHandlers = LeanEngineAlgorithmHandlers.FromConfiguration(Composer.Instance))
                using (var systemHandlers = LeanEngineSystemHandlers.FromConfiguration(Composer.Instance))
                {
                    Log.DebuggingEnabled = true;

                    Log.LogHandler.Trace("");
                    Log.LogHandler.Trace("{0}: Running " + algorithm + "...", DateTime.UtcNow);
                    Log.LogHandler.Trace("");

                    // run the algorithm in its own thread

                    var engine = new VigiothCapital.QuantTrader.Engine.Engine(systemHandlers, algorithmHandlers, false);
                    Task.Factory.StartNew(() =>
                    {
                        string algorithmPath;
                        var job = systemHandlers.JobQueue.NextJob(out algorithmPath);
                        engine.Run(job, algorithmPath);
                    }).Wait();

                    var backtestingResultHandler = (BacktestingResultHandler)algorithmHandlers.Results;
                    statistics = backtestingResultHandler.FinalStatistics;
                    
                    Log.DebuggingEnabled = debugEnabled;
                }
            }
            catch (Exception ex)
            {
                Log.LogHandler.Error("{0} {1}", ex.Message, ex.StackTrace);
            }

            foreach (var stat in expectedStatistics)
            {
                Assert.AreEqual(true, statistics.ContainsKey(stat.Key), "Missing key: " + stat.Key);
                Assert.AreEqual(stat.Value, statistics[stat.Key], "Failed on " + stat.Key);
            }
        }
    }
}
