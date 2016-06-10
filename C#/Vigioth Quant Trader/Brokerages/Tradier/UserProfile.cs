

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Brokerages.Tradier
{
    /// <summary>
    /// Model for a TradierUser returned from the API.
    /// </summary>
    public class TradierUserContainer
    {
        /// User Profile Contents
        [JsonProperty(PropertyName = "profile")]
        public TradierUser Profile;

        /// Constructor: Create user from tradier data.
        public TradierUserContainer()
        { }
    }

    /// <summary>
    /// User profile array:
    /// </summary>
    public class TradierUser
    {
        /// Unique brokerage user id.
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// Name of user:
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// Array of user account details:
        [JsonProperty(PropertyName = "account")]
        [JsonConverter(typeof(SingleValueListConverter<TradierUserAccount>))]
        public List<TradierUserAccount> Accounts { get; set; }

        /// Empty Constructor
        public TradierUser() 
        {
            Id = "";
            Name = "";
            Accounts = new List<TradierUserAccount>();
        }
    }

    /// <summary>
    /// Account only settings for a tradier user:
    /// </summary>
    public class TradierUserAccount 
    {
        /// Users account number
        [JsonProperty(PropertyName = "account_number")]
        public long AccountNumber { get; set; }

        /// Pattern Trader:
        [JsonProperty(PropertyName = "day_trader")]
        public bool DayTrader { get; set; }

        /// Options level permissions on account.
        [JsonProperty(PropertyName = "option_level")]
        public int OptionLevel { get; set; }

        /// Cash or Margin Account:
        [JsonProperty(PropertyName = "type")]
        public TradierAccountType Type { get; set; }

        /// Date time of the last update:
        [JsonProperty(PropertyName = "last_update_date")]
        public DateTime LastUpdated { get; set; }

        /// Status of the users account:
        [JsonProperty(PropertyName = "status")]
        public TradierAccountStatus Status { get; set; }

        /// Type of user account
        [JsonProperty(PropertyName = "classification")]
        public TradierAccountClassification Classification { get; set; }

        /// <summary>
        /// Create a new account:
        /// </summary>
        public TradierUserAccount() 
        {
            AccountNumber = 0;
            DayTrader = false;
            OptionLevel = 1;
            Type = TradierAccountType.Cash;
            LastUpdated = new DateTime();
            Status = TradierAccountStatus.Closed;
            Classification = TradierAccountClassification.Individual;
        }
    }

}
