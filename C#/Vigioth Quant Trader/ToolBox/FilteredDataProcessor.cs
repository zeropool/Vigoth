

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Provides an implementation of <see cref="IDataProcessor"/> that filters the incoming
    /// stream of data before passing it along to the wrapped processor
    /// </summary>
    public class FilteredDataProcessor : IDataProcessor
    {
        private readonly Func<BaseData, bool> _predicate;
        private readonly IDataProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilteredDataProcessor"/> class
        /// </summary>
        /// <param name="processor">The processor to filter data for</param>
        /// <param name="predicate">The filtering predicate to be applied</param>
        public FilteredDataProcessor(IDataProcessor processor, Func<BaseData, bool> predicate)
        {
            _predicate = predicate;
            _processor = processor;
        }

        /// <summary>
        /// Invoked for each piece of data from the source file
        /// </summary>
        /// <param name="data">The data to be processed</param>
        public void Process(BaseData data)
        {
            if (_predicate(data))
            {
                _processor.Process(data);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _processor.Dispose();
        }
    }
}