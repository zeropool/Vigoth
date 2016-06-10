
namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the n-period percentage rate of change in a value using the following:
    /// 100 * (value_0 - value_n) / value_n
    /// 
    /// This indicator yields the same results of RateOfChangePercent
    /// </summary>
    public class MomentumPercent : RateOfChangePercent
    {
        /// <summary>
        /// Creates a new MomentumPercent indicator with the specified period
        /// </summary>
        /// <param name="period">The period over which to perform to computation</param>
        public MomentumPercent(int period)
            : this("MOMP" + period, period)
        {
        }

        /// <summary>
        /// Creates a new MomentumPercent indicator with the specified period
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period over which to perform to computation</param>
        public MomentumPercent(string name, int period)
            : base(name, period)
        {
        }
    }
}