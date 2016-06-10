using VigiothCapital.QuantTrader.Brokerages;
namespace VigiothCapital.QuantTrader.Securities
{
    public class BrokerageModelSecurityInitializer : ISecurityInitializer
    {
        private readonly IBrokerageModel _brokerageModel;
        public BrokerageModelSecurityInitializer(IBrokerageModel brokerageModel)
        {
            _brokerageModel = brokerageModel;
        }
        public virtual void Initialize(Security security)
        {
            security.SetLeverage(_brokerageModel.GetLeverage(security));
            security.FillModel = _brokerageModel.GetFillModel(security);
            security.FeeModel = _brokerageModel.GetFeeModel(security);
            security.SlippageModel = _brokerageModel.GetSlippageModel(security);
            security.SettlementModel = _brokerageModel.GetSettlementModel(security, _brokerageModel.AccountType);
        }
    }
}
