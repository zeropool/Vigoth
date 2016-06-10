using System;
namespace VigiothCapital.QuantTrader.Orders
{
    public class CancelOrderRequest : OrderRequest
    {
        public override OrderRequestType OrderRequestType
        {
            get { return OrderRequestType.Cancel; }
        }
        public CancelOrderRequest(DateTime time, int orderId, string tag)
            : base(time, orderId, tag)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} UTC: Cancel Order: ({1}) - {2}", Time, OrderId, Tag) + " Status: " + Status;
        }
    }
}