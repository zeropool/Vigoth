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

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_2.Values
{
	/// <summary>
	/// Summary description for MsgType.
	/// </summary>
	public class MsgType : FIX.Values.MsgType
	{
		public const string IndicationOfInterest = "6";
		public const string Advertisement = "7";
		public const string ExecutionReport = "8";
		public const string OrderCancelReject = "9";
		public const string News = "B";
		public const string Email = "C";
		public const string NewOrderSingle = "D";
		public const string NewOrderList = "E";
		public const string OrderCancelRequest = "F";
		public const string OrderCancelReplaceRequest = "G";
		public const string OrderStatusRequest = "H";
		public const string Allocation = "J";
		public const string ListCancelRequest = "K";
		public const string ListExecute = "L";
		public const string ListStatusRequest = "M";
		public const string ListStatus = "N";
		public const string AllocationACK = "P";
		public const string DontKnowTrade = "Q";
		public const string QuoteRequest = "R";
		public const string Quote = "S";
		public const string BusinessMessageReject = "j";
	}
}
