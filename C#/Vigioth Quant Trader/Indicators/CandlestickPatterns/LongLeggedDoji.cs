

using System;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Long Legged Doji candlestick pattern indicator
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - doji body
    /// - one or two long shadows
    /// The meaning of "doji" is specified with SetCandleSettings
    /// The returned value is always positive(+1) but this does not mean it is bullish: long legged doji shows uncertainty
    /// </remarks>
    public class LongLeggedDoji : CandlestickPattern
    {
        private readonly int _bodyDojiAveragePeriod;
        private readonly int _shadowLongAveragePeriod;

        private decimal _bodyDojiPeriodTotal;
        private decimal _shadowLongPeriodTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongLeggedDoji"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public LongLeggedDoji(string name) 
            : base(name, Math.Max(CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod, CandleSettings.Get(CandleSettingType.ShadowLong).AveragePeriod) + 1)
        {
            _bodyDojiAveragePeriod = CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod;
            _shadowLongAveragePeriod = CandleSettings.Get(CandleSettingType.ShadowLong).AveragePeriod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongLeggedDoji"/> class.
        /// </summary>
        public LongLeggedDoji()
            : this("LONGLEGGEDDOJI")
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

                if (Samples >= Period - _shadowLongAveragePeriod)
                {
                    _shadowLongPeriodTotal += GetCandleRange(CandleSettingType.ShadowLong, input);
                }

                return 0m;
            }

            decimal value;
            if (GetRealBody(input) <= GetCandleAverage(CandleSettingType.BodyDoji, _bodyDojiPeriodTotal, input) &&
                (GetLowerShadow(input) > GetCandleAverage(CandleSettingType.ShadowLong, _shadowLongPeriodTotal, input)
                  ||
                  GetUpperShadow(input) > GetCandleAverage(CandleSettingType.ShadowLong, _shadowLongPeriodTotal, input)
                )
              )
                value = 1m;
            else
                value = 0m;

            // add the current range and subtract the first range: this is done after the pattern recognition 
            // when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)

            _bodyDojiPeriodTotal += GetCandleRange(CandleSettingType.BodyDoji, input) -
                                    GetCandleRange(CandleSettingType.BodyDoji, window[_bodyDojiAveragePeriod]);

            _shadowLongPeriodTotal += GetCandleRange(CandleSettingType.ShadowLong, input) -
                                      GetCandleRange(CandleSettingType.ShadowLong, window[_shadowLongAveragePeriod]);

            return value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _bodyDojiPeriodTotal = 0m;
            _shadowLongPeriodTotal = 0m;
            base.Reset();
        }
    }
}
