

using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages.InteractiveBrokers;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.InteractiveBrokers
{
    [TestFixture]
    [Ignore("These tests require the IBController and IB TraderWorkstation to be installed.")]
    public class InteractiveBrokersBrokerageDataQueueHandlerTest
    {
        [Test]
        public void GetsTickData()
        {
            InteractiveBrokersGatewayRunner.StartFromConfiguration();
            
            var ib = new InteractiveBrokersBrokerage(new OrderProvider(), new SecurityProvider());
            ib.Connect();

            ib.Subscribe(null, new List<Symbol> {Symbols.USDJPY, Symbols.EURGBP});
            
            Thread.Sleep(1000);

            for (int i = 0; i < 10; i++)
            {
                foreach (var tick in ib.GetNextTicks())
                {
                    Console.WriteLine("{0}: {1} - {2} @ {3}", tick.Time, tick.Symbol, tick.Price, ((Tick)tick).Quantity);
                }
            }

            InteractiveBrokersGatewayRunner.Stop();
        }
    }
}
