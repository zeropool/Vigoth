

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// The TradeBarIndicator is an indicator that accepts TradeBar data as its input.
    /// 
    /// This type is more of a shim/typedef to reduce the need to refer to things as IndicatorBase&lt;TradeBar&gt;
    /// </summary>
    public abstract class TradeBarIndicator : IndicatorBase<TradeBar>
    {
        /// <summary>
        /// Creates a new TradeBarIndicator with the specified name
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        protected TradeBarIndicator(string name)
            : base(name)
        {
        }
    }
}