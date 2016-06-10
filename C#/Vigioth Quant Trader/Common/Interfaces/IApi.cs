using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Securities;
namespace VigiothCapital.QuantTrader.Interfaces
{
    [InheritedExport(typeof(IApi))]
    public interface IApi : IDisposable
    {
        void Initialize();
        int[] ReadLogAllowance(int userId, string userToken);
        void UpdateDailyLogUsed(int userId, string backtestId, string url, int length, string userToken, bool hitLimit = false);
        AlgorithmControl GetAlgorithmStatus(string algorithmId, int userId);
        void SetAlgorithmStatus(string algorithmId, AlgorithmStatus status, string message = "");
        void SendStatistics(string algorithmId, decimal unrealized, decimal fees, decimal netProfit, decimal holdings, decimal equity, decimal netReturn, decimal volume, int trades, double sharpe);
        IEnumerable<MarketHoursSegment> MarketToday(DateTime time, Symbol symbol);
        void Store(string data, string location, StoragePermissions permissions, bool async = false);
        void SendUserEmail(string algorithmId, string subject, string body);
    }
}
