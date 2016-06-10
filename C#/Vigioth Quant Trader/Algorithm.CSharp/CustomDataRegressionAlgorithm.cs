

using System;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// Regression algorithm for custom data
    /// </summary>
    public class CustomDataRegressionAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2011, 9, 13);
            SetEndDate(2015, 12, 01);

            //Set the cash for the strategy:
            SetCash(100000);

            //Define the symbol and "type" of our generic data:
            var resolution = LiveMode ? Resolution.Second : Resolution.Daily;
            AddData<Bitcoin>("BTC", resolution);
        }

        /// <summary>
        /// Event Handler for Bitcoin Data Events: These Bitcoin objects are created from our 
        /// "Bitcoin" type below and fired into this event handler.
        /// </summary>
        /// <param name="data">One(1) Bitcoin Object, streamed into our algorithm synchronised in time with our other data streams</param>
        public void OnData(Bitcoin data)
        {
            //If we don't have any bitcoin "SHARES" -- invest"
            if (!Portfolio.Invested)
            {
                //Bitcoin used as a tradable asset, like stocks, futures etc. 
                if (data.Close != 0)
                {
                    Order("BTC", (Portfolio.Cash / Math.Abs(data.Close + 1)));
                }
            }
        }
    }
}