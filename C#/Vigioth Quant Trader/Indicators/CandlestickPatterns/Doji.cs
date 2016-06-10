

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Indicators.CandlestickPatterns
{
    /// <summary>
    /// Doji candlestick pattern indicator
    /// </summary>
    /// <remarks>
    /// Must have:
    /// - open quite equal to close
    /// How much can be the maximum distance between open and close is specified with SetCandleSettings
    /// The returned value is always positive(+1) but this does not mean it is bullish: doji shows uncertainty and it is
    /// neither bullish nor bearish when considered alone
    /// </remarks>
    public class Doji : CandlestickPattern
    {
        private readonly int _bodyDojiAveragePeriod;

        private decimal _bodyDojiPeriodTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Doji"/> class using the specified name.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        public Doji(string name) 
            : base(name, CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod + 1)
        {
            _bodyDojiAveragePeriod = CandleSettings.Get(CandleSettingType.BodyDoji).AveragePeriod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Doji"/> class.
        /// </summary>
        public Doji()
            : this("DOJI")
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

                return 0m;
            }

            var value = GetRealBody(input) <= GetCandleAverage(CandleSettingType.BodyDoji, _bodyDojiPeriodTotal, input) ? 1m : 0m;

            // add the current range and subtract the first range: this is done after the pattern recognition 
            // when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)

            _bodyDojiPeriodTotal += GetCandleRange(CandleSettingType.BodyDoji, input) -
                                    GetCandleRange(CandleSettingType.BodyDoji, window[_bodyDojiAveragePeriod]);

            return value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _bodyDojiPeriodTotal = 0m;
            base.Reset();
        }
    }
}
