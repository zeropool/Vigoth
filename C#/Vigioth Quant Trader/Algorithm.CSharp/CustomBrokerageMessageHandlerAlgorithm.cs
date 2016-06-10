

using System;
using VigiothCapital.QuantTrader.Algorithm;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Interfaces;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    
    public class CustomBrokerageErrorHandlerAlgorithm : QCAlgorithm
    {
        public override void Initialize()
        {
            SetStartDate(2013, 1, 1);
            SetEndDate(DateTime.Now.Date.AddDays(-1));
            SetCash(25000);
            AddSecurity(SecurityType.Equity, "SPY");

            //Set the brokerage message handler:
            SetBrokerageMessageHandler(new CustomBrokerageMessageHandler(this));
        }

        public void OnData(TradeBars data)
        {
            if (Portfolio.HoldStock) return;
            Order("SPY", 100);
            Debug("Purchased SPY on " + Time.ToShortDateString());
        }
    }

    /// <summary>
    /// Handle the error messages in a custom manner
    /// </summary>
    public class CustomBrokerageMessageHandler : IBrokerageMessageHandler
    {
        private readonly IAlgorithm _algo;
        public CustomBrokerageMessageHandler(IAlgorithm algo) { _algo = algo; }

        /// <summary>
        /// Process the brokerage message event. Trigger any actions in the algorithm or notifications system required.
        /// </summary>
        /// <param name="message">Message object</param>
        public void Handle(BrokerageMessageEvent message)
        {
            var toLog = _algo.Time.ToString("o") + " Event: " + message.Message;
            _algo.Debug(toLog);
            _algo.Log(toLog);
        }
    }
}