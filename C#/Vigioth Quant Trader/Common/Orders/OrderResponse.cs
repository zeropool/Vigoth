namespace VigiothCapital.QuantTrader.Orders
{
    public class OrderResponse
    {
        public int OrderId
        {
            get; private set;
        }
        public string ErrorMessage
        {
            get; private set;
        }
        public OrderResponseErrorCode ErrorCode
        {
            get; private set;
        }
        public bool IsSuccess
        {
            get { return IsProcessed && !IsError; }
        }
        public bool IsError
        {
            get { return IsProcessed && ErrorCode != OrderResponseErrorCode.None; }
        }
        public bool IsProcessed
        {
            get { return this != Unprocessed; }
        }
        private OrderResponse(int orderId, OrderResponseErrorCode errorCode, string errorMessage)
        {
            OrderId = orderId;
            ErrorCode = errorCode;
            if (errorCode != OrderResponseErrorCode.None)
            {
                ErrorMessage = errorMessage ?? "An unexpected error ocurred.";
            }
        }
        public override string ToString()
        {
            if (this == Unprocessed)
            {
                return "Unprocessed";
            }
            if (IsError)
            {
                return string.Format("Error: {0} - {1}", ErrorCode, ErrorMessage);
            }
            return "Success";
        }
        #region Statics - implicit(int), Unprocessed constant, reponse factory methods
        public static readonly OrderResponse Unprocessed = new OrderResponse(int.MinValue, OrderResponseErrorCode.None, "The request has not yet been processed.");
        public static OrderResponse Success(OrderRequest request)
        {
            return new OrderResponse(request.OrderId, OrderResponseErrorCode.None, null);
        }
        public static OrderResponse Error(OrderRequest request, OrderResponseErrorCode errorCode, string errorMessage)
        {
            return new OrderResponse(request.OrderId, errorCode, errorMessage);
        }
        public static OrderResponse InvalidStatus(OrderRequest request, Order order)
        {
            return Error(request, OrderResponseErrorCode.InvalidOrderStatus,
                string.Format("Unable to update order with id {0} because it already has {1} status", request.OrderId, order.Status));
        }
        public static OrderResponse UnableToFindOrder(OrderRequest request)
        {
            return Error(request, OrderResponseErrorCode.UnableToFindOrder,
                string.Format("Unable to locate order with id {0}.", request.OrderId));
        }
        public static OrderResponse ZeroQuantity(OrderRequest request)
        {
            const string format = "Unable to {0} order to have zero quantity.";
            return Error(request, OrderResponseErrorCode.OrderQuantityZero, string.Format(format, request.OrderRequestType.ToString().ToLower()));
        }
        public static OrderResponse WarmingUp(OrderRequest request)
        {
            return Error(request, OrderResponseErrorCode.AlgorithmWarmingUp, "Algorithm in warmup.");
        }
        #endregion
    }
}