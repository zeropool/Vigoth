

using System;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Algorithm.Examples
{
    /// <summary>
    /// Quick demo algorithm showing usage of the BrokerageModel property. The BrokerageModel helps to
    /// improve backtesting fidelity through simulation of a specific brokerage's rules around restrictions
    /// on submitting orders as well as fee structure.
    /// </summary>
    public class BrokerageModelAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Initialize the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must be initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash
            // Find more symbols here: http://quantconnect.com/data
            AddSecurity(SecurityType.Equity, "SPY", Resolution.Second);

            // there's two ways to set your brokerage model. The easiest would be to call
            // SetBrokerageModel( BrokerageName ); // BrokerageName is an enum
            //SetBrokerageModel(BrokerageName.TradierBrokerage);
            //SetBrokerageModel(BrokerageName.InteractiveBrokersBrokerage);
            //SetBrokerageModel(BrokerageName.Default);

            // the other way is to call SetBrokerageModel( IBrokerageModel ) with your
            // own custom model. I've defined a simple extension to the default brokerage
            // model to take into account a requirement to maintain 500 cash in the account
            // at all times

            SetBrokerageModel(new MinimumAccountBalanceBrokerageModel(this, 500.00m));
        }

        private decimal last = 1.0m;

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">TradeBars IDictionary object with your stock data</param>
        public void OnData(TradeBars data)
        {
            if (!Portfolio.Invested)
            {
                //fails first several times, we'll keep decrementing until it succeeds
                SetHoldings("SPY", last);
                if (Portfolio["SPY"].Quantity == 0)
                {
                    // each time we fail to purchase we'll decrease our set holdings percentage
                    Debug(Time + " - Failed to purchase stock"); 
                    last *= 0.95m;
                }
                else
                {
                    Debug(Time + " - Purchased Stock @ SetHoldings( " + last + " )");
                }
            }
        }

        /// <summary>
        /// Custom brokerage model that requires clients to maintain a minimum cash balance
        /// </summary>
        class MinimumAccountBalanceBrokerageModel : DefaultBrokerageModel
        {
            private readonly QCAlgorithm _algorithm;
            private readonly decimal _minimumAccountBalance;

            public MinimumAccountBalanceBrokerageModel(QCAlgorithm algorithm, decimal minimumAccountBalance)
            {
                _algorithm = algorithm;
                _minimumAccountBalance = minimumAccountBalance;
            }

            /// <summary>
            /// Prevent orders which would bring the account below a minimum cash balance
            /// </summary>
            public override bool CanSubmitOrder(Security security, Order order, out BrokerageMessageEvent message)
            {
                message = null;
                
                // we want to model brokerage requirement of _minimumAccountBalance cash value in account
                
                var orderCost = order.GetValue(security);
                var cash = _algorithm.Portfolio.Cash;
                var cashAfterOrder = cash - orderCost;
                if (cashAfterOrder < _minimumAccountBalance)
                {
                    // return a message describing why we're not allowing this order
                    message = new BrokerageMessageEvent(BrokerageMessageType.Warning, "InsufficientRemainingCapital", 
                        string.Format("Account must maintain a minimum of ${0} USD at all times. Order ID: {1}", _minimumAccountBalance, order.Id)
                        );
                    return false;
                }
                return true;
            }
        }
    }
}