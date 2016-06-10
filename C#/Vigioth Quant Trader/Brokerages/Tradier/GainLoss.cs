

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Brokerages.Tradier
{
    /// <summary>
    /// Gain loss parent class for deserialization
    /// </summary>
    public class TradierGainLossContainer
    {
        /// Profit Loss
        [JsonProperty(PropertyName = "gainloss")]
        public TradierGainLossClosed GainLossClosed;

        /// Null Constructor
        public TradierGainLossContainer()
        { }
    }

    /// <summary>
    /// Gain loss class
    /// </summary>
    public class TradierGainLossClosed
    {
        /// Array of user account details:
        [JsonProperty(PropertyName = "closed_position")]
        [JsonConverter(typeof(SingleValueListConverter<TradierGainLoss>))]
        public List<TradierGainLoss> ClosedPositions = new List<TradierGainLoss>();
    }

    /// <summary>
    /// Account only settings for a tradier user:
    /// </summary>
    public class TradierGainLoss 
    {
        /// Date the position was closed.
        [JsonProperty(PropertyName = "close_date")]
        public DateTime CloseDate;

        /// Date the position was opened
        [JsonProperty(PropertyName = "open_date")]
        public DateTime OpenDate;

        /// Total cost of the order.
        [JsonProperty(PropertyName = "cost")]
        public decimal Cost;

        /// Gain or loss on the position.
        [JsonProperty(PropertyName = "gain_loss")]
        public decimal GainLoss;

        /// Percentage of gain or loss on the position.
        [JsonProperty(PropertyName = "gain_loss_percent")]
        public decimal GainLossPercentage;

        /// Total amount received for the order.
        [JsonProperty(PropertyName = "proceeds")]
        public decimal Proceeds;

        /// Number of shares/contracts
        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity;

        /// Symbol
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol;

        /// Number of shares/contracts
        [JsonProperty(PropertyName = "term")]
        public decimal Term;

        /// <summary>
        /// Closed position trade summary
        /// </summary>
        public TradierGainLoss() 
        { }
    }

}
