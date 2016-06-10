#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Text;

namespace TradingClientSample
{
	/// <summary>
	/// Generic Order.
	/// </summary>
	public class Order : ICloneable
	{
		public Order(string clientOrderID, OrderType type, OrderSide side, string symbol)
		{
		    this.clientOrderID = clientOrderID;
            this.type = type;
            this.side = side;			
			this.symbol = symbol;		    
		}
		
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			
			builder.Append("Order [Symbol=" + symbol);
			if(null != clientOrderID)
			{
                builder.Append(", ClientOrderID=" + clientOrderID);
			}
			if(null != orderID)
			{
				builder.Append(", OrderID=" + orderID);
			}

			builder.Append(", Currency=" + currency);
			builder.Append(", Side=" + side);
			builder.Append(", TransactTime=" + transactTime);
			builder.Append(", Quantity=" + quantity);
			builder.Append(", TimeInForce=" + timeInForce);
			builder.Append(", Type=" + type);
			builder.Append(", LastFillPrice=" + lastFillPrice);			
			builder.Append(']');
			
			return builder.ToString();
		}

		public Object Clone()
		{
			Order clone = (Order) MemberwiseClone();
			return clone;
		}

		private string currency;

		public string Currency
		{
			get { return currency; }
            set { currency = value; }
		}

		public string Symbol
		{
			get { return symbol; }
		}

		public OrderSide Side
		{
			get { return side; }
			set { side = value; }
		}

		public void FlipSide()
		{
			if (OrderSide.Sell == side)
			{
				side = OrderSide.Buy;
			}
			else
			{
				side = OrderSide.Sell;
			}
		}

		public double Quantity
		{
			get { return quantity; }
            set { quantity = value; }
		}

		public OrderType Type
		{
			get { return type; }
		}

		public TimeInForce InForce
		{
			get { return timeInForce; }
			set { timeInForce = value; }
		}

	    private string clientOrderID;

        private string originalClientOrderID;

		public string ClientOrderID
		{
			get { return clientOrderID; }
			set { clientOrderID = value; }
		}

		public string OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

		public DateTime TransactTime
		{
			get { return transactTime; }
			set { transactTime = value; }
		}

		private double lastFillPrice;

		/// <summary>
		/// The price of last fill.
		/// </summary>
		public double LastFillPrice
		{
			get { return lastFillPrice; }
			set { lastFillPrice = value; }
		}

	    private double filledQuantity;

		private string orderID;

		private string symbol;

		public enum OrderSide
		{
			Buy = 1,
			Sell = 2
		} ;

		private OrderSide side;

		private double quantity;

		public enum TimeInForce
		{
			Unknown = 0,
			Day = '0',
			GoodTillCancel = '1',
			ImmediateOrCancel = '3',
			FillOrKill = '4',
			GoodTillDate = '6',
			GoodForSeconds = 'X'
		} ;		

		private TimeInForce timeInForce;

		private DateTime transactTime;
	    
	    private string securityID;

		public enum OrderType
		{
			Unknown = '0',
            Market = '1',
            Limit = '2',
			Stop = '3',
            StopLimit = '4',
			ForeignExchangeMarketOrder = 'C',
			ForeignExchangeLimitOrder = 'F',
			ForeignExchangeIcebergOrder = 'Z'
		} ;		

		private OrderType type;

	    private string text;
		
		public OrderStatus Status
		{
			get { return status; }
			set { status = value; }
		}
	    
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

	    public string SecurityID
	    {
	        get { return securityID; }
	        set { securityID = value; }
	    }

	    public string Text
	    {
	        get { return text; }
	        set { text = value; }
	    }

        /// <summary>
        /// Total number of shares filled.
        /// </summary>
	    public double FilledQuantity
	    {
	        get { return filledQuantity; }
	        set { filledQuantity = value; }
	    }

	    public string OriginalClientOrderID
	    {
	        get { return originalClientOrderID; }
	        set { originalClientOrderID = value; }
	    }


	    public enum OrderStatus
		{
			New = '0',
			PartialFill = '1',
			Fill = '2',
			DoneForDay = '3',
			Canceled = '4',
			Replace = '5',
			PendingCancel = '6',
			Stopped = '7',
			Rejected = '8',
			Suspended = '9',
			PendingNew = 'A',
			Calculated = 'B',
			Expired = 'C',
			Restated = 'D',
			PendingReplace = 'E'
		}

		private OrderStatus status = OrderStatus.PendingNew;
	}
}