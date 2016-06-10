

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the MidPrice (MIDPRICE).
    /// The MidPrice is calculated using the following formula:
    /// MIDPRICE = (Highest High + Lowest Low) / 2
    /// </summary>
    public class MidPrice : TradeBarIndicator
    {
        private readonly decimal _period;
        private readonly Maximum _maximum;
        private readonly Minimum _minimum;

        /// <summary>
        /// Initializes a new instance of the <see cref="MidPrice"/> class using the specified name and period.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period of the MIDPRICE</param>
        public MidPrice(string name, int period) 
            : base(name)
        {
            _period = period;
            _maximum = new Maximum(period);
            _minimum = new Minimum(period);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MidPrice"/> class using the specified period.
        /// </summary> 
        /// <param name="period">The period of the MIDPRICE</param>
        public MidPrice(int period)
            : this("MIDPRICE" + period, period)
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
            _maximum.Update(new IndicatorDataPoint { Value = input.High });
            _minimum.Update(new IndicatorDataPoint { Value = input.Low });

            return (_maximum + _minimum) / 2;
        }
    }
}
