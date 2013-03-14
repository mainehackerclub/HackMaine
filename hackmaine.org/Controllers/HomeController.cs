using hackmaine.org.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackmaine.org.Controllers
{

    public class HomeController : BaseController
    {
        public static readonly VenueInfo BAMInfo =
            new VenueInfo("Books-A-Million", "near the Bangor Mall in Bangor", "116 Bangor Mall Blvd.", "Bangor")
        {
            Latitude = 44.834174,
            Longitude = -68.746305,
        };

        public static readonly VenueInfo MDMInfo = new VenueInfo("Maine Discovery Museum", "in Downtown Bangor", "74 Main St.", "Bangor")
        {
            URL_Web = "http://www.mainediscoverymuseum.org/",
            URL_Image="http://www.bing.com/th?id=A%2b4a3T%2fdT%2fqNSoQ480x360",
            Latitude = 44.800106,
            Longitude = -68.772003,
        };

        public static readonly VenueInfo UnitedWayInfo = new VenueInfo("United Way", "Near the Bangor Mall", "24 Springer Drive Suite 201", "Bangor");

        List<EventInfo> ActiveEvents = new List<EventInfo>()
        {
            new EventInfo(Guid.Parse("6a73c03d-0f5a-4978-bee6-6919292e5654"), "Regular Meeting", "More info at http://www.hackmaine.org/",
                new EventSchedule[]{ 
                    new EventSchedule( MDMInfo, new DateTime(2013, 3, 13, 17, 0, 0), TimeSpan.FromHours(4.0), EventSchedule.RepeatType.None),
                    new EventSchedule( MDMInfo, new DateTime(2013, 1, 8, 18, 0 ,0), TimeSpan.FromHours(3.0), EventSchedule.RepeatType.BiWeekly),
                    new EventSchedule( BAMInfo, new DateTime(2013, 3, 27, 18, 0 ,0), TimeSpan.FromHours(3.0), EventSchedule.RepeatType.BiWeekly)
                }),
            new EventInfo(Guid.Parse("ed70d17e-dffb-4f4b-8c4b-16e6573a1c93"), "Hack Day", "Our first day of hacking.",
                new EventSchedule[]{ new EventSchedule( UnitedWayInfo, new DateTime(2013, 3, 9, 9, 30, 0), new DateTime(2013, 3, 9, 16, 0, 0), EventSchedule.RepeatType.None)}
                )
                {
                    ImageURLs=new string[]{ "/Images/flyers/HackDay20130309.jpg" }
                }
        };

        public ActionResult Index()
        {
            ViewBag.Message = "Getting nerdy at biweekly meetings in Bangor";
            ViewBag.ActiveEvents = ActiveEvents;

            return View();
        }

        public ActionResult vCal(string id)
        {
            string[] split = id.Split('_');
            Guid eventId;
            if(split.Length==2 && Guid.TryParse(split[0],out eventId))
            {
                var Event = ActiveEvents.Where(m=>m.ID==eventId).FirstOrDefault();
                if (eventId != null)
                {
                    var sch = Event.UpcomingFromUID(id);
                    if (sch != null)
                    {
                        string ics = Event.CreateICS(sch);
                        if (!string.IsNullOrWhiteSpace(ics))
                        {
                            Response.ContentType = "text/calendar";
                            Response.Write(ics);
                            return null;
                        }
                    }
                }
            }

            Response.StatusCode = 404;
            return null;
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
