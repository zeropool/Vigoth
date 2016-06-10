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

using System.Runtime.InteropServices;

namespace Helpers
{
    /// <summary>
    /// PrecisionTimer class. Used to measure small time periods to estimate operation
    /// performance.
    /// <example> This sample shows how to use PrecisionTimer class. 
    /// <code>
    /// 
    /// using System.Runtime.InteropServices;
    ///		// ...
    ///		PrecisionTimer t = new  PrecisionTimer();
    ///		t.Start();
    ///		// Do something here
    ///		t.Stop();
    ///		Console.WriteLine("Elapsed time: {0}", t.ElapsedTime);
    /// </code>
    /// </example>
    /// </summary>
    public class PrecisionTimer
    {
        #region Protected data members

        private long counter;
        private long frequency;

        #endregion

        #region Constructio and finalisation

        ///<summary>
        /// Creates and starts the timer.
        ///</summary> 
        public PrecisionTimer()
        {
			NativeMethods.QueryPerformanceFrequency(out frequency);
            Start();
        }

        #endregion

        #region Public methods

        ///<summary>
        /// Starts the timer.
        ///</summary> 
        public void Start()
        {
			NativeMethods.QueryPerformanceCounter(out counter);
        }

        /// <summary>
        /// Stops the timer and returns the elapsed time (in milliseconds).
        /// </summary>
        public double Stop()
        {
            long current = 0;
			NativeMethods.QueryPerformanceCounter(out current);
            counter = current - counter;

            return ElapsedTime;
        }

        #endregion

        #region Properties

        ///<summary>
        /// Gets the elapsed time (in milliseconds).
        ///</summary>
        public double ElapsedTime
        {
            get { return (double) counter/(double) frequency*1000; }
        }

        #endregion

        #region Imported functions

		static class NativeMethods
		{
			[DllImport("kernel32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

			[DllImport("kernel32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool QueryPerformanceFrequency(out long lpFrequency);
		}

        #endregion
    }
}