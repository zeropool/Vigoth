

using System;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;

namespace VigiothCapital.QuantTrader.Messaging
{
    /// <summary>
    /// Provides a common transmit method for utilizing the QC streaming API
    /// </summary>
    public static class StreamingApi
    {
        /// <summary>
        /// Gets a flag indicating whether or not the streaming api is enabled
        /// </summary>
        public static readonly bool IsEnabled = Config.GetBool("send-via-api");

        /// <summary>
        /// Send a message to the VigiothCapital.QuantTrader Chart Streaming API.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="apiToken">API token for authentication</param>
        /// <param name="packet">Packet to transmit</param>
        public static void Transmit(int userId, string apiToken, Packet packet)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var tx = JsonConvert.SerializeObject(packet);
                    if (tx.Length > 10000)
                    {
                        Log.Trace("StreamingApi.Transmit(): Packet too long: " + packet.GetType());
                    }
                    if (userId == 0)
                    {
                        Log.Error("StreamingApi.Transmit(): UserId is not set. Check your config.json file 'job-user-id' property.");
                        return;
                    }
                    if (apiToken == "")
                    {
                        Log.Error("StreamingApi.Transmit(): API Access token not set. Check your config.json file 'api-access-token' property.");
                        return;
                    }

                    var response = client.UploadValues("http://streaming.quantconnect.com", new NameValueCollection
                    {
                        {"uid", userId.ToString()},
                        {"token", apiToken},
                        {"tx", tx}
                    });

                    //Deserialize the response from the streaming API and throw in error case.
                    var result = JsonConvert.DeserializeObject<Response>(System.Text.Encoding.UTF8.GetString(response));
                    if (result.Type == "error")
                    {
                        throw new Exception(result.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Log.Error(err, "PacketType: " + packet.Type);
            }
        }

        /// <summary>
        /// Response object from the Streaming API.
        /// </summary>
        private class Response
        {
            /// <summary>
            /// Type of response from the streaming api.
            /// </summary>
            /// <remarks>success or error</remarks>
            public string Type;

            /// <summary>
            /// Message description of the error or success state.
            /// </summary>
            public string Message;
        }
    }
}