

using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// This algorithm demonstrates using the history provider to retrieve data
    /// to warm up indicators before data is received
    /// </summary>
    public class WarmupHistoryAlgorithm : QCAlgorithm
    {
        private ExponentialMovingAverage fast, slow;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Forex, "EURUSD", Resolution.Second);

            fast = EMA("EURUSD", 60);
            slow = EMA("EURUSD", 3600);

            // 3601 because rolling window waits for one to fall off the back to be considered ready
            var history = History("EURUSD", 3601);
            foreach (var bar in history)
            {
                fast.Update(bar.EndTime, bar.Close);
                slow.Update(bar.EndTime, bar.Close);
            }

            Log(string.Format("FAST IS {0} READY. Samples: {1}", fast.IsReady ? "" : "NOT", fast.Samples));
            Log(string.Format("SLOW IS {0} READY. Samples: {1}", slow.IsReady ? "" : "NOT", slow.Samples));
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (fast > slow)
            {
                SetHoldings("EURUSD", 1);
            }
            else
            {
                SetHoldings("EURUSD", -1);
            }
        }
    }
}