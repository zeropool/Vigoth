#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using FIXForge.NET.FIX;
using System.Runtime.InteropServices;

namespace Benchmark
{
    namespace Latency
    {
        /// <summary>
        /// Contains methods to work with high-resolution 
        /// performance counter. This class cannot be inherited.
        /// </summary>
        internal static class TimestampHelper
        {
            private static bool _perfCounterSupported = false;
            private static long _ticksPerSecond = 0;

            static TimestampHelper()
            {
                // Query the high-resolution timer only if it is supported.
                // A returned frequency of 1000 typically indicates that it is not
                // supported and is emulated by the OS using the same value that is
                // returned by Environment.TickCount.
                // A return value of 0 indicates that the performance counter is
                // not supported.
                int returnVal = QueryPerformanceFrequency(ref _ticksPerSecond);

                if (returnVal != 0 && _ticksPerSecond != 1000)
                {
                    // The performance counter is supported.
                    _perfCounterSupported = true;
                }
                else
                {
                    // The performance counter is not supported. Use
                    // Environment.TickCount instead.
                    _ticksPerSecond = 1000;
                }
            }

            /// <summary>
            /// Gets the number of ticks provided by 
            /// the high-resolution performance counter.
            /// </summary>
            public static long Ticks
            {
                get
                {
                    long ticks = 0;
                    if (_perfCounterSupported)
                    {
                        QueryPerformanceCounter(ref ticks);
                        return ticks;
                    }
                    else
                    {
                        return (long)Environment.TickCount;
                    }
                }
            }

            public static void GetTicks(ref long ticks)
            {
                if (_perfCounterSupported)
                {
                    QueryPerformanceCounter(ref ticks);
                }
                else
                {
                    ticks = (long)Environment.TickCount;
                }
            }

            /// <summary>
            /// Represents the number of ticks in 1 second.
            /// </summary>
            public static long TicksPerSecond
            {
                get { return _ticksPerSecond; }
            }

            /// <summary>
            /// Represents the number of ticks in 1 millisecond.
            /// </summary>
            public static long TicksPerMillisecond
            {
                get { return _ticksPerSecond / 1000; }
            }

            /// <summary>
            /// Represents the number of ticks in 1 microsecond.
            /// </summary>
            public static long TicksPerMicrosecond
            {
                get { return _ticksPerSecond / 1000000; }
            }

            /// <summary>
            /// Returns the number of whole seconds 
            /// represented by the specified number of ticks.
            /// </summary>
            /// <param name="ticks">A number of ticks.</param>
            /// <returns>A number of whole seconds.</returns>
            public static long TicksToSeconds(long ticks)
            {
                return ticks / _ticksPerSecond;
            }

            /// <summary>
            /// Returns the number of whole milliseconds 
            /// represented by the specified number of ticks.
            /// </summary>
            /// <param name="ticks">A number of ticks.</param>
            /// <returns>A number of whole milliseconds.</returns>
            public static long TicksToMilliseconds(long ticks)
            {
                return (ticks * 1000) / _ticksPerSecond;
            }

            /// <summary>
            /// Returns the number of whole microseconds 
            /// represented by the specified number of ticks.
            /// </summary>
            /// <param name="ticks">A number of ticks.</param>
            /// <returns>A number of whole microseconds.</returns>
            public static long TicksToMicroseconds(long ticks)
            {
                return (ticks * 1000000) / _ticksPerSecond;
            }

            [DllImport("kernel32.dll")]
            private static extern int QueryPerformanceCounter(ref long count);
            [DllImport("kernel32.dll")]
            private static extern int QueryPerformanceFrequency(ref long frequency);
        }

    }
}