namespace VigiothCapital.QuantTrader.Orders
{
    public enum OrderResponseErrorCode
    {
        None = 0,
        ProcessingError = -1,
        OrderAlreadyExists = -2,
        InsufficientBuyingPower = -3,
        BrokerageModelRefusedToSubmitOrder = -4,
        BrokerageFailedToSubmitOrder = -5,
        BrokerageFailedToUpdateOrder = -6,
        BrokerageHandlerRefusedToUpdateOrder = -7,
        BrokerageFailedToCancelOrder = -8,
        InvalidOrderStatus = -9,
        UnableToFindOrder = -10,
        OrderQuantityZero = -11,
        UnsupportedRequestType = -12,
        PreOrderChecksError = -13,
        MissingSecurity = -14,
        ExchangeNotOpen = -15,
        SecurityPriceZero = -16,
        ForexBaseAndQuoteCurrenciesRequired = -17,
        ForexConversionRateZero = -18,
        SecurityHasNoData = -19,
        ExceededMaximumOrders = -20,
        MarketOnCloseOrderTooLate = -21,
        InvalidRequest = -22,
        RequestCanceled = -23,
        AlgorithmWarmingUp = -24,
        BrokerageModelRefusedToUpdateOrder = -25,
        QuoteCurrencyRequired = -26,
        ConversionRateZero = -27,
        NonTradableSecurity = -28
    }
}