namespace VigiothCapital.QuantTrader.Orders
{
    public enum OrderType 
    {
        Market,
        Limit,
        StopMarket,
        StopLimit,
        MarketOnOpen,
        MarketOnClose
    }
    public enum OrderDuration
    {
        GTC,
        Custom
    }
    public enum OrderDirection {
        Buy,
        Sell,
        Hold
    }
    public enum OrderStatus {
        New = 0,
        Submitted = 1,
        PartiallyFilled = 2,
        Filled = 3,
        Canceled = 5,
        None = 6,
        Invalid = 7
    }
}    
