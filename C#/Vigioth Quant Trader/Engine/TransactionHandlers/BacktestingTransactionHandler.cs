

using System;
using VigiothCapital.QuantTrader.Brokerages.Backtesting;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;

namespace VigiothCapital.QuantTrader.Engine.TransactionHandlers
{
    /// <summary>
    /// This transaction handler is used for processing transactions during backtests
    /// </summary>
    public class BacktestingTransactionHandler : BrokerageTransactionHandler
    {
        // save off a strongly typed version of the brokerage
        private BacktestingBrokerage _brokerage;

        /// <summary>
        /// Creates a new BacktestingTransactionHandler using the BacktestingBrokerage
        /// </summary>
        /// <param name="algorithm">The algorithm instance</param>
        /// <param name="brokerage">The BacktestingBrokerage</param>
        /// <param name="resultHandler"></param>
        public override void Initialize(IAlgorithm algorithm, IBrokerage brokerage, IResultHandler resultHandler)
        {
            if (!(brokerage is BacktestingBrokerage))
            {
                throw new ArgumentException("Brokerage must be of type BacktestingBrokerage for use wth the BacktestingTransactionHandler");
            }
            
            _brokerage = (BacktestingBrokerage) brokerage;

            base.Initialize(algorithm, brokerage, resultHandler);
        }

        /// <summary>
        /// Processes all synchronous events that must take place before the next time loop for the algorithm
        /// </summary>
        public override void ProcessSynchronousEvents()
        {
            base.ProcessSynchronousEvents();

            _brokerage.Scan();
        }

        /// <summary>
        /// Processes asynchronous events on the transaction handler's thread
        /// </summary>
        public override void ProcessAsynchronousEvents()
        {
            base.ProcessAsynchronousEvents();

            _brokerage.Scan();
        }
    }
}