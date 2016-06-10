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

namespace FIX4NET.FIX.FIX_4_2
{
	/// <summary>
	/// Summary description for MessageFactory.
	/// </summary>
	public class MessageFactoryFIX : FIX.MessageFactoryFIX
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public MessageFactoryFIX() : base("FIX.4.2") { }

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
			else if (string.Equals(sMsgType, Values.MsgType.Logout))
				return new Logout();
			else if (string.Equals(sMsgType, Values.MsgType.Logon))
				return new Logon();

			else if (string.Equals(sMsgType, Values.MsgType.IndicationOfInterest))
				return new IndicationOfInterest();
			else if (string.Equals(sMsgType, Values.MsgType.Advertisement))
				return new Advertisement();
			else if (string.Equals(sMsgType, Values.MsgType.ExecutionReport))
				return new ExecutionReport();
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReject))
				return new OrderCancelReject();
			else if (string.Equals(sMsgType, Values.MsgType.News))
				return new News();
			else if (string.Equals(sMsgType, Values.MsgType.Email))
				return new Email();
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderSingle))
				return new NewOrderSingle();
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderList))
				return new NewOrderList();
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelRequest))
				return new OrderCancelRequest();
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReplaceRequest))
				return new OrderCancelReplaceRequest();
			else if (string.Equals(sMsgType, Values.MsgType.OrderStatusRequest))
				return new OrderStatusRequest();
			else if (string.Equals(sMsgType, Values.MsgType.Allocation))
				return new Allocation();
			else if (string.Equals(sMsgType, Values.MsgType.ListCancelRequest))
				return new ListCancelRequest();
			else if (string.Equals(sMsgType, Values.MsgType.ListExecute))
				return new ListExecute();
			else if (string.Equals(sMsgType, Values.MsgType.ListStatusRequest))
				return new ListStatusRequest();
			else if (string.Equals(sMsgType, Values.MsgType.ListStatus))
				return new ListStatus();
			else if (string.Equals(sMsgType, Values.MsgType.AllocationACK))
				return new AllocationACK();
			else if (string.Equals(sMsgType, Values.MsgType.DontKnowTrade))
				return new DontKnowTrade();
			else if (string.Equals(sMsgType, Values.MsgType.QuoteRequest))
				return new QuoteRequest();
			else if (string.Equals(sMsgType, Values.MsgType.Quote))
				return new Quote();
			else if (string.Equals(sMsgType, Values.MsgType.BusinessMessageReject))
				return new BusinessMessageReject();

			else
				return null;
		}

		public override IMessageReject CreateInstanceReject(ParseFieldException exParse)
		{
			Reject reject = new Reject();
			reject.RefSeqNum = exParse.RefSeqNum;
			reject.Text = exParse.Text;
			if (exParse is ParseFieldExceptionFIX)
			{
				ParseFieldExceptionFIX exParseFIX = (ParseFieldExceptionFIX)exParse;
				reject.RefTagID = exParseFIX.RefTagID;
				reject.RefMsgType = exParseFIX.RefMsgType;
				reject.SessionRejectReason = exParseFIX.SessionRejectReason;
			}
			return reject;
		}

		protected override ParseFieldException CreateInstanceParseFieldException(string sMessage, Exception exInner, IField field, string sMessageRaw)
		{
			ParseFieldExceptionFIX ex = new ParseFieldExceptionFIX(sMessage, exInner);
			ex.RefSeqNum = ParseMsgSeqNum(sMessageRaw);
			ex.RefTagID = field.Tag;
			ex.RefMsgType = ParseMsgType(sMessageRaw);
			ex.SessionRejectReason = 5;
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

			else if (string.Equals(sMsgType, Values.MsgType.IndicationOfInterest))
				return new MessageHelperIndicationOfInterest(message);
			else if (string.Equals(sMsgType, Values.MsgType.Advertisement))
				return new MessageHelperAdvertisement(message);
			else if (string.Equals(sMsgType, Values.MsgType.ExecutionReport))
				return new MessageHelperExecutionReport(message);
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReject))
				return new MessageHelperOrderCancelReject(message);
			else if (string.Equals(sMsgType, Values.MsgType.News))
				return new MessageHelperNews(message);
			else if (string.Equals(sMsgType, Values.MsgType.Email))
				return new MessageHelperEmail(message);
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderSingle))
				return new MessageHelperNewOrderSingle(message);
			else if (string.Equals(sMsgType, Values.MsgType.NewOrderList))
				return new MessageHelperNewOrderList(message);
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelRequest))
				return new MessageHelperOrderCancelRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.OrderCancelReplaceRequest))
				return new MessageHelperOrderCancelReplaceRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.OrderStatusRequest))
				return new MessageHelperOrderStatusRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.Allocation))
				return new MessageHelperAllocation(message);
			else if (string.Equals(sMsgType, Values.MsgType.ListCancelRequest))
				return new MessageHelperListCancelRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.ListExecute))
				return new MessageHelperListExecute(message);
			else if (string.Equals(sMsgType, Values.MsgType.ListStatusRequest))
				return new MessageHelperListStatusRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.ListStatus))
				return new MessageHelperListStatus(message);
			else if (string.Equals(sMsgType, Values.MsgType.AllocationACK))
				return new MessageHelperAllocationACK(message);
			else if (string.Equals(sMsgType, Values.MsgType.DontKnowTrade))
				return new MessageHelperDontKnowTrade(message);
			else if (string.Equals(sMsgType, Values.MsgType.QuoteRequest))
				return new MessageHelperQuoteRequest(message);
			else if (string.Equals(sMsgType, Values.MsgType.Quote))
				return new MessageHelperQuote(message);
			else if (string.Equals(sMsgType, Values.MsgType.BusinessMessageReject))
				return new MessageHelperBusinessMessageReject(message);

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
			private static string TAG_PREFIX_RefTagID = Reject.TAG_RefTagID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RefMsgType = Reject.TAG_RefMsgType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SessionRejectReason = Reject.TAG_SessionRejectReason.ToString() + TAG_DELIM;
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
				if (_message.RefSeqNum > 0)
					sb.Append(TAG_PREFIX_RefSeqNum).Append(_message.RefSeqNum).Append(FIELD_DELIM);
				if (_message.RefTagID > 0)
					sb.Append(TAG_PREFIX_RefTagID).Append(_message.RefTagID).Append(FIELD_DELIM);
				if (_message.RefMsgType != null && _message.RefMsgType.Length > 0)
					sb.Append(TAG_PREFIX_RefMsgType).Append(_message.RefMsgType).Append(FIELD_DELIM);
				if (_message.SessionRejectReason >= 0)
					sb.Append(TAG_PREFIX_SessionRejectReason).Append(_message.SessionRejectReason).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (Reject.TAG_RefSeqNum == field.Tag)
					_message.RefSeqNum = ParseInt(field.Value);
				else if (Reject.TAG_RefTagID == field.Tag)
					_message.RefTagID = ParseInt(field.Value);
				else if (Reject.TAG_RefMsgType == field.Tag)
					_message.RefMsgType = field.Value;
				else if (Reject.TAG_SessionRejectReason == field.Tag)
					_message.SessionRejectReason = ParseInt(field.Value);
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

		protected class MessageHelperIndicationOfInterest : MessageHelper
		{
			private static string TAG_PREFIX_IOIid = IndicationOfInterest.TAG_IOIid.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOITransType = IndicationOfInterest.TAG_IOITransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIRefID = IndicationOfInterest.TAG_IOIRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = IndicationOfInterest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = IndicationOfInterest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = IndicationOfInterest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = IndicationOfInterest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = IndicationOfInterest.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = IndicationOfInterest.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = IndicationOfInterest.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = IndicationOfInterest.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = IndicationOfInterest.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = IndicationOfInterest.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = IndicationOfInterest.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = IndicationOfInterest.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = IndicationOfInterest.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = IndicationOfInterest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = IndicationOfInterest.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = IndicationOfInterest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = IndicationOfInterest.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = IndicationOfInterest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIShares = IndicationOfInterest.TAG_IOIShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = IndicationOfInterest.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = IndicationOfInterest.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ValidUntilTime = IndicationOfInterest.TAG_ValidUntilTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIQltyInd = IndicationOfInterest.TAG_IOIQltyInd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOINaturalFlag = IndicationOfInterest.TAG_IOINaturalFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoIOIQualifiers = IndicationOfInterest.TAG_NoIOIQualifiers.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = IndicationOfInterest.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedTextLen = IndicationOfInterest.TAG_EncodedTextLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = IndicationOfInterest.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_URLLink = IndicationOfInterest.TAG_URLLink.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoRoutingIDs = IndicationOfInterest.TAG_NoRoutingIDs.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SpreadToBenchmark = IndicationOfInterest.TAG_SpreadToBenchmark.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Benchmark = IndicationOfInterest.TAG_Benchmark.ToString() + TAG_DELIM;

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
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.IOIShares != null && _message.IOIShares.Length > 0)
					sb.Append(TAG_PREFIX_IOIShares).Append(_message.IOIShares).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.ValidUntilTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ValidUntilTime).Append(ToFIXUTCTimestamp(_message.ValidUntilTime)).Append(FIELD_DELIM);
				if (_message.IOIQltyInd != '\0')
					sb.Append(TAG_PREFIX_IOIQltyInd).Append(_message.IOIQltyInd).Append(FIELD_DELIM);
				if (_message.IOINaturalFlag)
					sb.Append(TAG_PREFIX_IOINaturalFlag).Append(_message.IOINaturalFlag).Append(FIELD_DELIM);
				if (_message.NoIOIQualifiers != 0)
					sb.Append(TAG_PREFIX_NoIOIQualifiers).Append(_message.NoIOIQualifiers).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
				if (_message.EncodedTextLen != 0)
					sb.Append(TAG_PREFIX_EncodedTextLen).Append(_message.EncodedTextLen).Append(FIELD_DELIM);
				if (_message.TransactTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.URLLink != null && _message.URLLink.Length > 0)
					sb.Append(TAG_PREFIX_URLLink).Append(_message.URLLink).Append(FIELD_DELIM);
				if (_message.NoRoutingIDs != 0)
					sb.Append(TAG_PREFIX_NoRoutingIDs).Append(_message.NoRoutingIDs).Append(FIELD_DELIM);
				if (_message.SpreadToBenchmark != 0)
					sb.Append(TAG_PREFIX_SpreadToBenchmark).Append(_message.SpreadToBenchmark).Append(FIELD_DELIM);
				if (_message.Benchmark != '\0')
					sb.Append(TAG_PREFIX_Benchmark).Append(_message.Benchmark).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == IndicationOfInterest.TAG_IOIid)
					_message.IOIid = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_IOITransType)
					_message.IOITransType = field.Value[0];
				else if (field.Tag == IndicationOfInterest.TAG_IOIRefID)
					_message.IOIRefID = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == IndicationOfInterest.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_Side)
					_message.Side = field.Value[0];
				else if (field.Tag == IndicationOfInterest.TAG_IOIShares)
					_message.IOIShares = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_Price)
					_message.Price = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_Currency)
					_message.Currency = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_ValidUntilTime)
					_message.ValidUntilTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_IOIQltyInd)
					_message.IOIQltyInd = field.Value[0];
				else if (field.Tag == IndicationOfInterest.TAG_IOINaturalFlag)
					_message.IOINaturalFlag = FromFIXBoolean(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_NoIOIQualifiers)
					_message.NoIOIQualifiers = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_Text)
					_message.Text = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_EncodedTextLen)
					_message.EncodedTextLen = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_TransactTime)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_URLLink)
					_message.URLLink = field.Value;
				else if (field.Tag == IndicationOfInterest.TAG_NoRoutingIDs)
					_message.NoRoutingIDs = ParseInt(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_SpreadToBenchmark)
					_message.SpreadToBenchmark = double.Parse(field.Value);
				else if (field.Tag == IndicationOfInterest.TAG_Benchmark)
					_message.Benchmark = field.Value[0];
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperAdvertisement : MessageHelper
		{
			private Advertisement _message;
			public MessageHelperAdvertisement(IMessage message)
				: base(message)
			{
				_message = (Advertisement)message;
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

		protected class MessageHelperExecutionReport : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = ExecutionReport.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecondaryOrderID = ExecutionReport.TAG_SecondaryOrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = ExecutionReport.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrigClOrdID = ExecutionReport.TAG_OrigClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = ExecutionReport.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = ExecutionReport.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoContraBrokers = ExecutionReport.TAG_NoContraBrokers.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = ExecutionReport.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecID = ExecutionReport.TAG_ExecID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecTransType = ExecutionReport.TAG_ExecTransType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecRefID = ExecutionReport.TAG_ExecRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecType = ExecutionReport.TAG_ExecType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdStatus = ExecutionReport.TAG_OrdStatus.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdRejReason = ExecutionReport.TAG_OrdRejReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecRestatementReason = ExecutionReport.TAG_ExecRestatementReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = ExecutionReport.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = ExecutionReport.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = ExecutionReport.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = ExecutionReport.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = ExecutionReport.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = ExecutionReport.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = ExecutionReport.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = ExecutionReport.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = ExecutionReport.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = ExecutionReport.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = ExecutionReport.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = ExecutionReport.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = ExecutionReport.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = ExecutionReport.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = ExecutionReport.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = ExecutionReport.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = ExecutionReport.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = ExecutionReport.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuer = ExecutionReport.TAG_EncodedIssuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = ExecutionReport.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = ExecutionReport.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDesc = ExecutionReport.TAG_EncodedSecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = ExecutionReport.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = ExecutionReport.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CashOrderQty = ExecutionReport.TAG_CashOrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = ExecutionReport.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = ExecutionReport.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = ExecutionReport.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PegDifference = ExecutionReport.TAG_PegDifference.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionInst = ExecutionReport.TAG_DiscretionInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionOffset = ExecutionReport.TAG_DiscretionOffset.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = ExecutionReport.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ComplianceID = ExecutionReport.TAG_ComplianceID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SolicitedFlag = ExecutionReport.TAG_SolicitedFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = ExecutionReport.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EffectiveTime = ExecutionReport.TAG_EffectiveTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireDate = ExecutionReport.TAG_ExpireDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = ExecutionReport.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = ExecutionReport.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = ExecutionReport.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastShares = ExecutionReport.TAG_LastShares.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastPx = ExecutionReport.TAG_LastPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastSpotRate = ExecutionReport.TAG_LastSpotRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastForwardPoints = ExecutionReport.TAG_LastForwardPoints.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastMkt = ExecutionReport.TAG_LastMkt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TradingSessionID = ExecutionReport.TAG_TradingSessionID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LastCapacity = ExecutionReport.TAG_LastCapacity.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LeavesQty = ExecutionReport.TAG_LeavesQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CumQty = ExecutionReport.TAG_CumQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_AvgPx = ExecutionReport.TAG_AvgPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DayOrderQty = ExecutionReport.TAG_DayOrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DayCumQty = ExecutionReport.TAG_DayCumQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DayAvgPx = ExecutionReport.TAG_DayAvgPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_GTBookingInst = ExecutionReport.TAG_GTBookingInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TradeDate = ExecutionReport.TAG_TradeDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = ExecutionReport.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ReportToExch = ExecutionReport.TAG_ReportToExch.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = ExecutionReport.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = ExecutionReport.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_GrossTradeAmt = ExecutionReport.TAG_GrossTradeAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrAmt = ExecutionReport.TAG_SettlCurrAmt.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = ExecutionReport.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrFxRate = ExecutionReport.TAG_SettlCurrFxRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrFxRateCalc = ExecutionReport.TAG_SettlCurrFxRateCalc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HandlInst = ExecutionReport.TAG_HandlInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MinQty = ExecutionReport.TAG_MinQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxFloor = ExecutionReport.TAG_MaxFloor.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OpenClose = ExecutionReport.TAG_OpenClose.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxShow = ExecutionReport.TAG_MaxShow.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = ExecutionReport.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedTextLen = ExecutionReport.TAG_EncodedTextLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedText = ExecutionReport.TAG_EncodedText.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate2 = ExecutionReport.TAG_FutSettDate2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty2 = ExecutionReport.TAG_OrderQty2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingFirm = ExecutionReport.TAG_ClearingFirm.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingAccount = ExecutionReport.TAG_ClearingAccount.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MultiLegReportingType = ExecutionReport.TAG_MultiLegReportingType.ToString() + TAG_DELIM;

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
				if (_message.SecondaryOrderID != null && _message.SecondaryOrderID.Length > 0)
					sb.Append(TAG_PREFIX_SecondaryOrderID).Append(_message.SecondaryOrderID).Append(FIELD_DELIM);
				if (_message.ClOrdID != null && _message.ClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.OrigClOrdID != null && _message.OrigClOrdID.Length > 0)
					sb.Append(TAG_PREFIX_OrigClOrdID).Append(_message.OrigClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.NoContraBrokers != 0)
					sb.Append(TAG_PREFIX_NoContraBrokers).Append(_message.NoContraBrokers).Append(FIELD_DELIM);
				if (_message.ListID != null && _message.ListID.Length > 0)
					sb.Append(TAG_PREFIX_ListID).Append(_message.ListID).Append(FIELD_DELIM);
				if (_message.ExecID != null && _message.ExecID.Length > 0)
					sb.Append(TAG_PREFIX_ExecID).Append(_message.ExecID).Append(FIELD_DELIM);
				if (_message.ExecTransType != '\0')
					sb.Append(TAG_PREFIX_ExecTransType).Append(_message.ExecTransType).Append(FIELD_DELIM);
				if (_message.ExecRefID != null && _message.ExecRefID.Length > 0)
					sb.Append(TAG_PREFIX_ExecRefID).Append(_message.ExecRefID).Append(FIELD_DELIM);
				if (_message.ExecType != '\0')
					sb.Append(TAG_PREFIX_ExecType).Append(_message.ExecType).Append(FIELD_DELIM);
				if (_message.OrdStatus != '\0')
					sb.Append(TAG_PREFIX_OrdStatus).Append(_message.OrdStatus).Append(FIELD_DELIM);
				if (_message.OrdRejReason != 0)
					sb.Append(TAG_PREFIX_OrdRejReason).Append(_message.OrdRejReason).Append(FIELD_DELIM);
				if (_message.ExecRestatementReason != 0)
					sb.Append(TAG_PREFIX_ExecRestatementReason).Append(_message.ExecRestatementReason).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.CashOrderQty != 0)
					sb.Append(TAG_PREFIX_CashOrderQty).Append(_message.CashOrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.PegDifference != 0)
					sb.Append(TAG_PREFIX_PegDifference).Append(_message.PegDifference).Append(FIELD_DELIM);
				if (_message.DiscretionInst != '\0')
					sb.Append(TAG_PREFIX_DiscretionInst).Append(_message.DiscretionInst).Append(FIELD_DELIM);
				if (_message.DiscretionOffset != 0)
					sb.Append(TAG_PREFIX_DiscretionOffset).Append(_message.DiscretionOffset).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.ComplianceID != null && _message.ComplianceID.Length > 0)
					sb.Append(TAG_PREFIX_ComplianceID).Append(_message.ComplianceID).Append(FIELD_DELIM);
				if (_message.SolicitedFlag)
					sb.Append(TAG_PREFIX_SolicitedFlag).Append(ToFIXBoolean(_message.SolicitedFlag)).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.EffectiveTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_EffectiveTime).Append(ToFIXUTCTimestamp(_message.EffectiveTime)).Append(FIELD_DELIM);
				if (_message.ExpireDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireDate).Append(ToFIXLocalMktDate(_message.ExpireDate)).Append(FIELD_DELIM);
				if (_message.ExpireTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.ExecInst != null && _message.ExecInst.Length > 0)
					sb.Append(TAG_PREFIX_ExecInst).Append(_message.ExecInst).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.LastShares != 0)
					sb.Append(TAG_PREFIX_LastShares).Append(_message.LastShares).Append(FIELD_DELIM);
				if (_message.LastPx != 0)
					sb.Append(TAG_PREFIX_LastPx).Append(_message.LastPx).Append(FIELD_DELIM);
				if (_message.LastSpotRate != 0)
					sb.Append(TAG_PREFIX_LastSpotRate).Append(_message.LastSpotRate).Append(FIELD_DELIM);
				if (_message.LastForwardPoints != 0)
					sb.Append(TAG_PREFIX_LastForwardPoints).Append(_message.LastForwardPoints).Append(FIELD_DELIM);
				if (_message.LastMkt != null && _message.LastMkt.Length > 0)
					sb.Append(TAG_PREFIX_LastMkt).Append(_message.LastMkt).Append(FIELD_DELIM);
				if (_message.TradingSessionID != null && _message.TradingSessionID.Length > 0)
					sb.Append(TAG_PREFIX_TradingSessionID).Append(_message.TradingSessionID).Append(FIELD_DELIM);
				if (_message.LastCapacity != '\0')
					sb.Append(TAG_PREFIX_LastCapacity).Append(_message.LastCapacity).Append(FIELD_DELIM);
				if (_message.LeavesQty != 0)
					sb.Append(TAG_PREFIX_LeavesQty).Append(_message.LeavesQty).Append(FIELD_DELIM);
				if (_message.CumQty != 0)
					sb.Append(TAG_PREFIX_CumQty).Append(_message.CumQty).Append(FIELD_DELIM);
				if (_message.AvgPx != 0)
					sb.Append(TAG_PREFIX_AvgPx).Append(_message.AvgPx).Append(FIELD_DELIM);
				if (_message.DayOrderQty != 0)
					sb.Append(TAG_PREFIX_DayOrderQty).Append(_message.DayOrderQty).Append(FIELD_DELIM);
				if (_message.DayCumQty != 0)
					sb.Append(TAG_PREFIX_DayCumQty).Append(_message.DayCumQty).Append(FIELD_DELIM);
				if (_message.DayAvgPx != 0)
					sb.Append(TAG_PREFIX_DayAvgPx).Append(_message.DayAvgPx).Append(FIELD_DELIM);
				if (_message.GTBookingInst != 0)
					sb.Append(TAG_PREFIX_GTBookingInst).Append(_message.GTBookingInst).Append(FIELD_DELIM);
				if (_message.TradeDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_TradeDate).Append(ToFIXLocalMktDate(_message.TradeDate)).Append(FIELD_DELIM);
				if (_message.TransactTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.ReportToExch)
					sb.Append(TAG_PREFIX_ReportToExch).Append(ToFIXBoolean(_message.ReportToExch)).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.GrossTradeAmt != 0)
					sb.Append(TAG_PREFIX_GrossTradeAmt).Append(_message.GrossTradeAmt).Append(FIELD_DELIM);
				if (_message.SettlCurrAmt != 0)
					sb.Append(TAG_PREFIX_SettlCurrAmt).Append(_message.SettlCurrAmt).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.SettlCurrFxRate != 0)
					sb.Append(TAG_PREFIX_SettlCurrFxRate).Append(_message.SettlCurrFxRate).Append(FIELD_DELIM);
				if (_message.SettlCurrFxRateCalc != '\0')
					sb.Append(TAG_PREFIX_SettlCurrFxRateCalc).Append(_message.SettlCurrFxRateCalc).Append(FIELD_DELIM);
				if (_message.HandlInst != '\0')
					sb.Append(TAG_PREFIX_HandlInst).Append(_message.HandlInst).Append(FIELD_DELIM);
				if (_message.MinQty != 0)
					sb.Append(TAG_PREFIX_MinQty).Append(_message.MinQty).Append(FIELD_DELIM);
				if (_message.MaxFloor != 0)
					sb.Append(TAG_PREFIX_MaxFloor).Append(_message.MaxFloor).Append(FIELD_DELIM);
				if (_message.OpenClose != '\0')
					sb.Append(TAG_PREFIX_OpenClose).Append(_message.OpenClose).Append(FIELD_DELIM);
				if (_message.MaxShow != 0)
					sb.Append(TAG_PREFIX_MaxShow).Append(_message.MaxShow).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
				if (_message.EncodedTextLen != 0)
					sb.Append(TAG_PREFIX_EncodedTextLen).Append(_message.EncodedTextLen).Append(FIELD_DELIM);
				if (_message.FutSettDate2 > DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate2).Append(ToFIXLocalMktDate(_message.FutSettDate2)).Append(FIELD_DELIM);
				if (_message.OrderQty2 != 0)
					sb.Append(TAG_PREFIX_OrderQty2).Append(_message.OrderQty2).Append(FIELD_DELIM);
				if (_message.ClearingFirm != null && _message.ClearingFirm.Length > 0)
					sb.Append(TAG_PREFIX_ClearingFirm).Append(_message.ClearingFirm).Append(FIELD_DELIM);
				if (_message.ClearingAccount != null && _message.ClearingAccount.Length > 0)
					sb.Append(TAG_PREFIX_ClearingAccount).Append(_message.ClearingAccount).Append(FIELD_DELIM);
				if (_message.MultiLegReportingType != '\0')
					sb.Append(TAG_PREFIX_MultiLegReportingType).Append(_message.MultiLegReportingType).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == ExecutionReport.TAG_OrderID)
					_message.OrderID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SecondaryOrderID)
					_message.SecondaryOrderID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_OrigClOrdID)
					_message.OrigClOrdID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == ExecutionReport.TAG_NoContraBrokers)
					_message.NoContraBrokers = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ListID)
					_message.ListID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ExecID)
					_message.ExecID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ExecTransType)
					_message.ExecTransType = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_ExecRefID)
					_message.ExecRefID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ExecType)
					_message.ExecType = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_OrdStatus)
					_message.OrdStatus = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_OrdRejReason)
					_message.OrdRejReason = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ExecRestatementReason)
					_message.ExecRestatementReason = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SettlmntTyp)
					_message.SettlmntTyp = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_FutSettDate)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == ExecutionReport.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == ExecutionReport.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == ExecutionReport.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == ExecutionReport.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == ExecutionReport.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Side)
					_message.Side = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_OrderQty)
					_message.OrderQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_CashOrderQty)
					_message.CashOrderQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_OrdType)
					_message.OrdType = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_Price)
					_message.Price = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_StopPx)
					_message.StopPx = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_PegDifference)
					_message.PegDifference = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_DiscretionInst)
					_message.DiscretionInst = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_DiscretionOffset)
					_message.DiscretionOffset = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Currency)
					_message.Currency = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ComplianceID)
					_message.ComplianceID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_SolicitedFlag)
					_message.SolicitedFlag = FromFIXBoolean(field.Value);
				else if (field.Tag == ExecutionReport.TAG_TimeInForce)
					_message.TimeInForce = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_EffectiveTime)
					_message.EffectiveTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ExpireDate)
					_message.ExpireDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ExpireTime)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ExecInst)
					_message.ExecInst = field.Value;
				else if (field.Tag == ExecutionReport.TAG_Rule80A)
					_message.Rule80A = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_LastShares)
					_message.LastShares = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_LastPx)
					_message.LastPx = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_LastSpotRate)
					_message.LastSpotRate = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_LastForwardPoints)
					_message.LastForwardPoints = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_LastMkt)
					_message.LastMkt = field.Value;
				else if (field.Tag == ExecutionReport.TAG_TradingSessionID)
					_message.TradingSessionID = field.Value;
				else if (field.Tag == ExecutionReport.TAG_LastCapacity)
					_message.LastCapacity = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_LeavesQty)
					_message.LeavesQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_CumQty)
					_message.CumQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_AvgPx)
					_message.AvgPx = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_DayOrderQty)
					_message.DayOrderQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_DayCumQty)
					_message.DayCumQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_DayAvgPx)
					_message.DayAvgPx = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_GTBookingInst)
					_message.GTBookingInst = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_TradeDate)
					_message.TradeDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == ExecutionReport.TAG_TransactTime)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ReportToExch)
					_message.ReportToExch = FromFIXBoolean(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Commission)
					_message.Commission = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_CommType)
					_message.CommType = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_GrossTradeAmt)
					_message.GrossTradeAmt = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SettlCurrAmt)
					_message.SettlCurrAmt = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SettlCurrency)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SettlCurrFxRate)
					_message.SettlCurrFxRate = double.Parse(field.Value);
				else if (field.Tag == ExecutionReport.TAG_SettlCurrFxRateCalc)
					_message.SettlCurrFxRateCalc = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_HandlInst)
					_message.HandlInst = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_MinQty)
					_message.MinQty = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_MaxFloor)
					_message.MaxFloor = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_OpenClose)
					_message.OpenClose = field.Value[0];
				else if (field.Tag == ExecutionReport.TAG_MaxShow)
					_message.MaxShow = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_Text)
					_message.Text = field.Value;
				else if (field.Tag == ExecutionReport.TAG_EncodedTextLen)
					_message.EncodedTextLen = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_FutSettDate2)
					_message.FutSettDate2 = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == ExecutionReport.TAG_OrderQty2)
					_message.OrderQty2 = ParseInt(field.Value);
				else if (field.Tag == ExecutionReport.TAG_ClearingFirm)
					_message.ClearingFirm = field.Value;
				else if (field.Tag == ExecutionReport.TAG_ClearingAccount)
					_message.ClearingAccount = field.Value;
				else if (field.Tag == ExecutionReport.TAG_MultiLegReportingType)
					_message.MultiLegReportingType = field.Value[0];
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderCancelReject : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = OrderCancelReject.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderCancelReject.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderCancelReject.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = OrderCancelReject.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderCancelReject.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderCancelReject.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderCancelReject.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderCancelReject.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderCancelReject.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = OrderCancelReject.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = OrderCancelReject.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = OrderCancelReject.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = OrderCancelReject.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = OrderCancelReject.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = OrderCancelReject.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = OrderCancelReject.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = OrderCancelReject.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = OrderCancelReject.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderCancelReject.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = OrderCancelReject.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderCancelReject.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = OrderCancelReject.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderCancelReject.TAG_Side.ToString() + TAG_DELIM;

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
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
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
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == OrderCancelReject.TAG_OrderID)
					_message.OrderID = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == OrderCancelReject.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == OrderCancelReject.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReject.TAG_Side)
					_message.Side = field.Value[0];
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperNews : MessageHelper
		{
			private static string TAG_PREFIX_OrigTime = News.TAG_OrigTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Urgency = News.TAG_Urgency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Headline = News.TAG_Headline.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedHeadlineLen = News.TAG_EncodedHeadlineLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedHeadline = News.TAG_EncodedHeadline.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoRoutingIDs = News.TAG_NoRoutingIDs.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RoutingType = News.TAG_RoutingType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RoutingID = News.TAG_RoutingID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoRelatedSym = News.TAG_NoRelatedSym.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RelatdSym = News.TAG_RelatdSym.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = News.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = News.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = News.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = News.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = News.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = News.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = News.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = News.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = News.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = News.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = News.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = News.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = News.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = News.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuer = News.TAG_EncodedIssuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = News.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = News.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDesc = News.TAG_EncodedSecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LinesOfText = News.TAG_LinesOfText.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = News.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_URLLink = News.TAG_URLLink.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RawDataLength = News.TAG_RawDataLength.ToString() + TAG_DELIM;

			private News _message;

			public MessageHelperNews(IMessage message)
				: base(message)
			{
				_message = (News)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.OrigTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_OrigTime).Append(ToFIXUTCTimestamp(_message.OrigTime)).Append(FIELD_DELIM);
				if (_message.Urgency != '\0')
					sb.Append(TAG_PREFIX_Urgency).Append(_message.Urgency).Append(FIELD_DELIM);
				if (_message.Headline != null && _message.Headline.Length > 0)
					sb.Append(TAG_PREFIX_Headline).Append(_message.Headline).Append(FIELD_DELIM);
				if (_message.EncodedHeadlineLen != 0)
					sb.Append(TAG_PREFIX_EncodedHeadlineLen).Append(_message.EncodedHeadlineLen).Append(FIELD_DELIM);

				_message.NoRoutingIDs = _message.RouteID.Count;
				if (_message.NoRoutingIDs > 0)
				{
					sb.Append(TAG_PREFIX_NoRoutingIDs).Append(_message.NoRoutingIDs).Append(FIELD_DELIM);
					NewsRouteID routeID;
					for (int i = 0; i < _message.NoRoutingIDs; i++)
					{
						routeID = _message.RouteID[i];
						if (routeID.RoutingType != 0)
							sb.Append(TAG_PREFIX_RoutingType).Append(routeID.RoutingType).Append(FIELD_DELIM);
						if (routeID.RoutingID != null && routeID.RoutingID.Length > 0)
							sb.Append(TAG_PREFIX_RoutingID).Append(routeID.RoutingID).Append(FIELD_DELIM);
					}
				}

				_message.NoRelatedSym = _message.RelatedSym.Count;
				if (_message.NoRelatedSym > 0)
				{
					sb.Append(TAG_PREFIX_NoRelatedSym).Append(_message.NoRelatedSym).Append(FIELD_DELIM);
					NewsRelatdSym relatdSym;
					for (int i = 0; i < _message.NoRelatedSym; i++)
					{
						relatdSym = _message.RelatedSym[i];
						if (relatdSym.RelatdSym != null && relatdSym.RelatdSym.Length > 0)
							sb.Append(TAG_PREFIX_RelatdSym).Append(relatdSym.RelatdSym).Append(FIELD_DELIM);
						if (relatdSym.SymbolSfx != null && relatdSym.SymbolSfx.Length > 0)
							sb.Append(TAG_PREFIX_SymbolSfx).Append(relatdSym.SymbolSfx).Append(FIELD_DELIM);
						if (relatdSym.SecurityID != null && relatdSym.SecurityID.Length > 0)
							sb.Append(TAG_PREFIX_SecurityID).Append(relatdSym.SecurityID).Append(FIELD_DELIM);
						if (relatdSym.IDSource != null && relatdSym.IDSource.Length > 0)
							sb.Append(TAG_PREFIX_IDSource).Append(relatdSym.IDSource).Append(FIELD_DELIM);
						if (relatdSym.SecurityType != null && relatdSym.SecurityType.Length > 0)
							sb.Append(TAG_PREFIX_SecurityType).Append(relatdSym.SecurityType).Append(FIELD_DELIM);
						if (relatdSym.MaturityMonthYear > DateTime.MinValue)
							sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(relatdSym.MaturityMonthYear)).Append(FIELD_DELIM);
						if (relatdSym.MaturityDay != 0)
							sb.Append(TAG_PREFIX_MaturityDay).Append(relatdSym.MaturityDay).Append(FIELD_DELIM);
						if (relatdSym.PutOrCall != 0)
							sb.Append(TAG_PREFIX_PutOrCall).Append(relatdSym.PutOrCall).Append(FIELD_DELIM);
						if (relatdSym.StrikePrice != 0)
							sb.Append(TAG_PREFIX_StrikePrice).Append(relatdSym.StrikePrice).Append(FIELD_DELIM);
						if (relatdSym.OptAttribute != '\0')
							sb.Append(TAG_PREFIX_OptAttribute).Append(relatdSym.OptAttribute).Append(FIELD_DELIM);
						if (relatdSym.ContractMultiplier != 0)
							sb.Append(TAG_PREFIX_ContractMultiplier).Append(relatdSym.ContractMultiplier).Append(FIELD_DELIM);
						if (relatdSym.CouponRate != 0)
							sb.Append(TAG_PREFIX_CouponRate).Append(relatdSym.CouponRate).Append(FIELD_DELIM);
						if (relatdSym.SecurityExchange != null && relatdSym.SecurityExchange.Length > 0)
							sb.Append(TAG_PREFIX_SecurityExchange).Append(relatdSym.SecurityExchange).Append(FIELD_DELIM);
						if (relatdSym.Issuer != null && relatdSym.Issuer.Length > 0)
							sb.Append(TAG_PREFIX_Issuer).Append(relatdSym.Issuer).Append(FIELD_DELIM);
						if (relatdSym.EncodedIssuerLen != 0)
							sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(relatdSym.EncodedIssuerLen).Append(FIELD_DELIM);
						if (relatdSym.SecurityDesc != null && relatdSym.SecurityDesc.Length > 0)
							sb.Append(TAG_PREFIX_SecurityDesc).Append(relatdSym.SecurityDesc).Append(FIELD_DELIM);
						if (relatdSym.EncodedSecurityDescLen != 0)
							sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(relatdSym.EncodedSecurityDescLen).Append(FIELD_DELIM);
					}
				}

				_message.LinesOfText = _message.Text.Count;
				if (_message.LinesOfText > 0)
				{
					sb.Append(TAG_PREFIX_LinesOfText).Append(_message.LinesOfText).Append(FIELD_DELIM);
					NewsText text;
					for (int i = 0; i < _message.LinesOfText; i++)
					{
						text = _message.Text[i];
						if (text.Text != null && text.Text.Length > 0)
							sb.Append(TAG_PREFIX_Text).Append(text.Text).Append(FIELD_DELIM);
					}
				}

				if (_message.URLLink != null && _message.URLLink.Length > 0)
					sb.Append(TAG_PREFIX_URLLink).Append(_message.URLLink).Append(FIELD_DELIM);
				if (_message.RawDataLength != 0)
					sb.Append(TAG_PREFIX_RawDataLength).Append(_message.RawDataLength).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == News.TAG_OrigTime)
					_message.OrigTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == News.TAG_Urgency)
					_message.Urgency = field.Value[0];
				else if (field.Tag == News.TAG_Headline)
					_message.Headline = field.Value;
				else if (field.Tag == News.TAG_EncodedHeadlineLen)
					_message.EncodedHeadlineLen = ParseInt(field.Value);

				else if (field.Tag == News.TAG_NoRoutingIDs)
					_message.NoRoutingIDs = ParseInt(field.Value);
				else if (field.Tag == News.TAG_RoutingType)
				{
					NewsRouteID routeID = new NewsRouteID();
					routeID.RoutingType = ParseInt(field.Value);
					_message.RouteID.Add(routeID);
				}
				else if (field.Tag == News.TAG_RoutingID)
					_message.RouteID.Last.RoutingID = field.Value;

				else if (field.Tag == News.TAG_NoRelatedSym)
					_message.NoRelatedSym = ParseInt(field.Value);
				else if (field.Tag == News.TAG_RelatdSym)
				{
					NewsRelatdSym relatdSym = new NewsRelatdSym();
					relatdSym.RelatdSym = field.Value;
					_message.RelatedSym.Add(relatdSym);
				}
				else if (field.Tag == News.TAG_SymbolSfx)
					_message.RelatedSym.Last.SymbolSfx = field.Value;
				else if (field.Tag == News.TAG_SecurityID)
					_message.RelatedSym.Last.SecurityID = field.Value;
				else if (field.Tag == News.TAG_IDSource)
					_message.RelatedSym.Last.IDSource = field.Value;
				else if (field.Tag == News.TAG_SecurityType)
					_message.RelatedSym.Last.SecurityType = field.Value;
				else if (field.Tag == News.TAG_MaturityMonthYear)
					_message.RelatedSym.Last.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == News.TAG_MaturityDay)
					_message.RelatedSym.Last.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == News.TAG_PutOrCall)
					_message.RelatedSym.Last.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == News.TAG_StrikePrice)
					_message.RelatedSym.Last.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == News.TAG_OptAttribute)
					_message.RelatedSym.Last.OptAttribute = field.Value[0];
				else if (field.Tag == News.TAG_ContractMultiplier)
					_message.RelatedSym.Last.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == News.TAG_CouponRate)
					_message.RelatedSym.Last.CouponRate = double.Parse(field.Value);
				else if (field.Tag == News.TAG_SecurityExchange)
					_message.RelatedSym.Last.SecurityExchange = field.Value;
				else if (field.Tag == News.TAG_Issuer)
					_message.RelatedSym.Last.Issuer = field.Value;
				else if (field.Tag == News.TAG_EncodedIssuerLen)
					_message.RelatedSym.Last.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == News.TAG_SecurityDesc)
					_message.RelatedSym.Last.SecurityDesc = field.Value;
				else if (field.Tag == News.TAG_EncodedSecurityDescLen)
					_message.RelatedSym.Last.EncodedSecurityDescLen = ParseInt(field.Value);

				else if (field.Tag == News.TAG_LinesOfText)
					_message.LinesOfText = ParseInt(field.Value);
				else if (field.Tag == News.TAG_Text)
				{
					NewsText text = new NewsText();
					text.Text = field.Value;
					_message.Text.Add(text);
				}

				else if (field.Tag == News.TAG_URLLink)
					_message.URLLink = field.Value;
				else if (field.Tag == News.TAG_RawDataLength)
					_message.RawDataLength = ParseInt(field.Value);

				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperEmail : MessageHelper
		{
			private Email _message;
			public MessageHelperEmail(IMessage message)
				: base(message)
			{
				_message = (Email)message;
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

		protected class MessageHelperNewOrderSingle : MessageHelper
		{
			private static string TAG_PREFIX_ClOrdID = NewOrderSingle.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = NewOrderSingle.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = NewOrderSingle.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = NewOrderSingle.TAG_Account.ToString() + TAG_DELIM;
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
			private static string TAG_PREFIX_SecurityType = NewOrderSingle.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = NewOrderSingle.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = NewOrderSingle.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = NewOrderSingle.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = NewOrderSingle.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = NewOrderSingle.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = NewOrderSingle.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = NewOrderSingle.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = NewOrderSingle.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = NewOrderSingle.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = NewOrderSingle.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuer = NewOrderSingle.TAG_EncodedIssuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = NewOrderSingle.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = NewOrderSingle.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDesc = NewOrderSingle.TAG_EncodedSecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PrevClosePx = NewOrderSingle.TAG_PrevClosePx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = NewOrderSingle.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LocateReqd = NewOrderSingle.TAG_LocateReqd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = NewOrderSingle.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = NewOrderSingle.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CashOrderQty = NewOrderSingle.TAG_CashOrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = NewOrderSingle.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = NewOrderSingle.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = NewOrderSingle.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = NewOrderSingle.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ComplianceID = NewOrderSingle.TAG_ComplianceID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SolicitedFlag = NewOrderSingle.TAG_SolicitedFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IOIid = NewOrderSingle.TAG_IOIid.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_QuoteID = NewOrderSingle.TAG_QuoteID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = NewOrderSingle.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EffectiveTime = NewOrderSingle.TAG_EffectiveTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireDate = NewOrderSingle.TAG_ExpireDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = NewOrderSingle.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_GTBookingInst = NewOrderSingle.TAG_GTBookingInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = NewOrderSingle.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = NewOrderSingle.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = NewOrderSingle.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ForexReq = NewOrderSingle.TAG_ForexReq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = NewOrderSingle.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = NewOrderSingle.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedTextLen = NewOrderSingle.TAG_EncodedTextLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedText = NewOrderSingle.TAG_EncodedText.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate2 = NewOrderSingle.TAG_FutSettDate2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty2 = NewOrderSingle.TAG_OrderQty2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OpenClose = NewOrderSingle.TAG_OpenClose.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CoveredOrUncovered = NewOrderSingle.TAG_CoveredOrUncovered.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CustomerOrFirm = NewOrderSingle.TAG_CustomerOrFirm.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxShow = NewOrderSingle.TAG_MaxShow.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PegDifference = NewOrderSingle.TAG_PegDifference.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionInst = NewOrderSingle.TAG_DiscretionInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionOffset = NewOrderSingle.TAG_DiscretionOffset.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingFirm = NewOrderSingle.TAG_ClearingFirm.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingAccount = NewOrderSingle.TAG_ClearingAccount.ToString() + TAG_DELIM;

			private NewOrderSingle _message;

			public MessageHelperNewOrderSingle(IMessage message)
				: base(message)
			{
				_message = (NewOrderSingle)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				sb.Append(TAG_PREFIX_ClOrdID).Append(_message.ClOrdID).Append(FIELD_DELIM);
				if (_message.ClientID != null && _message.ClientID.Length > 0)
					sb.Append(TAG_PREFIX_ClientID).Append(_message.ClientID).Append(FIELD_DELIM);
				if (_message.ExecBroker != null && _message.ExecBroker.Length > 0)
					sb.Append(TAG_PREFIX_ExecBroker).Append(_message.ExecBroker).Append(FIELD_DELIM);
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
				if (_message.FutSettDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate).Append(ToFIXLocalMktDate(_message.FutSettDate)).Append(FIELD_DELIM);
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
				sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.PrevClosePx != 0)
					sb.Append(TAG_PREFIX_PrevClosePx).Append(_message.PrevClosePx).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.LocateReqd)
					sb.Append(TAG_PREFIX_LocateReqd).Append(ToFIXBoolean(_message.LocateReqd)).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.CashOrderQty != 0)
					sb.Append(TAG_PREFIX_CashOrderQty).Append(_message.CashOrderQty).Append(FIELD_DELIM);
				sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.ComplianceID != null && _message.ComplianceID.Length > 0)
					sb.Append(TAG_PREFIX_ComplianceID).Append(_message.ComplianceID).Append(FIELD_DELIM);
				if (_message.SolicitedFlag)
					sb.Append(TAG_PREFIX_SolicitedFlag).Append(ToFIXBoolean(_message.SolicitedFlag)).Append(FIELD_DELIM);
				if (_message.IOIid != null && _message.IOIid.Length > 0)
					sb.Append(TAG_PREFIX_IOIid).Append(_message.IOIid).Append(FIELD_DELIM);
				if (_message.QuoteID != null && _message.QuoteID.Length > 0)
					sb.Append(TAG_PREFIX_QuoteID).Append(_message.QuoteID).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.EffectiveTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_EffectiveTime).Append(ToFIXUTCTimestamp(_message.EffectiveTime)).Append(FIELD_DELIM);
				if (_message.ExpireDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireDate).Append(ToFIXLocalMktDate(_message.ExpireDate)).Append(FIELD_DELIM);
				if (_message.ExpireTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.GTBookingInst != 0)
					sb.Append(TAG_PREFIX_GTBookingInst).Append(_message.GTBookingInst).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.ForexReq == true)
				{
					sb.Append(TAG_PREFIX_ForexReq).Append(ToFIXBoolean(_message.ForexReq)).Append(FIELD_DELIM);
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				}
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
				if (_message.EncodedTextLen != 0)
					sb.Append(TAG_PREFIX_EncodedTextLen).Append(_message.EncodedTextLen).Append(FIELD_DELIM);
				if (_message.FutSettDate2 > DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate2).Append(ToFIXLocalMktDate(_message.FutSettDate2)).Append(FIELD_DELIM);
				if (_message.OrderQty2 != 0)
					sb.Append(TAG_PREFIX_OrderQty2).Append(_message.OrderQty2).Append(FIELD_DELIM);
				if (_message.OpenClose != '\0')
					sb.Append(TAG_PREFIX_OpenClose).Append(_message.OpenClose).Append(FIELD_DELIM);
				if (_message.CoveredOrUncovered != 0)
					sb.Append(TAG_PREFIX_CoveredOrUncovered).Append(_message.CoveredOrUncovered).Append(FIELD_DELIM);
				if (_message.CustomerOrFirm != 0)
					sb.Append(TAG_PREFIX_CustomerOrFirm).Append(_message.CustomerOrFirm).Append(FIELD_DELIM);
				if (_message.MaxShow != 0)
					sb.Append(TAG_PREFIX_MaxShow).Append(_message.MaxShow).Append(FIELD_DELIM);
				if (_message.PegDifference != 0)
					sb.Append(TAG_PREFIX_PegDifference).Append(_message.PegDifference).Append(FIELD_DELIM);
				if (_message.DiscretionInst != '\0')
					sb.Append(TAG_PREFIX_DiscretionInst).Append(_message.DiscretionInst).Append(FIELD_DELIM);
				if (_message.DiscretionOffset != 0)
					sb.Append(TAG_PREFIX_DiscretionOffset).Append(_message.DiscretionOffset).Append(FIELD_DELIM);
				if (_message.ClearingFirm != null && _message.ClearingFirm.Length > 0)
					sb.Append(TAG_PREFIX_ClearingFirm).Append(_message.ClearingFirm).Append(FIELD_DELIM);
				if (_message.ClearingAccount != null && _message.ClearingAccount.Length > 0)
					sb.Append(TAG_PREFIX_ClearingAccount).Append(_message.ClearingAccount).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == NewOrderSingle.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_FutSettDate)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_HandlInst)
					_message.HandlInst = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_ExecInst)
					_message.ExecInst = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_MinQty)
					_message.MinQty = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_MaxFloor)
					_message.MaxFloor = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_ExDestination)
					_message.ExDestination = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_ProcessCode)
					_message.ProcessCode = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_PrevClosePx)
					_message.PrevClosePx = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_Side)
					_message.Side = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_LocateReqd)
					_message.LocateReqd = FromFIXBoolean(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_TransactTime)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_OrderQty)
					_message.OrderQty = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_CashOrderQty)
					_message.CashOrderQty = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_OrdType)
					_message.OrdType = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_Price)
					_message.Price = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_StopPx)
					_message.StopPx = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_Currency)
					_message.Currency = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_ComplianceID)
					_message.ComplianceID = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_SolicitedFlag)
					_message.SolicitedFlag = FromFIXBoolean(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_IOIid)
					_message.IOIid = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_QuoteID)
					_message.QuoteID = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_TimeInForce)
					_message.TimeInForce = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_EffectiveTime)
					_message.EffectiveTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_ExpireDate)
					_message.ExpireDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_ExpireTime)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_GTBookingInst)
					_message.GTBookingInst = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_Commission)
					_message.Commission = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_CommType)
					_message.CommType = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_Rule80A)
					_message.Rule80A = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_ForexReq)
					_message.ForexReq = FromFIXBoolean(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_SettlCurrency)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_Text)
					_message.Text = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_EncodedTextLen)
					_message.EncodedTextLen = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_FutSettDate2)
					_message.FutSettDate2 = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_OrderQty2)
					_message.OrderQty2 = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_OpenClose)
					_message.OpenClose = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_CoveredOrUncovered)
					_message.CoveredOrUncovered = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_CustomerOrFirm)
					_message.CustomerOrFirm = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_MaxShow)
					_message.MaxShow = ParseInt(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_PegDifference)
					_message.PegDifference = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_DiscretionInst)
					_message.DiscretionInst = field.Value[0];
				else if (field.Tag == NewOrderSingle.TAG_DiscretionOffset)
					_message.DiscretionOffset = double.Parse(field.Value);
				else if (field.Tag == NewOrderSingle.TAG_ClearingFirm)
					_message.ClearingFirm = field.Value;
				else if (field.Tag == NewOrderSingle.TAG_ClearingAccount)
					_message.ClearingAccount = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperNewOrderList : MessageHelper
		{
			private NewOrderList _message;
			public MessageHelperNewOrderList(IMessage message)
				: base(message)
			{
				_message = (NewOrderList)message;
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

		protected class MessageHelperOrderCancelRequest : MessageHelper
		{
			private static string TAG_PREFIX_OrigClOrdID = OrderCancelRequest.TAG_OrigClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderID = OrderCancelRequest.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderCancelRequest.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ListID = OrderCancelRequest.TAG_ListID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = OrderCancelRequest.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderCancelRequest.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderCancelRequest.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderCancelRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderCancelRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderCancelRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderCancelRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = OrderCancelRequest.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = OrderCancelRequest.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = OrderCancelRequest.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = OrderCancelRequest.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = OrderCancelRequest.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = OrderCancelRequest.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = OrderCancelRequest.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = OrderCancelRequest.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = OrderCancelRequest.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderCancelRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = OrderCancelRequest.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderCancelRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = OrderCancelRequest.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderCancelRequest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = OrderCancelRequest.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = OrderCancelRequest.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CashOrderQty = OrderCancelRequest.TAG_CashOrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ComplianceID = OrderCancelRequest.TAG_ComplianceID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SolicitedFlag = OrderCancelRequest.TAG_SolicitedFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = OrderCancelRequest.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedTextLen = OrderCancelRequest.TAG_EncodedTextLen.ToString() + TAG_DELIM;

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
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
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
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.TransactTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.CashOrderQty != 0)
					sb.Append(TAG_PREFIX_CashOrderQty).Append(_message.CashOrderQty).Append(FIELD_DELIM);
				if (_message.ComplianceID != null && _message.ComplianceID.Length > 0)
					sb.Append(TAG_PREFIX_ComplianceID).Append(_message.ComplianceID).Append(FIELD_DELIM);
				if (_message.SolicitedFlag)
					sb.Append(TAG_PREFIX_SolicitedFlag).Append(ToFIXBoolean(_message.SolicitedFlag)).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
				if (_message.EncodedTextLen != 0)
					sb.Append(TAG_PREFIX_EncodedTextLen).Append(_message.EncodedTextLen).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == OrderCancelRequest.TAG_OrigClOrdID)
					_message.OrigClOrdID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_OrderID)
					_message.OrderID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_ListID)
					_message.ListID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == OrderCancelRequest.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_Side)
					_message.Side = field.Value[0];
				else if (field.Tag == OrderCancelRequest.TAG_TransactTime)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_OrderQty)
					_message.OrderQty = ParseInt(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_CashOrderQty)
					_message.CashOrderQty = ParseInt(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_ComplianceID)
					_message.ComplianceID = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_SolicitedFlag)
					_message.SolicitedFlag = FromFIXBoolean(field.Value);
				else if (field.Tag == OrderCancelRequest.TAG_Text)
					_message.Text = field.Value;
				else if (field.Tag == OrderCancelRequest.TAG_EncodedTextLen)
					_message.EncodedTextLen = ParseInt(field.Value);
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
			private static string TAG_PREFIX_NoAllocs = OrderCancelReplaceRequest.TAG_NoAllocs.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlmntTyp = OrderCancelReplaceRequest.TAG_SettlmntTyp.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate = OrderCancelReplaceRequest.TAG_FutSettDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_HandlInst = OrderCancelReplaceRequest.TAG_HandlInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecInst = OrderCancelReplaceRequest.TAG_ExecInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MinQty = OrderCancelReplaceRequest.TAG_MinQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxFloor = OrderCancelReplaceRequest.TAG_MaxFloor.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExDestination = OrderCancelReplaceRequest.TAG_ExDestination.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_NoTradingSessions = OrderCancelReplaceRequest.TAG_NoTradingSessions.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderCancelReplaceRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderCancelReplaceRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderCancelReplaceRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderCancelReplaceRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = OrderCancelReplaceRequest.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = OrderCancelReplaceRequest.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = OrderCancelReplaceRequest.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = OrderCancelReplaceRequest.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = OrderCancelReplaceRequest.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = OrderCancelReplaceRequest.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = OrderCancelReplaceRequest.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = OrderCancelReplaceRequest.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = OrderCancelReplaceRequest.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderCancelReplaceRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = OrderCancelReplaceRequest.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderCancelReplaceRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = OrderCancelReplaceRequest.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Side = OrderCancelReplaceRequest.TAG_Side.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TransactTime = OrderCancelReplaceRequest.TAG_TransactTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty = OrderCancelReplaceRequest.TAG_OrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CashOrderQty = OrderCancelReplaceRequest.TAG_CashOrderQty.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrdType = OrderCancelReplaceRequest.TAG_OrdType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Price = OrderCancelReplaceRequest.TAG_Price.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StopPx = OrderCancelReplaceRequest.TAG_StopPx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PegDifference = OrderCancelReplaceRequest.TAG_PegDifference.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionInst = OrderCancelReplaceRequest.TAG_DiscretionInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_DiscretionOffset = OrderCancelReplaceRequest.TAG_DiscretionOffset.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ComplianceID = OrderCancelReplaceRequest.TAG_ComplianceID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SolicitedFlag = OrderCancelReplaceRequest.TAG_SolicitedFlag.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Currency = OrderCancelReplaceRequest.TAG_Currency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_TimeInForce = OrderCancelReplaceRequest.TAG_TimeInForce.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EffectiveTime = OrderCancelReplaceRequest.TAG_EffectiveTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireDate = OrderCancelReplaceRequest.TAG_ExpireDate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExpireTime = OrderCancelReplaceRequest.TAG_ExpireTime.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_GTBookingInst = OrderCancelReplaceRequest.TAG_GTBookingInst.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Commission = OrderCancelReplaceRequest.TAG_Commission.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CommType = OrderCancelReplaceRequest.TAG_CommType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Rule80A = OrderCancelReplaceRequest.TAG_Rule80A.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ForexReq = OrderCancelReplaceRequest.TAG_ForexReq.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SettlCurrency = OrderCancelReplaceRequest.TAG_SettlCurrency.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = OrderCancelReplaceRequest.TAG_Text.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedTextLen = OrderCancelReplaceRequest.TAG_EncodedTextLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_FutSettDate2 = OrderCancelReplaceRequest.TAG_FutSettDate2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OrderQty2 = OrderCancelReplaceRequest.TAG_OrderQty2.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OpenClose = OrderCancelReplaceRequest.TAG_OpenClose.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CoveredOrUncovered = OrderCancelReplaceRequest.TAG_CoveredOrUncovered.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CustomerOrFirm = OrderCancelReplaceRequest.TAG_CustomerOrFirm.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaxShow = OrderCancelReplaceRequest.TAG_MaxShow.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_LocateReqd = OrderCancelReplaceRequest.TAG_LocateReqd.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingFirm = OrderCancelReplaceRequest.TAG_ClearingFirm.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClearingAccount = OrderCancelReplaceRequest.TAG_ClearingAccount.ToString() + TAG_DELIM;

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
				if (_message.NoAllocs != 0)
					sb.Append(TAG_PREFIX_NoAllocs).Append(_message.NoAllocs).Append(FIELD_DELIM);
				if (_message.SettlmntTyp != '\0')
					sb.Append(TAG_PREFIX_SettlmntTyp).Append(_message.SettlmntTyp).Append(FIELD_DELIM);
				if (_message.FutSettDate > DateTime.MinValue)
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
				if (_message.NoTradingSessions != 0)
					sb.Append(TAG_PREFIX_NoTradingSessions).Append(_message.NoTradingSessions).Append(FIELD_DELIM);
				if (_message.Symbol != null && _message.Symbol.Length > 0)
					sb.Append(TAG_PREFIX_Symbol).Append(_message.Symbol).Append(FIELD_DELIM);
				if (_message.SymbolSfx != null && _message.SymbolSfx.Length > 0)
					sb.Append(TAG_PREFIX_SymbolSfx).Append(_message.SymbolSfx).Append(FIELD_DELIM);
				if (_message.SecurityID != null && _message.SecurityID.Length > 0)
					sb.Append(TAG_PREFIX_SecurityID).Append(_message.SecurityID).Append(FIELD_DELIM);
				if (_message.IDSource != null && _message.IDSource.Length > 0)
					sb.Append(TAG_PREFIX_IDSource).Append(_message.IDSource).Append(FIELD_DELIM);
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
				if (_message.TransactTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_TransactTime).Append(ToFIXUTCTimestamp(_message.TransactTime)).Append(FIELD_DELIM);
				if (_message.OrderQty != 0)
					sb.Append(TAG_PREFIX_OrderQty).Append(_message.OrderQty).Append(FIELD_DELIM);
				if (_message.CashOrderQty != 0)
					sb.Append(TAG_PREFIX_CashOrderQty).Append(_message.CashOrderQty).Append(FIELD_DELIM);
				if (_message.OrdType != '\0')
					sb.Append(TAG_PREFIX_OrdType).Append(_message.OrdType).Append(FIELD_DELIM);
				if (_message.Price != 0)
					sb.Append(TAG_PREFIX_Price).Append(_message.Price).Append(FIELD_DELIM);
				if (_message.StopPx != 0)
					sb.Append(TAG_PREFIX_StopPx).Append(_message.StopPx).Append(FIELD_DELIM);
				if (_message.PegDifference != 0)
					sb.Append(TAG_PREFIX_PegDifference).Append(_message.PegDifference).Append(FIELD_DELIM);
				if (_message.DiscretionInst != '\0')
					sb.Append(TAG_PREFIX_DiscretionInst).Append(_message.DiscretionInst).Append(FIELD_DELIM);
				if (_message.DiscretionOffset != 0)
					sb.Append(TAG_PREFIX_DiscretionOffset).Append(_message.DiscretionOffset).Append(FIELD_DELIM);
				if (_message.ComplianceID != null && _message.ComplianceID.Length > 0)
					sb.Append(TAG_PREFIX_ComplianceID).Append(_message.ComplianceID).Append(FIELD_DELIM);
				if (_message.SolicitedFlag)
					sb.Append(TAG_PREFIX_SolicitedFlag).Append(_message.SolicitedFlag).Append(FIELD_DELIM);
				if (_message.Currency != 0)
					sb.Append(TAG_PREFIX_Currency).Append(_message.Currency).Append(FIELD_DELIM);
				if (_message.TimeInForce != '\0')
					sb.Append(TAG_PREFIX_TimeInForce).Append(_message.TimeInForce).Append(FIELD_DELIM);
				if (_message.EffectiveTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_EffectiveTime).Append(ToFIXUTCTimestamp(_message.EffectiveTime)).Append(FIELD_DELIM);
				if (_message.ExpireDate > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireDate).Append(ToFIXLocalMktDate(_message.ExpireDate)).Append(FIELD_DELIM);
				if (_message.ExpireTime > DateTime.MinValue)
					sb.Append(TAG_PREFIX_ExpireTime).Append(ToFIXUTCTimestamp(_message.ExpireTime)).Append(FIELD_DELIM);
				if (_message.GTBookingInst != 0)
					sb.Append(TAG_PREFIX_GTBookingInst).Append(_message.GTBookingInst).Append(FIELD_DELIM);
				if (_message.Commission != 0)
					sb.Append(TAG_PREFIX_Commission).Append(_message.Commission).Append(FIELD_DELIM);
				if (_message.CommType != '\0')
					sb.Append(TAG_PREFIX_CommType).Append(_message.CommType).Append(FIELD_DELIM);
				if (_message.Rule80A != '\0')
					sb.Append(TAG_PREFIX_Rule80A).Append(_message.Rule80A).Append(FIELD_DELIM);
				if (_message.ForexReq)
					sb.Append(TAG_PREFIX_ForexReq).Append(_message.ForexReq).Append(FIELD_DELIM);
				if (_message.SettlCurrency != 0)
					sb.Append(TAG_PREFIX_SettlCurrency).Append(_message.SettlCurrency).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
				if (_message.EncodedTextLen != 0)
					sb.Append(TAG_PREFIX_EncodedTextLen).Append(_message.EncodedTextLen).Append(FIELD_DELIM);
				if (_message.FutSettDate2 > DateTime.MinValue)
					sb.Append(TAG_PREFIX_FutSettDate2).Append(ToFIXLocalMktDate(_message.FutSettDate2)).Append(FIELD_DELIM);
				if (_message.OrderQty2 != 0)
					sb.Append(TAG_PREFIX_OrderQty2).Append(_message.OrderQty2).Append(FIELD_DELIM);
				if (_message.OpenClose != '\0')
					sb.Append(TAG_PREFIX_OpenClose).Append(_message.OpenClose).Append(FIELD_DELIM);
				if (_message.CoveredOrUncovered != 0)
					sb.Append(TAG_PREFIX_CoveredOrUncovered).Append(_message.CoveredOrUncovered).Append(FIELD_DELIM);
				if (_message.CustomerOrFirm != 0)
					sb.Append(TAG_PREFIX_CustomerOrFirm).Append(_message.CustomerOrFirm).Append(FIELD_DELIM);
				if (_message.MaxShow != 0)
					sb.Append(TAG_PREFIX_MaxShow).Append(_message.MaxShow).Append(FIELD_DELIM);
				if (_message.LocateReqd)
					sb.Append(TAG_PREFIX_LocateReqd).Append(_message.LocateReqd).Append(FIELD_DELIM);
				if (_message.ClearingFirm != null && _message.ClearingFirm.Length > 0)
					sb.Append(TAG_PREFIX_ClearingFirm).Append(_message.ClearingFirm).Append(FIELD_DELIM);
				if (_message.ClearingAccount != null && _message.ClearingAccount.Length > 0)
					sb.Append(TAG_PREFIX_ClearingAccount).Append(_message.ClearingAccount).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == OrderCancelReplaceRequest.TAG_OrderID)
					_message.OrderID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OrigClOrdID)
					_message.OrigClOrdID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ListID)
					_message.ListID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_NoAllocs)
					_message.NoAllocs = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SettlmntTyp)
					_message.SettlmntTyp = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_FutSettDate)
					_message.FutSettDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_HandlInst)
					_message.HandlInst = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ExecInst)
					_message.ExecInst = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_MinQty)
					_message.MinQty = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_MaxFloor)
					_message.MaxFloor = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ExDestination)
					_message.ExDestination = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_NoTradingSessions)
					_message.NoTradingSessions = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Side)
					_message.Side = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_TransactTime)
					_message.TransactTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OrderQty)
					_message.OrderQty = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_CashOrderQty)
					_message.CashOrderQty = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OrdType)
					_message.OrdType = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Price)
					_message.Price = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_StopPx)
					_message.StopPx = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_PegDifference)
					_message.PegDifference = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_DiscretionInst)
					_message.DiscretionInst = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_DiscretionOffset)
					_message.DiscretionOffset = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ComplianceID)
					_message.ComplianceID = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SolicitedFlag)
					_message.SolicitedFlag = FromFIXBoolean(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Currency)
					_message.Currency = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_TimeInForce)
					_message.TimeInForce = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_EffectiveTime)
					_message.EffectiveTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ExpireDate)
					_message.ExpireDate = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ExpireTime)
					_message.ExpireTime = FromFIXUTCTimestamp(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_GTBookingInst)
					_message.GTBookingInst = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Commission)
					_message.Commission = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_CommType)
					_message.CommType = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Rule80A)
					_message.Rule80A = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ForexReq)
					_message.ForexReq = FromFIXBoolean(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_SettlCurrency)
					_message.SettlCurrency = double.Parse(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_Text)
					_message.Text = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_EncodedTextLen)
					_message.EncodedTextLen = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_FutSettDate2)
					_message.FutSettDate2 = FromFIXLocalMktDate(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OrderQty2)
					_message.OrderQty2 = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_OpenClose)
					_message.OpenClose = field.Value[0];
				else if (field.Tag == OrderCancelReplaceRequest.TAG_CoveredOrUncovered)
					_message.CoveredOrUncovered = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_CustomerOrFirm)
					_message.CustomerOrFirm = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_MaxShow)
					_message.MaxShow = ParseInt(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_LocateReqd)
					_message.LocateReqd = FromFIXBoolean(field.Value);
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ClearingFirm)
					_message.ClearingFirm = field.Value;
				else if (field.Tag == OrderCancelReplaceRequest.TAG_ClearingAccount)
					_message.ClearingAccount = field.Value;
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperOrderStatusRequest : MessageHelper
		{
			private static string TAG_PREFIX_OrderID = OrderStatusRequest.TAG_OrderID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClOrdID = OrderStatusRequest.TAG_ClOrdID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ClientID = OrderStatusRequest.TAG_ClientID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Account = OrderStatusRequest.TAG_Account.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ExecBroker = OrderStatusRequest.TAG_ExecBroker.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Symbol = OrderStatusRequest.TAG_Symbol.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SymbolSfx = OrderStatusRequest.TAG_SymbolSfx.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityID = OrderStatusRequest.TAG_SecurityID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_IDSource = OrderStatusRequest.TAG_IDSource.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityType = OrderStatusRequest.TAG_SecurityType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityMonthYear = OrderStatusRequest.TAG_MaturityMonthYear.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_MaturityDay = OrderStatusRequest.TAG_MaturityDay.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_PutOrCall = OrderStatusRequest.TAG_PutOrCall.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_StrikePrice = OrderStatusRequest.TAG_StrikePrice.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_OptAttribute = OrderStatusRequest.TAG_OptAttribute.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_ContractMultiplier = OrderStatusRequest.TAG_ContractMultiplier.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_CouponRate = OrderStatusRequest.TAG_CouponRate.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityExchange = OrderStatusRequest.TAG_SecurityExchange.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Issuer = OrderStatusRequest.TAG_Issuer.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedIssuerLen = OrderStatusRequest.TAG_EncodedIssuerLen.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_SecurityDesc = OrderStatusRequest.TAG_SecurityDesc.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_EncodedSecurityDescLen = OrderStatusRequest.TAG_EncodedSecurityDescLen.ToString() + TAG_DELIM;
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
				if (_message.Account != null && _message.Account.Length > 0)
					sb.Append(TAG_PREFIX_Account).Append(_message.Account).Append(FIELD_DELIM);
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
				if (_message.SecurityType != null && _message.SecurityType.Length > 0)
					sb.Append(TAG_PREFIX_SecurityType).Append(_message.SecurityType).Append(FIELD_DELIM);
				if (_message.MaturityMonthYear > DateTime.MinValue)
					sb.Append(TAG_PREFIX_MaturityMonthYear).Append(ToFIXMonthYear(_message.MaturityMonthYear)).Append(FIELD_DELIM);
				if (_message.MaturityDay != 0)
					sb.Append(TAG_PREFIX_MaturityDay).Append(_message.MaturityDay).Append(FIELD_DELIM);
				if (_message.PutOrCall != 0)
					sb.Append(TAG_PREFIX_PutOrCall).Append(_message.PutOrCall).Append(FIELD_DELIM);
				if (_message.StrikePrice != 0)
					sb.Append(TAG_PREFIX_StrikePrice).Append(_message.StrikePrice).Append(FIELD_DELIM);
				if (_message.OptAttribute != '\0')
					sb.Append(TAG_PREFIX_OptAttribute).Append(_message.OptAttribute).Append(FIELD_DELIM);
				if (_message.ContractMultiplier != 0)
					sb.Append(TAG_PREFIX_ContractMultiplier).Append(_message.ContractMultiplier).Append(FIELD_DELIM);
				if (_message.CouponRate != 0)
					sb.Append(TAG_PREFIX_CouponRate).Append(_message.CouponRate).Append(FIELD_DELIM);
				if (_message.SecurityExchange != null && _message.SecurityExchange.Length > 0)
					sb.Append(TAG_PREFIX_SecurityExchange).Append(_message.SecurityExchange).Append(FIELD_DELIM);
				if (_message.Issuer != null && _message.Issuer.Length > 0)
					sb.Append(TAG_PREFIX_Issuer).Append(_message.Issuer).Append(FIELD_DELIM);
				if (_message.EncodedIssuerLen != 0)
					sb.Append(TAG_PREFIX_EncodedIssuerLen).Append(_message.EncodedIssuerLen).Append(FIELD_DELIM);
				if (_message.SecurityDesc != null && _message.SecurityDesc.Length > 0)
					sb.Append(TAG_PREFIX_SecurityDesc).Append(_message.SecurityDesc).Append(FIELD_DELIM);
				if (_message.EncodedSecurityDescLen != 0)
					sb.Append(TAG_PREFIX_EncodedSecurityDescLen).Append(_message.EncodedSecurityDescLen).Append(FIELD_DELIM);
				if (_message.Side != '\0')
					sb.Append(TAG_PREFIX_Side).Append(_message.Side).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (field.Tag == OrderStatusRequest.TAG_OrderID)
					_message.OrderID = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_ClOrdID)
					_message.ClOrdID = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_ClientID)
					_message.ClientID = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_Account)
					_message.Account = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_ExecBroker)
					_message.ExecBroker = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_Symbol)
					_message.Symbol = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_SymbolSfx)
					_message.SymbolSfx = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_SecurityID)
					_message.SecurityID = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_IDSource)
					_message.IDSource = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_SecurityType)
					_message.SecurityType = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_MaturityMonthYear)
					_message.MaturityMonthYear = FromFIXMonthYear(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_MaturityDay)
					_message.MaturityDay = byte.Parse(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_PutOrCall)
					_message.PutOrCall = ParseInt(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_StrikePrice)
					_message.StrikePrice = double.Parse(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_OptAttribute)
					_message.OptAttribute = field.Value[0];
				else if (field.Tag == OrderStatusRequest.TAG_ContractMultiplier)
					_message.ContractMultiplier = double.Parse(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_CouponRate)
					_message.CouponRate = double.Parse(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_SecurityExchange)
					_message.SecurityExchange = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_Issuer)
					_message.Issuer = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_EncodedIssuerLen)
					_message.EncodedIssuerLen = ParseInt(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_SecurityDesc)
					_message.SecurityDesc = field.Value;
				else if (field.Tag == OrderStatusRequest.TAG_EncodedSecurityDescLen)
					_message.EncodedSecurityDescLen = ParseInt(field.Value);
				else if (field.Tag == OrderStatusRequest.TAG_Side)
					_message.Side = field.Value[0];
				else
					base.ParseField(field);
			}
		}

		protected class MessageHelperAllocation : MessageHelper
		{
			private Allocation _message;
			public MessageHelperAllocation(IMessage message)
				: base(message)
			{
				_message = (Allocation)message;
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

		protected class MessageHelperListCancelRequest : MessageHelper
		{
			private ListCancelRequest _message;
			public MessageHelperListCancelRequest(IMessage message)
				: base(message)
			{
				_message = (ListCancelRequest)message;
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

		protected class MessageHelperListExecute : MessageHelper
		{
			private ListExecute _message;
			public MessageHelperListExecute(IMessage message)
				: base(message)
			{
				_message = (ListExecute)message;
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

		protected class MessageHelperListStatusRequest : MessageHelper
		{
			private ListStatusRequest _message;
			public MessageHelperListStatusRequest(IMessage message)
				: base(message)
			{
				_message = (ListStatusRequest)message;
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

		protected class MessageHelperListStatus : MessageHelper
		{
			private ListStatus _message;
			public MessageHelperListStatus(IMessage message)
				: base(message)
			{
				_message = (ListStatus)message;
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

		protected class MessageHelperAllocationACK : MessageHelper
		{
			private AllocationACK _message;
			public MessageHelperAllocationACK(IMessage message)
				: base(message)
			{
				_message = (AllocationACK)message;
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

		protected class MessageHelperDontKnowTrade : MessageHelper
		{
			private DontKnowTrade _message;
			public MessageHelperDontKnowTrade(IMessage message)
				: base(message)
			{
				_message = (DontKnowTrade)message;
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

		protected class MessageHelperQuoteRequest : MessageHelper
		{
			private QuoteRequest _message;
			public MessageHelperQuoteRequest(IMessage message)
				: base(message)
			{
				_message = (QuoteRequest)message;
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

		protected class MessageHelperQuote : MessageHelper
		{
			private Quote _message;
			public MessageHelperQuote(IMessage message)
				: base(message)
			{
				_message = (Quote)message;
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

		protected class MessageHelperBusinessMessageReject : MessageHelper
		{
			private static string TAG_PREFIX_RefSeqNum = BusinessMessageReject.TAG_RefSeqNum.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_RefMsgType = BusinessMessageReject.TAG_RefMsgType.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BusinessRejectRefID = BusinessMessageReject.TAG_BusinessRejectRefID.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_BusinessRejectReason = BusinessMessageReject.TAG_BusinessRejectReason.ToString() + TAG_DELIM;
			private static string TAG_PREFIX_Text = BusinessMessageReject.TAG_Text.ToString() + TAG_DELIM;

			private BusinessMessageReject _message;

			public MessageHelperBusinessMessageReject(IMessage message)
				: base(message)
			{
				_message = (BusinessMessageReject)message;
			}

			public override void BuildBody(StringBuilder sb)
			{
				base.BuildBody(sb);
				if (_message.RefSeqNum > 0)
					sb.Append(TAG_PREFIX_RefSeqNum).Append(_message.RefSeqNum).Append(FIELD_DELIM);
				if (_message.RefMsgType != null && _message.RefMsgType.Length > 0)
					sb.Append(TAG_PREFIX_RefMsgType).Append(_message.RefMsgType).Append(FIELD_DELIM);
				if (_message.BusinessRejectRefID != null && _message.BusinessRejectRefID.Length > 0)
					sb.Append(TAG_PREFIX_BusinessRejectRefID).Append(_message.BusinessRejectRefID).Append(FIELD_DELIM);
				if (_message.BusinessRejectReason >= 0)
					sb.Append(TAG_PREFIX_BusinessRejectReason).Append(_message.BusinessRejectReason).Append(FIELD_DELIM);
				if (_message.Text != null && _message.Text.Length > 0)
					sb.Append(TAG_PREFIX_Text).Append(_message.Text).Append(FIELD_DELIM);
			}

			public override void ParseField(IField field)
			{
				if (BusinessMessageReject.TAG_RefSeqNum == field.Tag)
					_message.RefSeqNum = ParseInt(field.Value);
				else if (BusinessMessageReject.TAG_RefMsgType == field.Tag)
					_message.RefMsgType = field.Value;
				else if (BusinessMessageReject.TAG_BusinessRejectRefID == field.Tag)
					_message.BusinessRejectRefID = field.Value;
				else if (BusinessMessageReject.TAG_BusinessRejectReason == field.Tag)
					_message.BusinessRejectReason = ParseInt(field.Value);
				else if (BusinessMessageReject.TAG_Text == field.Tag)
					_message.Text = field.Value;
				else
					base.ParseField(field);
			}
		}
	}
}
