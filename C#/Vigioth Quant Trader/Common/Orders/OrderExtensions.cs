namespace VigiothCapital.QuantTrader.Orders
{
    public static class OrderExtensions
    {
        public static bool IsClosed(this OrderStatus status)
        {
            return status == OrderStatus.Filled
                || status == OrderStatus.Canceled
                || status == OrderStatus.Invalid;
        }
        public static bool IsOpen(this OrderStatus status)
        {
            return !status.IsClosed();
        }
        public static bool IsFill(this OrderStatus status)
        {
            return status == OrderStatus.Filled || status == OrderStatus.PartiallyFilled;
        }
        public static bool IsLimitOrder(this OrderType orderType)
        {
            return orderType == OrderType.Limit || orderType == OrderType.StopLimit;
        }
        public static bool IsStopOrder(this OrderType orderType)
        {
            return orderType == OrderType.StopMarket || orderType == OrderType.StopLimit;
        }
    }
}
