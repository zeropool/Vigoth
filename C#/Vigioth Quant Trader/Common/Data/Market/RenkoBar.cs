using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class RenkoBar : BaseData
    {
        public decimal BrickSize { get; private set; }
        public decimal Open { get; private set; }
        public decimal Close
        {
            get { return Value; }
            private set { Value = value; }
        }
        public decimal High { get; private set; }
        public decimal Low { get; private set; }
        public long Volume { get; private set; }
        public override DateTime EndTime { get; set; }
        [Obsolete("RenkoBar.End is obsolete. Please use RenkoBar.EndTime property instead.")]
        public DateTime End
        {
            get { return EndTime; }
            set { EndTime = value; }
        }
        public DateTime Start
        {
            get { return Time; }
            private set { Time = value; }
        }
        public bool IsClosed { get; private set; }
        public RenkoBar()
        {
        }
        public RenkoBar(Symbol symbol, DateTime time, decimal brickSize, decimal open, long volume)
        {
            Symbol = symbol;
            Start = time;
            EndTime = time;
            BrickSize = brickSize;
            Open = open;
            Close = open;
            Volume = volume;
            High = open;
            Low = open;
        }
        public bool Update(DateTime time, decimal currentValue, long volumeSinceLastUpdate)
        {
            if (IsClosed) return true;
            if (Start == DateTime.MinValue) Start = time;
            EndTime = time;
            decimal lowClose = Open - BrickSize;
            decimal highClose = Open + BrickSize;
            Close = Math.Min(highClose, Math.Max(lowClose, currentValue));
            Volume += volumeSinceLastUpdate;
            if (currentValue <= lowClose  || currentValue >= highClose)
            {
                IsClosed = true;
            }
            if (Close > High) High = Close;
            if (Close < Low) Low = Close;
            return IsClosed;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotSupportedException("RenkoBar does not support the Reader function. This function should never be called on this type.");
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotSupportedException("RenkoBar does not support the GetSource function. This function should never be called on this type.");
        }
        public override BaseData Clone()
        {
            return new RenkoBar
            {
                BrickSize = BrickSize,
                Open = Open,
                Volume = Volume,
                Close = Close,
                EndTime = EndTime,
                High = High,
                IsClosed = IsClosed,
                Low = Low,
                Time = Time,
                Value = Value,
                Symbol = Symbol,
                DataType = DataType
            };
        }
    }
}