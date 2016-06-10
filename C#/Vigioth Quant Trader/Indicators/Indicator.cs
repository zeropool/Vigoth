

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Represents a type capable of ingesting a piece of data and producing a new piece of data.
    /// Indicators can be used to filter and transform data into a new, more informative form.
    /// </summary>
    public abstract class Indicator : IndicatorBase<IndicatorDataPoint>
    {
        /// <summary>
        /// Initializes a new instance of the Indicator class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        protected Indicator(string name) 
            : base(name)
        {
        }
    }
}