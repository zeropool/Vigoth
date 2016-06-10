

using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash
    /// </summary>
    public class BasicTemplateFillForwardAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 01);  //Set Start Date
            SetEndDate(2013, 11, 30);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "ASUR", Resolution.Second);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public void OnData(TradeBars data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings("ASUR", 1);
                Debug("Purchased Stock");
            }
        }
    }
}