using System;
using System.Collections.Generic;
using System.Linq;
namespace VigiothCapital.QuantTrader.Securities
{
    public class LocalMarketHours
    {
        private readonly bool _hasPreMarket;
        private readonly bool _hasPostMarket;
        private readonly bool _isOpenAllDay;
        private readonly bool _isClosedAllDay;
        private readonly DayOfWeek _dayOfWeek;
        private readonly MarketHoursSegment[] _segments;
        public bool IsClosedAllDay
        {
            get { return _isClosedAllDay; }
        }
        public bool IsOpenAllDay
        {
            get { return _isOpenAllDay; }
        }
        public DayOfWeek DayOfWeek 
        {
            get { return _dayOfWeek; }
        }
        public IEnumerable<MarketHoursSegment> Segments
        {
            get { return _segments; }
        }
        public LocalMarketHours(DayOfWeek day, params MarketHoursSegment[] segments)
            : this(day, (IEnumerable<MarketHoursSegment>) segments)
        {
        }
        public LocalMarketHours(DayOfWeek day, IEnumerable<MarketHoursSegment> segments)
        {
            _dayOfWeek = day;
            _segments = (segments ?? Enumerable.Empty<MarketHoursSegment>()).Where(x => x.State != MarketHoursState.Closed).ToArray();
            _isClosedAllDay = _segments.Length == 0;
            _isOpenAllDay = _segments.Length == 1 
                && _segments[0].Start == TimeSpan.Zero 
                && _segments[0].End == Time.OneDay
                && _segments[0].State == MarketHoursState.Market;
            foreach (var segment in _segments)
            {
                if (segment.State == MarketHoursState.PreMarket)
                {
                    _hasPreMarket = true;
                }
                if (segment.State == MarketHoursState.PostMarket)
                {
                    _hasPostMarket = true;
                }
            }
        }
        public LocalMarketHours(DayOfWeek day, TimeSpan extendedMarketOpen, TimeSpan marketOpen, TimeSpan marketClose, TimeSpan extendedMarketClose)
        {
            _dayOfWeek = day;
            var segments = new List<MarketHoursSegment>();
            if (extendedMarketOpen != marketOpen)
            {
                _hasPreMarket = true;
                segments.Add(new MarketHoursSegment(MarketHoursState.PreMarket, extendedMarketOpen, marketOpen));
            }
            if (marketOpen != TimeSpan.Zero || marketClose != TimeSpan.Zero)
            {
                segments.Add(new MarketHoursSegment(MarketHoursState.Market, marketOpen, marketClose));
            }
            if (marketClose != extendedMarketClose)
            {
                _hasPostMarket = true;
                segments.Add(new MarketHoursSegment(MarketHoursState.PostMarket, marketClose, extendedMarketClose));
            }
            _segments = segments.ToArray();
            _isClosedAllDay = _segments.Length == 0;
            if (marketOpen < extendedMarketOpen)
            {
                throw new ArgumentException("Extended market open time must be less than or equal to market open time.");
            }
            if (marketClose < marketOpen)
            {
                throw new ArgumentException("Market close time must be after market open time.");
            }
            if (extendedMarketClose < marketClose)
            {
                throw new ArgumentException("Extended market close time must be greater than or equal to market close time.");
            }
        }
        public LocalMarketHours(DayOfWeek day, TimeSpan marketOpen, TimeSpan marketClose)
            : this(day, marketOpen, marketOpen, marketClose, marketClose)
        {
        }
        public TimeSpan? GetMarketOpen(TimeSpan time, bool extendedMarket)
        {
            for (int i = 0; i < _segments.Length; i++)
            {
                if (_segments[i].State == MarketHoursState.Closed || _segments[i].End <= time)
                {
                    continue;
                }
                if (extendedMarket && _hasPreMarket)
                {
                    if (_segments[i].State == MarketHoursState.PreMarket)
                    {
                        return _segments[i].Start;
                    }
                }
                else if (_segments[i].State == MarketHoursState.Market)
                {
                    return _segments[i].Start;
                }
            }
            return null;
        }
        public TimeSpan? GetMarketClose(TimeSpan time, bool extendedMarket)
        {
            for (int i = 0; i < _segments.Length; i++)
            {
                if (_segments[i].State == MarketHoursState.Closed || _segments[i].End <= time)
                {
                    continue;
                }
                if (extendedMarket && _hasPostMarket)
                {
                    if (_segments[i].State == MarketHoursState.PostMarket)
                    {
                        return _segments[i].End;
                    }
                }
                else if (_segments[i].State == MarketHoursState.Market)
                {
                    return _segments[i].End;
                }
            }
            return null;
        }
        public bool IsOpen(TimeSpan time, bool extendedMarket)
        {
            for (int i = 0; i < _segments.Length; i++)
            {
                if (_segments[i].State == MarketHoursState.Closed)
                {
                    continue;
                }
                if (_segments[i].Contains(time))
                {
                    return extendedMarket || _segments[i].State == MarketHoursState.Market;
                }
            }
            return false;
        }
        public bool IsOpen(TimeSpan start, TimeSpan end, bool extendedMarket)
        {
            if (start == end)
            {
                return IsOpen(start, extendedMarket);
            }
            for (int i = 0; i < _segments.Length; i++)
            {
                if (_segments[i].State == MarketHoursState.Closed)
                {
                    continue;
                }
                if (extendedMarket || _segments[i].State == MarketHoursState.Market)
                {
                    if (_segments[i].Overlaps(start, end))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static LocalMarketHours ClosedAllDay(DayOfWeek dayOfWeek)
        {
            return new LocalMarketHours(dayOfWeek);
        }
        public static LocalMarketHours OpenAllDay(DayOfWeek dayOfWeek)
        {
            return new LocalMarketHours(dayOfWeek, new MarketHoursSegment(MarketHoursState.Market, TimeSpan.Zero, Time.OneDay));
        }
        public override string ToString()
        {
            if (IsClosedAllDay)
            {
                return "Closed All Day";
            }
            if (IsOpenAllDay)
            {
                return "Open All Day";
            }
            return DayOfWeek + ": " + string.Join(" | ", (IEnumerable<MarketHoursSegment>) _segments);
        }
    }
}