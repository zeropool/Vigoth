using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class LocalDiskMapFileProvider : IMapFileProvider
    {
        private static int _wroteTraceStatement;
        private readonly ConcurrentDictionary<string, MapFileResolver> _cache = new ConcurrentDictionary<string, MapFileResolver>();
        public MapFileResolver Get(string market)
        {
            market = market.ToLower();
            return _cache.GetOrAdd(market, GetMapFileResolver);
        }
        private static MapFileResolver GetMapFileResolver(string market)
        {
            var mapFileDirectory = Path.Combine(Globals.DataFolder, "equity", market.ToLower(), "map_files");
            if (!Directory.Exists(mapFileDirectory))
            {
                if (Interlocked.CompareExchange(ref _wroteTraceStatement, 1, 0) == 0)
                {
                    Log.Error("LocalDiskMapFileProvider.GetMapFileResolver({0}): The specified directory does not exist: {1}", market, mapFileDirectory);
                }
                return MapFileResolver.Empty;
            }
            return new MapFileResolver(MapFile.GetMapFiles(mapFileDirectory));
        }
    }
}
