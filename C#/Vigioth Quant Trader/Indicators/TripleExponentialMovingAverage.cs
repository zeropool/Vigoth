

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Triple Exponential Moving Average (TEMA). 
    /// The Triple Exponential Moving Average is calculated with the following formula:
    /// EMA1 = EMA(t,period)
    /// EMA2 = EMA(EMA(t,period),period)
    /// EMA3 = EMA(EMA(EMA(t,period),period),period)
    /// TEMA = 3 * EMA1 - 3 * EMA2 + EMA3
    /// </summary>
    public class TripleExponentialMovingAverage : IndicatorBase<IndicatorDataPoint>
    {
        private readonly int _period;
        private readonly ExponentialMovingAverage _ema1;
        private readonly ExponentialMovingAverage _ema2;
        private readonly ExponentialMovingAverage _ema3;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleExponentialMovingAverage"/> class using the specified name and period.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period of the TEMA</param>
        public TripleExponentialMovingAverage(string name, int period)
            : base(name)
        {
            _period = period;
            _ema1 = new ExponentialMovingAverage(name + "_1", period);
            _ema2 = new ExponentialMovingAverage(name + "_2", period);
            _ema3 = new ExponentialMovingAverage(name + "_3", period);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleExponentialMovingAverage"/> class using the specified period.
        /// </summary> 
        /// <param name="period">The period of the TEMA</param>
        public TripleExponentialMovingAverage(int period)
            : this("TEMA" + period, period)
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples > 3 * (_period - 1); }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IndicatorDataPoint input)
        {
            _ema1.Update(input);

            if (Samples > _period - 1)
                _ema2.Update(_ema1.Current);

            if (Samples > 2 * (_period - 1))
                _ema3.Update(_ema2.Current);

            return IsReady ? 3m * _ema1 - 3m * _ema2 + _ema3 : 0m;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _ema1.Reset();
            _ema2.Reset();
            _ema3.Reset();
            base.Reset();
        }
    }
}
