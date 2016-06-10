

using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Provides an implementation of <see cref="IDataProcessor"/> that simply forwards all
    /// received data to other attached processors
    /// </summary>
    public class PipeDataProcessor : IDataProcessor
    {
        private readonly HashSet<IDataProcessor> _processors;

        /// <summary>
        /// Initializes a new instance of the <see cref="PipeDataProcessor"/> class
        /// </summary>
        /// <param name="processors">The processors to pipe the data to</param>
        public PipeDataProcessor(IEnumerable<IDataProcessor> processors)
        {
            _processors = processors.ToHashSet();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PipeDataProcessor"/> class
        /// </summary>
        /// <param name="processors">The processors to pipe the data to</param>
        public PipeDataProcessor(params IDataProcessor[] processors)
            : this((IEnumerable<IDataProcessor>)processors)
        {
        }

        /// <summary>
        /// Adds the specified processor to the output pipe
        /// </summary>
        /// <param name="processor">Processor to receive data from this pipe</param>
        public void PipeTo(IDataProcessor processor)
        {
            _processors.Add(processor);
        }

        /// <summary>
        /// Invoked for each piece of data from the source file
        /// </summary>
        /// <param name="data">The data to be processed</param>
        public void Process(BaseData data)
        {
            foreach (var processor in _processors)
            {
                processor.Process(data);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var processor in _processors)
            {
                processor.Dispose();
            }
        }
    }
}