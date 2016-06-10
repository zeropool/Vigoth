using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class OptionChainUniverseDataCollection : BaseDataCollection
    {
        public BaseData Underlying { get; set; }
        public HashSet<Symbol> FilteredContracts { get; set; }
        public OptionChainUniverseDataCollection()
            : this(DateTime.MinValue, Symbol.Empty)
        {
            FilteredContracts = new HashSet<Symbol>();
        }
        public OptionChainUniverseDataCollection(DateTime time, Symbol symbol, IEnumerable<BaseData> data = null, BaseData underlying = null)
            : this(time, time, symbol, data, underlying)
        {
        }
        public OptionChainUniverseDataCollection(DateTime time, DateTime endTime, Symbol symbol, IEnumerable<BaseData> data = null, BaseData underlying = null)
            : base(time, endTime, symbol, data)
        {
            Underlying = underlying;
        }
        public override BaseData Clone()
        {
            return new OptionChainUniverseDataCollection
            {
                Underlying = Underlying,
                Symbol = Symbol,
                Time = Time,
                EndTime = EndTime,
                Data = Data,
                DataType = DataType,
                FilteredContracts = FilteredContracts
            };
        }
    }
}