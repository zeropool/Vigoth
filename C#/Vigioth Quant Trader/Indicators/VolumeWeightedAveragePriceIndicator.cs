
using VigiothCapital.QuantTrader.Data.Market;
using System;

namespace VigiothCapital.QuantTrader.Indicators
{
    /// <summary>
    /// Volume Weighted Average Price (VWAP) Indicator:
    /// It is calculated by adding up the dollars traded for every transaction (price multiplied
    /// by number of shares traded) and then dividing by the total shares traded for the day.
    /// </summary>
    public class VolumeWeightedAveragePriceIndicator : TradeBarIndicator
    {
        /// <summary>
        /// In this VWAP calculation, typical price is defined by (O + H + L + C) / 4
        /// </summary>
        private Identity _price;
        private Identity _volume;
        private CompositeIndicator<IndicatorDataPoint> _vwap;

        /// <summary>
        /// Initializes a new instance of the VWAP class with the default name and period
        /// </summary>
        /// <param name="period">The period of the VWAP</param>
        public VolumeWeightedAveragePriceIndicator(int period)
            : this("VWAP_" + period, period)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VWAP class with a given name and period
        /// </summary>
        /// <param name="name">string - the name of the indicator</param>
        /// <param name="period">The period of the VWAP</param>
        public VolumeWeightedAveragePriceIndicator(string name, int period)
            : base(name)
        {
            _price = new Identity("Price");
            _volume = new Identity("Volume");
            
            // This class will be using WeightedBy indicator extension 
            _vwap = _price.WeightedBy(_volume, period);
        }

        /// <summary>
        /// Gets a flag indicating when this indicator is ready and fully initialized
        /// </summary>
        public override bool IsReady
        {
            get { return _vwap.IsReady; }
        }

        /// <summary>
        /// Resets this indicator to its initial state
        /// </summary>
        public override void Reset()
        {
            _price.Reset();
            _volume.Reset();
            _vwap.Reset();
            base.Reset();
        }

        /// <summary>
        /// Computes the next value of this indicator from the given state
        /// </summary>
        /// <param name="input">The input given to the indicator</param>
        /// <returns>A new value for this indicator</returns>
        protected override decimal ComputeNextValue(TradeBar input)
        {
            _price.Update(input.EndTime, (input.Open + input.High + input.Low + input.Value) / 4);
            _volume.Update(input.EndTime, input.Volume);
            return _vwap.Current.Value;
        }
    }
}