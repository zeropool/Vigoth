
using System;
using MathNet.Numerics.Statistics;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Indicators;
namespace VigiothCapital.QuantTrader.Securities
{
    /// <summary>
    /// Provides an implementation of <see cref="IVolatilityModel"/> that computes the
    /// relative standard deviation as the volatility of the security
    /// </summary>
    public class RelativeStandardDeviationVolatilityModel : IVolatilityModel
    {
        private bool _needsUpdate;
        private decimal _volatility;
        private DateTime _lastUpdate;
        private readonly TimeSpan _periodSpan;
        private readonly object _sync = new object();
        private readonly RollingWindow<double> _window;
        /// <summary>
        /// Gets the volatility of the security as a percentage
        /// </summary>
        public decimal Volatility
        {
            get
            {
                lock (_sync)
                {
                    if (_window.Count < 2)
                    {
                        return 0m;
                    }
                    if (_needsUpdate)
                    {
                        _needsUpdate = false;
                        var mean = Math.Abs(_window.Mean().SafeDecimalCast());
                        if (mean != 0m)
                        {
                            // volatility here is supposed to be a percentage
                            var std = _window.StandardDeviation().SafeDecimalCast();
                            _volatility = std/mean;
                        }
                    }
                }
                return _volatility;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RelativeStandardDeviationVolatilityModel"/> class
        /// </summary>
        /// <param name="periodSpan">The time span representing one 'period' length</param>
        /// <param name="periods">The nuber of 'period' lengths to wait until updating the value</param>
        public RelativeStandardDeviationVolatilityModel(TimeSpan periodSpan, int periods)
        {
            if (periods < 2) throw new ArgumentOutOfRangeException("periods", "'periods' must be greater than or equal to 2.");
            _periodSpan = periodSpan;
            _window = new RollingWindow<double>(periods);
            _lastUpdate = DateTime.MinValue + TimeSpan.FromMilliseconds(periodSpan.TotalMilliseconds*periods);
        }
        /// <summary>
        /// Updates this model using the new price information in
        /// the specified security instance
        /// </summary>
        /// <param name="security">The security to calculate volatility for</param>
        /// <param name="data"></param>
        public void Update(Security security, BaseData data)
        {
            var timeSinceLastUpdate = data.EndTime - _lastUpdate;
            if (timeSinceLastUpdate >= _periodSpan)
            {
                lock (_sync)
                {
                    _needsUpdate = true;
                    // we purposefully use security.Price for consistency in our reporting
                    // some streams of data will have trade/quote data, so if we just use
                    // data.Value we could be mixing and matching data streams
                    _window.Add((double) security.Price);
                }
                _lastUpdate = data.EndTime;
            }
        }
    }
}