

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Tests.Common.Data
{
    [TestFixture]
    public class BaseDataConsolidatorTests
    {
        [Test]
        public void AggregatesNewTradeBarProperly()
        {
            TradeBar newTradeBar = null;
            var creator = new BaseDataConsolidator(4);
            creator.DataConsolidated += (sender, tradeBar) =>
            {
                newTradeBar = tradeBar;
            };
            var reference = DateTime.Today;
            var bar1 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference,
                Value = 5,
                Quantity = 10
            };
            creator.Update(bar1);
            Assert.IsNull(newTradeBar);

            var bar2 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(1),
                Value = 10,
                Quantity = 20
            };
            creator.Update(bar2);
            Assert.IsNull(newTradeBar);
            var bar3 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(2),
                Value = 1,
                Quantity = 10
            };
            creator.Update(bar3);
            Assert.IsNull(newTradeBar);

            var bar4 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(3),
                Value = 9,
                Quantity = 20
            };
            creator.Update(bar4);
            Assert.IsNotNull(newTradeBar);

            Assert.AreEqual(Symbols.SPY, newTradeBar.Symbol);
            Assert.AreEqual(bar1.Time, newTradeBar.Time);
            Assert.AreEqual(bar1.Value, newTradeBar.Open);
            Assert.AreEqual(bar2.Value, newTradeBar.High);
            Assert.AreEqual(bar3.Value, newTradeBar.Low);
            Assert.AreEqual(bar4.Value, newTradeBar.Close);

            // base data can't aggregate volume
            Assert.AreEqual(0, newTradeBar.Volume);
        }


        [Test]
        public void AggregatesPeriodInCountModeWithHourlyData()
        {
            TradeBar consolidated = null;
            var consolidator = new BaseDataConsolidator(2);
            consolidator.DataConsolidated += (sender, bar) =>
            {
                consolidated = bar;
            };

            var reference = new DateTime(2015, 04, 13);
            consolidator.Update(new Tick { Time = reference });
            Assert.IsNull(consolidated);

            consolidator.Update(new Tick { Time = reference.AddHours(1) });
            Assert.IsNotNull(consolidated);

            // sadly the first emit will be off by the data resolution since we 'swallow' a point, so to speak.
            Assert.AreEqual(TimeSpan.FromHours(1), consolidated.Period);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddHours(2) });
            Assert.IsNull(consolidated);

            consolidator.Update(new Tick { Time = reference.AddHours(3) });
            Assert.IsNotNull(consolidated);

            Assert.AreEqual(TimeSpan.FromHours(2), consolidated.Period);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddHours(4) });
            Assert.IsNull(consolidated);

            consolidator.Update(new Tick { Time = reference.AddHours(5) });
            Assert.IsNotNull(consolidated);

            Assert.AreEqual(TimeSpan.FromHours(2), consolidated.Period);
        }

        [Test]
        public void AggregatesPeriodInPeriodModeWithDailyData()
        {
            TradeBar consolidated = null;
            var consolidator = new BaseDataConsolidator(TimeSpan.FromDays(1));
            consolidator.DataConsolidated += (sender, bar) =>
            {
                consolidated = bar;
            };

            var reference = new DateTime(2015, 04, 13);
            consolidator.Update(new Tick { Time = reference });
            Assert.IsNull(consolidated);

            consolidator.Update(new Tick { Time = reference.AddDays(1) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddDays(2) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddDays(3) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
        }

        [Test]
        public void AggregatesPeriodInPeriodModeWithDailyDataAndRoundedTime()
        {
            TradeBar consolidated = null;
            var consolidator = new BaseDataConsolidator(TimeSpan.FromDays(1));
            consolidator.DataConsolidated += (sender, bar) =>
            {
                consolidated = bar;
            };

            var reference = new DateTime(2015, 04, 13);
            consolidator.Update(new Tick { Time = reference.AddSeconds(45) });
            Assert.IsNull(consolidated);

            consolidator.Update(new Tick { Time = reference.AddDays(1).AddMinutes(1) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
            Assert.AreEqual(reference, consolidated.Time);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddDays(2).AddHours(1).AddMinutes(1).AddSeconds(1) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
            Assert.AreEqual(reference.AddDays(1), consolidated.Time);
            consolidated = null;

            consolidator.Update(new Tick { Time = reference.AddDays(3) });
            Assert.IsNotNull(consolidated);
            Assert.AreEqual(TimeSpan.FromDays(1), consolidated.Period);
            Assert.AreEqual(reference.AddDays(2), consolidated.Time);
        }
    }
}
