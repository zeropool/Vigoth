using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Dividend : BaseData
    {
        public Dividend()
        {
            DataType = MarketDataType.Auxiliary;
        }
        public Dividend(Symbol symbol, DateTime date, decimal close, decimal priceFactorRatio)
            : this()
        {
            Symbol = symbol;
            Time = date;
            Distribution = close - (close * priceFactorRatio);
        }
        public Dividend(Symbol symbol, DateTime date, decimal distribution)
            : this()
        {
            Symbol = symbol;
            Time = date;
            Distribution = distribution;
        }
        public decimal Distribution
        {
            get { return Value; } 
            set { Value = Math.Round(value, 2); }
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Dividend type.");
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("This method is not supposed to be called on the Dividend type.");
        }
        public override BaseData Clone()
        {
            return new Dividend(Symbol, Time, Distribution);
        }
    }
}
