

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Accumulation/Distribution (AD)
    /// The Accumulation/Distribution is calculated using the following formula:
    /// AD = AD + ((Close - Low) - (High - Close)) / (High - Low) * Volume
    /// </summary>
    public class AccumulationDistribution : TradeBarIndicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulationDistribution"/> class using the specified name.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        public AccumulationDistribution(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples > 0; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(TradeBar input)
        {
            var range = input.High - input.Low;
            return Current.Value + (range > 0 ? ((input.Close - input.Low) - (input.High - input.Close)) / range * input.Volume : 0m);
        }
    }
}
