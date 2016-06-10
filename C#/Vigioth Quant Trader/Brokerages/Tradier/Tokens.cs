

using System;
using Newtonsoft.Json;

namespace VigiothCapital.QuantTrader.Brokerages.Tradier
{
    /// <summary>
    /// Token response model from VigiothCapital.QuantTrader terminal
    /// </summary>
    public class TokenResponse
    {
        /// Access token for current requests:
        [JsonProperty(PropertyName = "sAccessToken")]
        public string AccessToken;

        /// Refersh token for next time
        [JsonProperty(PropertyName = "sRefreshToken")]
        public string RefreshToken;

        /// Seconds the tokens expires
        [JsonProperty(PropertyName = "iExpiresIn")]
        public int ExpiresIn;

        /// Scope of token access
        [JsonProperty(PropertyName = "sScope")]
        public string Scope;

        /// Time the token was issued:
        [JsonProperty(PropertyName = "dtIssuedAt")]
        public DateTime IssuedAt;

        /// Success flag:
        [JsonProperty(PropertyName = "success")]
        public bool Success;

        /// <summary>
        ///  Default constructor:
        /// </summary>
        public TokenResponse() 
        { }
    }

}
