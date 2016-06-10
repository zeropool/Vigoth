using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface ISecurityPortfolioModel
    {
        void ProcessFill(SecurityPortfolioManager portfolio, Security security, OrderEvent fill);
    }
}