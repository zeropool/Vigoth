using System;
using VigiothCapital.QuantTrader.Data.Market;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public abstract class PeriodCountConsolidatorBase<T, TConsolidated> : DataConsolidator<T>
        where T : class, IBaseData
        where TConsolidated : BaseData
    {
        private readonly TimeSpan? _period;
        private readonly int? _maxCount;
        private int _currentCount;
        private TConsolidated _workingBar;
        private DateTime? _lastEmit;
        protected PeriodCountConsolidatorBase(TimeSpan period)
        {
            _period = period;
        }
        protected PeriodCountConsolidatorBase(int maxCount)
        {
            _maxCount = maxCount;
        }
        protected PeriodCountConsolidatorBase(int maxCount, TimeSpan period)
        {
            _maxCount = maxCount;
            _period = period;
        }
        public override Type OutputType
        {
            get { return typeof(TConsolidated); }
        }
        public override BaseData WorkingData
        {
            get { return _workingBar != null ? _workingBar.Clone() : null; }
        }
        public new event EventHandler<TConsolidated> DataConsolidated;
        public override void Update(T data)
        {
            if (!ShouldProcess(data))
            {
                return;
            }
            var fireDataConsolidated = false;
            bool aggregateBeforeFire = _maxCount.HasValue;
            if (_maxCount.HasValue)
            {
                _currentCount++;
                if (_currentCount >= _maxCount.Value)
                {
                    _currentCount = 0;
                    fireDataConsolidated = true;
                }
            }
            if (!_lastEmit.HasValue)
            {
                _lastEmit = data.Time;
            }
            if (_period.HasValue)
            {
                if (_workingBar != null && data.Time - _workingBar.Time >= _period.Value)
                {
                    fireDataConsolidated = true;
                }
                if (_period.Value == TimeSpan.Zero)
                {
                    fireDataConsolidated = true;
                    aggregateBeforeFire = true;
                }
            }
            if (aggregateBeforeFire)
            {
                AggregateBar(ref _workingBar, data);
            }
            if (fireDataConsolidated)
            {
                var workingTradeBar = _workingBar as TradeBar;
                if (workingTradeBar != null)
                {
                    if (_period.HasValue)
                    {
                        workingTradeBar.Period = _period.Value;
                    }
                    else if (!(data is TradeBar))
                    {
                        workingTradeBar.Period = data.Time - _lastEmit.Value;
                    }
                }
                OnDataConsolidated(_workingBar);
                _lastEmit = data.Time;
                _workingBar = null;
            }
            if (!aggregateBeforeFire)
            {
                AggregateBar(ref _workingBar, data);
            }
        }
        public override void Scan(DateTime currentLocalTime)
        {
            if (_period.HasValue)
            {
                if (_workingBar != null)
                {
                    var fireDataConsolidated = _period.Value == TimeSpan.Zero;
                    if (!fireDataConsolidated && currentLocalTime - _workingBar.Time >= _period.Value)
                    {
                        fireDataConsolidated = true;
                    }
                    if (fireDataConsolidated)
                    {
                        OnDataConsolidated(_workingBar);
                        _lastEmit = currentLocalTime;
                        _workingBar = null;
                    }
                }
            }
        }
        protected virtual bool ShouldProcess(T data)
        {
            return true;
        }
        protected abstract void AggregateBar(ref TConsolidated workingBar, T data);
        protected DateTime GetRoundedBarTime(DateTime time)
        {
            return _period.HasValue && !_maxCount.HasValue ? time.RoundDown((TimeSpan)_period) : time;
        }
        protected virtual void OnDataConsolidated(TConsolidated e)
        {
            var handler = DataConsolidated;
            if (handler != null) handler(this, e);
            base.OnDataConsolidated(e);
        }
    }
}