

using System;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// An indicator that will always return the same value.
    /// </summary>
    /// <typeparam name="T">The type of input this indicator takes</typeparam>
    public sealed class ConstantIndicator<T> : IndicatorBase<T>
        where T : BaseData
    {
        private readonly decimal _value;

        /// <summary>
        /// Gets true since the ConstantIndicator is always ready to return the same value
        /// </summary>
        public override bool IsReady
        {
            get { return true; }
        }

        /// <summary>
        /// Creates a new ConstantIndicator that will always return the specified value
        /// </summary>
        /// <param name="name">The name of this indicator</param>
        /// <param name="value">The constant value to be returned</param>
        public ConstantIndicator(string name, decimal value)
            : base(name)
        {
            _value = value;

            // set this immediatelyso it always has the .Value property correctly set, the
            // time will be updated anytime this indicators Update method gets called.
            Current = new IndicatorDataPoint(DateTime.MinValue, value);
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(T input)
        {
            return _value;
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            // re-initialize the current value, constant should ALWAYS return this value
            Current = new IndicatorDataPoint(DateTime.MinValue, _value);
        }
    }
}