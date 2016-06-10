using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class IdentityDataConsolidator<T> : DataConsolidator<T>
        where T : BaseData
    {
        private static readonly bool IsTick = typeof (T) == typeof (Tick);
        private T _last;
        public override BaseData WorkingData
        {
            get { return _last == null ? null : _last.Clone(); }
        }
        public override Type OutputType
        {
            get { return typeof (T); }
        }
        public override void Update(T data)
        {
            if (IsTick || _last == null || _last.EndTime != data.EndTime)
            {
                OnDataConsolidated(data);
                _last = data;
            }
        }
        public override void Scan(DateTime currentLocalTime)
        {
        }
    }
}