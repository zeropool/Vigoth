

using System.IO;
using Ionic.Zip;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds.Transport
{
    /// <summary>
    /// Represents a stream reader capable of reading lines from disk
    /// </summary>
    public class LocalFileSubscriptionStreamReader : IStreamReader
    {
        private StreamReader _streamReader;
        private readonly ZipFile _zipFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalFileSubscriptionStreamReader"/> class.
        /// </summary>
        /// <param name="source">The local file to be read</param>
        /// <param name="entryName">Specifies the zip entry to be opened. Leave null if not applicable,
        /// or to open the first zip entry found regardless of name</param>
        public LocalFileSubscriptionStreamReader(string source, string entryName = null)
        {
            // unzip if necessary
            _streamReader = source.GetExtension() == ".zip"
                ? Compression.Unzip(source, entryName, out _zipFile)
                : new StreamReader(source);
        }

        /// <summary>
        /// Gets <see cref="SubscriptionTransportMedium.LocalFile"/>
        /// </summary>
        public SubscriptionTransportMedium TransportMedium
        {
            get { return SubscriptionTransportMedium.LocalFile; }
        }

        /// <summary>
        /// Gets whether or not there's more data to be read in the stream
        /// </summary>
        public bool EndOfStream
        {
            get { return _streamReader == null || _streamReader.EndOfStream; }
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
            if (_streamReader != null)
            {
                _streamReader.Dispose();
                _streamReader = null;
            }
            if (_zipFile != null)
            {
                _zipFile.Dispose();
            }
        }
    }
}