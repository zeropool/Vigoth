using System;
using VigiothCapital.QuantTrader.Orders;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Delisting : BaseData
    {
        public DelistingType Type { get; private set; }
        public OrderTicket Ticket { get; private set; }
        public Delisting()
        {
            DataType = MarketDataType.Auxiliary;
            Type = DelistingType.Delisted;
        }
        public Delisting(Symbol symbol, DateTime date, decimal price, DelistingType type)
            : this()
        {
            Symbol = symbol;
            Time = date;
            Value = price;
            Type = type;
        }
        public void SetOrderTicket(OrderTicket ticket)
        {
            Ticket = ticket;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Delisting type.");
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Delisting type.");
        }
        public override BaseData Clone()
        {
            return new Delisting(Symbol, Time, Price, Type);
        }
    }
}
