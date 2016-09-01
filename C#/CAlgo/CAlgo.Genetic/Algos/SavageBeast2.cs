using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class SavageBeast2 : Robot
    {
        [Parameter(DefaultValue = 0.0)]
        public double Pairs { get; set; }

        protected override void OnStart()
        {

        }

        protected override void OnTick()
        {
            for (var x = 0; x < 20; x++)
            {


            }
        }

        protected override void OnStop()
        {

        }

        public static Double Correlation(Double[] Xs, Double[] Ys)
        {
            Double sumX = 0;
            Double sumX2 = 0;
            Double sumY = 0;
            Double sumY2 = 0;
            Double sumXY = 0;

            int n = Xs.Length < Ys.Length ? Xs.Length : Ys.Length;

            for (int i = 0; i < n; ++i)
            {
                Double x = Xs[i];
                Double y = Ys[i];

                sumX += x;
                sumX2 += x * x;
                sumY += y;
                sumY2 += y * y;
                sumXY += x * y;
            }

            Double stdX = Math.Sqrt(sumX2 / n - sumX * sumX / n / n);
            Double stdY = Math.Sqrt(sumY2 / n - sumY * sumY / n / n);
            Double covariance = (sumXY / n - sumX * sumY / n / n);

            return covariance / stdX / stdY;
        }

    }
}
