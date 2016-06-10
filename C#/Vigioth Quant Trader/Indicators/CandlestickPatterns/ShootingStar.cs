

using System;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Shooting Star candlestick pattern
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - small real body
    /// - long upper shadow
    /// - no, or very short, lower shadow
    /// - gap up from prior real body
    /// The meaning of "short", "very short" and "long" is specified with SetCandleSettings;
    /// The returned value is negative(-1): shooting star is always bearish;
    /// The user should consider that a shooting star must appear in an uptrend, while this function does not consider it
    /// </remarks>
    public class ShootingStar : CandlestickPattern
    {
        private readonly int _bodyShortAveragePeriod;
        private readonly int _shadowLongAveragePeriod;
        private readonly int _shadowVeryShortAveragePeriod;

        private decimal _bodyShortPeriodTotal;
        private decimal _shadowLongPeriodTotal;
        private decimal _shadowVeryShortPeriodTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShootingStar"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public ShootingStar(string name)
            : base(name, Math.Max(Math.Max(CandleSettings.Get(CandleSettingType.BodyShort).AveragePeriod, CandleSettings.Get(CandleSettingType.ShadowLong).AveragePeriod),
                  CandleSettings.Get(CandleSettingType.ShadowVeryShort).AveragePeriod) + 1 + 1)
        {
            _bodyShortAveragePeriod = CandleSettings.Get(CandleSettingType.BodyShort).AveragePeriod;
            _shadowLongAveragePeriod = CandleSettings.Get(CandleSettingType.ShadowLong).AveragePeriod;
            _shadowVeryShortAveragePeriod = CandleSettings.Get(CandleSettingType.ShadowVeryShort).AveragePeriod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShootingStar"/> class.
        /// </summary>
        public ShootingStar()
            : this("SHOOTINGSTAR")
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
                if (Samples >= Period - _bodyShortAveragePeriod)
                {
                    _bodyShortPeriodTotal += GetCandleRange(CandleSettingType.BodyShort, input);
                }

                if (Samples >= Period - _shadowLongAveragePeriod)
                {
                    _shadowLongPeriodTotal += GetCandleRange(CandleSettingType.ShadowLong, input);
                }

                if (Samples >= Period - _shadowVeryShortAveragePeriod)
                {
                    _shadowVeryShortPeriodTotal += GetCandleRange(CandleSettingType.ShadowVeryShort, input);
                }

                return 0m;
            }

            decimal value;
            if (
                // small rb
                GetRealBody(input) < GetCandleAverage(CandleSettingType.BodyShort, _bodyShortPeriodTotal, input) &&
                // long upper shadow
                GetUpperShadow(input) > GetCandleAverage(CandleSettingType.ShadowLong, _shadowLongPeriodTotal, input) &&
                // very short lower shadow
                GetLowerShadow(input) < GetCandleAverage(CandleSettingType.ShadowVeryShort, _shadowVeryShortPeriodTotal, input) &&
                // gap up
                GetRealBodyGapUp(input, window[1])
                )
                value = -1m;
            else
                value = 0m;

            // add the current range and subtract the first range: this is done after the pattern recognition 
            // when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)

            _bodyShortPeriodTotal += GetCandleRange(CandleSettingType.BodyShort, input) -
                                     GetCandleRange(CandleSettingType.BodyShort, window[_bodyShortAveragePeriod]);

            _shadowLongPeriodTotal += GetCandleRange(CandleSettingType.ShadowLong, input) -
                                      GetCandleRange(CandleSettingType.ShadowLong, window[_shadowLongAveragePeriod]);

            _shadowVeryShortPeriodTotal += GetCandleRange(CandleSettingType.ShadowVeryShort, input) -
                                           GetCandleRange(CandleSettingType.ShadowVeryShort, window[_shadowVeryShortAveragePeriod]);

            return value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _bodyShortPeriodTotal = 0;
            _shadowLongPeriodTotal = 0;
            _shadowVeryShortPeriodTotal = 0;
            base.Reset();
        }
    }
}
