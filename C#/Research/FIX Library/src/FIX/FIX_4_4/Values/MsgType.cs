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

namespace FIX4NET.FIX.FIX_4_4.Values
{
	public class MsgType : FIX.Values.MsgType
	{
		public const string BusinessMessageReject = "j";
		public const string UserRequest = "BE";
		public const string UserResponse = "BF";
		public const string Advertisement = "7";
		public const string IndicationOfInterest = "6";
		public const string News = "B";
		public const string Email = "C";
		public const string QuoteRequest = "R";
		public const string QuoteResponse = "AJ";
		public const string QuoteRequestReject = "AG";
		public const string RFQRequest = "AH";
		public const string Quote = "S";
		public const string QuoteCancel = "Z";
		public const string QuoteStatusRequest = "a";
		public const string QuoteStatusReport = "AI";
		public const string MassQuote = "i";
		public const string MassQuoteAcknowledgement = "b";
		public const string MarketDataRequest = "V";
		public const string MarketDataSnapshotFullRefresh = "W";
		public const string MarketDataIncrementalRefresh = "X";
		public const string MarketDataRequestReject = "Y";
		public const string SecurityDefinitionRequest = "c";
		public const string SecurityDefinition = "d";
		public const string SecurityTypeRequest = "v";
		public const string SecurityTypes = "w";
		public const string SecurityListRequest = "x";
		public const string SecurityList = "y";
		public const string DerivativeSecurityListRequest = "z";
		public const string DerivativeSecurityList = "AA";
		public const string SecurityStatusRequest = "e";
		public const string SecurityStatus = "f";
		public const string TradingSessionStatusRequest = "g";
		public const string TradingSessionStatus = "h";
		public const string NewOrderSingle = "D";
		public const string ExecutionReport = "8";
		public const string DontKnowTrade = "Q";
		public const string OrderCancelReplaceRequest = "G";
		public const string OrderCancelRequest = "F";
		public const string OrderCancelReject = "9";
		public const string OrderStatusRequest = "H";
		public const string OrderMassCancelRequest = "q";
		public const string OrderMassCancelReport = "r";
		public const string OrderMassStatusRequest = "AF";
		public const string NewOrderCross = "s";
		public const string CrossOrderCancelReplaceRequest = "t";
		public const string CrossOrderCancelRequest = "u";
		public const string NewOrderMultileg = "AB";
		public const string MultilegOrderCancelReplaceRequest = "AC";
		public const string BidRequest = "k";
		public const string BidResponse = "l";
		public const string NewOrderList = "E";
		public const string ListStrikePrice = "m";
		public const string ListStatus = "N";
		public const string ListExecute = "L";
		public const string ListCancelRequest = "K";
		public const string ListStatusRequest = "M";
		public const string AllocationInstruction = "J";
		public const string AllocationInstructionAck = "P";
		public const string AllocationReport = "AS";
		public const string AllocationReportAck = "AT";
		public const string Confirmation = "AK";
		public const string ConfirmationAck = "AU";
		public const string ConfirmationRequest = "BH";
		public const string SettlementInstructions = "T";
		public const string SettlementInstructionRequest = "AV";
		public const string TradeCaptureReportRequest = "AD";
		public const string TradeCaptureReportRequestAck = "AQ";
		public const string TradeCaptureReport = "AE";
		public const string TradeCaptureReportAck = "AR";
		public const string RegistrationInstructions = "o";
		public const string RegistrationInstructionsResponse = "p";
		public const string PositionMaintenanceRequest = "AL";
		public const string PositionMaintenanceReport = "AM";
		public const string RequestForPositions = "AN";
		public const string RequestForPositionsAck = "AO";
		public const string PositionReport = "AP";
		public const string AssignmentReport = "AW";
		public const string CollateralRequest = "AX";
		public const string CollateralAssignment = "AY";
		public const string CollateralResponse = "AZ";
		public const string CollateralReport = "BA";
		public const string CollateralInquiry = "BB";
		public const string NetworkStatusRequest = "BC";
		public const string NetworkStatusResponse = "BD";
		public const string CollateralInquiryAck = "BG";
	}
}
