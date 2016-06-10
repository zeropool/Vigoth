

using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages.Fxcm;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Logging;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Fxcm
{
    [TestFixture]
    public partial class FxcmBrokerageTests
    {
        [Test]
        public void GetsTickData()
        {
            var brokerage = (FxcmBrokerage)Brokerage;

            brokerage.Subscribe(null, new List<Symbol> {Symbols.USDJPY, Symbols.EURGBP});

            Thread.Sleep(5000);

            for (var i = 0; i < 10; i++)
            {
                foreach (var tick in brokerage.GetNextTicks())
                {
                    Log.Trace("{0}: {1} - {2} / {3}", tick.Time, tick.Symbol, ((Tick)tick).BidPrice, ((Tick)tick).AskPrice);
                }
            }
        }
    }
}
