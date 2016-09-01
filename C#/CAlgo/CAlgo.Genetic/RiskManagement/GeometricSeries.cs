using System;

namespace VigiothCapital.CAlgo.Genetic.RiskManagement
{
    
    public class GeometricSeries
    {
        /// <summary>
        /// Returns the sum of a geometric series of length n, who's first element is 1.
        /// For decay factor d, S = 1 + d + d^2 + ... + d^(n-1)
        /// </summary>
        /// <param name="decayFactor">Decay factor Typically between -1 adn +1.</param>
        /// <param name="length">Number of elements in the geometric series, must be positive.</param>
        /// <returns></returns>
        public static double SumOfGeometricSeries(double decayFactor, int length)
        {
            if (length < 1) return double.NaN;
            if (decayFactor == 1.0) return length;
            return (1.0 - Math.Pow(decayFactor, length)) / (1.0 - decayFactor);
        }

        /// <summary>
        /// Returns the inverse of the sum of a geometric series of length n, who's first element is 1.
        /// For decay factor d, S = 1 + d + d^2 + ... + d^(n-1). Return 1/S.
        /// </summary>
        /// <param name="decayFactor">Decay factor Typically between -1 adn +1.</param>
        /// <param name="length">Number of elements in the geometric series, must be positive.</param>
        /// <returns></returns>
        public static double InverseSumOfGeometricSeries(double decayFactor, int length)
        {
            if (length < 1) return double.NaN;
            if (decayFactor == 1.0) return 1.0 / length;
            return (1.0 - decayFactor) / (1.0 - Math.Pow(decayFactor, length));
        }

        /// <summary>
        /// Returns the sum of an infinite geometric series who's first element is 1.
        /// For decay factor d, S = 1 + d + d^2 + ...
        /// </summary>
        /// <param name="decayFactor">Decay factor. Typically between -1 adn +1.</param>
        /// <returns></returns>
        public static double SumOfInfiniteGeometricSeries(double decayFactor)
        {
            if (decayFactor >= 1) return double.PositiveInfinity;
            if (decayFactor <= 1) return double.NaN;
            return 1.0  / (1.0 - decayFactor);
        }

        /// <summary>
        /// Returns the half-life of a geometric series of length n, who's first element is 1.
        /// For decay factor d,  1 + d + d^2 + ... + d^(h-1) = 0.5 * [1 + d + d^2 + ... + d^(n-1)]
        /// </summary>
        /// <param name="decayFactor">Decay factor Typically between -1 adn +1.</param>
        /// <param name="length">Number of elements in the geometric series, must be positive.</param>
        /// <returns></returns>
        public static double HalfLifeOfGeometricSeries(double decayFactor, int length)
        {
            if (length < 1) return double.NaN;
            return Math.Log(0.5 + 0.5 * Math.Pow(decayFactor, length)) / Math.Log(decayFactor);
        }
    }
}
