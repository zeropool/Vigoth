using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class Momentum : Robot
    {

        ///////////////////////////////
        // DATA PARAMETERS
        ///////////////////////////////

        [Parameter("----DATA----")]
        public string l2 { get; set; }
        [Parameter("Source")]
        public DataSeries Source { get; set; }

        ///////////////////////////////
        // MACD
        ///////////////////////////////        
        [Parameter("----0 lag MACD-----")]
        public string l1 { get; set; }
        [Parameter("Long Cycle", DefaultValue = 26)]
        public int LongCycle { get; set; }
        [Parameter("Short Cycle", DefaultValue = 12)]
        public int ShortCycle { get; set; }
        [Parameter("Signal Periods", DefaultValue = 9)]
        public int SignalPeriods { get; set; }
        [Parameter("Moving Average Type", DefaultValue = MovingAverageType.Triangular)]
        public MovingAverageType macdMovingAverageType { get; set; }

        ///////////////////////////////
        // PRICE CHANEL
        /////////////////////////////// 
        [Parameter(" --- Price Action --- ")]
        public string l3 { get; set; }
        [Parameter("Price Channel Periods", DefaultValue = 12)]
        public int ChannelPeriods { get; set; }

        [Parameter("Use Force Index", DefaultValue = true)]
        public bool UseFI { get; set; }
        [Parameter("Force Index Periods", DefaultValue = 12)]
        public int ForceIndexPeriod { get; set; }
        [Parameter("Force Index Periods Change Ratio %", DefaultValue = 10)]
        public double ForceIndexChangeRatio { get; set; }

        [Parameter("Measure Ticks", DefaultValue = false)]
        public bool MeasureTicks { get; set; }
        [Parameter("Tick Interval", DefaultValue = 13)]
        public int TickInterval { get; set; }

        [Parameter("Use William Accumulatted Distribution", DefaultValue = true)]
        public bool UseWAD { get; set; }
        [Parameter("William Accumulated Distribution Change Ratio %", DefaultValue = 13)]
        public double WADChangeRatio { get; set; }

        [Parameter("Use Fast Slow Moving Average", DefaultValue = true)]
        public bool UseMASignal { get; set; }
        [Parameter("Fast Moving Average Periods", DefaultValue = 2)]
        public int FastMA { get; set; }
        [Parameter("Slow Moving Average Periods", DefaultValue = 13)]
        public int SlowMA { get; set; }
        [Parameter("Moving Average Type", DefaultValue = MovingAverageType.Triangular)]
        public MovingAverageType FastSlowMAType { get; set; }

        /////////////////////////////////
        // PORTFOLIO SETTINGS
        //////////////////////////////////
        [Parameter(" --- Risk Ratio Settings % --- ")]
        public string l9 { get; set; }
        [Parameter("Portfolio risk per trade %", DefaultValue = 0)]
        public double PorfolioRisk { get; set; }
        [Parameter("Consolidation Periods", DefaultValue = 2)]
        public int ConsolidationPeriods { get; set; }

        PriceChannels prc;
        ZeroLagMacd zlMcd;
        ForceIndex frceIndex;
        MovingAverage fastMA;
        MovingAverage slowMA;
        WilliamsAccumulationDistribution wad;
        PriceROC proc;

        protected override void OnStart()
        {
            prc = Indicators.GetIndicator<PriceChannels>(ChannelPeriods);
            zlMcd = Indicators.GetIndicator<ZeroLagMacd>(Source, LongCycle, ShortCycle, SignalPeriods, macdMovingAverageType);
            fastMA = Indicators.MovingAverage(Source, FastMA, FastSlowMAType);
            slowMA = Indicators.MovingAverage(Source, SlowMA, FastSlowMAType);
            wad = Indicators.WilliamsAccumulationDistribution(MarketSeries);
            frceIndex = Indicators.GetIndicator<ForceIndex>(ForceIndexPeriod, 0, 0);
            proc = Indicators.PriceROC(Source, 13);
        }


        private int _tickCreator;

        protected override void OnTick()
        {
            if (_tickCreator < TickInterval)
            {
                _tickCreator += 1;
                return;
            }
            else
            {
                _tickCreator = 0;
            }

            if (MeasureTicks)
            {
                bool canTrade = false;

                if (UseFI)
                {
                    canTrade = CalculateForceIndexChange();
                }

                if (canTrade)
                {

                }
            }
        }

        double firstHigh = 0;
        double firstLow = 0;
        bool isUpTrend = false;
        bool isDownTrend = false;

        private bool CalculateForceIndexChange()
        {

            double prev = frceIndex.ExtForceBuffer_AlgoOutputDataSeries.Last(1);
            double now = frceIndex.ExtForceBuffer_AlgoOutputDataSeries.Last(0);
            double realNow = (prev * 1000);

            if (!isUpTrend && !isDownTrend)
            {
                isUpTrend = (realNow > 0);
                isDownTrend = (realNow < 0);
            }


            if (realNow > 0 && isDownTrend)
            {
                isUpTrend = true;
                isDownTrend = false;
                firstHigh = realNow;
                firstLow = 0;
            }

            if (realNow < 0 && isUpTrend)
            {

                isUpTrend = false;
                isDownTrend = true;
                firstLow = realNow;
                firstHigh = 0;
            }

            if (isUpTrend)
            {
                double changeRatio = CalculateChange(firstHigh, realNow);
                Print(string.Format("Force Is Up: {0:p}", changeRatio));
            }

            if (isDownTrend)
            {
                double changeRatio = CalculateChange(firstLow, realNow);
                Print(string.Format("Force Is Down: {0:p}", changeRatio));
            }

            return false;
        }

        private bool CalculatePriceRateOfChange()
        {
            double prev = proc.Result.Last(1);
            double now = proc.Result.Last(0);
            double realNow = (prev * 1000);

            if (!isUpTrend && !isDownTrend)
            {
                isUpTrend = (realNow > 0);
                isDownTrend = (realNow < 0);
            }


            if (realNow > 0 && isDownTrend)
            {
                isUpTrend = true;
                isDownTrend = false;
                firstHigh = realNow;
                firstLow = 0;
            }

            if (realNow < 0 && isUpTrend)
            {

                isUpTrend = false;
                isDownTrend = true;
                firstLow = realNow;
                firstHigh = 0;
            }

            if (isUpTrend)
            {
                double changeRatio = CalculateChange(firstHigh, realNow);
                Print(string.Format("PROC Is Up: {0:p}", changeRatio));
            }

            if (isDownTrend)
            {
                double changeRatio = CalculateChange(firstLow, realNow);
                Print(string.Format("PROC Is Down: {0:p}", changeRatio));
            }

            return false;
        }

        private bool CalculatePriceChange()
        {
            double prev = MarketSeries.Close.Last(1);
            double now = MarketSeries.Close.Last(0);
            double realNow = (prev * 1000);

            if (!isUpTrend && !isDownTrend)
            {
                isUpTrend = (realNow > 0);
                isDownTrend = (realNow < 0);
            }


            if (realNow > 0 && isDownTrend)
            {
                isUpTrend = true;
                isDownTrend = false;
                firstHigh = realNow;
                firstLow = 0;
            }

            if (realNow < 0 && isUpTrend)
            {

                isUpTrend = false;
                isDownTrend = true;
                firstLow = realNow;
                firstHigh = 0;
            }

            if (isUpTrend)
            {
                double changeRatio = CalculateChange(firstHigh, realNow);
                Print(string.Format("Force Is Up: {0:p}", changeRatio));
            }

            if (isDownTrend)
            {
                double changeRatio = CalculateChange(firstLow, realNow);
                Print(string.Format("Force Is Down: {0:p}", changeRatio));
            }

            return false;


        private double CalculateChange(double previous, double current)
        {
            var change = current - previous;
            return (double)change / previous;
        }

        private string DoubleToPercentageString(double d)
        {
            return string.Format("%{0:p}", d);
        }

        protected override void OnBar()
        {
            CalculateForceIndexChange();
            //  CalculatePriceRateOfChange();
            //  CalculatePriceChange();
        }
         
        protected override void OnStop()
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////
        /// ORDER MANAGEMENT 
        ////////////////////////////////////////////////////////////////////////////////////
        private void Close(TradeType tradeType)
        {
            foreach (var position in Positions.FindAll("SampleRSI", Symbol, tradeType))
                ClosePosition(position);
        }

        private void Open(TradeType tradeType)
        {
        }



    }
}

