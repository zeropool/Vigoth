namespace VigiothCapital.QuantTrader.Data.Market
{
    public interface IBar
    {
        decimal Open { get; }
        decimal High { get; }
        decimal Low { get; }
        decimal Close { get; }
    }
}