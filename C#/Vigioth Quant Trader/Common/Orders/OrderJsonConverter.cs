using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Util;
namespace VigiothCapital.QuantTrader.Orders
{
    public class OrderJsonConverter : JsonConverter
    {
        private static readonly Lazy<IMapFileProvider> MapFileProvider = new Lazy<IMapFileProvider>(() =>
            Composer.Instance.GetExportedValueByTypeName<IMapFileProvider>(Config.Get("map-file-provider", "LocalDiskMapFileProvider"))
            );
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Order).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("The OrderJsonConverter does not implement a WriteJson method;.");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var order = CreateOrderFromJObject(jObject);
            return order;
        }
        public static Order CreateOrderFromJObject(JObject jObject)
        {
            var orderType = (OrderType) jObject["Type"].Value<int>();
            var order = CreateOrder(orderType, jObject);
            order.Id = jObject["Id"].Value<int>();
            order.Quantity = jObject["Quantity"].Value<int>();
            order.Status = (OrderStatus) jObject["Status"].Value<int>();
            order.Time = jObject["Time"].Value<DateTime>();
            order.Tag = jObject["Tag"].Value<string>();
            order.Quantity = jObject["Quantity"].Value<int>();
            order.Price = jObject["Price"].Value<decimal>();
            var securityType = (SecurityType) jObject["SecurityType"].Value<int>();
            order.BrokerId = jObject["BrokerId"].Select(x => x.Value<string>()).ToList();
            order.ContingentId = jObject["ContingentId"].Value<int>();
            var market = Market.USA;
            if (securityType == SecurityType.Forex) market = Market.FXCM;
            if (jObject.SelectTokens("Symbol.ID").Any())
            {
                var sid = SecurityIdentifier.Parse(jObject.SelectTokens("Symbol.ID").Single().Value<string>());
                var ticker = jObject.SelectTokens("Symbol.Value").Single().Value<string>();
                order.Symbol = new Symbol(sid, ticker);
            }
            else if (jObject.SelectTokens("Symbol.Value").Any())
            {
                var ticker = jObject.SelectTokens("Symbol.Value").Single().Value<string>();
                order.Symbol = Symbol.Create(ticker, securityType, market);
            }
            else
            {
                var tickerstring = jObject["Symbol"].Value<string>();
                order.Symbol = Symbol.Create(tickerstring, securityType, market);
            }
            return order;
        }
        private static Order CreateOrder(OrderType orderType, JObject jObject)
        {
            Order order;
            switch (orderType)
            {
                case OrderType.Market:
                    order = new MarketOrder();
                    break;
                case OrderType.Limit:
                    order = new LimitOrder {LimitPrice = jObject["LimitPrice"].Value<decimal>()};
                    break;
                case OrderType.StopMarket:
                    order = new StopMarketOrder
                    {
                        StopPrice = jObject["StopPrice"].Value<decimal>()
                    };
                    break;
                case OrderType.StopLimit:
                    order = new StopLimitOrder
                    {
                        LimitPrice = jObject["LimitPrice"].Value<decimal>(),
                        StopPrice = jObject["StopPrice"].Value<decimal>()
                    };
                    break;
                case OrderType.MarketOnOpen:
                    order = new MarketOnOpenOrder();
                    break;
                case OrderType.MarketOnClose:
                    order = new MarketOnCloseOrder();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return order;
        }
    }
}
