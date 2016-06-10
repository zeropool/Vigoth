using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Slippage
{
    public class ConstantSlippageModel : SpreadSlippageModel
    {
        private readonly decimal _slippagePercent;
        public ConstantSlippageModel(decimal slippagePercent)
        {
            _slippagePercent = slippagePercent;
        }
        public override decimal GetSlippageApproximation(Security asset, Order order)
        {
            var lastData = asset.GetLastData();
            if (lastData == null) return 0;
            return lastData.Value*_slippagePercent;
        }
    }
}
