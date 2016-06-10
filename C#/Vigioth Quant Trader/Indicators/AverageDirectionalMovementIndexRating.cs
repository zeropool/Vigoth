

using System;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Average Directional Movement Index Rating (ADXR). 
    /// The Average Directional Movement Index Rating is calculated with the following formula:
    /// ADXR[i] = (ADX[i] + ADX[i - period + 1]) / 2
    /// </summary>
    public class AverageDirectionalMovementIndexRating : TradeBarIndicator
    {
        private readonly int _period;
        private readonly AverageDirectionalIndex _adx;
        private readonly RollingWindow<decimal> _adxHistory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AverageDirectionalMovementIndexRating"/> class using the specified name and period.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period of the ADXR</param>
        public AverageDirectionalMovementIndexRating(string name, int period) 
            : base(name)
        {
            _period = period;
            _adx = new AverageDirectionalIndex(name + "_ADX", period);
            _adxHistory = new RollingWindow<decimal>(period);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AverageDirectionalMovementIndexRating"/> class using the specified period.
        /// </summary> 
        /// <param name="period">The period of the ADXR</param>
        public AverageDirectionalMovementIndexRating(int period)
            : this("ADXR" + period, period)
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples >= _period; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(TradeBar input)
        {
            _adx.Update(input);
            _adxHistory.Add(_adx);

            return (_adx + _adxHistory[Math.Min(_adxHistory.Count - 1, _period - 1)]) / 2;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _adx.Reset();
            _adxHistory.Reset();
            base.Reset();
        }
    }
}
