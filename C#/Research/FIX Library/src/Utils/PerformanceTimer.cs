//    Copyright 2006, 2007, 2008 East Tech Incorporated
//
//    This file is part of FIX4NET.
//
//    FIX4NET is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    FIX4NET is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with FIX4NET.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace FIX4NET.Utils
{
	/// <summary>
	/// Summary description for PerformanceTimer.
	/// </summary>
	public abstract class PerformanceTimer
	{
		[DllImport("Kernel32.dll")]	private static extern void QueryPerformanceCounter(ref long ticks);
		[DllImport("kernel32.dll")] private	static extern short QueryPerformanceFrequency(ref long frequency);

		private static long _lFrequency = 0;
		private static Hashtable _hTimersStart = new Hashtable();
		private static object _lockStart = new object();
		private static Hashtable _hTimersCount = new Hashtable();
		private static object _lockCount = new object();

		static PerformanceTimer()
		{
			QueryPerformanceFrequency(ref _lFrequency);
		}

		public static void ResetAll() 
		{
			lock(_lockStart) 
			{
				_hTimersStart.Clear();
			}
			lock(_lockCount) 
			{
				_hTimersCount.Clear();
			}
		}

		public static void Start(string sName) 
		{
			long lStart = 0;
			QueryPerformanceCounter(ref lStart);
			lock(_lockStart) 
			{
				_hTimersStart[sName] = lStart;
			}
		}

		public static double Difference(string sName) 
		{
			long lStop = 0;
			QueryPerformanceCounter(ref lStop);
			long lStart = 0;
			lock(_lockStart) 
			{
				if (_hTimersStart.Contains(sName))
					lStart = (long)_hTimersStart[sName];
			}
			return (double)(lStop - lStart) / _lFrequency;
		}

		public static double Stop(string sName) 
		{
			double dDiffCurrent = Difference(sName);
			double dDiffSaved = 0;
			lock(_lockCount) 
			{
				if (_hTimersCount.Contains(sName))
					dDiffSaved = (double)_hTimersCount[sName];
				_hTimersCount[sName] = dDiffCurrent + dDiffSaved;
			}
			return dDiffCurrent;
		}

		public static double Count(string sName) 
		{
			lock(_lockCount) 
			{
				return (double)_hTimersCount[sName];
			}
		}

		public static Hashtable Counts() 
		{
			lock(_lockCount) 
			{
				return (Hashtable)_hTimersCount.Clone();
			}
		}
	}
}
