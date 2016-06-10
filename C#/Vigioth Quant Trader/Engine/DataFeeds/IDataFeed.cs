

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Engine.Results;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Datafeed interface for creating custom datafeed sources.
    /// </summary>
    [InheritedExport(typeof(IDataFeed))]
    public interface IDataFeed : IEnumerable<TimeSlice>
    {
        /// <summary>
        /// Gets all of the current subscriptions this data feed is processing
        /// </summary>
        IEnumerable<Subscription> Subscriptions
        {
            get;
        }

        /// <summary>
        /// Public flag indicator that the thread is still busy.
        /// </summary>
        bool IsActive
        {
            get;
        }

        /// <summary>
        /// Initializes the data feed for the specified job and algorithm
        /// </summary>
        void Initialize(IAlgorithm algorithm, AlgorithmNodePacket job, IResultHandler resultHandler, IMapFileProvider mapFileProvider, IFactorFileProvider factorFileProvider);

        /// <summary>
        /// Adds a new subscription to provide data for the specified security.
        /// </summary>
        /// <param name="universe">The universe the subscription is to be added to</param>
        /// <param name="security">The security to add a subscription for</param>
        /// <param name="config">The subscription config to be added</param>
        /// <param name="utcStartTime">The start time of the subscription</param>
        /// <param name="utcEndTime">The end time of the subscription</param>
        /// <returns>True if the subscription was created and added successfully, false otherwise</returns>
        bool AddSubscription(Universe universe, Security security, SubscriptionDataConfig config, DateTime utcStartTime, DateTime utcEndTime);

        /// <summary>
        /// Removes the subscription from the data feed, if it exists
        /// </summary>
        /// <param name="configuration">The configuration of the subscription to remove</param>
        /// <returns>True if the subscription was successfully removed, false otherwise</returns>
        bool RemoveSubscription(SubscriptionDataConfig configuration);

        /// <summary>
        /// Primary entry point.
        /// </summary>
        void Run();

        /// <summary>
        /// External controller calls to signal a terminate of the thread.
        /// </summary>
        void Exit();
    }
}
