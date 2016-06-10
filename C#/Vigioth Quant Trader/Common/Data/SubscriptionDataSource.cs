using System;
namespace VigiothCapital.QuantTrader.Data
{
    public class SubscriptionDataSource : IEquatable<SubscriptionDataSource>
    {
        public readonly string Source;
        public readonly FileFormat Format;
        public readonly SubscriptionTransportMedium TransportMedium;
        public SubscriptionDataSource(string source, SubscriptionTransportMedium transportMedium)
        {
            Source = source;
            Format = FileFormat.Csv;
            TransportMedium = transportMedium;
        }
        public SubscriptionDataSource(string source, SubscriptionTransportMedium transportMedium, FileFormat format)
        {
            Source = source;
            Format = format;
            TransportMedium = transportMedium;
        }
        public bool Equals(SubscriptionDataSource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Source, other.Source) && TransportMedium == other.TransportMedium;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SubscriptionDataSource) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Source != null ? Source.GetHashCode() : 0)*397) ^ (int) TransportMedium;
            }
        }
        public static bool operator ==(SubscriptionDataSource left, SubscriptionDataSource right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SubscriptionDataSource left, SubscriptionDataSource right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return string.Format("{0}: {1} {2}", TransportMedium, Format, Source);
        }
    }
}