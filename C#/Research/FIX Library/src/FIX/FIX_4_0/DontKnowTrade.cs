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

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// The Don’t Know Trade (DK) message is used to notify a trading partner 
	/// that an electronically received execution has been rejected.  This message 
	/// can be thought of as an execution reject message.
	/// 
	/// This message has special utility when dealing with one-way execution 
	/// reporting, if the initial Order Acknowledgment message 
	/// (LastShares=0 and OrdStatus=New) does not match an existing order this 
	/// message can be used to notify the broker of a potential problem order.
	/// </summary>
	public class DontKnowTrade : Message
	{
		public const int TAG_OrderID = 37;
		public const int TAG_ExecID = 17;
		public const int TAG_DKReason = 127;
		public const int TAG_Symbol = 55;
		public const int TAG_Side = 54;
		public const int TAG_OrderQty = 38;
		public const int TAG_LastShares = 32;
		public const int TAG_LastPx = 31;
		public const int TAG_Text = 58;

		private string _sOrderID;
		private string _sExecID;
		private char _cDKReason;
		private string _sSymbol;
		private char _cSide;
		private int _iOrderQty;
		private int _iLastShares;
		private double _dLastPx;
		private string _sText;

		internal DontKnowTrade()
			: base()
		{
			_sMsgType = Values.MsgType.DontKnowTrade;
		}

		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string ExecID
		{
			get { return _sExecID; }
			set { _sExecID = value; }
		}
		public char DKReason
		{
			get { return _cDKReason; }
			set { _cDKReason = value; }
		}
		public string Symbol
		{
			get { return _sSymbol; }
			set { _sSymbol = value; }
		}
		public char Side
		{
			get { return _cSide; }
			set { _cSide = value; }
		}
		public int OrderQty
		{
			get { return _iOrderQty; }
			set { _iOrderQty = value; }
		}
		public int LastShares
		{
			get { return _iLastShares; }
			set { _iLastShares = value; }
		}
		public double LastPx
		{
			get { return _dLastPx; }
			set { _dLastPx = value; }
		}
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_OrderID)
					return _sOrderID;
				else if (iTag == TAG_ExecID)
					return _sExecID;
				else if (iTag == TAG_DKReason)
					return _cDKReason;
				else if (iTag == TAG_Symbol)
					return _sSymbol;
				else if (iTag == TAG_Side)
					return _cSide;
				else if (iTag == TAG_OrderQty)
					return _iOrderQty;
				else if (iTag == TAG_LastShares)
					return _iLastShares;
				else if (iTag == TAG_LastPx)
					return _dLastPx;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_OrderID)
					_sOrderID = (string)value;
				else if (iTag == TAG_ExecID)
					_sExecID = (string)value;
				else if (iTag == TAG_DKReason)
					_cDKReason = (char)value;
				else if (iTag == TAG_Symbol)
					_sSymbol = (string)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
				else if (iTag == TAG_OrderQty)
					_iOrderQty = (int)value;
				else if (iTag == TAG_LastShares)
					_iLastShares = (int)value;
				else if (iTag == TAG_LastPx)
					_dLastPx = (double)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
