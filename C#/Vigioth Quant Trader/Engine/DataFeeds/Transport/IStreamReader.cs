

using System;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Transport
{
    /// <summary>
    /// Defines a transport mechanism for data from its source into various reader methods
    /// </summary>
    public interface IStreamReader : IDisposable
    {
        /// <summary>
        /// Gets the transport medium of this stream reader
        /// </summary>
        SubscriptionTransportMedium TransportMedium { get; }

        /// <summary>
        /// Gets whether or not there's more data to be read in the stream
        /// </summary>
        bool EndOfStream { get; }
        
        /// <summary>
        /// Gets the next line/batch of content from the stream 
        /// </summary>
        string ReadLine();
    }
}
