

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Provides an implementation of <see cref="IDataProcessor"/> that writes the incoming
    /// stream of data to a csv file.
    /// </summary>
    public class CsvDataProcessor : IDataProcessor
    {
        private const int TicksPerFlush = 50;
        private static readonly object DirectoryCreateSync = new object();
        
        private readonly string _dataDirectory;
        private readonly Resolution _resolution;
        private readonly TickType _tickType;
        private readonly Dictionary<Symbol, Writer> _writers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvDataProcessor"/> class
        /// </summary>
        /// <param name="dataDirectory">The root data directory, /Data</param>
        /// <param name="resolution">The resolution being sent into the Process method</param>
        /// <param name="tickType">The tick type, trade or quote</param>
        public CsvDataProcessor(string dataDirectory, Resolution resolution, TickType tickType)
        {
            _dataDirectory = dataDirectory;
            _resolution = resolution;
            _tickType = tickType;
            _writers = new Dictionary<Symbol, Writer>();
        }

        /// <summary>
        /// Invoked for each piece of data from the source file
        /// </summary>
        /// <param name="data">The data to be processed</param>
        public void Process(BaseData data)
        {
            Writer writer;
            if (!_writers.TryGetValue(data.Symbol, out writer))
            {
                writer = CreateTextWriter(data);
                _writers[data.Symbol] = writer;
            }

            // flush every so often
            if (++writer.ProcessCount%TicksPerFlush == 0)
            {
                writer.TextWriter.Flush();
            }

            var line = LeanData.GenerateLine(data, data.Symbol.ID.SecurityType, _resolution);
            writer.TextWriter.WriteLine(line);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var kvp in _writers)
            {
                kvp.Value.TextWriter.Dispose();
            }
        }

        /// <summary>
        /// Creates the <see cref="TextWriter"/> that writes data to csv files
        /// </summary>
        private Writer CreateTextWriter(BaseData data)
        {
            var entry = LeanData.GenerateZipEntryName(data.Symbol, data.Time.Date, _resolution, _tickType);
            var relativePath = LeanData.GenerateRelativeZipFilePath(data.Symbol, data.Time.Date, _resolution, _tickType)
                .Replace(".zip", string.Empty);
            var path = Path.Combine(Path.Combine(_dataDirectory, relativePath), entry);
            var directory = new FileInfo(path).Directory.FullName;
            if (!Directory.Exists(directory))
            {
                // lock before checking again
                lock (DirectoryCreateSync) if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            }

            return new Writer(path, new StreamWriter(path));
        }


        private sealed class Writer
        {
            public readonly string Path;
            public readonly TextWriter TextWriter;
            public int ProcessCount;
            public Writer(string path, TextWriter textWriter)
            {
                Path = path;
                TextWriter = textWriter;
            }
        }
    }
}