

using Newtonsoft.Json;

namespace VigiothCapital.QuantTrader.Brokerages.Tradier
{
    /// <summary>
    /// Wrapper container for fault:
    /// </summary>
    public class TradierFaultContainer
    {
        /// Inner Fault Object
        [JsonProperty(PropertyName = "fault")]
        public TradierFault Fault;

        /// Fault Container Constructor:
        public TradierFaultContainer()
        { }
    }

    /// <summary>
    /// Tradier fault object:
    /// {"fault":{"faultstring":"Access Token expired","detail":{"errorcode":"keymanagement.service.access_token_expired"}}}
    /// </summary>
    public class TradierFault
    {
        /// Description of fault
        [JsonProperty(PropertyName = "faultstring")]
        public string Description = "";

        /// Detail object for fault exception
        [JsonProperty(PropertyName = "detail")]
        public TradierFaultDetail Details = new TradierFaultDetail();

        /// Tradier Fault Constructor:
        public TradierFault()
        { }
    }

    /// <summary>
    /// Error code associated with this fault.
    /// </summary>
    public class TradierFaultDetail
    {
        /// Error code for fault
        [JsonProperty(PropertyName = "errorcode")]
        public string ErrorCode;

        /// Tradier Detail Fault Constructor
        public TradierFaultDetail()
        { }
    }
}
