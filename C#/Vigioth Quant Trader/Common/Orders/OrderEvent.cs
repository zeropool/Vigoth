using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public class OrderEvent
    {
        public int OrderId;
        public Symbol Symbol;
        public DateTime UtcTime;
        public OrderStatus Status;
        public decimal OrderFee;
        public decimal FillPrice;
        public string FillPriceCurrency;
        public int FillQuantity;
        public int AbsoluteFillQuantity 
        {
            get 
            {
                return Math.Abs(FillQuantity);
            }
        }
        public OrderDirection Direction
        {
            get; private set;
        }
        public string Message;
        public OrderEvent(int orderId, Symbol symbol, DateTime utcTime, OrderStatus status, OrderDirection direction, decimal fillPrice, int fillQuantity, decimal orderFee, string message = "")
        {
            OrderId = orderId;
            Symbol = symbol;
            UtcTime = utcTime;
            Status = status;
            Direction = direction;
            FillPrice = fillPrice;
            FillPriceCurrency = string.Empty;
            FillQuantity = fillQuantity;
            OrderFee = Math.Abs(orderFee);
            Message = message;
        }
        public OrderEvent(Order order, DateTime utcTime, decimal orderFee, string message = "") 
        {
            OrderId = order.Id;
            Symbol = order.Symbol;
            Status = order.Status;
            Direction = order.Direction;
            FillQuantity = 0;
            FillPrice = 0;
            FillPriceCurrency = order.PriceCurrency;
            UtcTime = utcTime;
            OrderFee = Math.Abs(orderFee);
            Message = message;
        }
        public override string ToString()
        {
            var message = FillQuantity == 0 
                ? string.Format("Time: {0} OrderID: {1} Symbol: {2} Status: {3}", UtcTime, OrderId, Symbol, Status) 
                : string.Format("Time: {0} OrderID: {1} Symbol: {2} Status: {3} Quantity: {4} FillPrice: {5} {6}", UtcTime, OrderId, Symbol, Status, FillQuantity, FillPrice, FillPriceCurrency);
            if (OrderFee != 0m) message += string.Format(" OrderFee: {0} {1}", OrderFee, CashBook.AccountCurrency);
            return message;
        }
        public OrderEvent Clone()
        {
            return (OrderEvent)MemberwiseClone();
        }
    }
}    
