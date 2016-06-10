
using System;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Provides a functional implementation of the <see cref="IParallelRunnerWorkItem"/> interface
    /// </summary>
    public sealed class FuncParallelRunnerWorkItem : IParallelRunnerWorkItem
    {
        private readonly Func<bool> _isReady;
        private readonly Action _execute;
        /// <summary>
        /// Determines if this work item is ready to be processed
        /// </summary>
        public bool IsReady
        {
            get { return _isReady(); }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FuncParallelRunnerWorkItem"/> class
        /// </summary>
        /// <param name="isReady">The IsReady function implementation</param>
        /// <param name="execute">The Execute function implementation</param>
        public FuncParallelRunnerWorkItem(Func<bool> isReady, Action execute)
        {
            _isReady = isReady;
            _execute = execute;
        }
        /// <summary>
        /// Executes this work item
        /// </summary>
        /// <returns>The result of execution</returns>
        public void Execute()
        {
            _execute();
        }
    }
}