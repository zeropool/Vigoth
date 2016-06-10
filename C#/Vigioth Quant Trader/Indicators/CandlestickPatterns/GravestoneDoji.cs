

using System;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Gravestone Doji candlestick pattern indicator
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - doji body
    /// - open and close at the low of the day = no or very short lower shadow
    /// - upper shadow(to distinguish from other dojis, here upper shadow should not be very short)
    /// The meaning of "doji" and "very short" is specified with SetCandleSettings
    /// The returned value is always positive(+1) but this does not mean it is bullish: gravestone doji must be considered
    /// relatively to the trend
    /// </remarks>
    public class GravestoneDoji : CandlestickPattern
    {
        private readonly int _bodyDojiAveragePeriod;
        private readonly int _shadowVeryShortAveragePeriod;

        private decimal _bodyDojiPeriodTotal;
        private decimal _shadowVeryShortPeriodTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="GravestoneDoji"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public GravestoneDoji(string name) 
            : base(name, Math.Max(CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod, CandleSettings.Get(CandleSettingType.ShadowVeryShort).AveragePeriod) + 1)
        {
            _bodyDojiAveragePeriod = CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod;
            _shadowVeryShortAveragePeriod = CandleSettings.Get(CandleSettingType.ShadowVeryShort).AveragePeriod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GravestoneDoji"/> class.
        /// </summary>
        public GravestoneDoji()
            : this("GRAVESTONEDOJI")
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
                if (Samples >= Period - _bodyDojiAveragePeriod)
                {
                    _bodyDojiPeriodTotal += GetCandleRange(CandleSettingType.BodyDoji, input);
                }

                if (Samples >= Period - _shadowVeryShortAveragePeriod)
                {
                    _shadowVeryShortPeriodTotal += GetCandleRange(CandleSettingType.ShadowVeryShort, input);
                }

                return 0m;
            }

            decimal value;
            if (GetRealBody(input) <= GetCandleAverage(CandleSettingType.BodyDoji, _bodyDojiPeriodTotal, input) &&
                GetLowerShadow(input) < GetCandleAverage(CandleSettingType.ShadowVeryShort, _shadowVeryShortPeriodTotal, input) &&
                GetUpperShadow(input) > GetCandleAverage(CandleSettingType.ShadowVeryShort, _shadowVeryShortPeriodTotal, input)
              )
                value = 1m;
            else
                value = 0m;

            // add the current range and subtract the first range: this is done after the pattern recognition 
            // when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)

            _bodyDojiPeriodTotal += GetCandleRange(CandleSettingType.BodyDoji, input) -
                                    GetCandleRange(CandleSettingType.BodyDoji, window[_bodyDojiAveragePeriod]);

            _shadowVeryShortPeriodTotal += GetCandleRange(CandleSettingType.ShadowVeryShort, input) -
                                           GetCandleRange(CandleSettingType.ShadowVeryShort, window[_shadowVeryShortAveragePeriod]);

            return value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _bodyDojiPeriodTotal = 0m;
            _shadowVeryShortPeriodTotal = 0m;
            base.Reset();
        }
    }
}
