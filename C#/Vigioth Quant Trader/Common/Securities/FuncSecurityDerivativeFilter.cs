using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Securities
{
    public class FuncSecurityDerivativeFilter : IDerivativeSecurityFilter
    {
        private readonly Func<IEnumerable<Symbol>, BaseData, IEnumerable<Symbol>> _filter;
        public FuncSecurityDerivativeFilter(Func<IEnumerable<Symbol>, BaseData, IEnumerable<Symbol>> filter)
        {
            _filter = filter;
        }
        public IEnumerable<Symbol> Filter(IEnumerable<Symbol> symbols, BaseData underlying)
        {
            return _filter(symbols, underlying);
        }
    }
}