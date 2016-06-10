
using System;
using System.Collections;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Securities;

using System.Globalization;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader
{
    // Name your algorithm class anything, as long as it inherits QCAlgorithm
    public class TestMixedAssets : QCAlgorithm
    {
        private decimal _vix = 0;
        private decimal _deployedCapital = 1;
        private decimal _safeCapital = 0;
        private DateTime _lastRebalance = new DateTime();

        //Initialize the data and resolution you require for your strategy:
        public override void Initialize()
        {
            SetStartDate(2013, 7, 1);
            SetEndDate(2014, 10, 31);
            SetCash(250000);
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Minute, fillDataForward: false, leverage: 1, extendedMarketHours: false);
            AddSecurity(SecurityType.Equity, "IBM", Resolution.Minute, fillDataForward: false, leverage: 1, extendedMarketHours: false);
            AddData<VIX>("VIX", Resolution.Minute);
        }

        // Data Event Handler: New data arrives here. "TradeBars" type is a dictionary of strings so you can access it by symbol.
        public void OnData(TradeBars data)
        {
            if (_vix == 0) return;

            if (Time.Date > _lastRebalance.Date.AddDays(5))
            {
                //Rebalance every 5 days:
                _lastRebalance = Time;

                //Scale VIX fractionally 0-1 for 8-30.
                _deployedCapital = 1 - ((_vix - 8m) / 22m);

                //Don't allow negative scaling:
                if (_deployedCapital < -0.20m) _deployedCapital = -0.20m;

                //Fraction of capital preserved for bonds:
                _safeCapital = 1 - _deployedCapital;

                var tag = "Deployed: " + _deployedCapital.ToString("0.00") + " Safe: " + _safeCapital.ToString("0.00");

                SetHoldings("SPY", _deployedCapital, true, tag);
                SetHoldings("IBM", _safeCapital - 0.01m, false, tag);
            }
        }

        // 
        public void OnData(VIX vix)
        {
            _vix = vix.Close;
        }
    }


    /// <summary>
    /// Custom imported data -- VIX indicator:
    /// </summary>
    public class VIX : BaseData
    {
        public decimal Open = 0;
        public decimal High = 0;
        public decimal Low = 0;
        public decimal Close = 0;

        public VIX()
        { this.Symbol = "VIX"; }

        public override string GetSource(SubscriptionDataConfig config, DateTime date, DataFeedEndpoint datafeed)
        {
            return "https://www.quandl.com/api/v1/datasets/YAHOO/INDEX_VIX.csv?trim_start=2000-01-01&trim_end=2014-10-31&sort_order=asc&exclude_headers=true";
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, DataFeedEndpoint datafeed)
        {
            VIX fear = new VIX();
            //try
            //{
            //Date          Open     High     Low   Close    Volume    Adjusted Close
            //10/27/2014    17.24    17.87    16    16.04    0         16.04
            string[] data = line.Split(',');
            fear.Time = DateTime.ParseExact(data[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            fear.Open = Convert.ToDecimal(data[1], CultureInfo.InvariantCulture); 
            fear.High = Convert.ToDecimal(data[2], CultureInfo.InvariantCulture);
            fear.Low = Convert.ToDecimal(data[3], CultureInfo.InvariantCulture); 
            fear.Close = Convert.ToDecimal(data[4], CultureInfo.InvariantCulture);
            fear.Symbol = "VIX"; fear.Value = fear.Close;
            //}
            //catch 
            //{ }
            return fear;
        }
        public override BaseData Clone()
        {
            VIX fear = new VIX();
            fear.Open = Open; fear.High = High; fear.Low = Low; fear.Close = Close;
            return fear;
        }
    }
}