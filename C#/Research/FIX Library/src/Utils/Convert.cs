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

namespace FIX4NET.Utils
{
    public class Convert
    {
        /// <summary>
        /// Parses a int32 from a string.
        /// </summary>
        /// <param name="s">string that gets parsed</param>
        /// <returns>int value of string</returns>
        public static int ParseInt(string s)
        {
            return ParseInt(s, 0, s.Length);
        }

        /// <summary>
        /// Parses a int32 from a string.
        /// </summary>
        public static int ParseInt(string s, int iIndex, int iLen)
        {
            int iStop = iIndex + iLen;
            int iValue = 0;

            for (int i = iIndex; i < iStop; i++)
                iValue = (iValue * 10) + (s[i] - 48);

            return iValue;
        }

        /// <summary>
        /// Parses a int16 from a string.
        /// </summary>
        public static byte ParseByte(string s, int iIndex, int iLen)
        {
            int iStop = iIndex + iLen;
            byte iValue = 0;

            for (int i = iIndex; i < iStop; i++)
                iValue = (byte)((iValue * 10) + (s[i] - 48));

            return iValue;
        }
    }
}
