using System;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Securities
{
    public sealed class ConstantFeeTransactionModel : SecurityTransactionModel
    {
        private readonly decimal _fee;
        public ConstantFeeTransactionModel(decimal fee)
        {
            _fee = Math.Abs(fee);
        }
        public override decimal GetOrderFee(Security security, Order order)
        {
            return _fee;
        }
    }
}