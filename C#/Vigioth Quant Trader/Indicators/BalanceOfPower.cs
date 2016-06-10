

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the Balance Of Power (BOP). 
    /// The Balance Of Power is calculated with the following formula:
    /// BOP = (Close - Open) / (High - Low)
    /// </summary>
    public class BalanceOfPower : TradeBarIndicator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceOfPower"/> class using the specified name.
        /// </summary> 
        /// <param name="name">The name of this indicator</param>
        public BalanceOfPower(string name)
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
            return range > 0 ? (input.Close - input.Open) / range : 0m;
        }

    }
}
