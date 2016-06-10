using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders.Fees
{
    public class ConstantFeeModel : IFeeModel
    {
        private readonly decimal _fee;
        public ConstantFeeModel(decimal fee)
        {
            _fee = Math.Abs(fee);
        }
        public decimal GetOrderFee(Security security, Order order)
        {
            return _fee;
        }
    }
}