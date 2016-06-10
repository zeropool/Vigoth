

using System;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.DataFeeds;
using VigiothCapital.QuantTrader.Engine.RealTime;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Engine.Setup;
using VigiothCapital.QuantTrader.Engine.TransactionHandlers;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Engine
{
    /// <summary>
    /// Provides a container for the algorithm specific handlers
    /// </summary>
    public class LeanEngineAlgorithmHandlers : IDisposable
    {
        private readonly IDataFeed _dataFeed;
        private readonly ISetupHandler _setup;
        private readonly IResultHandler _results;
        private readonly IRealTimeHandler _realTime;
        private readonly ITransactionHandler _transactions;
        private readonly IHistoryProvider _historyProvider;
        private readonly ICommandQueueHandler _commandQueue;
        private readonly IMapFileProvider _mapFileProvider;
        private readonly IFactorFileProvider _factorFileProvider;

        /// <summary>
        /// Gets the result handler used to communicate results from the algorithm
        /// </summary>
        public IResultHandler Results
        {
            get { return _results; }
        }

        /// <summary>
        /// Gets the setup handler used to initialize the algorithm state
        /// </summary>
        public ISetupHandler Setup
        {
            get { return _setup; }
        }

        /// <summary>
        /// Gets the data feed handler used to provide data to the algorithm
        /// </summary>
        public IDataFeed DataFeed
        {
            get { return _dataFeed; }
        }

        /// <summary>
        /// Gets the transaction handler used to process orders from the algorithm
        /// </summary>
        public ITransactionHandler Transactions
        {
            get { return _transactions; }
        }

        /// <summary>
        /// Gets the real time handler used to process real time events
        /// </summary>
        public IRealTimeHandler RealTime
        {
            get { return _realTime; }
        }

        /// <summary>
        /// Gets the history provider used to process historical data requests within the algorithm
        /// </summary>
        public IHistoryProvider HistoryProvider
        {
            get { return _historyProvider; }
        }

        /// <summary>
        /// Gets the command queue responsible for receiving external commands for the algorithm
        /// </summary>
        public ICommandQueueHandler CommandQueue
        {
            get { return _commandQueue; }
        }

        /// <summary>
        /// Gets the map file provider used as a map file source for the data feed
        /// </summary>
        public IMapFileProvider MapFileProvider
        {
            get { return _mapFileProvider; }
        }

        /// <summary>
        /// Gets the map file provider used as a map file source for the data feed
        /// </summary>
        public IFactorFileProvider FactorFileProvider
        {
            get { return _factorFileProvider; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeanEngineAlgorithmHandlers"/> class from the specified handlers
        /// </summary>
        /// <param name="results">The result handler for communicating results from the algorithm</param>
        /// <param name="setup">The setup handler used to initialize algorithm state</param>
        /// <param name="dataFeed">The data feed handler used to pump data to the algorithm</param>
        /// <param name="transactions">The transaction handler used to process orders from the algorithm</param>
        /// <param name="realTime">The real time handler used to process real time events</param>
        /// <param name="historyProvider">The history provider used to process historical data requests</param>
        /// <param name="commandQueue">The command queue handler used to receive external commands for the algorithm</param>
        /// <param name="mapFileProvider">The map file provider used to retrieve map files for the data feed</param>
        public LeanEngineAlgorithmHandlers(IResultHandler results,
            ISetupHandler setup,
            IDataFeed dataFeed,
            ITransactionHandler transactions,
            IRealTimeHandler realTime,
            IHistoryProvider historyProvider,
            ICommandQueueHandler commandQueue,
            IMapFileProvider mapFileProvider,
            IFactorFileProvider factorFileProvider
            )
        {
            if (results == null)
            {
                throw new ArgumentNullException("results");
            }
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }
            if (dataFeed == null)
            {
                throw new ArgumentNullException("dataFeed");
            }
            if (transactions == null)
            {
                throw new ArgumentNullException("transactions");
            }
            if (realTime == null)
            {
                throw new ArgumentNullException("realTime");
            }
            if (historyProvider == null)
            {
                throw new ArgumentNullException("realTime");
            }
            if (commandQueue == null)
            {
                throw new ArgumentNullException("commandQueue");
            }
            if (mapFileProvider == null)
            {
                throw new ArgumentNullException("mapFileProvider");
            }
            if (factorFileProvider == null)
            {
                throw new ArgumentNullException("factorFileProvider");
            }
            _results = results;
            _setup = setup;
            _dataFeed = dataFeed;
            _transactions = transactions;
            _realTime = realTime;
            _historyProvider = historyProvider;
            _commandQueue = commandQueue;
            _mapFileProvider = mapFileProvider;
            _factorFileProvider = factorFileProvider;
        }
        
        /// <summary>
        /// Creates a new instance of the <see cref="LeanEngineAlgorithmHandlers"/> class from the specified composer using type names from configuration
        /// </summary>
        /// <param name="composer">The composer instance to obtain implementations from</param>
        /// <returns>A fully hydrates <see cref="LeanEngineSystemHandlers"/> instance.</returns>
        /// <exception cref="CompositionException">Throws a CompositionException during failure to load</exception>
        public static LeanEngineAlgorithmHandlers FromConfiguration(Composer composer)
        {
            var setupHandlerTypeName = Config.Get("setup-handler", "ConsoleSetupHandler");
            var transactionHandlerTypeName = Config.Get("transaction-handler", "BacktestingTransactionHandler");
            var realTimeHandlerTypeName = Config.Get("real-time-handler", "BacktestingRealTimeHandler");
            var dataFeedHandlerTypeName = Config.Get("data-feed-handler", "FileSystemDataFeed");
            var resultHandlerTypeName = Config.Get("result-handler", "BacktestingResultHandler");
            var historyProviderTypeName = Config.Get("history-provider", "SubscriptionDataReaderHistoryProvider");
            var commandQueueHandlerTypeName = Config.Get("command-queue-handler", "EmptyCommandQueueHandler");
            var mapFileProviderTypeName = Config.Get("map-file-provider", "LocalDiskMapFileProvider");
            var factorFileProviderTypeName = Config.Get("factor-file-provider", "LocalDiskFactorFileProvider");

            return new LeanEngineAlgorithmHandlers(
                composer.GetExportedValueByTypeName<IResultHandler>(resultHandlerTypeName),
                composer.GetExportedValueByTypeName<ISetupHandler>(setupHandlerTypeName),
                composer.GetExportedValueByTypeName<IDataFeed>(dataFeedHandlerTypeName),
                composer.GetExportedValueByTypeName<ITransactionHandler>(transactionHandlerTypeName),
                composer.GetExportedValueByTypeName<IRealTimeHandler>(realTimeHandlerTypeName),
                composer.GetExportedValueByTypeName<IHistoryProvider>(historyProviderTypeName),
                composer.GetExportedValueByTypeName<ICommandQueueHandler>(commandQueueHandlerTypeName),
                composer.GetExportedValueByTypeName<IMapFileProvider>(mapFileProviderTypeName),
                composer.GetExportedValueByTypeName<IFactorFileProvider>(factorFileProviderTypeName)
                );
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Setup.Dispose();
            CommandQueue.Dispose();
        }
    }
}