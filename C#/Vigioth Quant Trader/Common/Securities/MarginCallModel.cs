using System.Collections.Generic;
using System.Linq;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public class MarginCallModel
    {
        protected SecurityPortfolioManager Portfolio { get; private set; }
        public MarginCallModel(SecurityPortfolioManager portfolio)
        {
            Portfolio = portfolio;
        }
        public virtual List<OrderTicket> ExecuteMarginCall(IEnumerable<SubmitOrderRequest> generatedMarginCallOrders)
        {
            if (Portfolio.MarginRemaining >= 0)
            {
                return new List<OrderTicket>();
            }
            var executedOrders = new List<OrderTicket>();
            var ordersWithSecurities = generatedMarginCallOrders.ToDictionary(x => x, x => Portfolio[x.Symbol]);
            var orderedByLosers = ordersWithSecurities.OrderBy(x => x.Value.UnrealizedProfit).Select(x => x.Key);
            foreach (var request in orderedByLosers)
            {
                var ticket = Portfolio.Transactions.AddOrder(request);
                Portfolio.Transactions.WaitForOrder(request.OrderId);
                executedOrders.Add(ticket);
                if (Portfolio.MarginRemaining >= 0)
                {
                    break;
                }
            }
            return executedOrders;
        }
    }
}