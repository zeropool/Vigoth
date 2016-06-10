
using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.ToolBox
{
    /// <summary>
    /// Data Downloader Interface for pulling data from a remote source.
    /// </summary>
    public interface IDataDownloader
    {
        /// <summary>
        /// Get historical data enumerable for a single symbol, type and resolution given this start and end time (in UTC).
        /// </summary>
        /// <param name="symbol">Symbol for the data we're looking for.</param>
        /// <param name="resolution">Resolution of the data request</param>
        /// <param name="startUtc">Start time of the data in UTC</param>
        /// <param name="endUtc">End time of the data in UTC</param>
        /// <returns>Enumerable of base data for this symbol</returns>
        IEnumerable<BaseData> Get(Symbol symbol, Resolution resolution, DateTime startUtc, DateTime endUtc);
    }
}