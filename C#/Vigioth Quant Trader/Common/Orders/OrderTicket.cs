using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Orders
{
    public sealed class OrderTicket
    {
        private readonly object _orderEventsLock = new object();
        private readonly object _updateRequestsLock = new object();
        private readonly object _setCancelRequestLock = new object();
        private Order _order;
        private OrderStatus? _orderStatusOverride;
        private CancelOrderRequest _cancelRequest;
        private int _quantityFilled;
        private decimal _averageFillPrice;
        private readonly int _orderId;
        private readonly List<OrderEvent> _orderEvents; 
        private readonly SubmitOrderRequest _submitRequest;
        private readonly ManualResetEvent _orderStatusClosedEvent;
        private readonly List<UpdateOrderRequest> _updateRequests;
        private readonly SecurityTransactionManager _transactionManager;
        public int OrderId
        {
            get { return _orderId; }
        }
        public OrderStatus Status
        {
            get
            {
                if (_orderStatusOverride.HasValue) return _orderStatusOverride.Value;
                return _order == null ? OrderStatus.New : _order.Status;
            }
        }
        public Symbol Symbol
        {
            get { return _submitRequest.Symbol; }
        }
        public SecurityType SecurityType
        {
            get { return _submitRequest.SecurityType; }
        }
        public int Quantity
        {
            get { return _order == null ? _submitRequest.Quantity : _order.Quantity; }
        }
        public decimal AverageFillPrice
        {
            get { return _averageFillPrice; }
        }
        public decimal QuantityFilled
        {
            get { return _quantityFilled; }
        }
        public DateTime Time
        {
            get { return GetMostRecentOrderRequest().Time; }
        }
        public OrderType OrderType
        {
            get { return _submitRequest.OrderType; }
        }
        public string Tag 
        {
            get { return _order == null ? _submitRequest.Tag : _order.Tag; }
        }
        public SubmitOrderRequest SubmitRequest
        {
            get { return _submitRequest; }
        }
        public IReadOnlyList<UpdateOrderRequest> UpdateRequests
        {
            get
            {
                lock (_updateRequestsLock)
                {
                    return _updateRequests.ToList();
                }
            }
        }
        public CancelOrderRequest CancelRequest
        {
            get { return _cancelRequest; }
        }
        public IReadOnlyList<OrderEvent> OrderEvents
        {
            get
            {
                lock (_orderEventsLock)
                {
                    return _orderEvents.ToList();
                }
            }
        }
        public WaitHandle OrderClosed
        {
            get { return _orderStatusClosedEvent; }
        }
        public OrderTicket(SecurityTransactionManager transactionManager, SubmitOrderRequest submitRequest)
        {
            _submitRequest = submitRequest;
            _orderId = submitRequest.OrderId;
            _transactionManager = transactionManager;
            _orderEvents = new List<OrderEvent>();
            _updateRequests = new List<UpdateOrderRequest>();
            _orderStatusClosedEvent = new ManualResetEvent(false);
        }
        public decimal Get(OrderField field)
        {
            switch (field)
            {
                case OrderField.LimitPrice:
                    if (_submitRequest.OrderType == OrderType.Limit)
                    {
                        return AccessOrder<LimitOrder>(this, field, o => o.LimitPrice, r => r.LimitPrice);
                    }
                    if (_submitRequest.OrderType == OrderType.StopLimit)
                    {
                        return AccessOrder<StopLimitOrder>(this, field, o => o.LimitPrice, r => r.LimitPrice);
                    }
                    break;
                case OrderField.StopPrice:
                    if (_submitRequest.OrderType == OrderType.StopLimit)
                    {
                        return AccessOrder<StopLimitOrder>(this, field, o => o.StopPrice, r => r.StopPrice);
                    }
                    if (_submitRequest.OrderType == OrderType.StopMarket)
                    {
                        return AccessOrder<StopMarketOrder>(this, field, o => o.StopPrice, r => r.StopPrice);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("field", field, null);
            }
            throw new ArgumentException("Unable to get field " + field + " on order of type " + _submitRequest.OrderType);
        }
        public OrderResponse Update(UpdateOrderFields fields)
        {
            _transactionManager.UpdateOrder(new UpdateOrderRequest(_transactionManager.UtcTime, SubmitRequest.OrderId, fields));
            return _updateRequests.Last().Response;
        }
        public OrderResponse Cancel(string tag = null)
        {
            var request = new CancelOrderRequest(_transactionManager.UtcTime, OrderId, tag);
            _transactionManager.ProcessRequest(request);
            return CancelRequest.Response;
        }
        public OrderResponse GetMostRecentOrderResponse()
        {
            return GetMostRecentOrderRequest().Response;
        }
        public OrderRequest GetMostRecentOrderRequest()
        {
            if (CancelRequest != null)
            {
                return CancelRequest;
            }
            var lastUpdate = _updateRequests.LastOrDefault();
            if (lastUpdate != null)
            {
                return lastUpdate;
            }
            return SubmitRequest;
        }
        internal void AddOrderEvent(OrderEvent orderEvent)
        {
            lock (_orderEventsLock)
            {
                _orderEvents.Add(orderEvent);
                if (orderEvent.FillQuantity != 0)
                {
                    _quantityFilled += orderEvent.FillQuantity;
                    var quantityWeightedFillPrice = _orderEvents.Where(x => x.Status.IsFill()).Sum(x => x.AbsoluteFillQuantity*x.FillPrice);
                    _averageFillPrice = quantityWeightedFillPrice/Math.Abs(_quantityFilled);
                }
            }
            if (orderEvent.Status.IsClosed())
            {
                _orderStatusClosedEvent.Set();
            }
        }
        internal void SetOrder(Order order)
        {
            if (_order != null && _order.Id != order.Id)
            {
                throw new ArgumentException("Order id mismatch");
            }
            _order = order;
        }
        internal void AddUpdateRequest(UpdateOrderRequest request)
        {
            if (request.OrderId != OrderId)
            {
                throw new ArgumentException("Received UpdateOrderRequest for incorrect order id.");
            }
            lock (_updateRequestsLock)
            {
                _updateRequests.Add(request);
            }
        }
        internal bool TrySetCancelRequest(CancelOrderRequest request)
        {
            if (request.OrderId != OrderId)
            {
                throw new ArgumentException("Received CancelOrderRequest for incorrect order id.");
            }
            lock (_setCancelRequestLock)
            {
                if (_cancelRequest != null)
                {
                    return false;
                }
                _cancelRequest = request;
            }
            return true;
        }
        public static OrderTicket InvalidCancelOrderId(SecurityTransactionManager transactionManager, CancelOrderRequest request)
        {
            var submit = new SubmitOrderRequest(OrderType.Market, SecurityType.Base, Symbol.Empty, 0, 0, 0, DateTime.MaxValue, string.Empty);
            submit.SetResponse(OrderResponse.UnableToFindOrder(request));
            var ticket = new OrderTicket(transactionManager, submit);
            request.SetResponse(OrderResponse.UnableToFindOrder(request));
            ticket.TrySetCancelRequest(request);
            ticket._orderStatusOverride = OrderStatus.Invalid;
            return ticket;
        }
        public static OrderTicket InvalidUpdateOrderId(SecurityTransactionManager transactionManager, UpdateOrderRequest request)
        {
            var submit = new SubmitOrderRequest(OrderType.Market, SecurityType.Base, Symbol.Empty, 0, 0, 0, DateTime.MaxValue, string.Empty);
            submit.SetResponse(OrderResponse.UnableToFindOrder(request));
            var ticket = new OrderTicket(transactionManager, submit);
            request.SetResponse(OrderResponse.UnableToFindOrder(request));
            ticket.AddUpdateRequest(request);
            ticket._orderStatusOverride = OrderStatus.Invalid;
            return ticket;
        }
        public static OrderTicket InvalidSubmitRequest(SecurityTransactionManager transactionManager, SubmitOrderRequest request, OrderResponse response)
        {
            request.SetResponse(response);
            return new OrderTicket(transactionManager, request) { _orderStatusOverride = OrderStatus.Invalid };
        }
        public static OrderTicket InvalidWarmingUp(SecurityTransactionManager transactionManager, SubmitOrderRequest submit)
        {
            submit.SetResponse(OrderResponse.WarmingUp(submit));
            var ticket = new OrderTicket(transactionManager, submit);
            ticket._orderStatusOverride = OrderStatus.Invalid;
            return ticket;
        }
        public override string ToString()
        {
            var counts = "Request Count: " + RequestCount() + " Response Count: " + ResponseCount();
            if (_order != null)
            {
                return OrderId + ": " + _order + " " + counts;
            }
            return OrderId + ": " + counts;
        }
        private int ResponseCount()
        {
            return (_submitRequest.Response == OrderResponse.Unprocessed ? 0 : 1) 
                 + (_cancelRequest == null || _cancelRequest.Response == OrderResponse.Unprocessed ? 0 : 1)
                 + _updateRequests.Count(x => x.Response != OrderResponse.Unprocessed);
        }
        private int RequestCount()
        {
            return 1 + _updateRequests.Count + (_cancelRequest == null ? 0 : 1);
        }
        public static implicit operator int(OrderTicket ticket)
        {
            var response = ticket.GetMostRecentOrderResponse();
            if (response != null && response.IsError)
            {
                return (int) response.ErrorCode;
            }
            return ticket.OrderId;
        }
        private static decimal AccessOrder<T>(OrderTicket ticket, OrderField field, Func<T, decimal> orderSelector, Func<SubmitOrderRequest, decimal> requestSelector)
            where T : Order
        {
            var order = ticket._order;
            if (order == null)
            {
                return requestSelector(ticket._submitRequest);
            }
            var typedOrder = order as T;
            if (typedOrder != null)
            {
                return orderSelector(typedOrder);
            }
            throw new ArgumentException(string.Format("Unable to access property {0} on order of type {1}", field, order.Type));
        }
    }
}
