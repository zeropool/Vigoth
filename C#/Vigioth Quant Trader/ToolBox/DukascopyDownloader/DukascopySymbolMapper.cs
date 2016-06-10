

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Brokerages;

namespace VigiothCapital.QuantTrader.ToolBox.DukascopyDownloader
{
    public class DukascopySymbolMapper : ISymbolMapper
    {
        private class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
        {
            public void Add(T1 item1, T2 item2, T3 item3)
            {
                Add(new Tuple<T1, T2, T3>(item1, item2, item3));
            }
        }

        private static readonly TupleList<string, string, int> DukascopySymbolMappings = new TupleList<string, string, int>
        {
            { "AUDCAD", "AUDCAD", 100000 },
            { "AUDCHF", "AUDCHF", 100000 },
            { "AUDJPY", "AUDJPY", 1000 },
            { "AUDNZD", "AUDNZD", 100000 },
            { "AUDSGD", "AUDSGD", 100000 },
            { "AUDUSD", "AUDUSD", 100000 },
            { "AUSIDXAUD", "AU200AUD", 1000 },
            { "BRAIDXBRL", "BRIDXBRL", 1000 },
            { "BRENTCMDUSD", "BCOUSD", 1000 },
            { "CADCHF", "CADCHF", 100000 },
            { "CADHKD", "CADHKD", 100000 },
            { "CADJPY", "CADJPY", 1000 },
            { "CHEIDXCHF", "CH20CHF", 1000 },
            { "CHFJPY", "CHFJPY", 1000 },
            { "CHFPLN", "CHFPLN", 100000 },
            { "CHFSGD", "CHFSGD", 100000 },
            { "COPPERCMDUSD", "XCUUSD", 1000 },
            { "DEUIDXEUR", "DE30EUR", 1000 },
            { "ESPIDXEUR", "ES35EUR", 1000 },
            { "EURAUD", "EURAUD", 100000 },
            { "EURCAD", "EURCAD", 100000 },
            { "EURCHF", "EURCHF", 100000 },
            { "EURDKK", "EURDKK", 100000 },
            { "EURGBP", "EURGBP", 100000 },
            { "EURHKD", "EURHKD", 100000 },
            { "EURHUF", "EURHUF", 1000 },
            { "EURJPY", "EURJPY", 1000 },
            { "EURMXN", "EURMXN", 100000 },
            { "EURNOK", "EURNOK", 100000 },
            { "EURNZD", "EURNZD", 100000 },
            { "EURPLN", "EURPLN", 100000 },
            { "EURRUB", "EURRUB", 100000 },
            { "EURSEK", "EURSEK", 100000 },
            { "EURSGD", "EURSGD", 100000 },
            { "EURTRY", "EURTRY", 100000 },
            { "EURUSD", "EURUSD", 100000 },
            { "EURZAR", "EURZAR", 100000 },
            { "EUSIDXEUR", "EU50EUR", 1000 },
            { "FRAIDXEUR", "FR40EUR", 1000 },
            { "GBPAUD", "GBPAUD", 100000 },
            { "GBPCAD", "GBPCAD", 100000 },
            { "GBPCHF", "GBPCHF", 100000 },
            { "GBPJPY", "GBPJPY", 1000 },
            { "GBPNZD", "GBPNZD", 100000 },
            { "GBPUSD", "GBPUSD", 100000 },
            { "GBRIDXGBP", "UK100GBP", 1000 },
            { "HKDJPY", "HKDJPY", 100000 },
            { "HKGIDXHKD", "HK33HKD", 1000 },
            { "ITAIDXEUR", "IT40EUR", 1000 },
            { "JPNIDXJPY", "JP225JPY", 1000 },
            { "LIGHTCMDUSD", "WTICOUSD", 1000 },
            { "MXNJPY", "MXNJPY", 1000 },
            { "NGASCMDUSD", "NATGASUSD", 1000 },
            { "NLDIDXEUR", "NL25EUR", 1000 },
            { "NZDCAD", "NZDCAD", 100000 },
            { "NZDCHF", "NZDCHF", 100000 },
            { "NZDJPY", "NZDJPY", 1000 },
            { "NZDSGD", "NZDSGD", 100000 },
            { "NZDUSD", "NZDUSD", 100000 },
            { "PDCMDUSD", "XPDUSD", 1000 },
            { "PTCMDUSD", "XPTUSD", 1000 },
            { "SGDJPY", "SGDJPY", 1000 },
            { "USA30IDXUSD", "US30USD", 1000 },
            { "USA500IDXUSD", "SPX500USD", 1000 },
            { "USATECHIDXUSD", "NAS100USD", 1000 },
            { "USDBRL", "USDBRL", 100000 },
            { "USDCAD", "USDCAD", 100000 },
            { "USDCHF", "USDCHF", 100000 },
            { "USDCNH", "USDCNY", 100000 },
            { "USDDKK", "USDDKK", 100000 },
            { "USDHKD", "USDHKD", 100000 },
            { "USDHUF", "USDHUF", 1000 },
            { "USDJPY", "USDJPY", 1000 },
            { "USDMXN", "USDMXN", 100000 },
            { "USDNOK", "USDNOK", 100000 },
            { "USDPLN", "USDPLN", 100000 },
            { "USDRUB", "USDRUB", 100000 },
            { "USDSEK", "USDSEK", 100000 },
            { "USDSGD", "USDSGD", 100000 },
            { "USDTRY", "USDTRY", 100000 },
            { "USDZAR", "USDZAR", 100000 },
            { "XAGUSD", "XAGUSD", 1000 },
            { "XAUUSD", "XAUUSD", 1000 },
            { "ZARJPY", "ZARJPY", 100000 }
        };

