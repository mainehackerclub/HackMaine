using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackmaine.org.Models
{
    public class EventInfo
    {
        public EventInfo() { }

        public EventInfo(string eventname, IEnumerable<EventSchedule> schedules)
        {
            EventName = eventname;
            Schedules = schedules;
        }

        public string EventName { get; set; }
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
                DateTime Now=DateTime.Now;
                return Upcoming.FirstOrDefault();
            }
        }
    }
}