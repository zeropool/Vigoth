
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using VigiothCapital.QuantTrader.Securities;

using System.Globalization;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Algorithm;
using VigiothCapital.QuantTrader.Orders;

namespace VigiothCapital.QuantTrader
{

    public class TestCashStrategy : QCAlgorithm
    {
        public override void Initialize()
        {
            SetStartDate(2013, 1, 1);
            SetEndDate(2013, 12, 31);
            SetCash(100000);
            AddData<CashType>("CASH");
        }

        public void OnData(CashType data)
        {
            try
            {
                //TEST: FULL SWEEP TESTING:
                if (Time == new DateTime(2013, 1, 1))
                {
                    Order("CASH", 100); // +100 Holdings
                }
                else if (Time == new DateTime(2013, 2, 1))
                {
                    Order("CASH", -50); // +50 Holdings
                }
                else if (Time == new DateTime(2013, 3, 1))
                {
                    Order("CASH", -100); // -50 Holdings
                }
                else if (Time == new DateTime(2013, 4, 1))
                {
                    Order("CASH", -50); // -100 Holdings
                }
                else if (Time == new DateTime(2013, 5, 1))
                {
                    Order("CASH", 50); // -50 Holdings
                }
                else if (Time == new DateTime(2013, 6, 1))
                {
                    Order("CASH", 100);// +50 Holdings
                }
                else if (Time == new DateTime(2013, 7, 1))
                {
                    Order("CASH", 50); // +100 Holdings
                }
                else if (Time == new DateTime(2013, 8, 1))
                {
                    Order("CASH", -50); // +50 Holdings
                }
                else if (Time == new DateTime(2013, 9, 1))
                {
                    Order("CASH", -100); // -50 Holdings
                }
                else if (Time == new DateTime(2013, 10, 1))
                {
                    Order("CASH", -50); // -100 Holdings
                }
                else if (Time == new DateTime(2013, 11, 1))
                {
                    Order("CASH", +50); // -50 Holdings
                }
                else if (Time == new DateTime(2013, 12, 1))
                {
                    Order("CASH", +100); // +50 Holdings
                }
                else if (Time == new DateTime(2013, 12, 15))
                {
                    Order("CASH", -50); // +0 Holdings
                }
            }
            catch (Exception err)
            {
                Debug("Err: " + err.Message);
            }
        }

        // PLOT OUR CASH POSITION:
        public override void OnEndOfDay()
        {
            try
            {
                Plot("Cash", Portfolio.Cash);
                Plot("PortfolioValue", Portfolio.TotalPortfolioValue);
                Plot("HoldingValue", Portfolio["CASH"].HoldingsValue);
                Plot("HoldingQuantity", Portfolio["CASH"].Quantity);
            }
            catch (Exception err)
            {
                Debug("Err: " + err.Message);
            }
        }
    }


    public class CashType : BaseData
    {
        public CashType()
        {
            this.Symbol = "CASH";
        }

        public override string GetSource(SubscriptionDataConfig config, DateTime date, DataFeedEndpoint datafeed)
        {
            return "https://www.dropbox.com/s/oiliumoyqqj1ovl/2013-cash.csv?dl=1";
        }

        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, DataFeedEndpoint datafeed)
        {
            //New Bitcoin object
            CashType cash = new CashType();

            try
            {
                string[] data = line.Split(',');
                cash.Time = DateTime.ParseExact(data[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                cash.Value = Convert.ToDecimal(data[1], CultureInfo.InvariantCulture);
            }
            catch {  }

            return cash;
        }
    }

}