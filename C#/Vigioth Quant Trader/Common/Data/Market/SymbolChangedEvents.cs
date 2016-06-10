using System;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class SymbolChangedEvents : DataDictionary<SymbolChangedEvent>
    {
        public SymbolChangedEvents()
        {
        }
        public SymbolChangedEvents(DateTime frontier)
            : base(frontier)
        {
        }
    }
}
