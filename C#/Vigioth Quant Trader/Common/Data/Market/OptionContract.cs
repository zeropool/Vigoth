using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Securities.Option;
namespace VigiothCapital.QuantTrader.Data.Market
{
    public class OptionContract
    {
        private Lazy<OptionPriceModelResult> _optionPriceModelResult = new Lazy<OptionPriceModelResult>(() => new OptionPriceModelResult(0m, new FirstOrderGreeks())); 
        public Symbol Symbol
        {
            get; private set;
        }
        public Symbol UnderlyingSymbol
        {
            get; private set;
        }
        public decimal Strike
        {
            get { return Symbol.ID.StrikePrice; }
        }
        public DateTime Expiry
        {
            get { return Symbol.ID.Date; }
        }
        public OptionRight Right
        {
            get { return Symbol.ID.OptionRight; }
        }
        public decimal TheoreticalPrice
        {
            get { return _optionPriceModelResult.Value.TheoreticalPrice; }
        }
        public FirstOrderGreeks Greeks
        {
            get { return _optionPriceModelResult.Value.Greeks; }
        }
        public DateTime Time
        {
            get; set;
        }
        public decimal OpenInterest
        {
            get; set;
        }
        public decimal LastPrice
        {
            get; set;
        }
        public decimal BidPrice
        {
            get; set;
        }
        public long BidSize
        {
            get; set;
        }
        public decimal AskPrice
        {
            get; set;
        }
        public long AskSize
        {
            get; set;
        }
        public decimal UnderlyingLastPrice
        {
            get; set;
        }
        public OptionContract(Symbol symbol, Symbol underlyingSymbol)
        {
            Symbol = symbol;
            UnderlyingSymbol = underlyingSymbol;
        }
        internal void SetOptionPriceModel(Func<OptionPriceModelResult> optionPriceModelEvaluator)
        {
            _optionPriceModelResult = new Lazy<OptionPriceModelResult>(optionPriceModelEvaluator);
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3:00000000}", Symbol.ID.Symbol, Expiry.ToString(DateFormat.EightCharacter), Right.ToString()[0], Strike*1000m);
        }
    }
}
