using System;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Data.UniverseSelection
{
    public class UniverseSettings
    {
        public Resolution Resolution;
        public decimal Leverage;
        public bool FillForward;
        public bool ExtendedMarketHours;
        public TimeSpan MinimumTimeInUniverse;
        public UniverseSettings(Resolution resolution, decimal leverage, bool fillForward, bool extendedMarketHours, TimeSpan minimumTimeInUniverse)
        {
            Resolution = resolution;
            Leverage = leverage;
            FillForward = fillForward;
            ExtendedMarketHours = extendedMarketHours;
            MinimumTimeInUniverse = minimumTimeInUniverse;
        }
    }
}