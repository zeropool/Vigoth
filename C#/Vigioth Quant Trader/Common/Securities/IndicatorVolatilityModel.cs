using System;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Indicators;
namespace VigiothCapital.QuantTrader.Securities
{
    public class IndicatorVolatilityModel<T> : IVolatilityModel
        where T : BaseData
    {
        private readonly IIndicator<T> _indicator;
        private readonly Action<Security, BaseData, IIndicator<T>> _indicatorUpdate;
        public decimal Volatility
        {
            get { return _indicator.Current; }
        }
        public IndicatorVolatilityModel(IIndicator<T> indicator)
        {
            _indicator = indicator;
        }
        public IndicatorVolatilityModel(IIndicator<T> indicator, Action<Security, BaseData, IIndicator<T>> indicatorUpdate)
        {
            _indicator = indicator;
            _indicatorUpdate = indicatorUpdate;
        }
        public void Update(Security security, BaseData data)
        {
            if (_indicatorUpdate != null)
            {
                _indicatorUpdate(security, data, _indicator);
            }
        }
    }
}