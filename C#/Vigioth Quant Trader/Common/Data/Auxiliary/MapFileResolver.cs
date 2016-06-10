using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class MapFileResolver : IEnumerable<MapFile>
    {
        private readonly Dictionary<string, MapFile> _mapFilesByPermtick;
        private readonly Dictionary<string, SortedList<DateTime, MapFileRowEntry>> _bySymbol;
        public static readonly MapFileResolver Empty = new MapFileResolver(Enumerable.Empty<MapFile>());
        public MapFileResolver(IEnumerable<MapFile> mapFiles)
        {
            _mapFilesByPermtick = new Dictionary<string, MapFile>(StringComparer.InvariantCultureIgnoreCase);
            _bySymbol = new Dictionary<string, SortedList<DateTime, MapFileRowEntry>>(StringComparer.InvariantCultureIgnoreCase);
            foreach (var mapFile in mapFiles)
            {
                _mapFilesByPermtick.Add(mapFile.Permtick, mapFile);
                foreach (var row in mapFile)
                {
                    SortedList<DateTime, MapFileRowEntry> entries;
                    var mapFileRowEntry = new MapFileRowEntry(mapFile.Permtick, row);
                    if (!_bySymbol.TryGetValue(row.MappedSymbol, out entries))
                    {
                        entries = new SortedList<DateTime, MapFileRowEntry>();
                        _bySymbol[row.MappedSymbol] = entries;
                    }
                    if (entries.ContainsKey(mapFileRowEntry.MapFileRow.Date))
                    {
                        if (!entries[mapFileRowEntry.MapFileRow.Date].Equals(mapFileRowEntry))
                        {
                            throw new Exception("Attempted to assign different history for symbol.");
                        }
                    }
                    else
                    {
                        entries.Add(mapFileRowEntry.MapFileRow.Date, mapFileRowEntry);
                    }
                }
            }
        }
        public static MapFileResolver Create(string dataDirectory, string market)
        {
            return Create(Path.Combine(dataDirectory, "equity", market.ToLower(), "map_files"));
        }
        public static MapFileResolver Create(string mapFileDirectory)
        {
            return new MapFileResolver(MapFile.GetMapFiles(mapFileDirectory));
        }
        public MapFile GetByPermtick(string permtick)
        {
            MapFile mapFile;
            _mapFilesByPermtick.TryGetValue(permtick.ToUpper(), out mapFile);
            return mapFile;
        }
        public MapFile ResolveMapFile(string symbol, DateTime date)
        {
            SortedList<DateTime, MapFileRowEntry> entries;
            if (_bySymbol.TryGetValue(symbol, out entries))
            {
                if (entries.Count == 0)
                {
                    return new MapFile(symbol, new List<MapFileRow>());
                }
                var indexOf = entries.Keys.BinarySearch(date);
                if (indexOf >= 0)
                {
                    symbol = entries.Values[indexOf].EntitySymbol;
                }
                else
                {
                    indexOf = ~indexOf;
                    if (indexOf < 0 || indexOf > entries.Values.Count - 1)
                    {
                        return new MapFile(symbol, new List<MapFileRow>());
                    }
                    symbol = entries.Values[indexOf].EntitySymbol;
                }
            }
            MapFile mapFile;
            if (!_mapFilesByPermtick.TryGetValue(symbol, out mapFile))
            {
                return new MapFile(symbol, new List<MapFileRow>());
            }
            return mapFile;
        }
        class MapFileRowEntry : IEquatable<MapFileRowEntry>
        {
            public MapFileRow MapFileRow { get; private set; }
            public string EntitySymbol { get; private set; }
            public MapFileRowEntry(string entitySymbol, MapFileRow mapFileRow)
            {
                MapFileRow = mapFileRow;
                EntitySymbol = entitySymbol;
            }
            public bool Equals(MapFileRowEntry other)
            {
                if (other == null) return false;
                return other.MapFileRow.Date == MapFileRow.Date
                    && other.MapFileRow.MappedSymbol == MapFileRow.MappedSymbol;
            }
            public override string ToString()
            {
                return MapFileRow.Date + ": " + MapFileRow.MappedSymbol + ": " + EntitySymbol;
            }
        }
        #region Implementation of IEnumerable
        public IEnumerator<MapFile> GetEnumerator()
        {
            return _mapFilesByPermtick.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}