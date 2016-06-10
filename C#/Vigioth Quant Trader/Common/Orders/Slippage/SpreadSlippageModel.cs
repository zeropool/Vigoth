using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Slippage
{
    public class SpreadSlippageModel : ISlippageModel
    {
        public virtual decimal GetSlippageApproximation(Security asset, Order order)
        {
            var lastData = asset.GetLastData();
            var lastTick = lastData as Tick;
            if (lastTick != null)
            {
                return (lastTick.AskPrice - lastTick.BidPrice) / 2;
            }
            return 0m;
        }
    }
}