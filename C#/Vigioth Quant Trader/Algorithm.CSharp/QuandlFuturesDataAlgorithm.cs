

using System;
using VigiothCapital.QuantTrader.Algorithm;
using VigiothCapital.QuantTrader.Data.Custom;

namespace VigiothCapital.QuantTrader
{
    /// <summary>
    /// VigiothCapital.QuantTrader University: Futures Example
    /// 
    /// VigiothCapital.QuantTrader allows importing generic data sources! This example demonstrates importing a futures
    /// data from the popular open data source Quandl.
    /// 
    /// VigiothCapital.QuantTrader has a special deal with Quandl giving you access to Stevens Continuous Futurs (SCF) for free.
    /// If you'd like to download SCF for local backtesting, you can download it through Quandl.com.
    /// </summary>
    public class QCUQuandlFutures : QCAlgorithm
    {
        string _crude = "SCF/CME_CL1_ON";

        /// <summary>
        /// Initialize the data and resolution you require for your strategy
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2000, 1, 1);
            SetEndDate(DateTime.Now.Date.AddDays(-1));
            SetCash(25000);
            AddData<QuandlFuture>(_crude, Resolution.Daily);
        }

        /// <summary>
        /// Data Event Handler: New data arrives here. "TradeBars" type is a dictionary of strings so you can access it by symbol.
        /// </summary>
        /// <param name="data">Data.</param>
        public void OnData(Quandl data)
        {
            if (!Portfolio.HoldStock)
            {
                SetHoldings(_crude, 1);
                Debug(Time.ToString("u") + " Purchased Crude Oil: " + _crude);
            }
        }
    }

    /// <summary>
    /// Custom quandl data type for setting customized value column name. Value column is used for the primary trading calculations and charting.
    /// </summary>
    public class QuandlFuture : Quandl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VigiothCapital.QuantTrader.QuandlFuture"/> class.
        /// </summary>
        public QuandlFuture()
            : base(valueColumnName: "Settle")
        {
        }
    }
}