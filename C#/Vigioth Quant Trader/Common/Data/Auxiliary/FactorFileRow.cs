using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
namespace VigiothCapital.QuantTrader.Data.Auxiliary
{
    public class FactorFileRow
    {
        public DateTime Date { get; private set; }
        public decimal PriceFactor { get; private set; }
        public decimal SplitFactor { get; private set; }
        public decimal PriceScaleFactor
        {
            get { return PriceFactor*SplitFactor; }
        }
        public FactorFileRow(DateTime date, decimal priceFactor, decimal splitFactor)
        {
            Date = date;
            PriceFactor = priceFactor;
            SplitFactor = splitFactor;
        }
        public static IEnumerable<FactorFileRow> Read(string permtick, string market)
        {
            string path = Path.Combine(Globals.DataFolder, "equity", market, "factor_files", permtick.ToLower() + ".csv");
            return File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l)).Select(Parse);
        }
        public static FactorFileRow Parse(string line)
        {
            var csv = line.Split(',');
            return new FactorFileRow(
                DateTime.ParseExact(csv[0], DateFormat.EightCharacter, CultureInfo.InvariantCulture, DateTimeStyles.None),
                decimal.Parse(csv[1], CultureInfo.InvariantCulture),
                decimal.Parse(csv[2], CultureInfo.InvariantCulture)
                );
        }
        public override string ToString()
        {
            return Date + ": " + PriceScaleFactor.ToString("0.0000");
        }
    }
}