        private static readonly Dictionary<string, string> MapDukascopyToLean = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> MapLeanToDukascopy = new Dictionary<string, string>();
        private static readonly Dictionary<string, int> PointValues = new Dictionary<string, int>();

        private static readonly HashSet<string> KnownCurrencies = new HashSet<string>
        {
            "AUD", "BRL", "CAD", "CHF", "CNH", "DKK", "EUR", "GBP", "HKD", "HUF", "JPY", "MXN", "NOK", "NZD", "PLN", "RUB", "SEK", "SGD", "TRY", "USD", "ZAR"
        };

        static DukascopySymbolMapper()
        {
            foreach (var mapping in DukascopySymbolMappings)
            {
                MapDukascopyToLean[mapping.Item1] = mapping.Item2;
                MapLeanToDukascopy[mapping.Item2] = mapping.Item1;
                PointValues[mapping.Item2] = mapping.Item3;
            }
        }

        public string GetBrokerageSymbol(Symbol symbol)
        {
            if (symbol == null || symbol == Symbol.Empty || string.IsNullOrWhiteSpace(symbol.Value))
                throw new ArgumentException("Invalid symbol: " + (symbol == null ? "null" : symbol.ToString()));

            if (symbol.ID.SecurityType != SecurityType.Forex && symbol.ID.SecurityType != SecurityType.Cfd)
                throw new ArgumentException("Invalid security type: " + symbol.ID.SecurityType);

            var brokerageSymbol = ConvertLeanSymbolToDukascopySymbol(symbol.Value);

            if (!IsKnownBrokerageSymbol(brokerageSymbol))
                throw new ArgumentException("Unknown symbol: " + symbol.Value);

            return brokerageSymbol;
        }

        public Symbol GetLeanSymbol(string brokerageSymbol, SecurityType securityType, string market)
        {
            if (string.IsNullOrWhiteSpace(brokerageSymbol))
                throw new ArgumentException("Invalid Dukascopy symbol: " + brokerageSymbol);

            if (!IsKnownBrokerageSymbol(brokerageSymbol))
                throw new ArgumentException("Unknown Dukascopy symbol: " + brokerageSymbol);

            if (securityType != SecurityType.Forex && securityType != SecurityType.Cfd)
                throw new ArgumentException("Invalid security type: " + securityType);

            if (market != Market.Dukascopy)
                throw new ArgumentException("Invalid market: " + market);

            return Symbol.Create(ConvertDukascopySymbolToLeanSymbol(brokerageSymbol), GetBrokerageSecurityType(brokerageSymbol), Market.Dukascopy);
        }

        public SecurityType GetBrokerageSecurityType(string brokerageSymbol)
        {
            return (brokerageSymbol.Length == 6 && KnownCurrencies.Contains(brokerageSymbol.Substring(0, 3)) && KnownCurrencies.Contains(brokerageSymbol.Substring(3, 3)))
                ? SecurityType.Forex
                : SecurityType.Cfd;
        }

        public SecurityType GetLeanSecurityType(string leanSymbol)
        {
            string dukascopySymbol;
            if (!MapLeanToDukascopy.TryGetValue(leanSymbol, out dukascopySymbol))
                throw new ArgumentException("Unknown Lean symbol: " + leanSymbol);

            return GetBrokerageSecurityType(dukascopySymbol);
        }

        public bool IsKnownBrokerageSymbol(string brokerageSymbol)
        {
            return brokerageSymbol != null && MapDukascopyToLean.ContainsKey(brokerageSymbol);
        }

        public bool IsKnownLeanSymbol(Symbol symbol)
        {
            if (symbol == null || string.IsNullOrWhiteSpace(symbol.Value))
                return false;

            var dukascopySymbol = ConvertLeanSymbolToDukascopySymbol(symbol.Value);

            return MapDukascopyToLean.ContainsKey(dukascopySymbol) && GetBrokerageSecurityType(dukascopySymbol) == symbol.ID.SecurityType;
        }

        public int GetPointValue(Symbol symbol)
        {
            return PointValues[symbol.Value];
        }

        private static string ConvertDukascopySymbolToLeanSymbol(string dukascopySymbol)
        {
            string leanSymbol;
            return MapDukascopyToLean.TryGetValue(dukascopySymbol, out leanSymbol) ? leanSymbol : string.Empty;
        }

        private static string ConvertLeanSymbolToDukascopySymbol(string leanSymbol)
        {
            string dukascopySymbol;
            return MapLeanToDukascopy.TryGetValue(leanSymbol, out dukascopySymbol) ? dukascopySymbol : string.Empty;
        }

    }
}
