﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class FactorFile
    {
        private readonly SortedList<DateTime, FactorFileRow> _data;
        public string Permtick { get; private set; }
        public FactorFile(string permtick, IEnumerable<FactorFileRow> data)
        {
            Permtick = permtick.ToUpper();
            _data = new SortedList<DateTime, FactorFileRow>(data.ToDictionary(x => x.Date));
        }
        public static FactorFile Read(string permtick, string market)
        {
            return new FactorFile(permtick, FactorFileRow.Read(permtick, market));
        }
        public decimal GetPriceScaleFactor(DateTime searchDate)
        {
            decimal factor = 1;
            foreach (var splitDate in _data.Keys.Reverse())
            {
                if (splitDate.Date < searchDate.Date) break;
                factor = _data[splitDate].PriceScaleFactor;
            }
            return factor;
        }
        public decimal GetSplitFactor(DateTime searchDate)
        {
            decimal factor = 1;
            foreach (var splitDate in _data.Keys.Reverse())
            {
                if (splitDate.Date < searchDate.Date) break;
                factor = _data[splitDate].SplitFactor;
            }
            return factor;
        }
        public static bool HasScalingFactors(string permtick, string market)
        {
            var path = Path.Combine(Globals.DataFolder, "equity", market, "factor_files", permtick.ToLower() + ".csv");
            if (File.Exists(path))
            {
                return true;
            }
            Log.Trace("FactorFile.HasScalingFactors(): Factor file not found: " + permtick);
            return false;
        }
        public bool HasDividendEventOnNextTradingDay(DateTime date, out decimal priceFactorRatio)
        {
            priceFactorRatio = 0;
            var index = _data.IndexOfKey(date);
            if (index > -1 && index < _data.Count - 1)
            {
                var thisRow = _data.Values[index];
                var nextRow = _data.Values[index + 1];
                if (thisRow.PriceFactor != nextRow.PriceFactor)
                {
                    priceFactorRatio = thisRow.PriceFactor/nextRow.PriceFactor;
                    return true;
                }
            }
            return false;
        }
        public bool HasSplitEventOnNextTradingDay(DateTime date, out decimal splitFactor)
        {
            splitFactor = 1;
            var index = _data.IndexOfKey(date);
            if (index > -1 && index < _data.Count - 1)
            {
                var thisRow = _data.Values[index];
                var nextRow = _data.Values[index + 1];
                if (thisRow.SplitFactor != nextRow.SplitFactor)
                {
                    splitFactor = thisRow.SplitFactor/nextRow.SplitFactor;
                    return true;
                }
            }
            return false;
        }
    }
}