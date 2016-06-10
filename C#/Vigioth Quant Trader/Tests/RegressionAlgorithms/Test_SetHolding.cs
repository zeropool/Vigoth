
using System;
using System.Collections;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Securities;

using System.Globalization;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader
{
    public class TestSetHoldingAlgorithm : QCAlgorithm
    {
        int step = 0;

        public override void Initialize()
        {
            SetStartDate(2013, 06, 01);
            SetEndDate(2014, 05, 30);
            SetCash(100000);
            AddSecurity(SecurityType.Equity, "MSFT", Resolution.Minute);
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Minute);
            AddSecurity(SecurityType.Equity, "IBM", Resolution.Minute);  
        }

        public void OnData(TradeBars data)
        {
            //First Order, Set 50% MSFT:
            if (!Portfolio.Invested)
            {
                SetHoldings("MSFT", 0.5); step++;
            }

            if (Time.Date == new DateTime(2013, 7, 1) && step == 1)
            {
                SetHoldings("MSFT", 1); step++;
            }

            if (Time.Date == new DateTime(2013, 8, 1) && step == 2)
            {
                SetHoldings("IBM", 1, true); step++;
            }

            if (Time.Date == new DateTime(2013, 9, 3) && step == 3)
            {
                SetHoldings("IBM", -0.5, true); step++;
            }

            if (Time.Date == new DateTime(2013, 10, 1) && step == 4)
            {
                SetHoldings("SPY", -0.5); step++;
            }

            if (Time.Date == new DateTime(2013, 11, 1) && step == 5)
            {
                SetHoldings("IBM", -0.5, true);  //Succeed.
                SetHoldings("SPY", -0.5); step++;
            }
        }
    }

}