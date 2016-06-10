

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Engine.Setup;
using VigiothCapital.QuantTrader.Engine.TransactionHandlers;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Statistics;

namespace VigiothCapital.QuantTrader.Tests.Engine
{
    /// <summary>
    /// Provides a result handler implementation that handles result packets via
    /// a constructor defined function. Also, this implementation does not require
    /// the Run method to be called at all, a task is launched via ctor to process
    /// the packets
    /// </summary>
    public class TestResultHandler : IResultHandler
    {
        private AlgorithmNodePacket _job = new BacktestNodePacket();

        private readonly Action<Packet> _packetHandler;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public ConcurrentQueue<Packet> Messages { get; set; }
        public ConcurrentDictionary<string, Chart> Charts { get; set; }
        public TimeSpan ResamplePeriod { get; private set; }
        public TimeSpan NotificationPeriod { get; private set; }
        public bool IsActive { get; private set; }

        public TestResultHandler(Action<Packet> packetHandler = null)
        {
            _packetHandler = packetHandler ?? (packet => { });
            Messages = new ConcurrentQueue<Packet>();
            Task.Run(() =>
            {
                try
                {
                    IsActive = true;
                    while (!_cancellationTokenSource.IsCancellationRequested)
                    {
                        Packet packet;
                        if (Messages.TryDequeue(out packet))
                        {
                            _packetHandler(packet);
                        }

                        Thread.Sleep(1);
                    }
                }
                finally
                {
                    IsActive = false;
                }
            });
        }

        public void Initialize(AlgorithmNodePacket job,
            IMessagingHandler messagingHandler,
            IApi api,
            IDataFeed dataFeed,
            ISetupHandler setupHandler,
            ITransactionHandler transactionHandler)
        {
            _job = job;
        }

        public void Run()
        {
        }

        public void DebugMessage(string message)
        {
            Messages.Enqueue(new DebugPacket(_job.ProjectId, _job.AlgorithmId, _job.CompileId, message));
        }

        public void SecurityType(List<SecurityType> types)
        {
        }

        public void LogMessage(string message)
        {
            Messages.Enqueue(new LogPacket(_job.AlgorithmId, message));
        }

        public void ErrorMessage(string error, string stacktrace = "")
        {
            Messages.Enqueue(new HandledErrorPacket(_job.AlgorithmId, error, stacktrace));
        }

        public void RuntimeError(string message, string stacktrace = "")
        {
            Messages.Enqueue(new RuntimeErrorPacket(_job.AlgorithmId, message, stacktrace));
        }

        public void Sample(string chartName, string seriesName, int seriesIndex, SeriesType seriesType, DateTime time, decimal value, string unit = "$")
        {
            //Add a copy locally:
            if (!Charts.ContainsKey(chartName))
            {
                Charts.AddOrUpdate(chartName, new Chart(chartName));
            }

            //Add the sample to our chart:
            if (!Charts[chartName].Series.ContainsKey(seriesName))
            {
                Charts[chartName].Series.Add(seriesName, new Series(seriesName, seriesType, seriesIndex, unit));
            }

            //Add our value:
            Charts[chartName].Series[seriesName].Values.Add(new ChartPoint(time, value));
        }

        public void SampleEquity(DateTime time, decimal value)
        {
            Sample("Strategy Equity", "Equity", 0, SeriesType.Candle, time, value);
        }

        public void SamplePerformance(DateTime time, decimal value)
        {
            Sample("Strategy Equity", "Daily Performance", 1, SeriesType.Line, time, value, "%");
        }

        public void SampleBenchmark(DateTime time, decimal value)
        {
            Sample("Benchmark", "Benchmark", 0, SeriesType.Line, time, value);
        }

        public void SampleAssetPrices(Symbol symbol, DateTime time, decimal value)
        {
            Sample("Stockplot: " + symbol.Value, "Stockplot: " + symbol.Value, 0, SeriesType.Line, time, value);
        }

        public void SampleRange(List<Chart> updates)
        {
            foreach (var update in updates)
            {
                //Create the chart if it doesn't exist already:
                if (!Charts.ContainsKey(update.Name))
                {
                    Charts.AddOrUpdate(update.Name, new Chart(update.Name, update.ChartType));
                }

                //Add these samples to this chart.
                foreach (var series in update.Series.Values)
                {
                    //If we don't already have this record, its the first packet
                    if (!Charts[update.Name].Series.ContainsKey(series.Name))
                    {
                        Charts[update.Name].Series.Add(series.Name, new Series(series.Name, series.SeriesType, series.Index, series.Unit));
                    }

                    //We already have this record, so just the new samples to the end:
                    Charts[update.Name].Series[series.Name].Values.AddRange(series.Values);
                }
            }
        }

        public void SetAlgorithm(IAlgorithm algorithm)
        {
        }

        public void StoreResult(Packet packet, bool async = false)
        {
        }

        public void SendFinalResult(AlgorithmNodePacket job,
            Dictionary<int, Order> orders,
            Dictionary<DateTime, decimal> profitLoss,
            Dictionary<string, Holding> holdings,
            StatisticsResults statisticsResults,
            Dictionary<string, string> banner)
        {
        }

        public void SendStatusUpdate(AlgorithmStatus status, string message = "")
        {
        }

        public void SetChartSubscription(string symbol)
        {
        }

        public void RuntimeStatistic(string key, string value)
        {
        }

        public void OrderEvent(OrderEvent newEvent)
        {
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }

        public void PurgeQueue()
        {
            Messages.Clear();
        }

        public void ProcessSynchronousEvents(bool forceProcess = false)
        {
        }
    }
}