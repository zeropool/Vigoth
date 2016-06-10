

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Represents a type responsible for accepting an input <see cref="SubscriptionDataSource"/>
    /// and returning an enumerable of the source's <see cref="BaseData"/>
    /// </summary>
    public interface ISubscriptionFactory
    {
        /// <summary>
        /// Event fired when the specified source is considered invalid, this may
        /// be from a missing file or failure to download a remote source
        /// </summary>
        event EventHandler<InvalidSourceEventArgs> InvalidSource;

        /// <summary>
        /// Reads the specified <paramref name="source"/>
        /// </summary>
        /// <param name="source">The source to be read</param>
        /// <returns>An <see cref="IEnumerable{BaseData}"/> that contains the data in the source</returns>
        IEnumerable<BaseData> Read(SubscriptionDataSource source);
    }

    /// <summary>
    /// Provides a factory method for creating <see cref="ISubscriptionFactory"/> instances
    /// </summary>
    public static class SubscriptionFactory
    {
        /// <summary>
        /// Createsa new <see cref="ISubscriptionFactory"/> capable of handling the specified <paramref name="source"/>
        /// </summary>
        /// <param name="source">The subscription data source to create a factory for</param>
        /// <param name="config">The configuration of the subscription</param>
        /// <param name="date">The date to be processed</param>
        /// <param name="isLiveMode">True for live mode, false otherwise</param>
        /// <returns>A new <see cref="ISubscriptionFactory"/> that can read the specified <paramref name="source"/></returns>
        public static ISubscriptionFactory ForSource(SubscriptionDataSource source, SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            switch (source.Format)
            {
                case FileFormat.Csv:
                    return new TextSubscriptionFactory(config, date, isLiveMode);

                case FileFormat.Collection:
                    return new CollectionSubscriptionFactory(config, date, isLiveMode);

                case FileFormat.ZipEntryName:
                    return new ZipEntryNameSubscriptionFactory(config, date, isLiveMode);

                default:
                    throw new NotImplementedException("SubscriptionFactory.ForSource(" + source + ") has not been implemented yet.");
            }
        }
    }

}
