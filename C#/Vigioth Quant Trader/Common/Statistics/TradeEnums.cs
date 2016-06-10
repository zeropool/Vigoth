
namespace VigiothCapital.QuantTrader.Statistics
{
    /// <summary>
    /// Direction of a trade
    /// </summary>
    public enum TradeDirection
    {
        /// <summary>
        /// Long direction
        /// </summary>
        Long,
        /// <summary>
        /// Short direction
        /// </summary>
        Short
    }
    /// <summary>
    /// The method used to group order fills into trades
    /// </summary>
    public enum FillGroupingMethod
    {
        /// <summary>
        /// A Trade is defined by a fill that establishes or increases a position and an offsetting fill that reduces the position size.
        /// </summary>
        FillToFill,
        /// <summary>
        /// A Trade is defined by a sequence of fills, from a flat position to a non-zero position which may increase or decrease in quantity, and back to a flat position.
        /// </summary>
        FlatToFlat,
        /// <summary>
        /// A Trade is defined by a sequence of fills, from a flat position to a non-zero position and an offsetting fill that reduces the position size.
        /// </summary>
        FlatToReduced,
    }
    /// <summary>
    /// The method used to match offsetting order fills
    /// </summary>
    public enum FillMatchingMethod
    {
        /// <summary>
        /// First In First Out fill matching method
        /// </summary>
        FIFO,
        /// <summary>
        /// Last In Last Out fill matching method
        /// </summary>
        LIFO
    }
}
