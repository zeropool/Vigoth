using System.ComponentModel;
namespace VigiothCapital.QuantTrader.Orders
{
    public enum OrderError
    {
        [Description("Order has already been filled and cannot be modified")]
        CanNotUpdateFilledOrder = -8,
        [Description("General error in order")]
        GeneralError = -7,
        [Description("Order timestamp error. Order appears to be executing in the future")]
        TimestampError = -6,
        [Description("Exceeded maximum allowed orders for one analysis period")]
        MaxOrdersExceeded = -5,
        [Description("Insufficient capital to execute order")]
        InsufficientCapital = -4,
        [Description("Attempting market order outside of market hours")]
        MarketClosed = -3,
        [Description("There is no data yet for this security - please wait for data (market order price not available yet)")]
        NoData = -2,
        [Description("Order quantity must not be zero")]
        ZeroQuantity = -1,
        [Description("The order is OK")]
        None = 0
    }
}
