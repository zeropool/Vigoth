
using System;
using cAlgo.API;
using cAlgo.API.Internals;
using cAlgo.API.Indicators;
using cAlgo.Indicators;

namespace cAlgo.Indicators
{

    [Indicator(IsOverlay = true, TimeZone = TimeZones.UTC, AutoRescale = false, AccessRights = AccessRights.None)]
    public class PriceChannels : Indicator
    {
        [Parameter(DefaultValue = 20)]
        public int Periods { get; set; }

        [Output("Upper", Color = Colors.Pink)]
        public IndicatorDataSeries Upper { get; set; }

        [Output("Lower", Color = Colors.Pink)]
        public IndicatorDataSeries Lower { get; set; }

        [Output("Center", Color = Colors.Pink)]
        public IndicatorDataSeries Center { get; set; }

        public override void Calculate(int index)
        {
            double upper = double.MinValue;
            double lower = double.MaxValue;

            for (int i = index - Periods; i <= index - 1; i++)
            {
                upper = Math.Max(MarketSeries.High[i], upper);
                lower = Math.Min(MarketSeries.Low[i], lower);
            }

            Upper[index] = upper;
            Lower[index] = lower;
            Center[index] = (upper + lower) / 2;
        }
    }
}
