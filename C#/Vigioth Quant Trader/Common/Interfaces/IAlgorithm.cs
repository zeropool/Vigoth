using System;
using System.Collections.Generic;
using NodaTime;
using VigiothCapital.QuantTrader.Benchmarks;
using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Data;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
using VigiothCapital.QuantTrader.Notifications;
using VigiothCapital.QuantTrader.Orders;
using VigiothCapital.QuantTrader.Scheduling;
using VigiothCapital.QuantTrader.Securities;
using VigiothCapital.QuantTrader.Statistics;
namespace VigiothCapital.QuantTrader.Interfaces
{
    public interface IAlgorithm
    {
        SubscriptionManager SubscriptionManager
        {
            get;
        }
        SecurityManager Securities
        {
            get;
        }
        UniverseManager UniverseManager
        {
            get;
        }
        SecurityPortfolioManager Portfolio
        {
            get;
        }
        SecurityTransactionManager Transactions
        {
            get;
        }
        IBrokerageModel BrokerageModel
        {
            get;
        }
        IBrokerageMessageHandler BrokerageMessageHandler
        {
            get;
            set;
        }
        NotificationManager Notify
        {
            get;
        }
        ScheduleManager Schedule
        {
            get;
        }
        IHistoryProvider HistoryProvider
        {
            get; 
            set;
        }
        AlgorithmStatus Status
        {
            get; 
            set;
        }
        bool IsWarmingUp
        {
            get;
        }
        string Name
        {
            get;
        }
        DateTime Time
        {
            get;
        }
        DateTimeZone TimeZone
        {
            get;
        }
        DateTime UtcTime
        {
            get;
        }
        DateTime StartDate
        {
            get;
        }
        DateTime EndDate
        {
            get;
        }
        string AlgorithmId
        {
            get;
        }
        bool LiveMode
        {
            get;
        }
        UniverseSettings UniverseSettings
        {
            get;
        }
        List<string> DebugMessages
        {
            get;
        }
        List<string> ErrorMessages
        {
            get;
        }
        List<string> LogMessages
        {
            get;
        }
        Exception RunTimeError
        {
            get;
            set;
        }
        Dictionary<string, string> RuntimeStatistics
        {
            get;
        }
        IBenchmark Benchmark
        { 
            get;
        }
        ISecurityInitializer SecurityInitializer
        {
            get;
        }
        TradeBuilder TradeBuilder
        {
            get;
        }
        void Initialize();
        void PostInitialize();
        string GetParameter(string name);
        void SetParameters(Dictionary<string, string> parameters);
        void SetBrokerageModel(IBrokerageModel brokerageModel);
        void OnData(Slice slice);
        void OnSecuritiesChanged(SecurityChanges changes);
        void Debug(string message);
        void Log(string message);
        void Error(string message);
        void OnMarginCall(List<SubmitOrderRequest> requests);
        void OnMarginCallWarning();
        void OnEndOfDay();
        void OnEndOfDay(Symbol symbol);
        void OnEndOfAlgorithm();
        void OnOrderEvent(OrderEvent newEvent);
        void OnBrokerageMessage(BrokerageMessageEvent messageEvent);
        void OnBrokerageDisconnect();
        void OnBrokerageReconnect();
        void SetDateTime(DateTime time);
        void SetAlgorithmId(string algorithmId);
        void SetLocked();
        bool GetLocked();
        List<Chart> GetChartUpdates(bool clearChartData = false);
        Security AddSecurity(SecurityType securityType, string symbol, Resolution resolution, string market, bool fillDataForward, decimal leverage, bool extendedMarketHours);
        void SetCash(decimal startingCash);
        void SetCash(string symbol, decimal startingCash, decimal conversionRate);
        List<int> Liquidate(Symbol symbolToLiquidate = null);
        void SetLiveMode(bool live);
        void SetFinishedWarmingUp();
        IEnumerable<HistoryRequest> GetWarmupHistoryRequests();
        void SetMaximumOrders(int max);
    }
}
