

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Matching Low candlestick pattern indicator
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - first candle: black candle
    /// - second candle: black candle with the close equal to the previous close
    /// The meaning of "equal" is specified with SetCandleSettings
    /// The returned value is always positive(+1): matching low is always bullish;
    /// </remarks>
    public class MatchingLow : CandlestickPattern
    {
        private readonly int _equalAveragePeriod;

        private decimal _equalPeriodTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchingLow"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public MatchingLow(string name) 
            : base(name, CandleSettings.Get(CandleSettingType.Equal).AveragePeriod + 1 + 1)
        {
            _equalAveragePeriod = CandleSettings.Get(CandleSettingType.Equal).AveragePeriod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchingLow"/> class.
        /// </summary>
        public MatchingLow()
            : this("MATCHINGLOW")
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
                if (Samples >= Period - _equalAveragePeriod)
                {
                    _equalPeriodTotal += GetCandleRange(CandleSettingType.Equal, window[1]);
                }

                return 0m;
            }

            decimal value;
            if (
                // first black
                GetCandleColor(window[1]) == CandleColor.Black &&
                // second black
                GetCandleColor(input) == CandleColor.Black &&
                // 1st and 2nd same close
                input.Close <= window[1].Close + GetCandleAverage(CandleSettingType.Equal, _equalPeriodTotal, window[1]) &&
                input.Close >= window[1].Close - GetCandleAverage(CandleSettingType.Equal, _equalPeriodTotal, window[1])
              )
                value = 1m;
            else
                value = 0m;

            // add the current range and subtract the first range: this is done after the pattern recognition 
            // when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)

            _equalPeriodTotal += GetCandleRange(CandleSettingType.Equal, window[1]) -
                                 GetCandleRange(CandleSettingType.Equal, window[_equalAveragePeriod + 1]);

            return value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _equalPeriodTotal = 0m;
            base.Reset();
        }
    }
}
