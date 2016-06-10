

using System;

namespace VigiothCapital.QuantTrader.Tests
{
    /// <summary>
    /// Provides symbol instancs for unit tests
    /// </summary>
    public static class Symbols
    {
        public static readonly Symbol SPY = CreateEquitySymbol("SPY");
        public static readonly Symbol AAPL = CreateEquitySymbol("AAPL");
        public static readonly Symbol MSFT = CreateEquitySymbol("MSFT");
        public static readonly Symbol ZNGA = CreateEquitySymbol("ZNGA");
        public static readonly Symbol FXE = CreateEquitySymbol("FXE");

        public static readonly Symbol USDJPY = CreateForexSymbol("USDJPY");
        public static readonly Symbol EURUSD = CreateForexSymbol("EURUSD");
        public static readonly Symbol EURGBP = CreateForexSymbol("EURGBP");
        public static readonly Symbol GBPUSD = CreateForexSymbol("GBPUSD");
        
        public static readonly Symbol DE10YBEUR = CreateCfdSymbol("DE10YBEUR", Market.FXCM);

        public static readonly Symbol SPY_P_192_Feb19_2016 = CreateOptionSymbol("SPY", OptionRight.Put, 192m, new DateTime(2016, 02, 19));

        private static Symbol CreateForexSymbol(string symbol)
        {
            return Symbol.Create(symbol, SecurityType.Forex, Market.FXCM);
        }

        private static Symbol CreateEquitySymbol(string symbol)
        {
            return Symbol.Create(symbol, SecurityType.Equity, Market.USA);
        }

        private static Symbol CreateCfdSymbol(string symbol, string market)
        {
            return Symbol.Create(symbol, SecurityType.Cfd, market);
        }

        private static Symbol CreateOptionSymbol(string symbol, OptionRight right, decimal strike, DateTime expiry)
        {
            return Symbol.CreateOption(symbol, Market.USA, OptionStyle.American, right, strike, expiry);
        }
    }
}
