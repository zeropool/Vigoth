

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Engine;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Tests.Engine.DataFeeds;

namespace VigiothCapital.QuantTrader.Tests.Engine
{
    [TestFixture, Category("TravisExclude")]
    public class DefaultBrokerageMessageHandlerTests
    {
        [Test]
        public void DoesNotSetAlgorithmRunTimeErrorOnDisconnectIfAllSecuritiesClosed()
        {
            var referenceTime = DateTime.UtcNow;
            var algorithm = new AlgorithmStub(equities: new List<string> { "SPY" });
            algorithm.SetDateTime(referenceTime);
            algorithm.Securities[Symbols.SPY].Exchange.SetMarketHours(Enumerable.Empty<MarketHoursSegment>(), referenceTime.ConvertFromUtc(TimeZones.NewYork).DayOfWeek);
            var job = new LiveNodePacket();
            var results = new TestResultHandler();//packet => Console.WriteLine(FieldsToString(packet)));
            var api = new Api.Api();
            var handler = new DefaultBrokerageMessageHandler(algorithm, job, results, api, TimeSpan.FromMinutes(15));

            Assert.IsNull(algorithm.RunTimeError);

            handler.Handle(BrokerageMessageEvent.Disconnected("Disconnection!"));

            Assert.IsNull(algorithm.RunTimeError);

            results.Exit();
        }

        [Test]
        public void DoesNotSetRunTimeErrorWhenReconnectMessageComesThrough()
        {
            var algorithm = new AlgorithmStub(equities: new List<string> { "SPY" });
            var referenceTime = DateTime.UtcNow;
            algorithm.SetDateTime(referenceTime);
            var localReferencTime = referenceTime.ConvertFromUtc(TimeZones.NewYork);
            var open = localReferencTime.AddSeconds(1).TimeOfDay;
            var closed = TimeSpan.FromDays(1);
            var marketHours = new MarketHoursSegment(MarketHoursState.Market, open, closed);
            algorithm.Securities[Symbols.SPY].Exchange.SetMarketHours(new [] {marketHours}, localReferencTime.DayOfWeek);
            var job = new LiveNodePacket();
            var results = new TestResultHandler();//packet => Console.WriteLine(FieldsToString(packet)));
            var api = new Api.Api();
            var handler = new DefaultBrokerageMessageHandler(algorithm, job, results, api, TimeSpan.FromMinutes(15), TimeSpan.FromSeconds(.25));

            Assert.IsNull(algorithm.RunTimeError);

            handler.Handle(BrokerageMessageEvent.Disconnected("Disconnection!"));

            Thread.Sleep(100);

            handler.Handle(BrokerageMessageEvent.Reconnected("Reconnected!"));

            Thread.Sleep(500);

            Assert.IsNull(algorithm.RunTimeError);

            results.Exit();
        }
    }
}
