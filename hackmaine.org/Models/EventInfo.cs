using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace hackmaine.org.Models
{
    public class EventInfo
    {
        public EventInfo() { }

        public EventInfo(Guid eventguid, string eventname, string description, IEnumerable<EventSchedule> schedules)
        {
            ID = eventguid;
            EventName = eventname;
            Description = description;
            Schedules = schedules;
        }

        public Guid ID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }

        public IEnumerable<EventSchedule> Schedules { get; set; }

        public IEnumerable<String> ImageURLs { get; set; }

        public IEnumerable<EventSchedule> Upcoming
        {
            get
            {
                DateTime Now = DateTime.Now;
                return Schedules.Where(m => m.NextEnd > Now).OrderBy(m => m.NextStart);
            }
        }

        public EventSchedule Next
        {
            get
            {
                DateTime Now = DateTime.Now;
                return Upcoming.FirstOrDefault();
            }
        }

        public string NextUID(EventSchedule schedule)
        {
            DateTime start = schedule.NextStart;
            DateTime end = schedule.NextEnd;
            return string.Format("{0}_{1:0000}{2:00}{3:00}{4:00}{5:00}", this.ID.ToString(), start.Year, start.Month, start.Day, start.Hour, start.Minute);
        }


        /// <summary>
        /// Find an upcoming event schedule instance from it's ID
        /// </summary>
        public EventSchedule UpcomingFromUID(string UUID)
        {
            string myGuid = ID.ToString() + '_';
            if (UUID.StartsWith(myGuid))
            {
                DateTime? result = DecodeDateID(UUID.Remove(0, myGuid.Length));
                if (result.HasValue)
                {
                    foreach (var schedule in Upcoming)
                    {
                        if (schedule.NextStart == result)
                            return schedule;
                    }
                }
            }

            return null;
        }

        private static DateTime? DecodeDateID(string dateCode)
        {
            // Example: 201303041430
            ulong dateVal;
            if (ulong.TryParse(dateCode, out dateVal))
            {
                int year = (int)(dateVal / 100000000);
                int month = (int)((dateVal % 100000000) / 1000000);
                int day = (int)((dateVal % 1000000) / 10000);
                int hour = (int)((dateVal % 10000) / 100);
                int minute = (int)(dateVal % 100);
                DateTime result;
                try
                {
                    result = new DateTime(year, month, day, hour, minute, 0);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
                return result;
            }
            else
                return null;
        }

        public string CreateICS(EventSchedule schedule)
        {
            string UID = NextUID(schedule);
            return CreateICS(UID, schedule.NextStart, schedule.NextEnd, schedule.Venue.Name, Description, EventName, schedule.Venue.LocationAddrStreet,
                schedule.Venue.LocationAddrLocality, schedule.Venue.LocationAddrState, schedule.Venue.Latitude, schedule.Venue.Longitude);
        }

        public string CreateGoogleCalURL(EventSchedule schedule)
        {
            string UID = NextUID(schedule);
            return CreateGoogleCalURL(schedule.NextStart, schedule.NextEnd, "http://www.hackmaine.org", EventName, schedule.Venue.Name, schedule.Venue.LocationAddrStreet,
                schedule.Venue.LocationAddrLocality, schedule.Venue.LocationAddrState, "Hack Maine", Description);
        }

        public string CreateYahooCalURL(EventSchedule schedule)
        {
            string UID = NextUID(schedule);
            return CreateYahooCalURL(schedule.NextStart, schedule.Duration, "http://www.hackmaine.org", EventName, schedule.Venue.Name, schedule.Venue.LocationAddrStreet,
                schedule.Venue.LocationAddrLocality, schedule.Venue.LocationAddrState, "Hack Maine", Description);
        }

        public static string CreateICS(string UID, DateTime start, DateTime end, string venueName, string description, string eventName,
            string addrStreet, string addrLocality, string addrRegion, double? latitude = null, double? longitude = null)
        {
            string ProdID = System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            string location;
            string geo = "";
            if (latitude.HasValue && longitude.HasValue)
                geo = string.Format("GEO:{0};{1}\r\n", latitude.Value, longitude.Value);
            location = string.Format("{0}LOCATION:{1} ({2}\\, {3}\\, {4})", geo, venueName, addrStreet, addrLocality, addrRegion);

            string tzInfo = "BEGIN:VTIMEZONE\r\nTZID:America/New_York\r\nTZURL:http://tzurl.org/zoneinfo-outlook/America/New_York\r\nX-LIC-LOCATION:America/New_York\r\nBEGIN:DAYLIGHT\r\nTZOFFSETFROM:-0500\r\nTZOFFSETTO:-0400\r\nTZNAME:EDT\r\nDTSTART:19700308T020000\r\nRRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=2SU\r\nEND:DAYLIGHT\r\nBEGIN:STANDARD\r\nTZOFFSETFROM:-0400\r\nTZOFFSETTO:-0500\r\nTZNAME:EST\r\nDTSTART:19701101T020000\r\nRRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU\r\nEND:STANDARD\r\nEND:VTIMEZONE";

            string bodyCalendar = "BEGIN:VCALENDAR\r\nMETHOD:REQUEST\r\nPRODID:" + ProdID + "\r\nVERSION:2.0\r\n" + tzInfo + "\r\nBEGIN:VEVENT\r\nDTSTAMP:{6}\r\nDTSTART:{0}\r\nSUMMARY:Hack Maine: {5}\r\nUID:{3}\r\n{2}\r\nDTEND:{1}\r\nDESCRIPTION:{4}\\N\r\nSEQUENCE:1\r\nPRIORITY:5\r\nCLASS:\r\nCREATED:{6}\r\nLAST-MODIFIED:{6}\r\nSTATUS:CONFIRMED\r\nTRANSP:OPAQUE\r\nX-MICROSOFT-CDO-BUSYSTATUS:BUSY\r\nX-MICROSOFT-CDO-INSTTYPE:0\r\nX-MICROSOFT-CDO-INTENDEDSTATUS:BUSY\r\nX-MICROSOFT-CDO-ALLDAYEVENT:FALSE\r\nX-MICROSOFT-CDO-IMPORTANCE:1\r\nX-MICROSOFT-CDO-OWNERAPPTID:-1\r\nX-MICROSOFT-CDO-ATTENDEE-CRITICAL-CHANGE:{6}\r\nX-MICROSOFT-CDO-OWNER-CRITICAL-CHANGE:{6}\r\nBEGIN:VALARM\r\nACTION:DISPLAY\r\nDESCRIPTION:REMINDER\r\nTRIGGER;RELATED=START:-PT00H30M00S\r\nEND:VALARM\r\nEND:VEVENT\r\nEND:VCALENDAR\r\n";
            bodyCalendar = string.Format(bodyCalendar,
                start.ToISODateUTCString(),
                end.ToISODateUTCString(),
                location,
                UID,
                description,
                eventName,
                DateTime.Now.ToISODateUTCString()
            );
            return bodyCalendar;
        }

        public static string CreateGoogleCalURL(DateTime start, DateTime end, string website, string eventName, string location,
            string addrStreet, string addrLocality, string addrRegion, string groupName, string description)
        {
            string format = "http://www.google.com/calendar/event?action=TEMPLATE&dates={0}%2f{1}&sprop=website%3a{2}&text={3}&location={4}+-+{5}+-+{6}%2C+{7}&sprop=name:{8}&details={9}";
            string toReturn = string.Format(format,
                start.ToISODateUTCString(),
                end.ToISODateUTCString(),
                System.Net.WebUtility.UrlEncode(website),
                System.Net.WebUtility.UrlEncode("Hack Maine: "+ eventName),
                System.Net.WebUtility.UrlEncode(location),
                System.Net.WebUtility.UrlEncode(addrStreet),
                System.Net.WebUtility.UrlEncode(addrLocality),
                System.Net.WebUtility.UrlEncode(addrRegion),
                System.Net.WebUtility.UrlEncode(groupName),
                System.Net.WebUtility.UrlEncode(description)
                );
            return toReturn;
        }

        public static string CreateYahooCalURL(DateTime start, TimeSpan duration, string website, string eventName, string location,
            string addrStreet, string addrLocality, string addrRegion, string groupName, string summary)
        {
            string durString = string.Format("{0:00}{1:00}", (int)duration.TotalHours, duration.Minutes);
            string format = "http://calendar.yahoo.com/?v=60&VIEW=d&in_loc={4}&in_csz={6}%2c+{7}&type=20&TITLE={3}&ST={0}&DUR={1}&URL{2}&DESC={9}";
            string toReturn = string.Format(format,
                start.ToISODateUTCString(),
                durString,
                System.Net.WebUtility.UrlEncode(website),
                System.Net.WebUtility.UrlEncode("Hack Maine: " + eventName),
                System.Net.WebUtility.UrlEncode(location),
                System.Net.WebUtility.UrlEncode(addrStreet),
                System.Net.WebUtility.UrlEncode(addrLocality),
                System.Net.WebUtility.UrlEncode(addrRegion),
                System.Net.WebUtility.UrlEncode(groupName),
                System.Net.WebUtility.UrlEncode(summary)
                );
            return toReturn;
        }
    }
}