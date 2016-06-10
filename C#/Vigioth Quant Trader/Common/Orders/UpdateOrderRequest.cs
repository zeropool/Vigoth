using System;
using System.Collections.Generic;
namespace VigiothCapital.QuantTrader.Orders
{
    public class UpdateOrderRequest : OrderRequest
    {
        public override OrderRequestType OrderRequestType
        {
            get { return OrderRequestType.Update; }
        }
        public int? Quantity { get; private set; }
        public decimal? LimitPrice { get; private set; }
        public decimal? StopPrice { get; private set; }
        public UpdateOrderRequest(DateTime time, int orderId, UpdateOrderFields fields)
            : base(time, orderId, fields.Tag)
        {
            Quantity = fields.Quantity;
            LimitPrice = fields.LimitPrice;
            StopPrice = fields.StopPrice;
        }
        public override string ToString()
        {
            var updates = new List<string>();
            if (Quantity.HasValue)
            {
                updates.Add("Quantity: " + Quantity.Value);
            }
            if (LimitPrice.HasValue)
            {
                updates.Add("LimitPrice: " + LimitPrice.Value.SmartRounding());
            }
            if (StopPrice.HasValue)
            {
                updates.Add("StopPrice: " + StopPrice.Value.SmartRounding());
            }
            return string.Format("{0} UTC: Update Order: ({1}) - {2} {3} Status: {4}", Time, OrderId, string.Join(", ", updates), Tag, Status);
        }
    }
}