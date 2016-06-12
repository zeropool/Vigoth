using System;
using cAlgo.API;
using cAlgo.API.Indicators;


namespace cAlgo.Indicators
{
    [Indicator(ScalePrecision = 5, AccessRights = AccessRights.None)]
    public class ZeroLagMacd : Indicator
    {
        private MovingAverage _maLong;
        private MovingAverage _maShort;
        private MovingAverage _maSignal;
        private MovingAverage _maLong2;
        private MovingAverage _maShort2;

        [Parameter("Source")]
        public DataSeries Source { get; set; }

        [Parameter("Long Cycle", DefaultValue = 26)]
        public int LongCycle { get; set; }

        [Parameter("Short Cycle", DefaultValue = 12)]
        public int ShortCycle { get; set; }

        [Parameter("Signal Periods", DefaultValue = 9)]
        public int SignalPeriods { get; set; }

        [Parameter("Moving Average Type", DefaultValue = MovingAverageType.Triangular)]
        public MovingAverageType MovingAverageType { get; set; }

        [Output("Histogram", Color = Colors.Turquoise, PlotType = PlotType.Histogram)]
        public IndicatorDataSeries Histogram { get; set; }

        [Output("MACD", Color = Colors.Blue)]
        public IndicatorDataSeries MACD { get; set; }

        [Output("Signal", Color = Colors.Red, LineStyle = LineStyle.Lines)]
        public IndicatorDataSeries Signal { get; set; }

        private IndicatorDataSeries _zeroLagMaShort;
        private IndicatorDataSeries _zeroLagMaLong;

        protected override void Initialize()
        {
            _zeroLagMaShort = CreateDataSeries();
            _zeroLagMaLong = CreateDataSeries();

            _maLong = Indicators.MovingAverage(Source, LongCycle, MovingAverageType);
            _maLong2 = Indicators.MovingAverage(_maLong.Result, LongCycle, MovingAverageType);

            _maShort = Indicators.MovingAverage(Source, ShortCycle, MovingAverageType);
            _maShort2 = Indicators.MovingAverage(_maShort.Result, ShortCycle, MovingAverageType);

            _maSignal = Indicators.MovingAverage(MACD, SignalPeriods, MovingAverageType);
        }

        public override void Calculate(int index)
        {
            _zeroLagMaShort[index] = _maShort.Result[index] * 2 - _maShort2.Result[index];
            _zeroLagMaLong[index] = _maLong.Result[index] * 2 - _maLong2.Result[index];

            MACD[index] = _zeroLagMaShort[index] - _zeroLagMaLong[index];

            Signal[index] = _maSignal.Result[index];
            Histogram[index] = MACD[index] - Signal[index];
        }
    }
}
