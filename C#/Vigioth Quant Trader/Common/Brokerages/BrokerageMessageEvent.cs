namespace VigiothCapital.QuantTrader.Brokerages
{
    public class BrokerageMessageEvent
    {
        public BrokerageMessageType Type { get; private set; }
        public string Code { get; private set; }
        public string Message { get; private set; }
        public BrokerageMessageEvent(BrokerageMessageType type, int code, string message)
        {
            Type = type;
            Code = code.ToString();
            Message = message;
        }
        public BrokerageMessageEvent(BrokerageMessageType type, string code, string message)
        {
            Type = type;
            Code = code;
            Message = message;
        }
        public static BrokerageMessageEvent Disconnected(string message)
        {
            return new BrokerageMessageEvent(BrokerageMessageType.Disconnect, "Disconnect", message);
        }
        public static BrokerageMessageEvent Reconnected(string message)
        {
            return new BrokerageMessageEvent(BrokerageMessageType.Reconnect, "Reconnect", message);
        }
        public override string ToString()
        {
            return string.Format("{0} - Code: {1} - {2}", Type, Code, Message);
        }
    }
}