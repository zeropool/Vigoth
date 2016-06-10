using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface ISecurityMarginModel
    {
        decimal GetLeverage(Security security);
        void SetLeverage(Security security, decimal leverage);
        decimal GetInitialMarginRequiredForOrder(Security security, Order order);
        decimal GetMaintenanceMargin(Security security);
        decimal GetMarginRemaining(SecurityPortfolioManager portfolio, Security security, OrderDirection direction);
        SubmitOrderRequest GenerateMarginCallOrder(Security security, decimal netLiquidationValue, decimal totalMargin);
    }
}
