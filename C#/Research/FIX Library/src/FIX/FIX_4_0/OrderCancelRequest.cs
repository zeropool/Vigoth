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
	/// The order cancel request message is used to request the cancellation 
	/// of all or part of the remaining quantity of an existing order.  The 
	/// CxlType field is used to distinguish if all or part of the outstanding 
	/// quantity is to be canceled. 
	/// 
	/// Although the Order Cancel Request message can be used to partially 
	/// cancel (reduce) an order it is recommended that the Cancel/Replace Request 
	/// message be used for that purpose.
	/// 
	/// The request will only be accepted if the order can successfully be 
	/// pulled back from the exchange floor without executing.
	/// 
	/// Note that a cancel request is assigned an order id and is treated as 
	/// a separate entity.  If rejected, the order id of the cancel request 
	/// will be sent in the Cancel Reject message.  The OrderID assigned to the 
	/// cancel request must be unique amongst the OrderID’s assigned to regular 
	/// orders and replacement orders.
	/// </summary>
	public class OrderCancelRequest : Message
	{
		public const int TAG_OrigClOrdID = 41;
		public const int TAG_OrderID = 37;
		public const int TAG_ClOrdID = 11;
		public const int TAG_ListID = 66;
		public const int TAG_CxlType = 125;
		public const int TAG_ClientID = 109;
		public const int TAG_ExecBroker = 76;
		public const int TAG_Symbol = 55;
		public const int TAG_SymbolSfx = 65;
		public const int TAG_SecurityID = 48;
		public const int TAG_IDSource = 22;
		public const int TAG_Issuer = 106;
		public const int TAG_SecurityDesc = 107;
		public const int TAG_Side = 54;
		public const int TAG_OrderQty = 38;
		public const int TAG_Text = 58;

		private string _sOrigClOrdID;
		private string _sOrderID;
		private string _sClOrdID;
		private string _sListID;
		private char _cCxlType;
		private string _sClientID;
		private string _sExecBroker;
		private string _sSymbol;
		private string _sSymbolSfx;
		private string _sSecurityID;
		private string _sIDSource;
		private string _sIssuer;
		private string _sSecurityDesc;
		private char _cSide;
		private int _iOrderQty;
		private string _sText;

		public string OrigClOrdID
		{
			get { return _sOrigClOrdID; }
			set { _sOrigClOrdID = value; }
		}
		public string OrderID
		{
			get { return _sOrderID; }
			set { _sOrderID = value; }
		}
		public string ClOrdID
		{
			get { return _sClOrdID; }
			set { _sClOrdID = value; }
		}
		public string ListID
		{
			get { return _sListID; }
			set { _sListID = value; }
		}
		public char CxlType
		{
			get { return _cCxlType; }
			set { _cCxlType = value; }
		}
		public string ClientID
		{
			get { return _sClientID; }
			set { _sClientID = value; }
		}
		public string ExecBroker
		{
			get { return _sExecBroker; }
			set { _sExecBroker = value; }
		}
		public string Symbol
		{
			get { return _sSymbol; }
			set { _sSymbol = value; }
		}
		public string SymbolSfx
		{
			get { return _sSymbolSfx; }
			set { _sSymbolSfx = value; }
		}
		public string SecurityID
		{
			get { return _sSecurityID; }
			set { _sSecurityID = value; }
		}
		public string IDSource
		{
			get { return _sIDSource; }
			set { _sIDSource = value; }
		}
		public string Issuer
		{
			get { return _sIssuer; }
			set { _sIssuer = value; }
		}
		public string SecurityDesc
		{
			get { return _sSecurityDesc; }
			set { _sSecurityDesc = value; }
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
		public string Text
		{
			get { return _sText; }
			set { _sText = value; }
		}

		internal OrderCancelRequest()
			: base()
		{
			_sMsgType = Values.MsgType.OrderCancelRequest;
		}

		public override object this[int iTag]
		{
			get
			{
				if (iTag == TAG_OrigClOrdID)
					return _sOrigClOrdID;
				else if (iTag == TAG_OrderID)
					return _sOrderID;
				else if (iTag == TAG_ClOrdID)
					return _sClOrdID;
				else if (iTag == TAG_ListID)
					return _sListID;
				else if (iTag == TAG_CxlType)
					return _cCxlType;
				else if (iTag == TAG_ClientID)
					return _sClientID;
				else if (iTag == TAG_ExecBroker)
					return _sExecBroker;
				else if (iTag == TAG_Symbol)
					return _sSymbol;
				else if (iTag == TAG_SymbolSfx)
					return _sSymbolSfx;
				else if (iTag == TAG_SecurityID)
					return _sSecurityID;
				else if (iTag == TAG_IDSource)
					return _sIDSource;
				else if (iTag == TAG_Issuer)
					return _sIssuer;
				else if (iTag == TAG_SecurityDesc)
					return _sSecurityDesc;
				else if (iTag == TAG_Side)
					return _cSide;
				else if (iTag == TAG_OrderQty)
					return _iOrderQty;
				else if (iTag == TAG_Text)
					return _sText;
				else
					return base[iTag];
			}
			set
			{
				if (iTag == TAG_OrigClOrdID)
					_sOrigClOrdID = (string)value;
				else if (iTag == TAG_OrderID)
					_sOrderID = (string)value;
				else if (iTag == TAG_ClOrdID)
					_sClOrdID = (string)value;
				else if (iTag == TAG_ListID)
					_sListID = (string)value;
				else if (iTag == TAG_CxlType)
					_cCxlType = (char)value;
				else if (iTag == TAG_ClientID)
					_sClientID = (string)value;
				else if (iTag == TAG_ExecBroker)
					_sExecBroker = (string)value;
				else if (iTag == TAG_Symbol)
					_sSymbol = (string)value;
				else if (iTag == TAG_SymbolSfx)
					_sSymbolSfx = (string)value;
				else if (iTag == TAG_SecurityID)
					_sSecurityID = (string)value;
				else if (iTag == TAG_IDSource)
					_sIDSource = (string)value;
				else if (iTag == TAG_Issuer)
					_sIssuer = (string)value;
				else if (iTag == TAG_SecurityDesc)
					_sSecurityDesc = (string)value;
				else if (iTag == TAG_Side)
					_cSide = (char)value;
				else if (iTag == TAG_OrderQty)
					_iOrderQty = (int)value;
				else if (iTag == TAG_Text)
					_sText = (string)value;
				else
					base[iTag] = value;
			}
		}
	}
}
