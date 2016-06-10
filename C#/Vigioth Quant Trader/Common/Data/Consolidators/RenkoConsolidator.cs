using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class RenkoConsolidator : DataConsolidator<IBaseData>
    {
        public new EventHandler<RenkoBar> DataConsolidated; 
        private RenkoBar _currentBar;
        private readonly decimal _barSize;
        private readonly bool _evenBars;
        private readonly Func<IBaseData, decimal> _selector;
        private readonly Func<IBaseData, long> _volumeSelector;
        public RenkoConsolidator(decimal barSize, bool evenBars = true)
        {
            _barSize = barSize;
            _selector = x => x.Value;
            _volumeSelector = x => 0;
            _evenBars = evenBars;
        }
        public RenkoConsolidator(decimal barSize, Func<IBaseData, decimal> selector, Func<IBaseData, long> volumeSelector = null, bool evenBars = true)
        {
            if (barSize < Extensions.GetDecimalEpsilon())
            {
                throw new ArgumentOutOfRangeException("barSize", "RenkoConsolidator bar size must be positve and greater than 1e-28");
            }
            _barSize = barSize;
            _evenBars = evenBars;
            _selector = selector ?? (x => x.Value);
            _volumeSelector = volumeSelector ?? (x => 0);
        }
        public decimal BarSize
        {
            get { return _barSize; }
        }
        public override BaseData WorkingData
        {
            get { return _currentBar == null ? null : _currentBar.Clone(); }
        }
        public override Type OutputType
        {
            get { return typeof(RenkoBar); }
        }
        public override void Update(IBaseData data)
        {
            var currentValue = _selector(data);
            var volume = _volumeSelector(data);
            decimal? close = null;
            if (_currentBar != null)
            {
                _currentBar.Update(data.Time, currentValue, volume);
                if (_currentBar.IsClosed)
                {
                    close = _currentBar.Close;
                    OnDataConsolidated(_currentBar);
                    _currentBar = null;
                }
            }
            if (_currentBar == null)
            {
                var open = close ?? currentValue;
                if (_evenBars && !close.HasValue)
                {
                    open = Math.Ceiling(open/_barSize)*_barSize;
                }
                _currentBar = new RenkoBar(data.Symbol, data.Time, _barSize, open, volume);
            }
        }
        public override void Scan(DateTime currentLocalTime)
        {
        }
        protected virtual void OnDataConsolidated(RenkoBar consolidated)
        {
            var handler = DataConsolidated;
            if (handler != null) handler(this, consolidated);
            base.OnDataConsolidated(consolidated);
        }
    }
    public class RenkoConsolidator<TInput> : RenkoConsolidator
        where TInput : IBaseData
    {
        public RenkoConsolidator(decimal barSize, Func<TInput, decimal> selector, Func<TInput, long> volumeSelector = null, bool evenBars = true)
            : base(barSize, x => selector((TInput)x), volumeSelector == null ? (Func<IBaseData, long>) null : x => volumeSelector((TInput)x), evenBars)
        {
        }
        public RenkoConsolidator(decimal barSize, bool evenBars = true)
            : base(barSize, evenBars)
        {
        }
        public void Update(TInput data)
        {
            base.Update(data);
        }
    }
}
