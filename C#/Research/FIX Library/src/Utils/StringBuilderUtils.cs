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
using System.Text;

namespace FIX4NET.Utils
{
	/// <summary>
	/// Summary description for StringBuilderUtils.
	/// </summary>
	public class StringBuilderUtils
	{

		public static int Find(StringBuilder sb, string sFind, int iStart) 
		{

			if(sb == null)
				return -1;

			if(sFind == null || sFind.Length == 0)
				return -1;

			if(iStart < 0 && iStart > sb.Length)
				return -1;

			int iFind = -1;
			bool bFound = false;
			int i = iStart;
			int iLenFind = sFind.Length - 1;
			int iLenString = sb.Length - 1;
			int j, iPos;

			while (!bFound && i <= iLenString)
			{
				if (sb[i] == sFind[0]) 
				{
					if (0 == iLenFind) 
					{
						bFound = true;
						iFind = i;
					}
					else
					{
						j = i + 1;
						iPos = 1;

						while (iPos <= iLenFind && j <= iLenString) 
						{
							if (sb[j] == sFind[iPos]) 
							{
								if (iPos == iLenFind) 
								{
									bFound = true;
									iFind = i;
									iPos = iLenFind + 1;
								} 
								else 
								{
									iPos += 1;
								}
							}
							else 
							{
								iPos = iLenFind + 1;
							}

							j += 1;
						}
					}
				}

				i += 1;
			}

			return iFind;
		}

	}
}
