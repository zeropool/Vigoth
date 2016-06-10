
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Represents a work item to be processed
    /// </summary>
    public interface IParallelRunnerWorkItem
    {
        /// <summary>
        /// Determines if this work item is ready to be processed
        /// </summary>
        bool IsReady { get; }
        /// <summary>
        /// Executes this work item
        /// </summary>
        /// <returns>The result of execution</returns>
        void Execute();
    }
}