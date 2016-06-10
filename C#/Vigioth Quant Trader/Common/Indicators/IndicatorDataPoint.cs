using System;
using VigiothCapital.QuantTrader.Data;
namespace VigiothCapital.QuantTrader.Indicators
{
    public class IndicatorDataPoint : BaseData, IEquatable<IndicatorDataPoint>, IComparable<IndicatorDataPoint>, IComparable
    {
        public IndicatorDataPoint()
        {
            Value = 0m;
            Time = DateTime.MinValue;
        }
        public IndicatorDataPoint(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }
        public IndicatorDataPoint(Symbol symbol, DateTime time, decimal value)
        {
            Symbol = symbol;
            Time = time;
            Value = value;
        }
        public bool Equals(IndicatorDataPoint other)
        {
            if (other == null)
            {
                return false;
            }
            return other.Time == Time && other.Value == Value;
        }
        public int CompareTo(IndicatorDataPoint other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Value.CompareTo(other.Value);
        }
        public int CompareTo(object obj)
        {
            var other = obj as IndicatorDataPoint;
            if (other == null)
            {
                throw new ArgumentException("Object must be of type " + GetType().GetBetterTypeName());
            }
            return CompareTo(other);
        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Time.ToString("s"), Value);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IndicatorDataPoint && Equals((IndicatorDataPoint) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode()*397) ^ Time.GetHashCode();
            }
        }
        public static implicit operator decimal(IndicatorDataPoint instance)
        {
            return instance.Value;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("IndicatorDataPoint does not support the Reader function. This function should never be called on this type.");
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException("IndicatorDataPoint does not support the GetSource function. This function should never be called on this type.");
        }
    }
}