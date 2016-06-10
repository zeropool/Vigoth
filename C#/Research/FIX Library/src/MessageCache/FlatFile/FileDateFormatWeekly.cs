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

namespace FIX4NET.MessageCache.FlatFile
{
    /// <summary>
    /// Generates a weekly date trailer put at the end of a file.  This will roll the cache file weekly so MsgSeqNum In/Out chages weekly.
    /// </summary>
    public class FileDateFormatWeekly : IFileDateFormat
    {
        /// <summary>
        /// Create the trailer string put at the end of the file name to roll files.
        /// </summary>
        /// <param name="date">The date to be used when generating the file name trailer.</param>
        /// <returns>The value that gets appended to the file name to roll files.</returns>
        public string ToString(DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            int daysMinus = 0;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    daysMinus = 0;
                    break;
                case DayOfWeek.Monday:
                    daysMinus = 1;
                    break;
                case DayOfWeek.Tuesday:
                    daysMinus = 2;
                    break;
                case DayOfWeek.Wednesday:
                    daysMinus = 3;
                    break;
                case DayOfWeek.Thursday:
                    daysMinus = 4;
                    break;
                case DayOfWeek.Friday:
                    daysMinus = 5;
                    break;
                case DayOfWeek.Saturday:
                    daysMinus = 6;
                    break;

            }
            DateTime dtStart = date.AddDays(-daysMinus);
            DateTime dtEnd = dtStart.AddDays(6);

            return string.Format("{0:yyyyMMdd}_{1:yyyyMMdd}", dtStart, dtEnd);
        }
    }
}
