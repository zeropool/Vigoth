using System;
using System.Collections.Generic;
using System.Linq;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class BaseDataCollection : BaseData
    {
        private DateTime _endTime;
        public List<BaseData> Data { get; set; }
        public override DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        public BaseDataCollection()
            : this(DateTime.MinValue, Symbol.Empty)
        {
        }
        public BaseDataCollection(DateTime time, Symbol symbol, IEnumerable<BaseData> data = null)
            : this(time, time, symbol, data)
        {
        }
        public BaseDataCollection(DateTime time, DateTime endTime, Symbol symbol, IEnumerable<BaseData> data = null)
        {
            Symbol = symbol;
            Time = time;
            _endTime = endTime;
            Data = data != null ? data.ToList() : new List<BaseData>();
        }
        public override BaseData Clone()
        {
            return new BaseDataCollection(Time, EndTime, Symbol, Data);
        }
    }
}
