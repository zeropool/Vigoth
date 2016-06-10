

using System;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Data.Consolidators;
using VigiothCapital.QuantTrader.Data.Market;

namespace VigiothCapital.QuantTrader.Tests.Common.Data
{
    [TestFixture]
    public class TickQuoteBarConsolidatorTests
    {
        [Test]
        public void AggregatesNewQuoteBarProperly()
        {
            QuoteBar quoteBar = null;
            var creator = new TickQuoteBarConsolidator(4);
            creator.DataConsolidated += (sender, args) =>
            {
                quoteBar = args;
            };
            var reference = DateTime.Today;
            var tick1 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference,
                BidPrice = 10,
                BidSize = 20,
                TickType = TickType.Quote
            };
            creator.Update(tick1);
            Assert.IsNull(quoteBar);

            var tick2 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(1),
                AskPrice = 20,
                AskSize = 10,
                TickType = TickType.Quote
            };

            var badTick = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(1),
                AskPrice = 25,
                AskSize = 100,
                BidPrice = -100,
                BidSize = 2,
                Value = 50,
                Quantity = 1234,
                TickType = TickType.Trade
            };
            creator.Update(badTick);
            Assert.IsNull(quoteBar);
            
            creator.Update(tick2);
            Assert.IsNull(quoteBar);
            var tick3 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(2),
                BidPrice = 12,
                BidSize = 50,
                TickType = TickType.Quote
            };
            creator.Update(tick3);
            Assert.IsNull(quoteBar);

            var tick4 = new Tick
            {
                Symbol = Symbols.SPY,
                Time = reference.AddHours(3),
                AskPrice = 17,
                AskSize = 15,
                TickType = TickType.Quote
            };
            creator.Update(tick4);
            Assert.IsNotNull(quoteBar);

            Assert.AreEqual(Symbols.SPY, quoteBar.Symbol);
            Assert.AreEqual(tick1.Time, quoteBar.Time);
            Assert.AreEqual(tick1.BidPrice, quoteBar.Bid.Open);
            Assert.AreEqual(tick1.BidPrice, quoteBar.Bid.Low);
            Assert.AreEqual(tick3.BidPrice, quoteBar.Bid.High);
            Assert.AreEqual(tick3.BidPrice, quoteBar.Bid.Close);
            Assert.AreEqual(tick3.BidSize, quoteBar.LastBidSize);

            Assert.AreEqual(tick2.AskPrice, quoteBar.Ask.Open);
            Assert.AreEqual(tick4.AskPrice, quoteBar.Ask.Low);
            Assert.AreEqual(tick2.AskPrice, quoteBar.Ask.High);
            Assert.AreEqual(tick4.AskPrice, quoteBar.Ask.Close);
            Assert.AreEqual(tick4.AskSize, quoteBar.LastAskSize);
        }
    }
}