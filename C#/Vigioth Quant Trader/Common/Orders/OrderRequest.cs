using System;
namespace VigiothCapital.QuantTrader.Orders
{
    public abstract class OrderRequest
    {
        public abstract OrderRequestType OrderRequestType
        {
            get;
        }
        public OrderRequestStatus Status
        {
            get; private set;
        }
        public DateTime Time
        {
            get; private set;
        }
        public int OrderId
        {
            get; protected set;
        }
        public string Tag
        {
            get; private set;
        }
        public OrderResponse Response
        {
            get; private set;
        }
        protected OrderRequest(DateTime time, int orderId, string tag)
        {
            Time = time;
            OrderId = orderId;
            Tag = tag;
            Response = OrderResponse.Unprocessed;
            Status = OrderRequestStatus.Unprocessed;
        }
        public void SetResponse(OrderResponse response, OrderRequestStatus status = OrderRequestStatus.Error)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response", "Response can not be null");
            }
            Status = response.IsError ? OrderRequestStatus.Error : status;
            Response = response;
        }
        public override string ToString()
        {
            return string.Format("{0} UTC: Order: ({1}) - {2} Status: {3}", Time, OrderId, Tag, Status);
        }
    }
}