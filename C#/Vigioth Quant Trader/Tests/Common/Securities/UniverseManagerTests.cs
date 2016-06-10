

using System;
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Securities
{
    [TestFixture]
    public class UniverseManagerTests
    {
        [Test]
        public void NotifiesWhenSecurityAdded()
        {
            var manager = new UniverseManager();

            var universe = new FuncUniverse(CreateTradeBarConfig(), new UniverseSettings(Resolution.Minute, 2, true, false, TimeSpan.Zero), SecurityInitializer.Null,
                data => data.Select(x => x.Symbol)
                );

            manager.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems.OfType<object>().Single() != universe)
                {
                    Assert.Fail("Expected args.NewItems to have exactly one element equal to universe");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Add);
                    Assert.Pass();
                }
            };

            manager.Add(universe.Configuration.Symbol, universe);
        }

        [Test]
        public void NotifiesWhenSecurityAddedViaIndexer()
        {
            var manager = new UniverseManager();

            var universe = new FuncUniverse(CreateTradeBarConfig(), new UniverseSettings(Resolution.Minute, 2, true, false, TimeSpan.Zero), SecurityInitializer.Null,
                data => data.Select(x => x.Symbol)
                );

            manager.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems.OfType<object>().Single() != universe)
                {
                    Assert.Fail("Expected args.NewItems to have exactly one element equal to universe");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Add);
                    Assert.Pass();
                }
            };

            manager[universe.Configuration.Symbol] = universe;
        }

        [Test]
        public void NotifiesWhenSecurityRemoved()
        {
            var manager = new UniverseManager();

            var universe = new FuncUniverse(CreateTradeBarConfig(), new UniverseSettings(Resolution.Minute, 2, true, false, TimeSpan.Zero), SecurityInitializer.Null,
                data => data.Select(x => x.Symbol)
                );

            manager.Add(universe.Configuration.Symbol, universe);
            manager.CollectionChanged += (sender, args) =>
            {
                if (args.OldItems.OfType<object>().Single() != universe)
                {
                    Assert.Fail("Expected args.OldItems to have exactly one element equal to universe");
                }
                else
                {
                    Assert.IsTrue(args.Action == NotifyCollectionChangedAction.Remove);
                    Assert.Pass();
                }
            };

            manager.Remove(universe.Configuration.Symbol);
        }

        private SubscriptionDataConfig CreateTradeBarConfig()
        {
            return new SubscriptionDataConfig(typeof(TradeBar), Symbols.SPY, Resolution.Minute, TimeZones.NewYork, TimeZones.NewYork, false, false, true);
        }
    }
}
