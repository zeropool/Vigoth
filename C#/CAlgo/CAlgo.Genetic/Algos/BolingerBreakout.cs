using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class SampleBreakoutcBot : Robot
    {
        [Parameter("Source")]
        public DataSeries Source { get; set; }

        [Parameter("Band Height (pips)", DefaultValue = 40.0, MinValue = 0)]
        public double BandHeightPips { get; set; }

        [Parameter("Stop Loss (pips)", DefaultValue = 20, MinValue = 1)]
        public int StopLossInPips { get; set; }

        [Parameter("Take Profit (pips)", DefaultValue = 40, MinValue = 1)]
        public int TakeProfitInPips { get; set; }

        [Parameter("Quantity (Lots)", DefaultValue = 1, MinValue = 0.01, Step = 0.01)]
        public double Quantity { get; set; }

        [Parameter("Bollinger Bands Deviations", DefaultValue = 2)]
        public double Deviations { get; set; }

        [Parameter("Bollinger Bands Periods", DefaultValue = 20)]
        public int Periods { get; set; }

        [Parameter("Bollinger Bands MA Type")]
        public MovingAverageType MAType { get; set; }

        [Parameter("Consolidation Periods", DefaultValue = 2)]
        public int ConsolidationPeriods { get; set; }

        BollingerBands bollingerBands;
        string label = "Sample Breakout cBot";
        int consolidation;

        protected override void OnStart()
        {
            bollingerBands = Indicators.BollingerBands(Source, Periods, Deviations, MAType);
        }

        protected override void OnBar()
        {

            var top = bollingerBands.Top.Last(1);
            var bottom = bollingerBands.Bottom.Last(1);

            if (top - bottom <= BandHeightPips * Symbol.PipSize)
            {
                consolidation = consolidation + 1;
            }
            else
            {
                consolidation = 0;
            }

            if (consolidation >= ConsolidationPeriods)
            {
                var volumeInUnits = Symbol.QuantityToVolume(Quantity);
                if (Symbol.Ask > top)
                {
                    ExecuteMarketOrder(TradeType.Buy, Symbol, volumeInUnits, label, StopLossInPips, TakeProfitInPips);

                    consolidation = 0;
                }
                else if (Symbol.Bid < bottom)
                {
                    ExecuteMarketOrder(TradeType.Sell, Symbol, volumeInUnits, label, StopLossInPips, TakeProfitInPips);

                    consolidation = 0;
                }
            }
        }
    }
}
