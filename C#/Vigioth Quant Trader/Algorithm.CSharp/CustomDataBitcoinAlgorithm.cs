

using System;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// 3.0 CUSTOM DATA SOURCE: USE YOUR OWN MARKET DATA (OPTIONS, FOREX, FUTURES, DERIVATIVES etc).
    /// 
    /// The new VigiothCapital.QuantTrader.Backtesting Engine is incredibly flexible and allows you to define your own data source. 
    /// 
    /// This includes any data source which has a TIME and VALUE. These are the *only* requirements. To demonstrate this we're loading
    /// in "Bitcoin" data.
    /// 
    /// </summary>
    public class CustomDataBitcoinAlgorithm : QCAlgorithm
    {


        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            //Weather data we have is within these days:
            SetStartDate(2011, 9, 13);
            SetEndDate(DateTime.Now.Date.AddDays(-1));

            //Set the cash for the strategy:
            SetCash(100000);

            //Define the symbol and "type" of our generic data:
            AddData<Bitcoin>("BTC");
        }

        /// <summary>
        /// Event Handler for Bitcoin Data Events: These weather objects are created from our 
        /// "Weather" type below and fired into this event handler.
        /// </summary>
        /// <param name="data">One(1) Weather Object, streamed into our algorithm synchronised in time with our other data streams</param>
        public void OnData(Bitcoin data)
        {
            //If we don't have any weather "SHARES" -- invest"
            if (!Portfolio.Invested)
            {
                //Weather used as a tradable asset, like stocks, futures etc. 
                if (data.Close != 0)
                {
                    Order("BTC", (Portfolio.Cash / Math.Abs(data.Close + 1)));
                }
                Console.WriteLine("Buying BTC 'Shares': BTC: " + data.Close);
            }
            Console.WriteLine("Time: " + Time.ToLongDateString() + " " + Time.ToLongTimeString() + data.Close.ToString());
        }
    }
}