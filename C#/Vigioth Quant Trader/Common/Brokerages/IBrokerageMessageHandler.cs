namespace VigiothCapital.QuantTrader.Brokerages
{
    public interface IBrokerageMessageHandler
    {
        void Handle(BrokerageMessageEvent message);
    }
}
