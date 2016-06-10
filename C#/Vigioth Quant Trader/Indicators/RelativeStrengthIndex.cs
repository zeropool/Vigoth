
namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Represents the  Relative Strength Index (RSI) developed by K. Welles Wilder.
    /// You can optionally specified a different moving average type to be used in the computation
    /// </summary>
    public class RelativeStrengthIndex : Indicator
    {
        private IndicatorDataPoint previousInput;

        /// <summary>
        /// Gets the type of indicator used to compute AverageGain and AverageLoss
        /// </summary>
        public MovingAverageType MovingAverageType { get; private set; }

        /// <summary>
        /// Gets the EMA for the down days
        /// </summary>
        public IndicatorBase<IndicatorDataPoint> AverageLoss { get; private set; }

        /// <summary>
        /// Gets the indicator for average gain
        /// </summary>
        public IndicatorBase<IndicatorDataPoint> AverageGain { get; private set; }

        /// <summary>
        /// Initializes a new instance of the RelativeStrengthIndex class with the specified name and period
        /// </summary>
        /// <param name="period">The period used for up and down days</param>
        /// <param name="movingAverageType">The type of moving average to be used for computing the average gain/loss values</param>
        public RelativeStrengthIndex(int period, MovingAverageType movingAverageType = MovingAverageType.Wilders)
            : this("RSI" + period, period, movingAverageType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RelativeStrengthIndex class with the specified name and period
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The period used for up and down days</param>
        /// <param name="movingAverageType">The type of moving average to be used for computing the average gain/loss values</param>
        public RelativeStrengthIndex(string name, int period, MovingAverageType movingAverageType = MovingAverageType.Wilders)
            : base(name)
        {
            MovingAverageType = movingAverageType;
            AverageGain = movingAverageType.AsIndicator(name + "Up", period);
            AverageLoss = movingAverageType.AsIndicator(name + "Down", period);
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return AverageGain.IsReady && AverageLoss.IsReady; }
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IndicatorDataPoint input)
        {
            if (previousInput != null && input.Value >= previousInput.Value)
            {
                AverageGain.Update(input.Time, input.Value - previousInput.Value);
                AverageLoss.Update(input.Time, 0m);
            }
            else if (previousInput != null && input.Value < previousInput.Value)
            {
                AverageGain.Update(input.Time, 0m);
                AverageLoss.Update(input.Time, previousInput.Value - input.Value);
            }

            previousInput = input;
            if (AverageLoss == 0m)
            {
                // all up days is 100
                return 100m;
            }

            var rs = AverageGain / AverageLoss;
            return 100m - (100m / (1 + rs));
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            AverageGain.Reset();
            AverageLoss.Reset();
            base.Reset();
        }
    }
}