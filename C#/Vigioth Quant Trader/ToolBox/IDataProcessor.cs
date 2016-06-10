

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Specifies a piece of processing that should be performed against a source file
    /// </summary>
    public interface IDataProcessor : IDisposable
    {
        /// <summary>
        /// Invoked for each piece of data from the source file
        /// </summary>
        /// <param name="data">The data to be processed</param>
        void Process(BaseData data);
    }

    /// <summary>
    /// Provides methods for creating data processor stacks
    /// </summary>
    public static class DataProcessor
    {
        /// <summary>
        /// Creates a new data processor that will filter in input data before piping it into the specified processor
        /// </summary>
        public static IDataProcessor FilteredBy(this IDataProcessor processor, Func<BaseData, bool> predicate)
        {
            return new FilteredDataProcessor(processor, predicate);
        }

        /// <summary>
        /// Creates a data processor that will aggregate and zip the requested resolutions of data
        /// </summary>
        public static IDataProcessor Zip(string dataDirectory, IEnumerable<Resolution> resolutions, TickType tickType, bool sourceIsTick)
        {
            var set = resolutions.ToHashSet();

            var root = new PipeDataProcessor();

            // only filter tick sources
            var stack = !sourceIsTick ? root 
                : (IDataProcessor) new FilteredDataProcessor(root, x => ((Tick) x).TickType == tickType);

            if (set.Contains(Resolution.Tick))
            {
                // tick is filtered via trade/quote
                var tick = new CsvDataProcessor(dataDirectory, Resolution.Tick, tickType);
                root.PipeTo(tick);
            }
            if (set.Contains(Resolution.Second))
            {
                root = AddResolution(dataDirectory, tickType, root, Resolution.Second, sourceIsTick);
                sourceIsTick = false;
            }
            if (set.Contains(Resolution.Minute))
            {
                root = AddResolution(dataDirectory, tickType, root, Resolution.Minute, sourceIsTick);
                sourceIsTick = false;
            }
            if (set.Contains(Resolution.Hour))
            {
                root = AddResolution(dataDirectory, tickType, root, Resolution.Hour, sourceIsTick);
                sourceIsTick = false;
            }
            if (set.Contains(Resolution.Daily))
            {
                AddResolution(dataDirectory, tickType, root, Resolution.Daily, sourceIsTick);
            }
            return stack;
        }

        private static PipeDataProcessor AddResolution(string dataDirectory, TickType tickType, PipeDataProcessor root, Resolution resolution, bool sourceIsTick)
        {
            var second = new CsvDataProcessor(dataDirectory, resolution, tickType);
            var secondRoot = new PipeDataProcessor(second);
            var aggregator = new ConsolidatorDataProcessor(secondRoot, data => CreateConsolidator(resolution, tickType, data, sourceIsTick));
            root.PipeTo(aggregator);
            return secondRoot;
        }

        private static IDataConsolidator CreateConsolidator(Resolution resolution, TickType tickType, BaseData data, bool sourceIsTick)
        {
            var securityType = data.Symbol.ID.SecurityType;
            switch (securityType)
            {
                case SecurityType.Base:
                case SecurityType.Equity:
                case SecurityType.Cfd:
                case SecurityType.Forex:
                    return new TickConsolidator(resolution.ToTimeSpan());

                case SecurityType.Option:
                    if (tickType == TickType.Trade)
                    {
                        return sourceIsTick
                            ? new TickConsolidator(resolution.ToTimeSpan())
                            : (IDataConsolidator) new TradeBarConsolidator(resolution.ToTimeSpan());
                    }
                    if (tickType == TickType.Quote)
                    {
                        return sourceIsTick
                            ? new TickQuoteBarConsolidator(resolution.ToTimeSpan())
                            : (IDataConsolidator) new QuoteBarConsolidator(resolution.ToTimeSpan());
                    }
                    break;
            }
            throw new NotImplementedException("Consolidator creation is not defined for " + securityType + " " + tickType);
        }
    }
}