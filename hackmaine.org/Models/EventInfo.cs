using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackmaine.org.Models
{
    public class EventInfo
    {
        public enum RepeatType
        {
            None,
            Weekly,
            BiWeekly,
            MonthlyByDate,
            MonthlyFirstWeek,
            MonthlySecondWeek,
            MonthlyThirdWeek,
            MonthlyFourthWeek,
            MonthlyLastWeek,
        }

        public EventInfo() { }

        public EventInfo(string eventname, VenueInfo venue, DateTime start, TimeSpan duration, RepeatType repeat = RepeatType.None)
            : this(eventname, venue, start, start + duration, repeat) { }

        public EventInfo(string eventname, VenueInfo venue, DateTime start, DateTime end, RepeatType repeat = RepeatType.None)
        {
            EventName = eventname;
            Venue = venue;
            Start = start;
            End = end;
            Repeat = repeat;
        }

        public string EventName { get; set; }
        public VenueInfo Venue { get; set; }
        public RepeatType Repeat { get; set; }

        DateTime _Start = DateTime.Now;
        public DateTime Start
        {
            get { return _Start; }
            set
            {
                _Start = value;
                InvalidateDates();
            }
        }

        DateTime _End = DateTime.Now;
        public DateTime End
        { 
            get { return _End; }
            set
            {
                _End = value;
                InvalidateDates();
            }
        }

        public TimeSpan Length { get { return End - Start; } }

        DateTime? _NextStart = null;
        public DateTime NextStart
        {
            get
            {
                if (!_NextStart.HasValue)
                    _NextStart = GetNextDateFrom(End) - Length;
                return _NextStart.Value;
            }
        }

        DateTime? _NextEnd = null;
        public DateTime NextEnd
        {
            get
            {
                if (!_NextEnd.HasValue)
                    _NextEnd = NextStart + Length;
                return _NextEnd.Value;
            }
        }

        private DateTime GetNextDateFrom(DateTime start)
        {
            if (start > DateTime.Now) return start;
            DateTime toReturn=start;
            DateTime now=DateTime.Now;
            switch (Repeat)
            {
                case RepeatType.Weekly:
                    while (toReturn < now) toReturn = toReturn.AddDays(7);
                    break;
                case RepeatType.BiWeekly:
                    while (toReturn < now) toReturn = toReturn.AddDays(14);
                    break;
                case RepeatType.MonthlyFirstWeek:
                    {
                        while (toReturn < now) toReturn = toReturn.AddDays(7);
                        toReturn = AdjustToNextWeekNum(toReturn, 1);
                        break;
                    }
                case RepeatType.MonthlySecondWeek:
                    {
                        while (toReturn < now) toReturn = toReturn.AddDays(7);
                        toReturn = AdjustToNextWeekNum(toReturn, 2);
                        break;
                    }
                case RepeatType.MonthlyThirdWeek:
                    {
                        while (toReturn < now) toReturn = toReturn.AddDays(7);
                        toReturn = AdjustToNextWeekNum(toReturn, 3);
                        break;
                    }
                case RepeatType.MonthlyFourthWeek:
                    {
                        while (toReturn < now) toReturn = toReturn.AddDays(7);
                        toReturn = AdjustToNextWeekNum(toReturn, 4);
                        break;
                    }
                case RepeatType.MonthlyLastWeek:
                    {
                        while (toReturn < now) toReturn = toReturn.AddDays(7);
                        toReturn = AdjustToNextWeekNum(toReturn, 5);
                        break;
                    }
                case RepeatType.MonthlyByDate:
                    while (toReturn < now) toReturn = toReturn.AddMonths(1);
                    break;
                case RepeatType.None:
                    toReturn = start;
                    break;
                default:
                    throw new Exception("Cannot calculate next date: RepeatType " + Repeat + " is not configured in EventInfo class!");
            }
            return toReturn;
        }

        private static DateTime AdjustToNextWeekNum(DateTime toReturn, int targetweek)
        {
            int week = (toReturn.Day / 7) + 1;

            while (week != Math.Min(targetweek, 4))
            {
                toReturn = toReturn.AddDays(7);
                week = (toReturn.Day / 7) + 1;
            }

            if (targetweek > 4) // ensure it's the last week of the month;
            {
                int targetmonth = toReturn.Month;
                while (targetmonth == toReturn.Month) toReturn = toReturn.AddDays(7);
                toReturn = toReturn.AddDays(-7);
            }
            return toReturn;
        }

        private void InvalidateDates()
        {
            _NextStart = null;
            _NextEnd = null;
        }

    }
}