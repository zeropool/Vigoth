

using VigiothCapital.QuantTrader.Data.UniverseSelection;

namespace VigiothCapital.QuantTrader.Algorithm
{
    /// <summary>
    /// Provides helpers for defining universes in algorithms
    /// </summary>
    public class UniverseDefinitions
    {
        /// <summary>
        /// Specifies that universe selection should not make changes on this iteration
        /// </summary>
        public Universe.UnchangedUniverse Unchanged
        {
            get { return Universe.Unchanged; }
        }

        /// <summary>
        /// Gets a helper that provides methods for creating universes based on daily dollar volumes
        /// </summary>
        public DollarVolumeUniverseDefinitions DollarVolume
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniverseDefinitions"/> class
        /// </summary>
        /// <param name="algorithm">The algorithm instance, used for obtaining the default <see cref="UniverseSettings"/></param>
        public UniverseDefinitions(QCAlgorithm algorithm)
        {
            DollarVolume = new DollarVolumeUniverseDefinitions(algorithm);
        }
    }
}
