using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class MapFileRow : IEquatable<MapFileRow>
    {
        public DateTime Date { get; private set; }
        public string MappedSymbol { get; private set; }
        public MapFileRow(DateTime date, string mappedSymbol)
        {
            Date = date;
            MappedSymbol = mappedSymbol.ToUpper();
        }
        public static IEnumerable<MapFileRow> Read(string permtick, string market)
        {
            var path = MapFile.GetMapFilePath(permtick, market);
            return File.Exists(path) 
                ? Read(path) 
                : Enumerable.Empty<MapFileRow>();
        }
        public static IEnumerable<MapFileRow> Read(string path)
        {
            return File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l)).Select(Parse);
        }
        public static MapFileRow Parse(string line)
        {
            var csv = line.Split(',');
            return new MapFileRow(DateTime.ParseExact(csv[0], DateFormat.EightCharacter, null), csv[1]);
        }
        #region Equality members
        public bool Equals(MapFileRow other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Date.Equals(other.Date) && string.Equals(MappedSymbol, other.MappedSymbol);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MapFileRow)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Date.GetHashCode() * 397) ^ (MappedSymbol != null ? MappedSymbol.GetHashCode() : 0);
            }
        }
        public static bool operator ==(MapFileRow left, MapFileRow right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(MapFileRow left, MapFileRow right)
        {
            return !Equals(left, right);
        }
        #endregion
        public override string ToString()
        {
            return Date.ToShortDateString() + ": " + MappedSymbol;
        }
    }
}