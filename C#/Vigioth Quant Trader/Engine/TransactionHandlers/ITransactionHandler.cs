

using System.Collections.Concurrent;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Engine.TransactionHandlers
{
    /// <summary>
    /// Transaction handlers define how the transactions are processed and set the order fill information.
    /// The pass this information back to the algorithm portfolio and ensure the cash and portfolio are synchronized.
    /// </summary>
    [InheritedExport(typeof(ITransactionHandler))]
    public interface ITransactionHandler : IOrderProcessor
    {
        /// <summary>
        /// Boolean flag indicating the thread is busy. 
        /// False indicates it is completely finished processing and ready to be terminated.
        /// </summary>
        bool IsActive
        {
            get;
        }

        /// <summary>
        /// Gets the permanent storage for all orders
        /// </summary>
        ConcurrentDictionary<int, Order> Orders
        {
            get;
        }

        /// <summary>
        /// Initializes the transaction handler for the specified algorithm using the specified brokerage implementation
        /// </summary>
        void Initialize(IAlgorithm algorithm, IBrokerage brokerage, IResultHandler resultHandler);

        /// <summary>
        /// Primary thread entry point to launch the transaction thread.
        /// </summary>
        void Run();

        /// <summary>
        /// Signal a end of thread request to stop montioring the transactions.
        /// </summary>
        void Exit();

        /// <summary>
        /// Process any synchronous events from the primary algorithm thread.
        /// </summary>
        void ProcessSynchronousEvents();
    }
}
