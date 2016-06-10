using System.Threading;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class Bar : IBar
    {
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public Bar()
        {
        }
        public Bar(decimal open, decimal high, decimal low, decimal close)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }
        public void Update(decimal value)
        {
            if (value == 0) return;
            if (Open == 0) Open = High = Low = Close = value;
            if (value > High) High = value;
            if (value < Low) Low = value;
            Close = value;
        }
        public Bar Clone()
        {
            return new Bar(Open, High, Low, Close);
        }
    }
}