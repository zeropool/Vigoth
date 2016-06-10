using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class SymbolChangedEvent : BaseData
    {
        public string OldSymbol { get; private set; }
        public string NewSymbol { get; private set; }
        public SymbolChangedEvent()
        {
            DataType = MarketDataType.Auxiliary;
        }
        public SymbolChangedEvent(Symbol requestedSymbol, DateTime date, string oldSymbol, string newSymbol)
            : this()
        {
            Time = date;
            Symbol = requestedSymbol;
            OldSymbol = oldSymbol;
            NewSymbol = newSymbol;
        }
        public override BaseData Clone()
        {
            return new SymbolChangedEvent(Symbol, Time, OldSymbol, NewSymbol);
        }
    }
}
