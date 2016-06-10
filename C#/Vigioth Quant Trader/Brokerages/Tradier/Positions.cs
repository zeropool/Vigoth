

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Brokerages.Tradier
{
    /// <summary>
    /// Empty class for deserializing positions held.
    /// </summary>
    public class TradierPositionsContainer
    {
        /// Positions Class
        [JsonProperty(PropertyName = "positions")]
        [JsonConverter(typeof(NullStringValueConverter<TradierPositions>))]
        public TradierPositions TradierPositions;

        /// Default Constructor:
        public TradierPositionsContainer()
        { }
    }

    /// <summary>
    /// Position array container.
    /// </summary>
    public class TradierPositions 
    { 
        /// Positions Class List
        [JsonProperty(PropertyName = "position")]
        [JsonConverter(typeof(SingleValueListConverter<TradierPosition>))]
        public List<TradierPosition> Positions;

        /// Default Constructor for JSON
        public TradierPositions()
        { }
    }


    /// <summary>
    /// Individual Tradier position model.
    /// </summary>
    public class TradierPosition
    { 
        /// Position Id
        [JsonProperty(PropertyName = "id")]
        public long Id;

        /// Postion Date Acquired,
        [JsonProperty(PropertyName = "date_acquired")]
        public DateTime DateAcquired;

        /// Position Quantity
        [JsonProperty(PropertyName = "quantity")]
        public long Quantity;

        /// Position Cost:
        [JsonProperty(PropertyName = "cost_basis")]
        public decimal CostBasis;

        ///Position Symbol
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol;
    }

}
