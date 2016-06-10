using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Split : BaseData
    {
        public Split()
        {
            DataType = MarketDataType.Auxiliary;
        }
        public Split(Symbol symbol, DateTime date, decimal price, decimal splitFactor)
             : this()
        {
            Symbol = symbol;
            Time = date;
            ReferencePrice = price;
            SplitFactor = splitFactor;
        }
        public decimal SplitFactor
        {
            get { return Value; }
            set { Value = value; }
        }
        public decimal ReferencePrice
        {
            get; private set;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Split type.");
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Split type.");
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", Symbol, SplitFactor);
        }
        public override BaseData Clone()
        {
            return new Split(Symbol, Time, Price, SplitFactor);
        }
    }
}
