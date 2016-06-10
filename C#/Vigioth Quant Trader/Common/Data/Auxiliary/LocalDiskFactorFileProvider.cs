using System.Collections.Concurrent;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class LocalDiskFactorFileProvider : IFactorFileProvider
    {
        private readonly IMapFileProvider _mapFileProvider;
        private readonly ConcurrentDictionary<Symbol, FactorFile> _cache;
        public LocalDiskFactorFileProvider()
            : this(Composer.Instance.GetExportedValueByTypeName<IMapFileProvider>(Config.Get("map-file-provider", "LocalDiskMapFileProvider")))
        {
        }
        public LocalDiskFactorFileProvider(IMapFileProvider mapFileProvider)
        {
            _mapFileProvider = mapFileProvider;
            _cache = new ConcurrentDictionary<Symbol, FactorFile>();
        }
        public FactorFile Get(Symbol symbol)
        {
            FactorFile factorFile;
            if (_cache.TryGetValue(symbol, out factorFile))
            {
                return factorFile;
            }
            var market = symbol.ID.Market;
            var mapFileResolver = _mapFileProvider.Get(market);
            if (mapFileResolver == null)
            {
                return GetFactorFile(symbol, symbol.Value, market);
            }
            var mapFile = mapFileResolver.ResolveMapFile(symbol.ID.Symbol, symbol.ID.Date);
            if (mapFile.IsNullOrEmpty())
            {
                return GetFactorFile(symbol, symbol.Value, market);
            }
            return GetFactorFile(symbol, mapFile.Permtick, market);
        }
        private FactorFile GetFactorFile(Symbol symbol, string permtick, string market)
        {
            if (FactorFile.HasScalingFactors(permtick, market))
            {
                var factorFile = FactorFile.Read(permtick, market);
                _cache.AddOrUpdate(symbol, factorFile, (s, c) => factorFile);
                return factorFile;
            }
            return null;
        }
    }
}
