

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the MidPoint (MIDPOINT)
    /// The MidPoint is calculated using the following formula:
    /// MIDPOINT = (Highest Value + Lowest Value) / 2
    /// </summary>
    public class MidPoint : IndicatorBase<IndicatorDataPoint>
    {
        private readonly int _period;
        private readonly Maximum _maximum;
        private readonly Minimum _minimum;

        /// <summary>
        /// Initializes a new instance of the <see cref="MidPoint"/> class using the specified name and period.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period of the MIDPOINT</param>
        public MidPoint(string name, int period) 
            : base(name)
        {
            _period = period;
            _maximum = new Maximum(period);
            _minimum = new Minimum(period);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MidPoint"/> class using the specified period.
        /// </summary> 
        /// <param name="period">The period of the MIDPOINT</param>
        public MidPoint(int period)
            : this("MIDPOINT" + period, period)
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
        protected override decimal ComputeNextValue(IndicatorDataPoint input)
        {
            _maximum.Update(input);
            _minimum.Update(input);

            return (_maximum + _minimum) / 2;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _maximum.Reset();
            _minimum.Reset();
            base.Reset();
        }
    }
}
