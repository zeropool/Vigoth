

using System.Collections.Generic;
using System.IO;
using Ionic.BZip2;

namespace VigiothCapital.QuantTrader.ToolBox
{
    public class Bz2StreamProvider : IStreamProvider
    {
        /// <summary>
        /// Opens the specified source as read to be consumed stream
        /// </summary>
        /// <param name="source">The source file to be opened</param>
        /// <returns>The stream representing the specified source</returns>
        public IEnumerable<Stream> Open(string source)
        {
            yield return new BZip2InputStream(File.OpenRead(source));
        }

        /// <summary>
        /// Closes the specified source file stream
        /// </summary>
        /// <param name="source">The source file to be closed</param>
        public void Close(string source)
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}