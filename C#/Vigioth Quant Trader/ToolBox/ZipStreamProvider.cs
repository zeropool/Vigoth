

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Provides an implementation of <see cref="IStreamProvider"/> that opens zip files
    /// </summary>
    public class ZipStreamProvider : IStreamProvider
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, ZipFile> _zipFiles = new Dictionary<string, ZipFile>();

        /// <summary>
        /// Opens the specified source as read to be consumed stream
        /// </summary>
        /// <param name="source">The source file to be opened</param>
        /// <returns>The stream representing the specified source</returns>
        public IEnumerable<Stream> Open(string source)
        {
            lock (_sync)
            {
                var archive = new ZipFile(source);
                _zipFiles.Add(source, archive);
                foreach (var entry in archive)
                {
                    yield return entry.OpenReader();
                }
            }
        }

        /// <summary>
        /// Closes the specified source file stream
        /// </summary>
        /// <param name="source">The source file to be closed</param>
        public void Close(string source)
        {
            lock (_sync)
            {
                ZipFile archive;
                if (_zipFiles.TryGetValue(source, out archive))
                {
                    _zipFiles.Remove(source);
                    archive.Dispose();
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            lock (_sync)
            {
                foreach (var zipFile in _zipFiles.Values)
                {
                    zipFile.Dispose();
                }
                _zipFiles.Clear();
            }
        }
    }
}