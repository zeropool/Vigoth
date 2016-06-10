using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Fills
{
    public interface IFillModel
    {
        OrderEvent MarketFill(Security asset, MarketOrder order);
        OrderEvent StopMarketFill(Security asset, StopMarketOrder order);
        OrderEvent StopLimitFill(Security asset, StopLimitOrder order);
        OrderEvent LimitFill(Security asset, LimitOrder order);
        OrderEvent MarketOnOpenFill(Security asset, MarketOnOpenOrder order);
        OrderEvent MarketOnCloseFill(Security asset, MarketOnCloseOrder order);
    }
}