

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VigiothCapital.QuantTrader.Logging
{
    /// <summary>
    /// Provides methods for determining higher stack frames
    /// </summary>
    public static class WhoCalledMe
    {
        /// <summary>
        /// Gets the method name of the caller
        /// </summary>
        /// <param name="frame">The number of stack frames to retrace from the caller's position</param>
        /// <returns>The method name of the containing scope 'frame' stack frames above the caller</returns>
        [MethodImpl(MethodImplOptions.NoInlining)] // inlining messes this up pretty badly
        public static string GetMethodName(int frame = 1)
        {
            // we need to increment the frame to account for this method
            var methodBase = new StackFrame(frame + 1).GetMethod();
            var declaringType = methodBase.DeclaringType;
            return declaringType != null ? declaringType.Name + "." + methodBase.Name : methodBase.Name;
        }
    }
}
