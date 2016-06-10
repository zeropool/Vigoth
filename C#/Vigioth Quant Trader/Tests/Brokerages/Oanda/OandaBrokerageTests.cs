

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using VigiothCapital.QuantTrader.Brokerages.Oanda;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Securities;
using Environment = VigiothCapital.QuantTrader.Brokerages.Oanda.Environment;

namespace VigiothCapital.QuantTrader.Tests.Brokerages.Oanda
{
    [TestFixture, Ignore("This test requires a configured and testable Oanda practice account")]
    public partial class OandaBrokerageTests : BrokerageTests
    {
        /// <summary>
        ///     Creates the brokerage under test and connects it
        /// </summary>
        /// <returns>A connected brokerage instance</returns>
        protected override IBrokerage CreateBrokerage(IOrderProvider orderProvider, ISecurityProvider securityProvider)
        {
            var environment = Config.Get("oanda-environment").ConvertTo<Environment>();
            var accessToken = Config.Get("oanda-access-token");
            var accountId = Config.Get("oanda-account-id").ConvertTo<int>();

            return new OandaBrokerage(orderProvider, securityProvider, environment, accessToken, accountId);
        }

        /// <summary>
        ///     Gets the symbol to be traded, must be shortable
        /// </summary>
        protected override Symbol Symbol
        {
            get { return Symbol.Create("EURUSD", SecurityType.Forex, Market.Oanda); }
        }

        /// <summary>
        ///     Gets the security type associated with the <see cref="BrokerageTests.Symbol" />
        /// </summary>
        protected override SecurityType SecurityType
        {
            get { return SecurityType.Forex; }
        }

        /// <summary>
        ///     Gets a high price for the specified symbol so a limit sell won't fill
        /// </summary>
        protected override decimal HighPrice
        {
            get { return 5m; }
        }

        /// <summary>
        ///     Gets a low price for the specified symbol so a limit buy won't fill
        /// </summary>
        protected override decimal LowPrice
        {
            get { return 0.32m; }
        }

        /// <summary>
        ///     Gets the current market price of the specified security
        /// </summary>
        protected override decimal GetAskPrice(Symbol symbol)
        {
            var oanda = (OandaBrokerage) Brokerage;
            var quotes = oanda.GetRates(new List<string> { new OandaSymbolMapper().GetBrokerageSymbol(symbol) });
            return (decimal)quotes[0].ask;
        }

        [Test]
        public void ValidateLimitOrders()
        {
            var oanda = (OandaBrokerage)Brokerage;
            var symbol = Symbol;
            var quotes = oanda.GetRates(new List<string> { new OandaSymbolMapper().GetBrokerageSymbol(symbol) });

            // Buy Limit order below market
            var limitPrice = Convert.ToDecimal(quotes[0].bid - 0.5);
            var order = new LimitOrder(symbol, 1, limitPrice, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // update Buy Limit order with no changes
            Assert.IsTrue(oanda.UpdateOrder(order));

            // move Buy Limit order above market
            order.LimitPrice = Convert.ToDecimal(quotes[0].ask + 0.5);
            Assert.IsTrue(oanda.UpdateOrder(order));
        }

        [Test]
        public void ValidateStopMarketOrders()
        {
            var oanda = (OandaBrokerage)Brokerage;
            var symbol = Symbol;
            var quotes = oanda.GetRates(new List<string> { new OandaSymbolMapper().GetBrokerageSymbol(symbol) });

            // Buy StopMarket order below market
            var price = Convert.ToDecimal(quotes[0].bid - 0.5);
            var order = new StopMarketOrder(symbol, 1, price, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Buy StopMarket order above market
            price = Convert.ToDecimal(quotes[0].ask + 0.5);
            order = new StopMarketOrder(symbol, 1, price, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Sell StopMarket order below market
            price = Convert.ToDecimal(quotes[0].bid - 0.5);
            order = new StopMarketOrder(symbol, -1, price, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Sell StopMarket order above market
            price = Convert.ToDecimal(quotes[0].ask + 0.5);
            order = new StopMarketOrder(symbol, -1, price, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));
        }

        [Test]
        public void ValidateStopLimitOrders()
        {
            var oanda = (OandaBrokerage) Brokerage;
            var symbol = Symbol;
            var quotes = oanda.GetRates(new List<string> {new OandaSymbolMapper().GetBrokerageSymbol(symbol)});

            // Buy StopLimit order below market (Oanda accepts this order but cancels it immediately)
            var stopPrice = Convert.ToDecimal(quotes[0].bid - 0.5);
            var limitPrice = stopPrice + 0.0005m;
            var order = new StopLimitOrder(symbol, 1, stopPrice, limitPrice, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Buy StopLimit order above market
            stopPrice = Convert.ToDecimal(quotes[0].ask + 0.5);
            limitPrice = stopPrice + 0.0005m;
            order = new StopLimitOrder(symbol, 1, stopPrice, limitPrice, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Sell StopLimit order below market
            stopPrice = Convert.ToDecimal(quotes[0].bid - 0.5);
            limitPrice = stopPrice - 0.0005m;
            order = new StopLimitOrder(symbol, -1, stopPrice, limitPrice, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));

            // Sell StopLimit order above market (Oanda accepts this order but cancels it immediately)
            stopPrice = Convert.ToDecimal(quotes[0].ask + 0.5);
            limitPrice = stopPrice - 0.0005m;
            order = new StopLimitOrder(symbol, -1, stopPrice, limitPrice, DateTime.Now);
            Assert.IsTrue(oanda.PlaceOrder(order));
        }

        [Test, Ignore("This test requires disconnecting the internet to test for connection resiliency")]
        public void ClientReconnectsAfterInternetDisconnect()
        {
            var brokerage = Brokerage;
            Assert.IsTrue(brokerage.IsConnected);

            var tenMinutes = TimeSpan.FromMinutes(10);

            Console.WriteLine("------");
            Console.WriteLine("Waiting for internet disconnection ");
            Console.WriteLine("------");

            // spin while we manually disconnect the internet
            while (brokerage.IsConnected)
            {
                Thread.Sleep(2500);
                Console.Write(".");
            }

            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine("------");
            Console.WriteLine("Trying to reconnect ");
            Console.WriteLine("------");

            // spin until we're reconnected
            while (!brokerage.IsConnected && stopwatch.Elapsed < tenMinutes)
            {
                Thread.Sleep(2500);
                Console.Write(".");
            }

            Assert.IsTrue(brokerage.IsConnected);
        }

    }
}
