

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Engulfing candlestick pattern
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - first: black (white) real body
    /// - second: white(black) real body that engulfs the prior real body
    /// The returned value is positive(+1) when bullish or negative(-1) when bearish;
    /// The user should consider that an engulfing must appear in a downtrend if bullish or in an uptrend if bearish,
    /// while this function does not consider it
    /// </remarks>
    public class Engulfing : CandlestickPattern
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Engulfing"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public Engulfing(string name) 
            : base(name, 3)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Engulfing"/> class.
        /// </summary>
        public Engulfing()
            : this("ENGULFING")
        {
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return Samples >= Period; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="window">The window of data held in this indicator</param>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<TradeBar> window, TradeBar input)
        {
            if (!IsReady)
            {
                return 0m;
            }

            decimal value;
            if (
                // white engulfs black
                (GetCandleColor(input) == CandleColor.White && GetCandleColor(window[1]) == CandleColor.Black &&
                  input.Close > window[1].Open && input.Open < window[1].Close
                )
                ||
                // black engulfs white
                (GetCandleColor(input) == CandleColor.Black && GetCandleColor(window[1]) == CandleColor.White &&
                  input.Open > window[1].Close && input.Close < window[1].Open
                )
              )
                value = (int)GetCandleColor(input);
            else
                value = 0;

            return value;
        }
    }
}
