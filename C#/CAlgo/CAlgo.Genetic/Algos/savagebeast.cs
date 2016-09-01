using System;
using cAlgo.API;

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class SavageBeast : Robot
    {
        private bool _accountIsOutOfMoney;
        private int _openTradeResult;

        private readonly string Label = "SavageBeast";
        private DateTime _lastBuyTradeTime;
        private DateTime _lastSellTradeTime;

        [Parameter("Buy", DefaultValue = true)]
        public bool Buy { get; set; }

        [Parameter("Sell", DefaultValue = true)]
        public bool Sell { get; set; }

        [Parameter("Pip Step", DefaultValue = 10, MinValue = 1)]
        public int PipStep { get; set; }

        [Parameter("First Volume", DefaultValue = 1000, MinValue = 1000, Step = 1000)]
        public int FirstVolume { get; set; }

        [Parameter("Volume Exponent", DefaultValue = 1.0, MinValue = 0.1, MaxValue = 5.0)]
        public double VolumeExponent { get; set; }

        [Parameter("Max Spread", DefaultValue = 3.0)]
        public double MaxSpread { get; set; }

        [Parameter("Average TP", DefaultValue = 3, MinValue = 1)]
        public int AverageTakeProfit { get; set; }

        private double CurrentSpread
        {
            get { return (Symbol.Ask - Symbol.Bid) / Symbol.PipSize; }
        }


        protected override void OnStart()
        {
        }

        protected override void OnTick()
        {
            if (CountOfTradesOfType(TradeType.Buy) > 0)
                AdjustBuyPositionTakeProfits(CalculateAveragePositionPrice(TradeType.Buy), AverageTakeProfit);
            if (CountOfTradesOfType(TradeType.Sell) > 0)
                AdjustSellPositionTakeProfits(CalculateAveragePositionPrice(TradeType.Sell), AverageTakeProfit);
            if (CurrentSpread <= MaxSpread && !_accountIsOutOfMoney)
                ProcessTrades();

            if (!this.IsBacktesting)
                DisplayStatusOnChart();
        }

        protected override void OnError(Error error)
        {
            if (error.Code == ErrorCode.NoMoney)
            {
                _accountIsOutOfMoney = true;
                Print("opening stopped because: not enough money");
            }
        }

        protected override void OnBar()
        {
            RefreshData();
        }

        protected override void OnStop()
        {
            ChartObjects.RemoveAllObjects();
        }

        private void ProcessTrades()
        {

            if (Buy && CountOfTradesOfType(TradeType.Buy) == 0 && MarketSeries.Close.Last(1) > MarketSeries.Close.Last(2))
            {
                _openTradeResult = OrderSend(TradeType.Buy, LimitVolume(FirstVolume));
                if (_openTradeResult > 0)
                    _lastBuyTradeTime = MarketSeries.OpenTime.Last(0);
                else
                    Print("First BUY openning error at: ", Symbol.Ask, "Error Type: ", LastResult.Error);
            }
            if (Sell && CountOfTradesOfType(TradeType.Sell) == 0 && MarketSeries.Close.Last(2) > MarketSeries.Close.Last(1))
            {
                _openTradeResult = OrderSend(TradeType.Sell, LimitVolume(FirstVolume));
                if (_openTradeResult > 0)
                    _lastSellTradeTime = MarketSeries.OpenTime.Last(0);
                else
                    Print("First SELL opening error at: ", Symbol.Bid, "Error Type: ", LastResult.Error);
            }

            if (CountOfTradesOfType(TradeType.Buy) > 0)
            {
                if (Math.Round(Symbol.Ask, Symbol.Digits) < Math.Round(FindLowestPositionPrice(TradeType.Buy) - PipStep * Symbol.PipSize, Symbol.Digits) && _lastBuyTradeTime != MarketSeries.OpenTime.Last(0))
                {
                    var calculatedVolume = CalculateVolume(TradeType.Buy);
                    _openTradeResult = OrderSend(TradeType.Buy, LimitVolume(calculatedVolume));
                    if (_openTradeResult > 0)
                        _lastBuyTradeTime = MarketSeries.OpenTime.Last(0);
                    else
                        Print("Next BUY opening error at: ", Symbol.Ask, "Error Type: ", LastResult.Error);
                }
            }
            if (CountOfTradesOfType(TradeType.Sell) > 0)
            {
                if (Math.Round(Symbol.Bid, Symbol.Digits) > Math.Round(FindHighestPositionPrice(TradeType.Sell) + PipStep * Symbol.PipSize, Symbol.Digits) && _lastSellTradeTime != MarketSeries.OpenTime.Last(0))
                {
                    var calculatedVolume = CalculateVolume(TradeType.Sell);
                    _openTradeResult = OrderSend(TradeType.Sell, LimitVolume(calculatedVolume));
                    if (_openTradeResult > 0)
                        _lastSellTradeTime = MarketSeries.OpenTime.Last(0);
                    else
                        Print("Next SELL opening error at: ", Symbol.Bid, "Error Type: ", LastResult.Error);
                }
            }
        }



        private int OrderSend(TradeType tradeType, long volumeToUse)
        {
            var returnResult = 0;
            if (volumeToUse > 0)
            {
                var result = ExecuteMarketOrder(tradeType, Symbol, volumeToUse, Label, 0, 0, 0, "savage_beast");

                if (result.IsSuccessful)
                {
                    Print(tradeType, "Opened at: ", result.Position.EntryPrice);
                    returnResult = 1;
                }
                else
                    Print(tradeType, "Openning Error: ", result.Error);
            }
            else
                Print("Volume calculation error: Calculated Volume is: ", volumeToUse);
            return returnResult;
        }

        private void AdjustBuyPositionTakeProfits(double averageBuyPositionPrice, int averageTakeProfit)
        {
            foreach (var buyPosition in Positions)
            {
                if (buyPosition.Label == Label && buyPosition.SymbolCode == Symbol.Code)
                {
                    if (buyPosition.TradeType == TradeType.Buy)
                    {
                        double? calculatedTakeProfit = Math.Round(averageBuyPositionPrice + averageTakeProfit * Symbol.PipSize, Symbol.Digits);
                        if (buyPosition.TakeProfit != calculatedTakeProfit)
                            ModifyPosition(buyPosition, buyPosition.StopLoss, calculatedTakeProfit);
                    }
                }
            }
        }

        private void AdjustSellPositionTakeProfits(double averageSellPositionPrice, int averageTakeProfit)
        {
            foreach (var sellPosition in Positions)
            {
                if (sellPosition.Label == Label && sellPosition.SymbolCode == Symbol.Code)
                {
                    if (sellPosition.TradeType == TradeType.Sell)
                    {
                        double? calculatedTakeProfit = Math.Round(averageSellPositionPrice - averageTakeProfit * Symbol.PipSize, Symbol.Digits);
                        if (sellPosition.TakeProfit != calculatedTakeProfit)
                            ModifyPosition(sellPosition, sellPosition.StopLoss, calculatedTakeProfit);
                    }
                }
            }
        }

        private void DisplayStatusOnChart()
        {
            if (CountOfTradesOfType(TradeType.Buy) > 1)
            {
                var y = CalculateAveragePositionPrice(TradeType.Buy);
                ChartObjects.DrawHorizontalLine("bpoint", y, Colors.Yellow, 2, LineStyle.Dots);
            }
            else
                ChartObjects.RemoveObject("bpoint");
            if (CountOfTradesOfType(TradeType.Sell) > 1)
            {
                var z = CalculateAveragePositionPrice(TradeType.Sell);
                ChartObjects.DrawHorizontalLine("spoint", z, Colors.HotPink, 2, LineStyle.Dots);
            }
            else
                ChartObjects.RemoveObject("spoint");
            ChartObjects.DrawText("pan", GenerateStatusText(), StaticPosition.TopLeft, Colors.Tomato);
        }

        private string GenerateStatusText()
        {
            var statusText = "";
            var buyPositions = "";
            var sellPositions = "";
            var spread = "";
            var buyDistance = "";
            var sellDistance = "";
            spread = "\nSpread = " + Math.Round(CurrentSpread, 1);
            buyPositions = "\nBuy Positions = " + CountOfTradesOfType(TradeType.Buy);
            sellPositions = "\nSell Positions = " + CountOfTradesOfType(TradeType.Sell);
            if (CountOfTradesOfType(TradeType.Buy) > 0)
            {
                var averageBuyFromCurrent = Math.Round((CalculateAveragePositionPrice(TradeType.Buy) - Symbol.Bid) / Symbol.PipSize, 1);
                buyDistance = "\nBuy Target Away = " + averageBuyFromCurrent;
            }
            if (CountOfTradesOfType(TradeType.Sell) > 0)
            {
                var averageSellFromCurrent = Math.Round((Symbol.Ask - CalculateAveragePositionPrice(TradeType.Sell)) / Symbol.PipSize, 1);
                sellDistance = "\nSell Target Away = " + averageSellFromCurrent;
            }
            if (CurrentSpread > MaxSpread)
                statusText = "MAX SPREAD EXCEED";
            else
                statusText = "Savage Beast" + buyPositions + spread + sellPositions + buyDistance + sellDistance;
            return (statusText);
        }



        private int CountOfTradesOfType(TradeType tradeType)
        {
            var tradeCount = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                        tradeCount++;
                }
            }

            return tradeCount;
        }

        private double CalculateAveragePositionPrice(TradeType tradeType)
        {
            double result = 0;
            double averagePrice = 0;
            long count = 0;


            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                    {
                        averagePrice += position.EntryPrice * position.Volume;
                        count += position.Volume;
                    }
                }

            }

            if (averagePrice > 0 && count > 0)
                result = Math.Round(Convert.ToDouble(averagePrice) / Convert.ToDouble(count), Symbol.Digits);
            return result;
        }

        private double FindLowestPositionPrice(TradeType tradeType)
        {
            double lowestPrice = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                    {
                        if (lowestPrice == 0)
                        {
                            lowestPrice = position.EntryPrice;
                            continue;
                        }
                        if (position.EntryPrice < lowestPrice)
                            lowestPrice = position.EntryPrice;
                    }
                }
            }

            return lowestPrice;
        }

        private double FindHighestPositionPrice(TradeType tradeType)
        {
            double highestPrice = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                    {
                        if (highestPrice == 0)
                        {
                            highestPrice = position.EntryPrice;
                            continue;
                        }
                        if (position.EntryPrice > highestPrice)
                            highestPrice = position.EntryPrice;
                    }
                }
            }

            return highestPrice;
        }

        private double FindPriceOfMostRecentPositionId(TradeType tradeType)
        {
            double price = 0;
            var highestPositionId = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                    {
                        if (highestPositionId == 0 || highestPositionId > position.Id)
                        {
                            price = position.EntryPrice;
                            highestPositionId = position.Id;
                        }
                    }
                }
            }

            return price;
        }

        private long GetMostRecentPositionVolume(TradeType tradeType)
        {
            long mostRecentVolume = 0;
            var highestPositionId = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType)
                    {
                        if (highestPositionId == 0 || highestPositionId > position.Id)
                        {
                            mostRecentVolume = position.Volume;
                            highestPositionId = position.Id;
                        }
                    }
                }
            }

            return mostRecentVolume;
        }

        private int CountNumberOfPositionsOfType(TradeType tradeType)
        {
            var mostRecentPrice = FindPriceOfMostRecentPositionId(tradeType);
            var numberOfPositionsOfType = 0;

            foreach (var position in Positions)
            {
                if (position.Label == Label && position.SymbolCode == Symbol.Code)
                {
                    if (position.TradeType == tradeType && tradeType == TradeType.Buy)
                    {
                        if (Math.Round(position.EntryPrice, Symbol.Digits) <= Math.Round(mostRecentPrice, Symbol.Digits))
                            numberOfPositionsOfType++;
                    }
                    if (position.TradeType == tradeType && tradeType == TradeType.Sell)
                    {
                        if (Math.Round(position.EntryPrice, Symbol.Digits) >= Math.Round(mostRecentPrice, Symbol.Digits))
                            numberOfPositionsOfType++;
                    }
                }
            }

            return (numberOfPositionsOfType);
        }

        private long CalculateVolume(TradeType tradeType)
        {
            var numberOfPositions = CountNumberOfPositionsOfType(tradeType);
            var mostRecentVolume = GetMostRecentPositionVolume(tradeType);
            var calculatedVolume = Symbol.NormalizeVolume(mostRecentVolume * Math.Pow(VolumeExponent, numberOfPositions));
            return (calculatedVolume);
        }

        private long LimitVolume(long volumeIn)
        {
            var symbolVolumeMin = Symbol.VolumeMin;
            var symbolVolumeMax = Symbol.VolumeMax;
            var result = volumeIn;
            if (result < symbolVolumeMin)
                result = symbolVolumeMin;
            if (result > symbolVolumeMax)
                result = symbolVolumeMax;
            return (result);
        }
    }
}
