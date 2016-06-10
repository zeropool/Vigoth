using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class MapFile : IEnumerable<MapFileRow>
    {
        private readonly SortedDictionary<DateTime, MapFileRow> _data;
        public string Permtick { get; private set; }
        public DateTime DelistingDate
        {
            get { return _data.Keys.Count == 0 ? Time.EndOfTime : _data.Keys.Last(); }
        }
        public DateTime FirstDate
        {
            get { return _data.Keys.Count == 0 ? Time.BeginningOfTime : _data.Keys.First(); }
        }
        public MapFile(string permtick, IEnumerable<MapFileRow> data)
        {
            Permtick = permtick.ToUpper();
            _data = new SortedDictionary<DateTime, MapFileRow>(data.Distinct().ToDictionary(x => x.Date));
        }
        public string GetMappedSymbol(DateTime searchDate)
        {
            var mappedSymbol = "";
            foreach (var splitDate in _data.Keys)
            {
                if (splitDate < searchDate) continue;
                mappedSymbol = _data[splitDate].MappedSymbol;
                break;
            }
            return mappedSymbol;
        }
        public bool HasData(DateTime date)
        {
            if (_data.Count == 0)
            {
                return true;
            }
            if (date < _data.Keys.First() || date > _data.Keys.Last())
            {
                return false;
            }
            return true;
        }
        public static MapFile Read(string permtick, string market)
        {
            return new MapFile(permtick, MapFileRow.Read(permtick, market));
        }
        public static string GetMapFilePath(string permtick, string market)
        {
            return Path.Combine(Globals.DataFolder, "equity", market, "map_files", permtick.ToLower() + ".csv");
        }
        #region Implementation of IEnumerable
        public IEnumerator<MapFileRow> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        public static IEnumerable<MapFile> GetMapFiles(string mapFileDirectory)
        {
            return from file in Directory.EnumerateFiles(mapFileDirectory)
                   where file.EndsWith(".csv")
                   let permtick = Path.GetFileNameWithoutExtension(file)
                   let fileRead = SafeMapFileRowRead(file)
                   select new MapFile(permtick, fileRead);
        }
        private static List<MapFileRow> SafeMapFileRowRead(string file)
        {
            try
            {
                return MapFileRow.Read(file).ToList();
            }
            catch (Exception err)
            {
                Log.Error(err, "File: " + file);
                return new List<MapFileRow>();
            }
        }
    }
}