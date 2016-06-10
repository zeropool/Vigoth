

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Chande Momentum Oscillator (CMO). 
    /// CMO calculation is mostly identical to RSI.
    /// The only difference is in the last step of calculation:
    /// RSI = gain / (gain+loss)
    /// CMO = (gain-loss) / (gain+loss)
    /// </summary>
    public class ChandeMomentumOscillator : WindowIndicator<IndicatorDataPoint>
    {
        private decimal _prevValue;
        private decimal _prevGain;
        private decimal _prevLoss;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChandeMomentumOscillator"/> class using the specified period.
        /// </summary> 
        /// <param name="period">The period of the indicator</param>
        public ChandeMomentumOscillator(int period)
            : this("CMO" + period, period)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChandeMomentumOscillator"/> class using the specified name and period.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period of the indicator</param>
        public ChandeMomentumOscillator(string name, int period)
            : base(name, period)
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples > Period; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <param name="window">The window for the input history</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<IndicatorDataPoint> window, IndicatorDataPoint input)
        {
            if (Samples == 1)
            {
                _prevValue = input;
                return 0m;
            }

            var difference = input.Value - _prevValue;

            _prevValue = input.Value;

            if (Samples > Period + 1)
            {
                _prevLoss *= (Period - 1);
                _prevGain *= (Period - 1);
            }

            if (difference < 0)
                _prevLoss -= difference;
            else
                _prevGain += difference;

            if (!IsReady)
                return 0m;

            _prevLoss /= Period;
            _prevGain /= Period;

            var sum = _prevGain + _prevLoss;
            return sum != 0 ? 100m * ((_prevGain - _prevLoss) / sum) : 0m;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _prevValue = 0;
            _prevGain = 0;
            _prevLoss = 0;
            base.Reset();
        }
    }
}
