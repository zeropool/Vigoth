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
using System.Text;

using FIX = FIX4NET.FIX;

namespace FIX4NET.FIX.FIX_4_0
{
	/// <summary>
	/// Summary description for MessageFactory.
	/// </summary>
	public class MessageFactoryFIX : FIX.MessageFactoryFIX
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public MessageFactoryFIX() : base("FIX.4.0") { }

		public override IMessage CreateInstance(string sMsgType)
		{
			if (string.Equals(sMsgType, Values.MsgType.Heartbeat))
				return new Heartbeat();
			else if (string.Equals(sMsgType, Values.MsgType.TestRequest))
				return new TestRequest();
			else if (string.Equals(sMsgType, Values.MsgType.ResendRequest))
				return new ResendRequest();
			else if (string.Equals(sMsgType, Values.MsgType.Reject))
				return new Reject();
			else if (string.Equals(sMsgType, Values.MsgType.SequenceReset))
				return new SequenceReset();
			else if (string.Equals(sMsgType, Values.MsgType.Logon))
				return new Logon();
			else if (string.Equals(sMsgType, Values.MsgType.Logout))
				return new Logout();

			else if (string.Equals(sMsgType, Values.MsgType.Advertisement))
				return new Advertisement();
			else if (string.Equals(sMsgType, Values.MsgType.IndicationOfInterest))
				return new IndicationOfInterest();
			else if (string.Equals(sMsgType, Values.MsgType.ExecutionReport))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReject))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.News))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Email))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderSingle))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderList))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReplaceRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderStatusRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Allocation))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListCancelRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListExecute))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListStatusRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListStatus))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.AllocationACK))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.DontKnowTrade))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.QuoteRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Quote))
				return null;

			else
				return null;
		}

		public override IMessageReject CreateInstanceReject(ParseFieldException exParse)
		{
			Reject reject = new Reject();
			reject.RefSeqNum = exParse.RefSeqNum;
			reject.Text = exParse.Text;
			return reject;
		}

		protected override ParseFieldException CreateInstanceParseFieldException(string sMessage, Exception exInner, IField field, string sMessageRaw)
		{
			ParseFieldException ex = new ParseFieldException(sMessage, exInner);
			ex.RefSeqNum = ParseMsgSeqNum(sMessageRaw);
			ex.Text = string.Format("PARSE ERROR ON TAG {0}", field.Tag);
			return ex;
		}

		protected override FIX.MessageFactoryFIX.MessageHelper CreateMessageHelper(IMessage message)
		{
			string sMsgType = message.MsgType;

			if (string.Equals(sMsgType, Values.MsgType.Heartbeat))
				return new MessageHelperHeartbeat(message);
			else if (string.Equals(sMsgType, Values.MsgType.TestRequest))
				return new MessageHelperTestRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.ResendRequest))
				return new MessageHelperResendRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.Reject))
				return new MessageHelperReject(message);
			else if (string.Equals(sMsgType, Values.MsgType.SequenceReset))
				return new MessageHelperSequenceReset(message);
			else if (string.Equals(sMsgType, Values.MsgType.Logon))
				return new MessageHelperLogon(message);
			else if (string.Equals(sMsgType, Values.MsgType.Logout))
				return new MessageHelperLogout(message);

			else if (string.Equals(sMsgType, Values.MsgType.Advertisement))
				return new MessageHelperAdvertisement(message);
			else if (string.Equals(sMsgType, Values.MsgType.IndicationOfInterest))
				return new MessageHelperIndicationOfInterest(message);
			else if (string.Equals(sMsgType, Values.MsgType.ExecutionReport))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReject))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.News))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Email))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderSingle))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderList))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReplaceRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.OrderStatusRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Allocation))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListCancelRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListExecute))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListStatusRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.ListStatus))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.AllocationACK))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.DontKnowTrade))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.QuoteRequest))
				return null;
			else if (string.Equals(sMsgType, Values.MsgType.Quote))
				return null;

			else
				return null;
		}

		protected new class MessageHelper : FIX.MessageFactoryFIX.MessageHelper
		{
			private Message _message;
			public MessageHelper(IMessage message)
				: base(message)
			{
				_message = (Message)message;
			}
			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
			}
			public override void ParseField(IField field)
			{
				base.ParseField(field);
			}
		}
		protected new class MessageHelperHeartbeat : MessageHelper
		{
			private static string TAG_PREFIX_TestReqID = Heartbeat.TAG_TestReqID.ToString() + TAG_DELIM;

			private Heartbeat _message;

			public MessageHelperHeartbeat(IMessage message)
				: base(message)
			{
				_message = (Heartbeat)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.TestReqID != null)
					sb.Append(TAG_PREFIX_TestReqID).Append(_message.TestReqID).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Heartbeat.TAG_TestReqID == field.Tag)
					_message.TestReqID = field.Value;
				else
					base.ParseField(field);
			}
		}
		protected new class MessageHelperTestRequest : MessageHelper
		{
			private static string TAG_PREFIX_TestReqID = TestRequest.TAG_TestReqID.ToString() + TAG_DELIM;

			private TestRequest _message;

			public MessageHelperTestRequest(IMessage message)
				: base(message)
			{
				_message = (TestRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.TestReqID != null)
					sb.Append(TAG_PREFIX_TestReqID).Append(_message.TestReqID).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (TestRequest.TAG_TestReqID == field.Tag)
					_message.TestReqID = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected new class MessageHelperResendRequest : MessageHelper
		{
			private static string TAG_PREFIX_BeginSeqNo = ResendRequest.TAG_BeginSeqNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EndSeqNo = ResendRequest.TAG_EndSeqNo.ToString() + TAG_DELIM;

			private ResendRequest _message;

			public MessageHelperResendRequest(IMessage message)
				: base(message)
			{
				_message = (ResendRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_BeginSeqNo).Append(_message.BeginSeqNo).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_EndSeqNo).Append(_message.EndSeqNo).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ResendRequest.TAG_BeginSeqNo == field.Tag)
					_message.BeginSeqNo = ParseInt(field.Value);
				else if (ResendRequest.TAG_EndSeqNo == field.Tag)
					_message.EndSeqNo = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected new class MessageHelperReject : MessageHelper
		{
			private static string TAG_PREFIX_RefSeqNum = Reject.TAG_RefSeqNum.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = Reject.TAG_Text.ToString() + TAG_DELIM;

			private Reject _message;

			public MessageHelperReject(IMessage message)
				: base(message)
			{
				_message = (Reject)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_RefSeqNum).Append(_message.RefSeqNum).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Reject.TAG_RefSeqNum == field.Tag)
					_message.RefSeqNum = ParseInt(field.Value);
				else if (Reject.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected new class MessageHelperSequenceReset : MessageHelper
		{
			private static string TAG_PREFIX_GapFillFlag = SequenceReset.TAG_GapFillFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NewSeqNo = SequenceReset.TAG_NewSeqNo.ToString() + TAG_DELIM;

			private SequenceReset _message;

			public MessageHelperSequenceReset(IMessage message)
				: base(message)
			{
				_message = (SequenceReset)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.GapFillFlag)
					sb.Append(TAG_PREFIX_GapFillFlag).Append(ToFIXBoolean(_message.GapFillFlag)).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_NewSeqNo).Append(_message.NewSeqNo).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (SequenceReset.TAG_GapFillFlag == field.Tag)
					_message.GapFillFlag = FromFIXBoolean(field.Value);
				else if (SequenceReset.TAG_NewSeqNo == field.Tag)
					_message.NewSeqNo = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected new class MessageHelperLogon : MessageHelper
		{
			private static string TAG_PREFIX_EncryptMethod = Logon.TAG_EncryptMethod.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HeartBtInt = Logon.TAG_HeartBtInt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RawDataLength = Logon.TAG_RawDataLength.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RawData = Logon.TAG_RawData.ToString() + TAG_DELIM;

			private Logon _message;

			public MessageHelperLogon(IMessage message)
				: base(message)
			{
				_message = (Logon)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_EncryptMethod).Append(_message.EncryptMethod).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_HeartBtInt).Append(_message.HeartBtInt).Append(FIELD_DELIM);
				if (_message.RawDataLength != 0)
					sb.Append(TAG_PREFIX_RawDataLength).Append(_message.RawDataLength).Append(FIELD_DELIM);
				if (_message.RawData != null)
					sb.Append(TAG_PREFIX_RawData).Append(_message.RawData).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Logon.TAG_EncryptMethod == field.Tag)
					_message.EncryptMethod = ParseInt(field.Value);
				else if (Logon.TAG_HeartBtInt == field.Tag)
					_message.HeartBtInt = ParseInt(field.Value);
				else if (Logon.TAG_RawDataLength == field.Tag)
					_message.RawDataLength = ParseInt(field.Value);
				else if (Logon.TAG_RawData == field.Tag)
					_message.RawData = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected new class MessageHelperLogout : MessageHelper
		{
			private static string TAG_PREFIX_Text = Logout.TAG_Text.ToString() + TAG_DELIM;

			private Logout _message;

			public MessageHelperLogout(IMessage message)
				: base(message)
			{
				_message = (Logout)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Logout.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperAdvertisement : MessageHelper
		{
			private static string TAG_PREFIX_AdvId = Advertisement.TAG_AdvId.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AdvTransType = Advertisement.TAG_AdvTransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AdvRefID = Advertisement.TAG_AdvRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = Advertisement.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = Advertisement.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = Advertisement.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = Advertisement.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = Advertisement.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = Advertisement.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AdvSide = Advertisement.TAG_AdvSide.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Shares = Advertisement.TAG_Shares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = Advertisement.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = Advertisement.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = Advertisement.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = Advertisement.TAG_Text.ToString() + TAG_DELIM;

			private Advertisement _message;

			public MessageHelperAdvertisement(IMessage message)
				: base(message)
			{
				_message = (Advertisement)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.AdvId != 0)
					sb.Append(TAG_PREFIX_AdvId).Append(_message.AdvId).Append(FIELD_DELIM);
				if (_message.AdvTransType != '\0')
					sb.Append(TAG_PREFIX_AdvTransType).Append(_message.AdvTransType).Append(FIELD_DELIM);
				if (_message.AdvRefID != 0)
					sb.Append(TAG_PREFIX_AdvRefID).Append(_message.AdvRefID).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.AdvSide != '\0')
					sb.Append(TAG_PREFIX_AdvSide).Append(_message.AdvSide).Append(FIELD_DELIM);
				if (_message.Shares != 0)
					sb.Append(TAG_PREFIX_Shares).Append(_message.Shares).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.Currency != null && _message.Currency.Length > 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.TransactTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Advertisement.TAG_AdvId == field.Tag)
					_message.AdvId = ParseInt(field.Value);
				else if (Advertisement.TAG_AdvTransType == field.Tag)
					_message.AdvTransType = field.Value[0];
				else if (Advertisement.TAG_AdvRefID == field.Tag)
					_message.AdvRefID = ParseInt(field.Value);
				else if (Advertisement.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (Advertisement.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (Advertisement.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (Advertisement.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (Advertisement.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (Advertisement.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (Advertisement.TAG_AdvSide == field.Tag)
					_message.AdvSide = field.Value[0];
				else if (Advertisement.TAG_Shares == field.Tag)
					_message.Shares = ParseInt(field.Value);
				else if (Advertisement.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (Advertisement.TAG_Currency == field.Tag)
					_message.Currency = field.Value;
				else if (Advertisement.TAG_TransactTime == field.Tag)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (Advertisement.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperIndicationOfInterest : MessageHelper
		{
			private static string TAG_PREFIX_IOIid = IndicationOfInterest.TAG_IOIid.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOITransType = IndicationOfInterest.TAG_IOITransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIRefID = IndicationOfInterest.TAG_IOIRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = IndicationOfInterest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = IndicationOfInterest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = IndicationOfInterest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = IndicationOfInterest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = IndicationOfInterest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = IndicationOfInterest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = IndicationOfInterest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIShares = IndicationOfInterest.TAG_IOIShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = IndicationOfInterest.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = IndicationOfInterest.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ValidUntilTime = IndicationOfInterest.TAG_ValidUntilTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIQltyInd = IndicationOfInterest.TAG_IOIQltyInd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIOthSvc = IndicationOfInterest.TAG_IOIOthSvc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOINaturalFlag = IndicationOfInterest.TAG_IOINaturalFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIQualifier = IndicationOfInterest.TAG_IOIQualifier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = IndicationOfInterest.TAG_Text.ToString() + TAG_DELIM;

			private IndicationOfInterest _message;

			public MessageHelperIndicationOfInterest(IMessage message)
				: base(message)
			{
				_message = (IndicationOfInterest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.IOIid != null && _message.IOIid.Length > 0)
					sb.Append(TAG_PREFIX_IOIid).Append(_message.IOIid).Append(FIELD_DELIM);
				if (_message.IOITransType != '\0')
					sb.Append(TAG_PREFIX_IOITransType).Append(_message.IOITransType).Append(FIELD_DELIM);
				if (_message.IOIRefID != null && _message.IOIRefID.Length > 0)
					sb.Append(TAG_PREFIX_IOIRefID).Append(_message.IOIRefID).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.IOIShares != null && _message.IOIShares.Length > 0)
					sb.Append(TAG_PREFIX_IOIShares).Append(_message.IOIShares).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.ValidUntilTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ValidUntilTime).Append(ToFIXUTCTimestamp(_message.ValidUntilTime)).Append(FIELD_DELIM);
				if (_message.IOIQltyInd != '\0')
					sb.Append(TAG_PREFIX_IOIQltyInd).Append(_message.IOIQltyInd).Append(FIELD_DELIM);
				if (_message.IOIOthSvc != '\0')
					sb.Append(TAG_PREFIX_IOIOthSvc).Append(_message.IOIOthSvc).Append(FIELD_DELIM);
				if (_message.IOINaturalFlag != false)
					sb.Append(TAG_PREFIX_IOINaturalFlag).Append(ToFIXBoolean(_message.IOINaturalFlag)).Append(FIELD_DELIM);
				if (_message.IOIQualifier != '\0')
					sb.Append(TAG_PREFIX_IOIQualifier).Append(_message.IOIQualifier).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (IndicationOfInterest.TAG_IOIid == field.Tag)
					_message.IOIid = field.Value;
				else if (IndicationOfInterest.TAG_IOITransType == field.Tag)
					_message.IOITransType = field.Value[0];
				else if (IndicationOfInterest.TAG_IOIRefID == field.Tag)
					_message.IOIRefID = field.Value;
				else if (IndicationOfInterest.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (IndicationOfInterest.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (IndicationOfInterest.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (IndicationOfInterest.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (IndicationOfInterest.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (IndicationOfInterest.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (IndicationOfInterest.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (IndicationOfInterest.TAG_IOIShares == field.Tag)
					_message.IOIShares = field.Value;
				else if (IndicationOfInterest.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (IndicationOfInterest.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (IndicationOfInterest.TAG_ValidUntilTime == field.Tag)
					_message.ValidUntilTime = FromFIXUTCTimestamp(field.Value);
				else if (IndicationOfInterest.TAG_IOIQltyInd == field.Tag)
					_message.IOIQltyInd = field.Value[0];
				else if (IndicationOfInterest.TAG_IOIOthSvc == field.Tag)
					_message.IOIOthSvc = field.Value[0];
				else if (IndicationOfInterest.TAG_IOINaturalFlag == field.Tag)
					_message.IOINaturalFlag = FromFIXBoolean(field.Value);
				else if (IndicationOfInterest.TAG_IOIQualifier == field.Tag)
					_message.IOIQualifier = field.Value[0];
				else if (IndicationOfInterest.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperNews : MessageHelper
		{
			private static string TAG_PREFIX_OrigTime = News.TAG_OrigTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Urgency = News.TAG_Urgency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RelatdSym = News.TAG_RelatdSym.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LinesOfText = News.TAG_LinesOfText.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = News.TAG_Text.ToString() + TAG_DELIM;

			private News _message;

			public MessageHelperNews(IMessage message)
				: base(message)
			{
				_message = (News)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrigTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_OrigTime).Append(ToFIXUTCTimestamp(_message.OrigTime)).Append(FIELD_DELIM);
				if (_message.Urgency != '\0')
					sb.Append(TAG_PREFIX_Urgency).Append(_message.Urgency).Append(FIELD_DELIM);
				if (_message.RelatdSym != null && _message.RelatdSym.Length > 0)
					sb.Append(TAG_PREFIX_RelatdSym).Append(_message.RelatdSym).Append(FIELD_DELIM);
				if (_message.LinesOfText != 0)
					sb.Append(TAG_PREFIX_LinesOfText).Append(_message.LinesOfText).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (News.TAG_OrigTime == field.Tag)
					_message.OrigTime = FromFIXUTCTimestamp(field.Value);
				else if (News.TAG_Urgency == field.Tag)
					_message.Urgency = field.Value[0];
				else if (News.TAG_RelatdSym == field.Tag)
					_message.RelatdSym = field.Value;
				else if (News.TAG_LinesOfText == field.Tag)
					_message.LinesOfText = ParseInt(field.Value);
				else if (News.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperEmail : MessageHelper
		{
			private static string TAG_PREFIX_EmailType = Email.TAG_EmailType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrigTime = Email.TAG_OrigTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RelatdSym = Email.TAG_RelatdSym.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderID = Email.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = Email.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LinesOfText = Email.TAG_LinesOfText.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = Email.TAG_Text.ToString() + TAG_DELIM;

			private Email _message;

			public MessageHelperEmail(IMessage message)
				: base(message)
			{
				_message = (Email)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.EmailType != '\0')
					sb.Append(TAG_PREFIX_EmailType).Append(_message.EmailType).Append(FIELD_DELIM);
				if (_message.OrigTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_OrigTime).Append(ToFIXUTCTimestamp(_message.OrigTime)).Append(FIELD_DELIM);
				if (_message.RelatdSym != null && _message.RelatdSym.Length > 0)
					sb.Append(TAG_PREFIX_RelatdSym).Append(_message.RelatdSym).Append(FIELD_DELIM);
				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.LinesOfText != 0)
					sb.Append(TAG_PREFIX_LinesOfText).Append(_message.LinesOfText).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Email.TAG_EmailType == field.Tag)
					_message.EmailType = field.Value[0];
				else if (Email.TAG_OrigTime == field.Tag)
					_message.OrigTime = FromFIXUTCTimestamp(field.Value);
				else if (Email.TAG_RelatdSym == field.Tag)
					_message.RelatdSym = field.Value;
				else if (Email.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (Email.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (Email.TAG_LinesOfText == field.Tag)
					_message.LinesOfText = ParseInt(field.Value);
				else if (Email.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperQuoteRequest : MessageHelper
		{
			private static string TAG_PREFIX_QuoteReqID = QuoteRequest.TAG_QuoteReqID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = QuoteRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = QuoteRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = QuoteRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = QuoteRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = QuoteRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = QuoteRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PrevClosePx = QuoteRequest.TAG_PrevClosePx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = QuoteRequest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = QuoteRequest.TAG_OrderQty.ToString() + TAG_DELIM;

			private QuoteRequest _message;

			public MessageHelperQuoteRequest(IMessage message)
				: base(message)
			{
				_message = (QuoteRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.QuoteReqID != null && _message.QuoteReqID.Length > 0)
					sb.Append(TAG_PREFIX_QuoteReqID).Append(_message.QuoteReqID).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.PrevClosePx != 0)
					sb.Append(TAG_PREFIX_PrevClosePx).Append(_message.PrevClosePx).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (QuoteRequest.TAG_QuoteReqID == field.Tag)
					_message.QuoteReqID = field.Value;
				else if (QuoteRequest.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (QuoteRequest.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (QuoteRequest.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (QuoteRequest.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (QuoteRequest.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (QuoteRequest.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (QuoteRequest.TAG_PrevClosePx == field.Tag)
					_message.PrevClosePx = double.Parse(field.Value);
				else if (QuoteRequest.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (QuoteRequest.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperQuote : MessageHelper
		{
			private static string TAG_PREFIX_QuoteReqID = Quote.TAG_QuoteReqID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_QuoteID = Quote.TAG_QuoteID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = Quote.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = Quote.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = Quote.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = Quote.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = Quote.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = Quote.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BidPx = Quote.TAG_BidPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OfferPx = Quote.TAG_OfferPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BidSize = Quote.TAG_BidSize.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OfferSize = Quote.TAG_OfferSize.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ValidUntilTime = Quote.TAG_ValidUntilTime.ToString() + TAG_DELIM;

			private Quote _message;

			public MessageHelperQuote(IMessage message)
				: base(message)
			{
				_message = (Quote)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.QuoteReqID != null && _message.QuoteReqID.Length > 0)
					sb.Append(TAG_PREFIX_QuoteReqID).Append(_message.QuoteReqID).Append(FIELD_DELIM);
				if (_message.QuoteID != null && _message.QuoteID.Length > 0)
					sb.Append(TAG_PREFIX_QuoteID).Append(_message.QuoteID).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.BidPx != 0)
					sb.Append(TAG_PREFIX_BidPx).Append(_message.BidPx).Append(FIELD_DELIM);
				if (_message.OfferPx != 0)
					sb.Append(TAG_PREFIX_OfferPx).Append(_message.OfferPx).Append(FIELD_DELIM);
				if (_message.BidSize != 0)
					sb.Append(TAG_PREFIX_BidSize).Append(_message.BidSize).Append(FIELD_DELIM);
				if (_message.OfferSize != 0)
					sb.Append(TAG_PREFIX_OfferSize).Append(_message.OfferSize).Append(FIELD_DELIM);
				if (_message.ValidUntilTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ValidUntilTime).Append(_message.ValidUntilTime).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Quote.TAG_QuoteReqID == field.Tag)
					_message.QuoteReqID = field.Value;
				else if (Quote.TAG_QuoteID == field.Tag)
					_message.QuoteID = field.Value;
				else if (Quote.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (Quote.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (Quote.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (Quote.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (Quote.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (Quote.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (Quote.TAG_BidPx == field.Tag)
					_message.BidPx = double.Parse(field.Value);
				else if (Quote.TAG_OfferPx == field.Tag)
					_message.OfferPx = double.Parse(field.Value);
				else if (Quote.TAG_BidSize == field.Tag)
					_message.BidSize = ParseInt(field.Value);
				else if (Quote.TAG_OfferSize == field.Tag)
					_message.OfferSize = ParseInt(field.Value);
				else if (Quote.TAG_ValidUntilTime == field.Tag)
					_message.ValidUntilTime = FromFIXUTCTimestamp(field.Value);
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperNewOrderSingle : MessageHelper
		{
			private static string TAG_PREFIX_ClOrdID = NewOrderSingle.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = NewOrderSingle.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = NewOrderSingle.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = NewOrderSingle.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = NewOrderSingle.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = NewOrderSingle.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HandlInst = NewOrderSingle.TAG_HandlInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = NewOrderSingle.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MinQty = NewOrderSingle.TAG_MinQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxFloor = NewOrderSingle.TAG_MaxFloor.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExDestination = NewOrderSingle.TAG_ExDestination.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ProcessCode = NewOrderSingle.TAG_ProcessCode.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = NewOrderSingle.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = NewOrderSingle.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = NewOrderSingle.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = NewOrderSingle.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = NewOrderSingle.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = NewOrderSingle.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PrevClosePx = NewOrderSingle.TAG_PrevClosePx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = NewOrderSingle.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LocateReqd = NewOrderSingle.TAG_LocateReqd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = NewOrderSingle.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = NewOrderSingle.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = NewOrderSingle.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = NewOrderSingle.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = NewOrderSingle.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIid = NewOrderSingle.TAG_IOIid.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_QuoteID = NewOrderSingle.TAG_QuoteID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = NewOrderSingle.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = NewOrderSingle.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = NewOrderSingle.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = NewOrderSingle.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = NewOrderSingle.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ForexReq = NewOrderSingle.TAG_ForexReq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = NewOrderSingle.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = NewOrderSingle.TAG_Text.ToString() + TAG_DELIM;

			private NewOrderSingle _message;

			public MessageHelperNewOrderSingle(IMessage message)
				: base(message)
			{
				_message = (NewOrderSingle)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.HandlInst != '\0')
					sb.Append(TAG_PREFIX_HandlInst).Append(_message.HandlInst).Append(FIELD_DELIM);
				if (_message.ExecInst != null && _message.ExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ExecInst).Append(_message.ExecInst).Append(FIELD_DELIM);
				if (_message.MinQty != 0)
					sb.Append(TAG_PREFIX_MinQty).Append(_message.MinQty).Append(FIELD_DELIM);
				if (_message.MaxFloor != 0)
					sb.Append(TAG_PREFIX_MaxFloor).Append(_message.MaxFloor).Append(FIELD_DELIM);
				if (_message.ExDestination != null && _message.ExDestination.Length > 0)
					sb.Append(TAG_PREFIX_ExDestination).Append(_message.ExDestination).Append(FIELD_DELIM);
				if (_message.ProcessCode != '\0')
					sb.Append(TAG_PREFIX_ProcessCode).Append(_message.ProcessCode).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.PrevClosePx != 0)
					sb.Append(TAG_PREFIX_PrevClosePx).Append(_message.PrevClosePx).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.LocateReqd != false)
					sb.Append(TAG_PREFIX_LocateReqd).Append(ToFIXBoolean(_message.LocateReqd)).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.IOIid != null && _message.IOIid.Length > 0)
					sb.Append(TAG_PREFIX_IOIid).Append(_message.IOIid).Append(FIELD_DELIM);
				if (_message.QuoteID != null && _message.QuoteID.Length > 0)
					sb.Append(TAG_PREFIX_QuoteID).Append(_message.QuoteID).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.ExpireTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.ForexReq != false)
					sb.Append(TAG_PREFIX_ForexReq).Append(ToFIXBoolean(_message.ForexReq)).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (NewOrderSingle.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (NewOrderSingle.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (NewOrderSingle.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (NewOrderSingle.TAG_Account == field.Tag)
					_message.Account = field.Value;
				else if (NewOrderSingle.TAG_SettlmntTyp == field.Tag)
					_message.SettlmntTyp = field.Value[0];
				else if (NewOrderSingle.TAG_FutSettDate == field.Tag)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (NewOrderSingle.TAG_HandlInst == field.Tag)
					_message.HandlInst = field.Value[0];
				else if (NewOrderSingle.TAG_ExecInst == field.Tag)
					_message.ExecInst = field.Value;
				else if (NewOrderSingle.TAG_MinQty == field.Tag)
					_message.MinQty = ParseInt(field.Value);
				else if (NewOrderSingle.TAG_MaxFloor == field.Tag)
					_message.MaxFloor = ParseInt(field.Value);
				else if (NewOrderSingle.TAG_ExDestination == field.Tag)
					_message.ExDestination = field.Value;
				else if (NewOrderSingle.TAG_ProcessCode == field.Tag)
					_message.ProcessCode = field.Value[0];
				else if (NewOrderSingle.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (NewOrderSingle.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (NewOrderSingle.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (NewOrderSingle.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (NewOrderSingle.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (NewOrderSingle.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (NewOrderSingle.TAG_PrevClosePx == field.Tag)
					_message.PrevClosePx = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (NewOrderSingle.TAG_LocateReqd == field.Tag)
					_message.LocateReqd = FromFIXBoolean(field.Value);
				else if (NewOrderSingle.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (NewOrderSingle.TAG_OrdType == field.Tag)
					_message.OrdType = field.Value[0];
				else if (NewOrderSingle.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_StopPx == field.Tag)
					_message.StopPx = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_IOIid == field.Tag)
					_message.IOIid = field.Value;
				else if (NewOrderSingle.TAG_QuoteID == field.Tag)
					_message.QuoteID = field.Value;
				else if (NewOrderSingle.TAG_TimeInForce == field.Tag)
					_message.TimeInForce = field.Value[0];
				else if (NewOrderSingle.TAG_ExpireTime == field.Tag)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (NewOrderSingle.TAG_Commission == field.Tag)
					_message.Commission = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_CommType == field.Tag)
					_message.CommType = field.Value[0];
				else if (NewOrderSingle.TAG_Rule80A == field.Tag)
					_message.Rule80A = field.Value[0];
				else if (NewOrderSingle.TAG_ForexReq == field.Tag)
					_message.ForexReq = FromFIXBoolean(field.Value);
				else if (NewOrderSingle.TAG_SettlCurrency == field.Tag)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (NewOrderSingle.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperExecutionReport : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = ExecutionReport.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = ExecutionReport.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = ExecutionReport.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = ExecutionReport.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = ExecutionReport.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecID = ExecutionReport.TAG_ExecID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecTransType = ExecutionReport.TAG_ExecTransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecRefID = ExecutionReport.TAG_ExecRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdStatus = ExecutionReport.TAG_OrdStatus.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdRejReason = ExecutionReport.TAG_OrdRejReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = ExecutionReport.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = ExecutionReport.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = ExecutionReport.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = ExecutionReport.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = ExecutionReport.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = ExecutionReport.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = ExecutionReport.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = ExecutionReport.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = ExecutionReport.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = ExecutionReport.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = ExecutionReport.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = ExecutionReport.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = ExecutionReport.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = ExecutionReport.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = ExecutionReport.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = ExecutionReport.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = ExecutionReport.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = ExecutionReport.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = ExecutionReport.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastShares = ExecutionReport.TAG_LastShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastPx = ExecutionReport.TAG_LastPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastMkt = ExecutionReport.TAG_LastMkt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastCapacity = ExecutionReport.TAG_LastCapacity.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CumQty = ExecutionReport.TAG_CumQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AvgPx = ExecutionReport.TAG_AvgPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TradeDate = ExecutionReport.TAG_TradeDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = ExecutionReport.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ReportToExch = ExecutionReport.TAG_ReportToExch.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = ExecutionReport.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = ExecutionReport.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoMiscFees = ExecutionReport.TAG_NoMiscFees.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeAmt = ExecutionReport.TAG_MiscFeeAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeCurr = ExecutionReport.TAG_MiscFeeCurr.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeType = ExecutionReport.TAG_MiscFeeType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NetMoney = ExecutionReport.TAG_NetMoney.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrAmt = ExecutionReport.TAG_SettlCurrAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = ExecutionReport.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = ExecutionReport.TAG_Text.ToString() + TAG_DELIM;

			private ExecutionReport _message;

			public MessageHelperExecutionReport(IMessage message)
				: base(message)
			{
				_message = (ExecutionReport)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.ExecID != null && _message.ExecID.Length > 0)
					sb.Append(TAG_PREFIX_ExecID).Append(_message.ExecID).Append(FIELD_DELIM);
				if (_message.ExecTransType != '\0')
					sb.Append(TAG_PREFIX_ExecTransType).Append(_message.ExecTransType).Append(FIELD_DELIM);
				if (_message.ExecRefID != null && _message.ExecRefID.Length > 0)
					sb.Append(TAG_PREFIX_ExecRefID).Append(_message.ExecRefID).Append(FIELD_DELIM);
				if (_message.OrdStatus != '\0')
					sb.Append(TAG_PREFIX_OrdStatus).Append(_message.OrdStatus).Append(FIELD_DELIM);
				if (_message.OrdRejReason != '\0')
					sb.Append(TAG_PREFIX_OrdRejReason).Append(_message.OrdRejReason).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.ExpireTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.ExecInst != null && _message.ExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ExecInst).Append(_message.ExecInst).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.LastShares != 0)
					sb.Append(TAG_PREFIX_LastShares).Append(_message.LastShares).Append(FIELD_DELIM);
				if (_message.LastPx != 0)
					sb.Append(TAG_PREFIX_LastPx).Append(_message.LastPx).Append(FIELD_DELIM);
				if (_message.LastMkt != null && _message.LastMkt.Length > 0)
					sb.Append(TAG_PREFIX_LastMkt).Append(_message.LastMkt).Append(FIELD_DELIM);
				if (_message.LastCapacity != '\0')
					sb.Append(TAG_PREFIX_LastCapacity).Append(_message.LastCapacity).Append(FIELD_DELIM);
				if (_message.CumQty != 0)
					sb.Append(TAG_PREFIX_CumQty).Append(_message.CumQty).Append(FIELD_DELIM);
				if (_message.AvgPx != 0)
					sb.Append(TAG_PREFIX_AvgPx).Append(_message.AvgPx).Append(FIELD_DELIM);
				if (_message.TradeDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TradeDate).Append(ToFIXLocalMktDate(_message.TradeDate)).Append(FIELD_DELIM);
				if (_message.TransactTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.ReportToExch != false)
					sb.Append(TAG_PREFIX_ReportToExch).Append(ToFIXBoolean(_message.ReportToExch)).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.NoMiscFees != 0)
					sb.Append(TAG_PREFIX_NoMiscFees).Append(_message.NoMiscFees).Append(FIELD_DELIM);
				if (_message.MiscFeeAmt != 0)
					sb.Append(TAG_PREFIX_MiscFeeAmt).Append(_message.MiscFeeAmt).Append(FIELD_DELIM);
				if (_message.MiscFeeCurr != 0)
					sb.Append(TAG_PREFIX_MiscFeeCurr).Append(_message.MiscFeeCurr).Append(FIELD_DELIM);
				if (_message.MiscFeeType != '\0')
					sb.Append(TAG_PREFIX_MiscFeeType).Append(_message.MiscFeeType).Append(FIELD_DELIM);
				if (_message.NetMoney != 0)
					sb.Append(TAG_PREFIX_NetMoney).Append(_message.NetMoney).Append(FIELD_DELIM);
				if (_message.SettlCurrAmt != 0)
					sb.Append(TAG_PREFIX_SettlCurrAmt).Append(_message.SettlCurrAmt).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ExecutionReport.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (ExecutionReport.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (ExecutionReport.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (ExecutionReport.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (ExecutionReport.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (ExecutionReport.TAG_ExecID == field.Tag)
					_message.ExecID = field.Value;
				else if (ExecutionReport.TAG_ExecTransType == field.Tag)
					_message.ExecTransType = field.Value[0];
				else if (ExecutionReport.TAG_ExecRefID == field.Tag)
					_message.ExecRefID = field.Value;
				else if (ExecutionReport.TAG_OrdStatus == field.Tag)
					_message.OrdStatus = field.Value[0];
				else if (ExecutionReport.TAG_OrdRejReason == field.Tag)
					_message.OrdRejReason = field.Value[0];
				else if (ExecutionReport.TAG_Account == field.Tag)
					_message.Account = field.Value;
				else if (ExecutionReport.TAG_SettlmntTyp == field.Tag)
					_message.SettlmntTyp = field.Value[0];
				else if (ExecutionReport.TAG_FutSettDate == field.Tag)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (ExecutionReport.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (ExecutionReport.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (ExecutionReport.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (ExecutionReport.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (ExecutionReport.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (ExecutionReport.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (ExecutionReport.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (ExecutionReport.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (ExecutionReport.TAG_OrdType == field.Tag)
					_message.OrdType = field.Value[0];
				else if (ExecutionReport.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (ExecutionReport.TAG_StopPx == field.Tag)
					_message.StopPx = double.Parse(field.Value);
				else if (ExecutionReport.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (ExecutionReport.TAG_TimeInForce == field.Tag)
					_message.TimeInForce = field.Value[0];
				else if (ExecutionReport.TAG_ExpireTime == field.Tag)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (ExecutionReport.TAG_ExecInst == field.Tag)
					_message.ExecInst = field.Value;
				else if (ExecutionReport.TAG_Rule80A == field.Tag)
					_message.Rule80A = field.Value[0];
				else if (ExecutionReport.TAG_LastShares == field.Tag)
					_message.LastShares = ParseInt(field.Value);
				else if (ExecutionReport.TAG_LastPx == field.Tag)
					_message.LastPx = double.Parse(field.Value);
				else if (ExecutionReport.TAG_LastMkt == field.Tag)
					_message.LastMkt = field.Value;
				else if (ExecutionReport.TAG_LastCapacity == field.Tag)
					_message.LastCapacity = field.Value[0];
				else if (ExecutionReport.TAG_CumQty == field.Tag)
					_message.CumQty = ParseInt(field.Value);
				else if (ExecutionReport.TAG_AvgPx == field.Tag)
					_message.AvgPx = double.Parse(field.Value);
				else if (ExecutionReport.TAG_TradeDate == field.Tag)
					_message.TradeDate = FromFIXLocalMktDate(field.Value);
				else if (ExecutionReport.TAG_TransactTime == field.Tag)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (ExecutionReport.TAG_ReportToExch == field.Tag)
					_message.ReportToExch = FromFIXBoolean(field.Value);
				else if (ExecutionReport.TAG_Commission == field.Tag)
					_message.Commission = double.Parse(field.Value);
				else if (ExecutionReport.TAG_CommType == field.Tag)
					_message.CommType = field.Value[0];
				else if (ExecutionReport.TAG_NoMiscFees == field.Tag)
					_message.NoMiscFees = ParseInt(field.Value);
				else if (ExecutionReport.TAG_MiscFeeAmt == field.Tag)
					_message.MiscFeeAmt = double.Parse(field.Value);
				else if (ExecutionReport.TAG_MiscFeeCurr == field.Tag)
					_message.MiscFeeCurr = double.Parse(field.Value);
				else if (ExecutionReport.TAG_MiscFeeType == field.Tag)
					_message.MiscFeeType = field.Value[0];
				else if (ExecutionReport.TAG_NetMoney == field.Tag)
					_message.NetMoney = double.Parse(field.Value);
				else if (ExecutionReport.TAG_SettlCurrAmt == field.Tag)
					_message.SettlCurrAmt = double.Parse(field.Value);
				else if (ExecutionReport.TAG_SettlCurrency == field.Tag)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (ExecutionReport.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperDontKnowTrade : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = DontKnowTrade.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecID = DontKnowTrade.TAG_ExecID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DKReason = DontKnowTrade.TAG_DKReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = DontKnowTrade.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = DontKnowTrade.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = DontKnowTrade.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastShares = DontKnowTrade.TAG_LastShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastPx = DontKnowTrade.TAG_LastPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = DontKnowTrade.TAG_Text.ToString() + TAG_DELIM;

			private DontKnowTrade _message;

			public MessageHelperDontKnowTrade(IMessage message)
				: base(message)
			{
				_message = (DontKnowTrade)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ExecID != null && _message.ExecID.Length > 0)
					sb.Append(TAG_PREFIX_ExecID).Append(_message.ExecID).Append(FIELD_DELIM);
				if (_message.DKReason != '\0')
					sb.Append(TAG_PREFIX_DKReason).Append(_message.DKReason).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.LastShares != 0)
					sb.Append(TAG_PREFIX_LastShares).Append(_message.LastShares).Append(FIELD_DELIM);
				if (_message.LastPx != 0)
					sb.Append(TAG_PREFIX_LastPx).Append(_message.LastPx).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (DontKnowTrade.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (DontKnowTrade.TAG_ExecID == field.Tag)
					_message.ExecID = field.Value;
				else if (DontKnowTrade.TAG_DKReason == field.Tag)
					_message.DKReason = field.Value[0];
				else if (DontKnowTrade.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (DontKnowTrade.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (DontKnowTrade.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (DontKnowTrade.TAG_LastShares == field.Tag)
					_message.LastShares = ParseInt(field.Value);
				else if (DontKnowTrade.TAG_LastPx == field.Tag)
					_message.LastPx = double.Parse(field.Value);
				else if (DontKnowTrade.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderCancelReplaceRequest : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = OrderCancelReplaceRequest.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderCancelReplaceRequest.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderCancelReplaceRequest.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrigClOrdID = OrderCancelReplaceRequest.TAG_OrigClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderCancelReplaceRequest.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = OrderCancelReplaceRequest.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = OrderCancelReplaceRequest.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = OrderCancelReplaceRequest.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = OrderCancelReplaceRequest.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HandlInst = OrderCancelReplaceRequest.TAG_HandlInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = OrderCancelReplaceRequest.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MinQty = OrderCancelReplaceRequest.TAG_MinQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxFloor = OrderCancelReplaceRequest.TAG_MaxFloor.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExDestination = OrderCancelReplaceRequest.TAG_ExDestination.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderCancelReplaceRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderCancelReplaceRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderCancelReplaceRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderCancelReplaceRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderCancelReplaceRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderCancelReplaceRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderCancelReplaceRequest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = OrderCancelReplaceRequest.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = OrderCancelReplaceRequest.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = OrderCancelReplaceRequest.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = OrderCancelReplaceRequest.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = OrderCancelReplaceRequest.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = OrderCancelReplaceRequest.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = OrderCancelReplaceRequest.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = OrderCancelReplaceRequest.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = OrderCancelReplaceRequest.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = OrderCancelReplaceRequest.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ForexReq = OrderCancelReplaceRequest.TAG_ForexReq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = OrderCancelReplaceRequest.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = OrderCancelReplaceRequest.TAG_Text.ToString() + TAG_DELIM;

			private OrderCancelReplaceRequest _message;

			public MessageHelperOrderCancelReplaceRequest(IMessage message)
				: base(message)
			{
				_message = (OrderCancelReplaceRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.OrigClOrdID != null && _message.OrigClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_OrigClOrdID).Append(_message.OrigClOrdID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.HandlInst != '\0')
					sb.Append(TAG_PREFIX_HandlInst).Append(_message.HandlInst).Append(FIELD_DELIM);
				if (_message.ExecInst != null && _message.ExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ExecInst).Append(_message.ExecInst).Append(FIELD_DELIM);
				if (_message.MinQty != 0)
					sb.Append(TAG_PREFIX_MinQty).Append(_message.MinQty).Append(FIELD_DELIM);
				if (_message.MaxFloor != 0)
					sb.Append(TAG_PREFIX_MaxFloor).Append(_message.MaxFloor).Append(FIELD_DELIM);
				if (_message.ExDestination != null && _message.ExDestination.Length > 0)
					sb.Append(TAG_PREFIX_ExDestination).Append(_message.ExDestination).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.ExpireTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.ForexReq != false)
					sb.Append(TAG_PREFIX_ForexReq).Append(ToFIXBoolean(_message.ForexReq)).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (OrderCancelReplaceRequest.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (OrderCancelReplaceRequest.TAG_OrigClOrdID == field.Tag)
					_message.OrigClOrdID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_Account == field.Tag)
					_message.Account = field.Value;
				else if (OrderCancelReplaceRequest.TAG_SettlmntTyp == field.Tag)
					_message.SettlmntTyp = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_FutSettDate == field.Tag)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (OrderCancelReplaceRequest.TAG_HandlInst == field.Tag)
					_message.HandlInst = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_ExecInst == field.Tag)
					_message.ExecInst = field.Value;
				else if (OrderCancelReplaceRequest.TAG_MinQty == field.Tag)
					_message.MinQty = ParseInt(field.Value);
				else if (OrderCancelReplaceRequest.TAG_MaxFloor == field.Tag)
					_message.MaxFloor = ParseInt(field.Value);
				else if (OrderCancelReplaceRequest.TAG_ExDestination == field.Tag)
					_message.ExDestination = field.Value;
				else if (OrderCancelReplaceRequest.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (OrderCancelReplaceRequest.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (OrderCancelReplaceRequest.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (OrderCancelReplaceRequest.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (OrderCancelReplaceRequest.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (OrderCancelReplaceRequest.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (OrderCancelReplaceRequest.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (OrderCancelReplaceRequest.TAG_OrdType == field.Tag)
					_message.OrdType = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (OrderCancelReplaceRequest.TAG_StopPx == field.Tag)
					_message.StopPx = double.Parse(field.Value);
				else if (OrderCancelReplaceRequest.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (OrderCancelReplaceRequest.TAG_TimeInForce == field.Tag)
					_message.TimeInForce = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_ExpireTime == field.Tag)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (OrderCancelReplaceRequest.TAG_Commission == field.Tag)
					_message.Commission = double.Parse(field.Value);
				else if (OrderCancelReplaceRequest.TAG_CommType == field.Tag)
					_message.CommType = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_Rule80A == field.Tag)
					_message.Rule80A = field.Value[0];
				else if (OrderCancelReplaceRequest.TAG_ForexReq == field.Tag)
					_message.ForexReq = FromFIXBoolean(field.Value);
				else if (OrderCancelReplaceRequest.TAG_SettlCurrency == field.Tag)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (OrderCancelReplaceRequest.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderCancelRequest : MessageHelper
		{
			private static string TAG_PREFIX_OrigClOrdID = OrderCancelRequest.TAG_OrigClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderID = OrderCancelRequest.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderCancelRequest.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = OrderCancelRequest.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CxlType = OrderCancelRequest.TAG_CxlType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderCancelRequest.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderCancelRequest.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderCancelRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderCancelRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderCancelRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderCancelRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderCancelRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderCancelRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderCancelRequest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = OrderCancelRequest.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = OrderCancelRequest.TAG_Text.ToString() + TAG_DELIM;

			private OrderCancelRequest _message;

			public MessageHelperOrderCancelRequest(IMessage message)
				: base(message)
			{
				_message = (OrderCancelRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrigClOrdID != null && _message.OrigClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_OrigClOrdID).Append(_message.OrigClOrdID).Append(FIELD_DELIM);
				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.CxlType != '\0')
					sb.Append(TAG_PREFIX_CxlType).Append(_message.CxlType).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (OrderCancelRequest.TAG_OrigClOrdID == field.Tag)
					_message.OrigClOrdID = field.Value;
				else if (OrderCancelRequest.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (OrderCancelRequest.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (OrderCancelRequest.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (OrderCancelRequest.TAG_CxlType == field.Tag)
					_message.CxlType = field.Value[0];
				else if (OrderCancelRequest.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (OrderCancelRequest.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (OrderCancelRequest.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (OrderCancelRequest.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (OrderCancelRequest.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (OrderCancelRequest.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (OrderCancelRequest.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (OrderCancelRequest.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (OrderCancelRequest.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (OrderCancelRequest.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (OrderCancelRequest.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderCancelReject : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = OrderCancelReject.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderCancelReject.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderCancelReject.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderCancelReject.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = OrderCancelReject.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CxlRejReason = OrderCancelReject.TAG_CxlRejReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = OrderCancelReject.TAG_Text.ToString() + TAG_DELIM;

			private OrderCancelReject _message;

			public MessageHelperOrderCancelReject(IMessage message)
				: base(message)
			{
				_message = (OrderCancelReject)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.CxlRejReason != 0)
					sb.Append(TAG_PREFIX_CxlRejReason).Append(_message.CxlRejReason).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (OrderCancelReject.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (OrderCancelReject.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (OrderCancelReject.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (OrderCancelReject.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (OrderCancelReject.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (OrderCancelReject.TAG_CxlRejReason == field.Tag)
					_message.CxlRejReason = ParseInt(field.Value);
				else if (OrderCancelReject.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderStatusRequest : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = OrderStatusRequest.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderStatusRequest.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderStatusRequest.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderStatusRequest.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderStatusRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderStatusRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderStatusRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderStatusRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderStatusRequest.TAG_Side.ToString() + TAG_DELIM;

			private OrderStatusRequest _message;

			public MessageHelperOrderStatusRequest(IMessage message)
				: base(message)
			{
				_message = (OrderStatusRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.OrderID != null && _message.OrderID.Length > 0)
					sb.Append(TAG_PREFIX_OrderID).Append(_message.OrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (OrderStatusRequest.TAG_OrderID == field.Tag)
					_message.OrderID = field.Value;
				else if (OrderStatusRequest.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (OrderStatusRequest.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (OrderStatusRequest.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (OrderStatusRequest.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (OrderStatusRequest.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (OrderStatusRequest.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (OrderStatusRequest.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (OrderStatusRequest.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperAllocation : MessageHelper
		{
			private static string TAG_PREFIX_AllocID = Allocation.TAG_AllocID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocTransType = Allocation.TAG_AllocTransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RefAllocID = Allocation.TAG_RefAllocID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoOrders = Allocation.TAG_NoOrders.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = Allocation.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderID = Allocation.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = Allocation.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = Allocation.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoExecs = Allocation.TAG_NoExecs.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecID = Allocation.TAG_ExecID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastShares = Allocation.TAG_LastShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastPx = Allocation.TAG_LastPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastMkt = Allocation.TAG_LastMkt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = Allocation.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = Allocation.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = Allocation.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = Allocation.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = Allocation.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = Allocation.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = Allocation.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Shares = Allocation.TAG_Shares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AvgPx = Allocation.TAG_AvgPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = Allocation.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AvgPrxPrecision = Allocation.TAG_AvgPrxPrecision.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TradeDate = Allocation.TAG_TradeDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = Allocation.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = Allocation.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = Allocation.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NetMoney = Allocation.TAG_NetMoney.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoMiscFees = Allocation.TAG_NoMiscFees.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeAmt = Allocation.TAG_MiscFeeAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeCurr = Allocation.TAG_MiscFeeCurr.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MiscFeeType = Allocation.TAG_MiscFeeType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrAmt = Allocation.TAG_SettlCurrAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = Allocation.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OpenClose = Allocation.TAG_OpenClose.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = Allocation.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoAllocs = Allocation.TAG_NoAllocs.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocAccount = Allocation.TAG_AllocAccount.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocShares = Allocation.TAG_AllocShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ProcessCode = Allocation.TAG_ProcessCode.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = Allocation.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = Allocation.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = Allocation.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = Allocation.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoDlvyInst = Allocation.TAG_NoDlvyInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BrokerOfCredit = Allocation.TAG_BrokerOfCredit.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DlvyInst = Allocation.TAG_DlvyInst.ToString() + TAG_DELIM;

			private Allocation _message;

			private AllocationOrder _allocationOrderLast;
			private AllocationExec _allocationExecLast;
			private AllocationMiscFee _allocationMiscFeeLast;
			private AllocationAlloc _allocationAllocLast;
			private AllocationAllocDlvyInst _allocationAllocDlvyInstLast;

			public MessageHelperAllocation(IMessage message)
				: base(message)
			{
				_message = (Allocation)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.AllocID != null && _message.AllocID.Length > 0)
					sb.Append(TAG_PREFIX_AllocID).Append(_message.AllocID).Append(FIELD_DELIM);
				if (_message.AllocTransType != '\0')
					sb.Append(TAG_PREFIX_AllocTransType).Append(_message.AllocTransType).Append(FIELD_DELIM);
				if (_message.RefAllocID != null && _message.RefAllocID.Length > 0)
					sb.Append(TAG_PREFIX_RefAllocID).Append(_message.RefAllocID).Append(FIELD_DELIM);

				_message.NoOrders = _message.Order.Count;
				if (_message.NoOrders != 0)
				{
					sb.Append(TAG_PREFIX_NoOrders).Append(_message.NoOrders).Append(FIELD_DELIM);
					AllocationOrder allocationOrder;
					for (int i = 0; i < _message.NoOrders; i++)
					{
						allocationOrder = _message.Order[i];
						if (allocationOrder.ClOrdID != null && allocationOrder.ClOrdID.Length > 0)
							sb.Append(TAG_PREFIX_ClOrdID).Append(allocationOrder.ClOrdID).Append(FIELD_DELIM);
						if (allocationOrder.OrderID != null && allocationOrder.OrderID.Length > 0)
							sb.Append(TAG_PREFIX_OrderID).Append(allocationOrder.OrderID).Append(FIELD_DELIM);
						if (allocationOrder.ListID != null && allocationOrder.ListID.Length > 0)
							sb.Append(TAG_PREFIX_ListID).Append(allocationOrder.ListID).Append(FIELD_DELIM);
						if (allocationOrder.WaveNo != null && allocationOrder.WaveNo.Length > 0)
							sb.Append(TAG_PREFIX_WaveNo).Append(allocationOrder.WaveNo).Append(FIELD_DELIM);
					}
				}

				_message.NoExecs = _message.Exec.Count;
				if (_message.NoExecs != 0)
				{
					sb.Append(TAG_PREFIX_NoExecs).Append(_message.NoExecs).Append(FIELD_DELIM);
					AllocationExec allocationExec;
					for (int i = 0; i < _message.NoExecs; i++)
					{
						allocationExec = _message.Exec[i];
						if (allocationExec.ExecID != null && allocationExec.ExecID.Length > 0)
							sb.Append(TAG_PREFIX_ExecID).Append(allocationExec.ExecID).Append(FIELD_DELIM);
						if (allocationExec.LastShares != 0)
							sb.Append(TAG_PREFIX_LastShares).Append(allocationExec.LastShares).Append(FIELD_DELIM);
						if (allocationExec.LastPx != 0)
							sb.Append(TAG_PREFIX_LastPx).Append(allocationExec.LastPx).Append(FIELD_DELIM);
						if (allocationExec.LastMkt != null && allocationExec.LastMkt.Length > 0)
							sb.Append(TAG_PREFIX_LastMkt).Append(allocationExec.LastMkt).Append(FIELD_DELIM);
					}
				}

				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.Shares != 0)
					sb.Append(TAG_PREFIX_Shares).Append(_message.Shares).Append(FIELD_DELIM);
				if (_message.AvgPx != 0)
					sb.Append(TAG_PREFIX_AvgPx).Append(_message.AvgPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.AvgPrxPrecision != 0)
					sb.Append(TAG_PREFIX_AvgPrxPrecision).Append(_message.AvgPrxPrecision).Append(FIELD_DELIM);
				if (_message.TradeDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TradeDate).Append(ToFIXLocalMktDate(_message.TradeDate)).Append(FIELD_DELIM);
				if (_message.TransactTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXUTCTimestamp(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.NetMoney != 0)
					sb.Append(TAG_PREFIX_NetMoney).Append(_message.NetMoney).Append(FIELD_DELIM);

				_message.NoMiscFees = _message.MiscFee.Count;
				if (_message.NoMiscFees != 0)
				{
					sb.Append(TAG_PREFIX_NoMiscFees).Append(_message.NoMiscFees).Append(FIELD_DELIM);
					AllocationMiscFee allocationMiscFee;
					for (int i = 0; i < _message.NoMiscFees; i++)
					{
						allocationMiscFee = _message.MiscFee[i];
						if (allocationMiscFee.MiscFeeAmt != 0)
							sb.Append(TAG_PREFIX_MiscFeeAmt).Append(allocationMiscFee.MiscFeeAmt).Append(FIELD_DELIM);
						if (allocationMiscFee.MiscFeeCurr != 0)
							sb.Append(TAG_PREFIX_MiscFeeCurr).Append(allocationMiscFee.MiscFeeCurr).Append(FIELD_DELIM);
						if (allocationMiscFee.MiscFeeType != '\0')
							sb.Append(TAG_PREFIX_MiscFeeType).Append(allocationMiscFee.MiscFeeType).Append(FIELD_DELIM);
					}
				}

				if (_message.SettlCurrAmt != 0)
					sb.Append(TAG_PREFIX_SettlCurrAmt).Append(_message.SettlCurrAmt).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.OpenClose != 0)
					sb.Append(TAG_PREFIX_OpenClose).Append(_message.OpenClose).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);

				_message.NoAllocs = _message.Alloc.Count;
				if (_message.NoAllocs != 0)
				{
					sb.Append(TAG_PREFIX_NoAllocs).Append(_message.NoAllocs).Append(FIELD_DELIM);
					AllocationAlloc allocationAlloc;
					for (int iAlloc = 0; iAlloc < _message.NoAllocs; iAlloc++)
					{
						allocationAlloc = _message.Alloc[iAlloc];
						if (allocationAlloc.AllocAccount != null && allocationAlloc.AllocAccount.Length > 0)
							sb.Append(TAG_PREFIX_AllocAccount).Append(allocationAlloc.AllocAccount).Append(FIELD_DELIM);
						if (allocationAlloc.AllocShares != 0)
							sb.Append(TAG_PREFIX_AllocShares).Append(allocationAlloc.AllocShares).Append(FIELD_DELIM);
						if (allocationAlloc.ProcessCode != '\0')
							sb.Append(TAG_PREFIX_ProcessCode).Append(allocationAlloc.ProcessCode).Append(FIELD_DELIM);
						if (allocationAlloc.ExecBroker != null && allocationAlloc.ExecBroker.Length > 0)
							sb.Append(TAG_PREFIX_ExecBroker).Append(allocationAlloc.ExecBroker).Append(FIELD_DELIM);
						if (allocationAlloc.ClientID != null && allocationAlloc.ClientID.Length > 0)
							sb.Append(TAG_PREFIX_ClientID).Append(allocationAlloc.ClientID).Append(FIELD_DELIM);
						if (allocationAlloc.Commission != 0)
							sb.Append(TAG_PREFIX_Commission).Append(allocationAlloc.Commission).Append(FIELD_DELIM);
						if (allocationAlloc.CommType != '\0')
							sb.Append(TAG_PREFIX_CommType).Append(allocationAlloc.CommType).Append(FIELD_DELIM);

						allocationAlloc.NoDlvyInst = allocationAlloc.DlvyInst.Count;
						if (allocationAlloc.NoDlvyInst != 0)
						{
							sb.Append(TAG_PREFIX_NoDlvyInst).Append(allocationAlloc.NoDlvyInst).Append(FIELD_DELIM);
							AllocationAllocDlvyInst allocationAllocDlvyInst;
							for (int iDlvyInst = 0; iDlvyInst < allocationAlloc.NoDlvyInst; iDlvyInst++)
							{
								allocationAllocDlvyInst = allocationAlloc.DlvyInst[iDlvyInst];
								if (allocationAllocDlvyInst.BrokerOfCredit != null && allocationAllocDlvyInst.BrokerOfCredit.Length > 0)
									sb.Append(TAG_PREFIX_BrokerOfCredit).Append(allocationAllocDlvyInst.BrokerOfCredit).Append(FIELD_DELIM);
								if (allocationAllocDlvyInst.DlvyInst != null && allocationAllocDlvyInst.DlvyInst.Length > 0)
									sb.Append(TAG_PREFIX_DlvyInst).Append(allocationAllocDlvyInst.DlvyInst).Append(FIELD_DELIM);
							}
						}
					}
				}
			}

			public override void ParseField(IField field)
			{
				if (Allocation.TAG_AllocID == field.Tag)
					_message.AllocID = field.Value;
				else if (Allocation.TAG_AllocTransType == field.Tag)
					_message.AllocTransType = field.Value[0];
				else if (Allocation.TAG_RefAllocID == field.Tag)
					_message.RefAllocID = field.Value;

					//Order
				else if (Allocation.TAG_NoOrders == field.Tag)
					_message.NoOrders = ParseInt(field.Value);
				else if (Allocation.TAG_ClOrdID == field.Tag)
				{
					_allocationOrderLast = new AllocationOrder();
					_message.Order.Add(_allocationOrderLast);
					_allocationOrderLast.ClOrdID = field.Value;
				}
				else if (Allocation.TAG_OrderID == field.Tag)
					_allocationOrderLast.OrderID = field.Value;
				else if (Allocation.TAG_ListID == field.Tag)
					_allocationOrderLast.ListID = field.Value;
				else if (Allocation.TAG_WaveNo == field.Tag)
					_allocationOrderLast.WaveNo = field.Value;

					//Exec
				else if (Allocation.TAG_NoExecs == field.Tag)
					_message.NoExecs = ParseInt(field.Value);
				else if (Allocation.TAG_ExecID == field.Tag)
				{
					_allocationExecLast = new AllocationExec();
					_message.Exec.Add(_allocationExecLast);
					_allocationExecLast.ExecID = field.Value;
				}
				else if (Allocation.TAG_LastShares == field.Tag)
					_allocationExecLast.LastShares = ParseInt(field.Value);
				else if (Allocation.TAG_LastPx == field.Tag)
					_allocationExecLast.LastPx = double.Parse(field.Value);
				else if (Allocation.TAG_LastMkt == field.Tag)
					_allocationExecLast.LastMkt = field.Value;

				else if (Allocation.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (Allocation.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (Allocation.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (Allocation.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (Allocation.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (Allocation.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (Allocation.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (Allocation.TAG_Shares == field.Tag)
					_message.Shares = ParseInt(field.Value);
				else if (Allocation.TAG_AvgPx == field.Tag)
					_message.AvgPx = double.Parse(field.Value);
				else if (Allocation.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (Allocation.TAG_AvgPrxPrecision == field.Tag)
					_message.AvgPrxPrecision = ParseInt(field.Value);
				else if (Allocation.TAG_TradeDate == field.Tag)
					_message.TradeDate = FromFIXLocalMktDate(field.Value);
				else if (Allocation.TAG_TransactTime == field.Tag)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (Allocation.TAG_SettlmntTyp == field.Tag)
					_message.SettlmntTyp = field.Value[0];
				else if (Allocation.TAG_FutSettDate == field.Tag)
					_message.FutSettDate = FromFIXUTCTimestamp(field.Value);
				else if (Allocation.TAG_NetMoney == field.Tag)
					_message.NetMoney = double.Parse(field.Value);

					//MisFee
				else if (Allocation.TAG_NoMiscFees == field.Tag)
					_message.NoMiscFees = ParseInt(field.Value);
				else if (Allocation.TAG_MiscFeeAmt == field.Tag)
				{
					_allocationMiscFeeLast = new AllocationMiscFee();
					_message.MiscFee.Add(_allocationMiscFeeLast);
					_allocationMiscFeeLast.MiscFeeAmt = double.Parse(field.Value);
				}
				else if (Allocation.TAG_MiscFeeCurr == field.Tag)
					_allocationMiscFeeLast.MiscFeeCurr = double.Parse(field.Value);
				else if (Allocation.TAG_MiscFeeType == field.Tag)
					_allocationMiscFeeLast.MiscFeeType = field.Value[0];

				else if (Allocation.TAG_SettlCurrAmt == field.Tag)
					_message.SettlCurrAmt = double.Parse(field.Value);
				else if (Allocation.TAG_SettlCurrency == field.Tag)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (Allocation.TAG_OpenClose == field.Tag)
					_message.OpenClose = field.Value[0];
				else if (Allocation.TAG_Text == field.Tag)
					_message.Text = field.Value;

					//Alloc
				else if (Allocation.TAG_NoAllocs == field.Tag)
					_message.NoAllocs = ParseInt(field.Value);
				else if (Allocation.TAG_AllocAccount == field.Tag)
				{
					_allocationAllocLast = new AllocationAlloc();
					_message.Alloc.Add(_allocationAllocLast);
					_allocationAllocLast.AllocAccount = field.Value;
				}
				else if (Allocation.TAG_AllocShares == field.Tag)
					_allocationAllocLast.AllocShares = ParseInt(field.Value);
				else if (Allocation.TAG_ProcessCode == field.Tag)
					_allocationAllocLast.ProcessCode = field.Value[0];
				else if (Allocation.TAG_ExecBroker == field.Tag)
					_allocationAllocLast.ExecBroker = field.Value;
				else if (Allocation.TAG_ClientID == field.Tag)
					_allocationAllocLast.ClientID = field.Value;
				else if (Allocation.TAG_Commission == field.Tag)
					_allocationAllocLast.Commission = double.Parse(field.Value);
				else if (Allocation.TAG_CommType == field.Tag)
					_allocationAllocLast.CommType = field.Value[0];

					//DlvyInst
				else if (Allocation.TAG_NoDlvyInst == field.Tag)
					_allocationAllocLast.NoDlvyInst = ParseInt(field.Value);
				else if (Allocation.TAG_BrokerOfCredit == field.Tag)
				{
					_allocationAllocDlvyInstLast = new AllocationAllocDlvyInst();
					_allocationAllocLast.DlvyInst.Add(_allocationAllocDlvyInstLast);
					_allocationAllocDlvyInstLast.BrokerOfCredit = field.Value;
				}
				else if (Allocation.TAG_DlvyInst == field.Tag)
					_allocationAllocDlvyInstLast.DlvyInst = field.Value;

				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperAllocationACK : MessageHelper
		{
			private static string TAG_PREFIX_ClientID = AllocationACK.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = AllocationACK.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocID = AllocationACK.TAG_AllocID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TradeDate = AllocationACK.TAG_TradeDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = AllocationACK.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocStatus = AllocationACK.TAG_AllocStatus.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AllocRejCode = AllocationACK.TAG_AllocRejCode.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = AllocationACK.TAG_Text.ToString() + TAG_DELIM;

			private AllocationACK _message;

			public MessageHelperAllocationACK(IMessage message)
				: base(message)
			{
				_message = (AllocationACK)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.AllocID != null && _message.AllocID.Length > 0)
					sb.Append(TAG_PREFIX_AllocID).Append(_message.AllocID).Append(FIELD_DELIM);
				if (_message.TradeDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TradeDate).Append(ToFIXLocalMktDate(_message.TradeDate)).Append(FIELD_DELIM);
				if (_message.TransactTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.AllocStatus != 0)
					sb.Append(TAG_PREFIX_AllocStatus).Append(_message.AllocStatus).Append(FIELD_DELIM);
				if (_message.AllocRejCode != 0)
					sb.Append(TAG_PREFIX_AllocRejCode).Append(_message.AllocRejCode).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (AllocationACK.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (AllocationACK.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (AllocationACK.TAG_AllocID == field.Tag)
					_message.AllocID = field.Value;
				else if (AllocationACK.TAG_TradeDate == field.Tag)
					_message.TradeDate = FromFIXLocalMktDate(field.Value);
				else if (AllocationACK.TAG_TransactTime == field.Tag)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (AllocationACK.TAG_AllocStatus == field.Tag)
					_message.AllocStatus = ParseInt(field.Value);
				else if (AllocationACK.TAG_AllocRejCode == field.Tag)
					_message.AllocRejCode = ParseInt(field.Value);
				else if (AllocationACK.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperNewOrderList : MessageHelper
		{
			private static string TAG_PREFIX_ListID = NewOrderList.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = NewOrderList.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListSeqNo = NewOrderList.TAG_ListSeqNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TotNoOrders = NewOrderList.TAG_TotNoOrders.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListExecInst = NewOrderList.TAG_ListExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = NewOrderList.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = NewOrderList.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = NewOrderList.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = NewOrderList.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = NewOrderList.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = NewOrderList.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HandlInst = NewOrderList.TAG_HandlInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = NewOrderList.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MinQty = NewOrderList.TAG_MinQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxFloor = NewOrderList.TAG_MaxFloor.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExDestination = NewOrderList.TAG_ExDestination.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ProcessCode = NewOrderList.TAG_ProcessCode.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = NewOrderList.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = NewOrderList.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = NewOrderList.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = NewOrderList.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = NewOrderList.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = NewOrderList.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PrevClosePx = NewOrderList.TAG_PrevClosePx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = NewOrderList.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LocateReqd = NewOrderList.TAG_LocateReqd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = NewOrderList.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = NewOrderList.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = NewOrderList.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = NewOrderList.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = NewOrderList.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = NewOrderList.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = NewOrderList.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = NewOrderList.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = NewOrderList.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = NewOrderList.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ForexReq = NewOrderList.TAG_ForexReq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = NewOrderList.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = NewOrderList.TAG_Text.ToString() + TAG_DELIM;

			private NewOrderList _message;

			public MessageHelperNewOrderList(IMessage message)
				: base(message)
			{
				_message = (NewOrderList)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.WaveNo != null && _message.WaveNo.Length > 0)
					sb.Append(TAG_PREFIX_WaveNo).Append(_message.WaveNo).Append(FIELD_DELIM);
				if (_message.ListSeqNo != 0)
					sb.Append(TAG_PREFIX_ListSeqNo).Append(_message.ListSeqNo).Append(FIELD_DELIM);
				if (_message.TotNoOrders != 0)
					sb.Append(TAG_PREFIX_TotNoOrders).Append(_message.TotNoOrders).Append(FIELD_DELIM);
				if (_message.ListExecInst != null && _message.ListExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ListExecInst).Append(_message.ListExecInst).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate != DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.HandlInst != '\0')
					sb.Append(TAG_PREFIX_HandlInst).Append(_message.HandlInst).Append(FIELD_DELIM);
				if (_message.ExecInst != null && _message.ExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ExecInst).Append(_message.ExecInst).Append(FIELD_DELIM);
				if (_message.MinQty != 0)
					sb.Append(TAG_PREFIX_MinQty).Append(_message.MinQty).Append(FIELD_DELIM);
				if (_message.MaxFloor != 0)
					sb.Append(TAG_PREFIX_MaxFloor).Append(_message.MaxFloor).Append(FIELD_DELIM);
				if (_message.ExDestination != null && _message.ExDestination.Length > 0)
					sb.Append(TAG_PREFIX_ExDestination).Append(_message.ExDestination).Append(FIELD_DELIM);
				if (_message.ProcessCode != '\0')
					sb.Append(TAG_PREFIX_ProcessCode).Append(_message.ProcessCode).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.PrevClosePx != 0)
					sb.Append(TAG_PREFIX_PrevClosePx).Append(_message.PrevClosePx).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.LocateReqd != false)
					sb.Append(TAG_PREFIX_LocateReqd).Append(ToFIXBoolean(_message.LocateReqd)).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.ExpireTime != DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.ForexReq != false)
					sb.Append(TAG_PREFIX_ForexReq).Append(ToFIXBoolean(_message.ForexReq)).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (NewOrderList.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (NewOrderList.TAG_WaveNo == field.Tag)
					_message.WaveNo = field.Value;
				else if (NewOrderList.TAG_ListSeqNo == field.Tag)
					_message.ListSeqNo = ParseInt(field.Value);
				else if (NewOrderList.TAG_TotNoOrders == field.Tag)
					_message.TotNoOrders = ParseInt(field.Value);
				else if (NewOrderList.TAG_ListExecInst == field.Tag)
					_message.ListExecInst = field.Value;
				else if (NewOrderList.TAG_ClOrdID == field.Tag)
					_message.ClOrdID = field.Value;
				else if (NewOrderList.TAG_ClientID == field.Tag)
					_message.ClientID = field.Value;
				else if (NewOrderList.TAG_ExecBroker == field.Tag)
					_message.ExecBroker = field.Value;
				else if (NewOrderList.TAG_Account == field.Tag)
					_message.Account = field.Value;
				else if (NewOrderList.TAG_SettlmntTyp == field.Tag)
					_message.SettlmntTyp = field.Value[0];
				else if (NewOrderList.TAG_FutSettDate == field.Tag)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (NewOrderList.TAG_HandlInst == field.Tag)
					_message.HandlInst = field.Value[0];
				else if (NewOrderList.TAG_ExecInst == field.Tag)
					_message.ExecInst = field.Value;
				else if (NewOrderList.TAG_MinQty == field.Tag)
					_message.MinQty = ParseInt(field.Value);
				else if (NewOrderList.TAG_MaxFloor == field.Tag)
					_message.MaxFloor = ParseInt(field.Value);
				else if (NewOrderList.TAG_ExDestination == field.Tag)
					_message.ExDestination = field.Value;
				else if (NewOrderList.TAG_ProcessCode == field.Tag)
					_message.ProcessCode = field.Value[0];
				else if (NewOrderList.TAG_Symbol == field.Tag)
					_message.Symbol = field.Value;
				else if (NewOrderList.TAG_SymbolSfx == field.Tag)
					_message.SymbolSfx = field.Value;
				else if (NewOrderList.TAG_SecurityID == field.Tag)
					_message.SecurityID = field.Value;
				else if (NewOrderList.TAG_IDSource == field.Tag)
					_message.IDSource = field.Value;
				else if (NewOrderList.TAG_Issuer == field.Tag)
					_message.Issuer = field.Value;
				else if (NewOrderList.TAG_SecurityDesc == field.Tag)
					_message.SecurityDesc = field.Value;
				else if (NewOrderList.TAG_PrevClosePx == field.Tag)
					_message.PrevClosePx = double.Parse(field.Value);
				else if (NewOrderList.TAG_Side == field.Tag)
					_message.Side = field.Value[0];
				else if (NewOrderList.TAG_LocateReqd == field.Tag)
					_message.LocateReqd = FromFIXBoolean(field.Value);
				else if (NewOrderList.TAG_OrderQty == field.Tag)
					_message.OrderQty = ParseInt(field.Value);
				else if (NewOrderList.TAG_OrdType == field.Tag)
					_message.OrdType = field.Value[0];
				else if (NewOrderList.TAG_Price == field.Tag)
					_message.Price = double.Parse(field.Value);
				else if (NewOrderList.TAG_StopPx == field.Tag)
					_message.StopPx = double.Parse(field.Value);
				else if (NewOrderList.TAG_Currency == field.Tag)
					_message.Currency = double.Parse(field.Value);
				else if (NewOrderList.TAG_TimeInForce == field.Tag)
					_message.TimeInForce = field.Value[0];
				else if (NewOrderList.TAG_ExpireTime == field.Tag)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (NewOrderList.TAG_Commission == field.Tag)
					_message.Commission = double.Parse(field.Value);
				else if (NewOrderList.TAG_CommType == field.Tag)
					_message.CommType = field.Value[0];
				else if (NewOrderList.TAG_Rule80A == field.Tag)
					_message.Rule80A = field.Value[0];
				else if (NewOrderList.TAG_ForexReq == field.Tag)
					_message.ForexReq = FromFIXBoolean(field.Value);
				else if (NewOrderList.TAG_SettlCurrency == field.Tag)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (NewOrderList.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperListStatus : MessageHelper
		{
			private static string TAG_PREFIX_ListID = ListStatus.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = ListStatus.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoRpts = ListStatus.TAG_NoRpts.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RptSeq = ListStatus.TAG_RptSeq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoOrders = ListStatus.TAG_NoOrders.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = ListStatus.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CumQty = ListStatus.TAG_CumQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CxlQty = ListStatus.TAG_CxlQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AvgPx = ListStatus.TAG_AvgPx.ToString() + TAG_DELIM;

			private ListStatus _message;

			public MessageHelperListStatus(IMessage message)
				: base(message)
			{
				_message = (ListStatus)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.WaveNo != null && _message.WaveNo.Length > 0)
					sb.Append(TAG_PREFIX_WaveNo).Append(_message.WaveNo).Append(FIELD_DELIM);
				if (_message.NoRpts != 0)
					sb.Append(TAG_PREFIX_NoRpts).Append(_message.NoRpts).Append(FIELD_DELIM);
				if (_message.RptSeq != 0)
					sb.Append(TAG_PREFIX_RptSeq).Append(_message.RptSeq).Append(FIELD_DELIM);

				//Repeating Group - Order
				_message.NoOrders = _message.Order.Count;
				if (_message.NoOrders != 0)
				{
					sb.Append(TAG_PREFIX_NoOrders).Append(_message.NoOrders).Append(FIELD_DELIM);
					ListStatusOrder listStatusOrder;
					for (int i = 0; i < _message.NoOrders; i++)
					{
						listStatusOrder = _message.Order[i];
						if (listStatusOrder.ClOrdID != null && listStatusOrder.ClOrdID.Length > 0)
							sb.Append(TAG_PREFIX_ClOrdID).Append(listStatusOrder.ClOrdID).Append(FIELD_DELIM);
						if (listStatusOrder.CumQty != 0)
							sb.Append(TAG_PREFIX_CumQty).Append(listStatusOrder.CumQty).Append(FIELD_DELIM);
						if (listStatusOrder.CxlQty != 0)
							sb.Append(TAG_PREFIX_CxlQty).Append(listStatusOrder.CxlQty).Append(FIELD_DELIM);
						if (listStatusOrder.AvgPx != 0)
							sb.Append(TAG_PREFIX_AvgPx).Append(listStatusOrder.AvgPx).Append(FIELD_DELIM);
					}
				}
			}

			private ListStatusOrder _listStatusOrderLast;

			public override void ParseField(IField field)
			{
				if (ListStatus.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (ListStatus.TAG_WaveNo == field.Tag)
					_message.WaveNo = field.Value;
				else if (ListStatus.TAG_NoRpts == field.Tag)
					_message.NoRpts = ParseInt(field.Value);
				else if (ListStatus.TAG_RptSeq == field.Tag)
					_message.RptSeq = ParseInt(field.Value);

					//Repeating Group - Order
				else if (ListStatus.TAG_NoOrders == field.Tag)
					_message.NoOrders = ParseInt(field.Value);
				else if (ListStatus.TAG_ClOrdID == field.Tag)
				{
					_listStatusOrderLast = new ListStatusOrder();
					_message.Order.Add(_listStatusOrderLast);
					_listStatusOrderLast.ClOrdID = field.Value;
				}
				else if (ListStatus.TAG_CumQty == field.Tag)
					_listStatusOrderLast.CumQty = ParseInt(field.Value);
				else if (ListStatus.TAG_CxlQty == field.Tag)
					_listStatusOrderLast.CxlQty = ParseInt(field.Value);
				else if (ListStatus.TAG_AvgPx == field.Tag)
					_listStatusOrderLast.AvgPx = double.Parse(field.Value);

				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperListExecute : MessageHelper
		{
			private static string TAG_PREFIX_ListID = ListExecute.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = ListExecute.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = ListExecute.TAG_Text.ToString() + TAG_DELIM;

			private ListExecute _message;

			public MessageHelperListExecute(IMessage message)
				: base(message)
			{
				_message = (ListExecute)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.WaveNo != null && _message.WaveNo.Length > 0)
					sb.Append(TAG_PREFIX_WaveNo).Append(_message.WaveNo).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ListExecute.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (ListExecute.TAG_WaveNo == field.Tag)
					_message.WaveNo = field.Value;
				else if (ListExecute.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperListCancelRequest : MessageHelper
		{
			private static string TAG_PREFIX_ListID = ListCancelRequest.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = ListCancelRequest.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = ListCancelRequest.TAG_Text.ToString() + TAG_DELIM;

			private ListCancelRequest _message;

			public MessageHelperListCancelRequest(IMessage message)
				: base(message)
			{
				_message = (ListCancelRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.WaveNo != null && _message.WaveNo.Length > 0)
					sb.Append(TAG_PREFIX_WaveNo).Append(_message.WaveNo).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ListCancelRequest.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (ListCancelRequest.TAG_WaveNo == field.Tag)
					_message.WaveNo = field.Value;
				else if (ListCancelRequest.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperListStatusRequest : MessageHelper
		{
			private static string TAG_PREFIX_ListID = ListStatusRequest.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_WaveNo = ListStatusRequest.TAG_WaveNo.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = ListStatusRequest.TAG_Text.ToString() + TAG_DELIM;

			private ListStatusRequest _message;

			public MessageHelperListStatusRequest(IMessage message)
				: base(message)
			{
				_message = (ListStatusRequest)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);

				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.WaveNo != null && _message.WaveNo.Length > 0)
					sb.Append(TAG_PREFIX_WaveNo).Append(_message.WaveNo).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (ListStatusRequest.TAG_ListID == field.Tag)
					_message.ListID = field.Value;
				else if (ListStatusRequest.TAG_WaveNo == field.Tag)
					_message.WaveNo = field.Value;
				else if (ListStatusRequest.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}
	}
}
