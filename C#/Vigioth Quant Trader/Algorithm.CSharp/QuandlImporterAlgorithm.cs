

using System;
using VigiothCapital.QuantTrader.Data.Custom;
using VigiothCapital.QuantTrader.Indicators;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// VigiothCapital.QuantTrader University: Generic Quandl Data Importer
    /// Using the underlying dynamic data class "Quandl" we take care of the data 
    /// importing and definition for you. Simply point VigiothCapital.QuantTrader to the Quandl Short Code.
    /// 
    /// The Quandl object has properties which match the spreadsheet headers.
    /// If you have multiple quandl streams look at data.Symbol to distinguish them.
    /// </summary>
    public class QuandlImporterAlgorithm : QCAlgorithm
    {
        private SimpleMovingAverage sma;
        string _quandlCode = "YAHOO/INDEX_SPY";

        /// Initialize the data and resolution you require for your strategy:
        public override void Initialize()
        {
            //Start and End Date range for the backtest:
            SetStartDate(2013, 1, 1);
            SetEndDate(DateTime.Now.Date.AddDays(-1));

            //Cash allocation
            SetCash(25000);

            //Add Generic Quandl Data:
            AddData<Quandl>(_quandlCode, Resolution.Daily);

            sma = SMA(_quandlCode, 14);
        }

        /// Data Event Handler: New data arrives here. "TradeBars" type is a dictionary of strings so you can access it by symbol
        public void OnData(Quandl data)
        {
            if (!Portfolio.HoldStock)
            {
                //Order function places trades: enter the string symbol and the quantity you want:
                SetHoldings(_quandlCode, 1);

                //Debug sends messages to the user console: "Time" is the algorithm time keeper object 
                Debug("Purchased " + _quandlCode + " >> " + Time.ToShortDateString());
            }

            Plot("SPY", sma);
        }
    }
}