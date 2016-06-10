using System;
using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public abstract class Order 
    {
        public int Id { get; internal set; }
        public int ContingentId { get; internal set; }
        public List<string> BrokerId { get; internal set; }
        public Symbol Symbol { get; internal set; }
        public decimal Price { get; internal set; }
        public string PriceCurrency { get; internal set; }
        public DateTime Time { get; internal set; }
        public int Quantity { get; internal set; }
        public abstract OrderType Type { get; }
        public OrderStatus Status { get; internal set; }
        public OrderDuration Duration { get; internal set; }
        public string Tag { get; internal set; }
        public SecurityType SecurityType { get { return Symbol.ID.SecurityType; } }
        public OrderDirection Direction 
        {
            get 
            {
                if (Quantity > 0) 
                {
                    return OrderDirection.Buy;
                } 
                if (Quantity < 0) 
                {
                    return OrderDirection.Sell;
                }
                return OrderDirection.Hold;
            }
        }
        public decimal AbsoluteQuantity
        {
            get { return Math.Abs(Quantity); }
        }
        public decimal Value
        {
            get { return Quantity*Price; }
        }
        protected Order()
        {
            Time = new DateTime();
            Price = 0;
            PriceCurrency = string.Empty;
            Quantity = 0;
            Symbol = Symbol.Empty;
            Status = OrderStatus.None;
            Tag = "";
            Duration = OrderDuration.GTC;
            BrokerId = new List<string>();
            ContingentId = 0;
            DurationValue = DateTime.MaxValue;
        }
        protected Order(Symbol symbol, int quantity, DateTime time, string tag = "")
        {
            Time = time;
            Price = 0;
            PriceCurrency = string.Empty;
            Quantity = quantity;
            Symbol = symbol;
            Status = OrderStatus.None;
            Tag = tag;
            Duration = OrderDuration.GTC;
            BrokerId = new List<string>();
            ContingentId = 0;
            DurationValue = DateTime.MaxValue;
        }
        public decimal GetValue(Security security)
        {
            var value = GetValueImpl(security);
            return value*security.QuoteCurrency.ConversionRate*security.SymbolProperties.ContractMultiplier;
        }
        protected abstract decimal GetValueImpl(Security security);
        public virtual void ApplyUpdateOrderRequest(UpdateOrderRequest request)
        {
            if (request.OrderId != Id)
            {
                throw new ArgumentException("Attempted to apply updates to the incorrect order!");
            }
            if (request.Quantity.HasValue)
            {
                Quantity = request.Quantity.Value;
            }
            if (request.Tag != null)
            {
                Tag = request.Tag;
            }
        }
        public override string ToString()
        {
            return string.Format("OrderId: {0} {1} {2} order for {3} unit{4} of {5}", Id, Status, Type, Quantity, Quantity == 1 ? "" : "s", Symbol);
        }
        public abstract Order Clone();
        protected void CopyTo(Order order)
        {
            order.Id = Id;
            order.Time = Time;
            order.BrokerId = BrokerId.ToList();
            order.ContingentId = ContingentId;
            order.Duration = Duration;
            order.Price = Price;
            order.PriceCurrency = PriceCurrency;
            order.Quantity = Quantity;
            order.Status = Status;
            order.Symbol = Symbol;
            order.Tag = Tag;
        }
        public static Order CreateOrder(SubmitOrderRequest request)
        {
            Order order;
            switch (request.OrderType)
            {
                case OrderType.Market:
                    order = new MarketOrder(request.Symbol, request.Quantity, request.Time, request.Tag);
                    break;
                case OrderType.Limit:
                    order = new LimitOrder(request.Symbol, request.Quantity, request.LimitPrice, request.Time, request.Tag);
                    break;
                case OrderType.StopMarket:
                    order = new StopMarketOrder(request.Symbol, request.Quantity, request.StopPrice, request.Time, request.Tag);
                    break;
                case OrderType.StopLimit:
                    order = new StopLimitOrder(request.Symbol, request.Quantity, request.StopPrice, request.LimitPrice, request.Time, request.Tag);
                    break;
                case OrderType.MarketOnOpen:
                    order = new MarketOnOpenOrder(request.Symbol, request.Quantity, request.Time, request.Tag);
                    break;
                case OrderType.MarketOnClose:
                    order = new MarketOnCloseOrder(request.Symbol, request.Quantity, request.Time, request.Tag);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            order.Status = OrderStatus.New;
            order.Id = request.OrderId;
            if (request.Tag != null)
            {
                order.Tag = request.Tag;
            }
            return order;
        }
        public DateTime DurationValue;
    }
}
