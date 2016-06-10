

using System;
using System.Linq;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// This indicator computes the n-period mean absolute deviation.
    /// </summary>
    public class MeanAbsoluteDeviation : WindowIndicator<IndicatorDataPoint>
    {
        /// <summary>
        /// Gets the mean used to compute the deviation
        /// </summary>
        public IndicatorBase<IndicatorDataPoint> Mean { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MeanAbsoluteDeviation class with the specified period.
        ///
        /// Evaluates the mean absolute deviation of samples in the lookback period.
        /// </summary>
        /// <param name="period">The sample size of the standard deviation</param>
        public MeanAbsoluteDeviation(int period)
            : this("MAD" + period, period)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MeanAbsoluteDeviation class with the specified period.
        ///
        /// Evaluates the mean absolute deviation of samples in the lookback period.
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="period">The sample size of the mean absoluate deviation</param>
        public MeanAbsoluteDeviation(string name, int period)
            : base(name, period)
        {
            Mean = MovingAverageType.Simple.AsIndicator(string.Format("{0}_{1}", name, "Mean"), period);
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
        /// <param name="input">The input given to the indicator</param>
        /// <param name="window">The window for the input history</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(IReadOnlyWindow<IndicatorDataPoint> window, IndicatorDataPoint input)
        {
            Mean.Update(input);
            if (Samples < 2)
            {
                return 0m;
            }
            return window.Average(v => Math.Abs(v - Mean.Current.Value));
        }

        /// <summary>
        /// Resets this indicator and its sub-indicator Mean to their initial state
        /// </summary>
        public override void Reset()
        {
            Mean.Reset();
            base.Reset();
        }
    }
}
