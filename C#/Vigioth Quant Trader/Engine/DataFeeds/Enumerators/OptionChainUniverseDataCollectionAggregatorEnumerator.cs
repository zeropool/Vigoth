

using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Auxiliary;
using VigiothCapital.QuantTrader.Data.UniverseSelection;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Enumerators
{
    /// <summary>
    /// Aggregates an enumerator into <see cref="OptionChainUniverseDataCollection"/> instances
    /// </summary>
    public class OptionChainUniverseDataCollectionAggregatorEnumerator : BaseDataCollectionAggregatorEnumerator<OptionChainUniverseDataCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionChainUniverseDataCollectionAggregatorEnumerator"/> class
        /// </summary>
        /// <param name="enumerator">The enumerator to aggregate</param>
        /// <param name="symbol">The output data's symbol</param>
        public OptionChainUniverseDataCollectionAggregatorEnumerator(IEnumerator<BaseData> enumerator, Symbol symbol)
            : base(enumerator, symbol)
        {
        }

        /// <summary>
        /// Adds the specified instance of <see cref="BaseData"/> to the current collection
        /// </summary>
        /// <param name="collection">The collection to be added to</param>
        /// <param name="current">The data to be added</param>
        protected override void Add(OptionChainUniverseDataCollection collection, BaseData current)
        {
            AddSingleItem(collection, current);
        }

        private static void AddSingleItem(OptionChainUniverseDataCollection collection, BaseData current)
        {
            var baseDataCollection = current as BaseDataCollection;
            if (baseDataCollection != null)
            {
                foreach (var data in baseDataCollection.Data)
                {
                    AddSingleItem(collection, data);
                }
                return;
            }

            if (current is ZipEntryName)
            {
                collection.Data.Add(current);
                return;
            }

            collection.Underlying = current;
        }
    }
}