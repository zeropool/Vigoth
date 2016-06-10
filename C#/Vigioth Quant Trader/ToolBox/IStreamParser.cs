

using System;
using System.Collections.Generic;
using System.IO;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Represents a type capable of accepting a stream and parsing it into an enumerable of data
    /// </summary>
    public interface IStreamParser : IDisposable
    {
        /// <summary>
        /// Parses the specified input stream into an enumerable of data
        /// </summary>
        /// <param name="source">The source of the stream</param>
        /// <param name="stream">The input stream to be parsed</param>
        /// <returns>An enumerable of base data</returns>
        IEnumerable<BaseData> Parse(string source, Stream stream);
    }
}