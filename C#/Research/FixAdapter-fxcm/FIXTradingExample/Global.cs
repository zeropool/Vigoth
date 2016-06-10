using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using TicTacTec.TA.Library;
namespace FIXTradingExample
{
    public static class Global
    {
        private static Hashtable objectHash = new Hashtable();
        public static void AddTick(string name, TimeMarker instr, DateTime date)
        {
            if (!objectHash.ContainsKey(name))
            {   
                var col = new Instrument();
                col.Name = name;
                col.Ticks = new List<TimeMarker>();
                col.Ticks.Add(instr);
                objectHash[name] = col;
            }
            else
            {
                ((Instrument)objectHash[name]).Ticks.Add(instr);
            }

            try
            {
                //CalculatePriceAction(((Instrument)objectHash[name]), date);
            }
            catch(Exception ex)
            {
                string e = ex.Message;
            }
        }
        public static List<Candle> GetMinuteCandles() {
            var list = new List<Candle>();
            foreach(var o in objectHash)
            {
                                                 
            }
            return list;
        }
        public class Candle
        {
            public double Open { get; set; }
            public double High{ get; set; }
            public double Low { get; set; }
            public double Close { get; set; }
            public DateTime Time { get; set; }


        }
        public static void CalculatePriceAction(Instrument col, DateTime date)
        {
            double price = col.Ticks.Last().Bid;
            double prevPrice = (col.Ticks.ToArray().Length > 3 ) ? col.Ticks.ToArray()[col.Ticks.ToArray().Length - 2].Bid : col.Ticks.Last().Bid;
            double[] roc = new double[2];
            int bgidexl = 0;
            int outNBElement = 0;

            Core.Roc(0, 1, new double[2] { price, prevPrice }, 14,out bgidexl, out outNBElement, roc);
            if ( roc[0] > roc[1] )
            {
                col.IsUp = true;
            }
            else
            {
                col.IsUp = false;
            }
            col.ROC.Add(new ROC { roc = roc[1], TimeStamp = date });
            objectHash[col.Name] = col;
        }
    }
    public class TimeMarker
    {
        public double Bid;
        public double Ask;
        public DateTime TimeStamp;

    }
    public class Instrument {

        public List<TimeMarker> Ticks = new List<TimeMarker>();
        public List<TimeMarker> Minutes = new List<TimeMarker>();
        public List<TimeMarker> Hours = new List<TimeMarker>();
        public List<TimeMarker> Days = new List<TimeMarker>();
        public List<TimeMarker> Weeks = new List<TimeMarker>();

        public decimal MACD;
        public decimal RSI;
        public List<ROC> ROC = new List<ROC>();
        public bool IsUp = false;
        public double firstROC;
        public double lastROC;
        public double rocGrowth;
        public string Name;
    }
    public class ROC 
    {
        public DateTime TimeStamp = new DateTime();
        public double roc = 0;
    }

}
