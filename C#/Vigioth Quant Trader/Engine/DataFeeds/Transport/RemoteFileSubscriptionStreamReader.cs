

using System;
using System.IO;
using System.Net;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Transport
{
    /// <summary>
    /// Represents a stream reader capabable of downloading a remote file and then
    /// reading it from disk
    /// </summary>
    public class RemoteFileSubscriptionStreamReader : IStreamReader
    {
        private readonly IStreamReader _streamReader;

        /// <summary>
        /// Initializes a new insance of the <see cref="RemoteFileSubscriptionStreamReader"/> class.
        /// </summary>
        /// <param name="source">The remote url to be downloaded via web client</param>
        /// <param name="downloadDirectory">The local directory and destination of the download</param>
        public RemoteFileSubscriptionStreamReader(string source, string downloadDirectory)
        {
            // create a hash for a new filename
            var filename = Guid.NewGuid() + source.GetExtension();
            var destination = Path.Combine(downloadDirectory, filename);

            using (var client = new WebClient())
            {
                client.Proxy = WebRequest.GetSystemWebProxy();
                client.DownloadFile(source, destination);
            }

            // now we can just use the local file reader
            _streamReader = new LocalFileSubscriptionStreamReader(destination);
        }

        /// <summary>
        /// Gets <see cref="SubscriptionTransportMedium.RemoteFile"/>
        /// </summary>
        public SubscriptionTransportMedium TransportMedium
        {
            get { return SubscriptionTransportMedium.RemoteFile; }
        }

        /// <summary>
        /// Gets whether or not there's more data to be read in the stream
        /// </summary>
        public bool EndOfStream
        {
            get { return _streamReader.EndOfStream; }
        }

        /// <summary>
        /// Gets the next line/batch of content from the stream 
        /// </summary>
        public string ReadLine()
        {
            return _streamReader.ReadLine();
        }

        /// <summary>
        /// Disposes of the stream
        /// </summary>
        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
