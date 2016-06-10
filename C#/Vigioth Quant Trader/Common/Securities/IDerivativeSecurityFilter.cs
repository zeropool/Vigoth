using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities
{
    public interface IDerivativeSecurityFilter
    {
        IEnumerable<Symbol> Filter(IEnumerable<Symbol> symbols, BaseData underlying);
    }
}
