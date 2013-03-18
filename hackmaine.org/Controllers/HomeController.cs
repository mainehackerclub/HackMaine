using hackmaine.org.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public static ImageInfo[] Images = 
        { 
            new ImageInfo() { Date=new DateTime(2012,7,24), Title="Hacking Arduino via Sketch IDE.", ThumbURL="/Images/meetups/20120724_01t.jpg", FullURL="/Images/meetups/20120724_01.jpg"},
            new ImageInfo() { Date=new DateTime(2012,7,24), Title="Grokking memory corruption security exploits.", ThumbURL="/Images/meetups/20120724_02t.jpg", FullURL="/Images/meetups/20120724_02.jpg"},
            new ImageInfo() { Date=new DateTime(2012,9,18), Title="Denis takes us through a “Electrical Circuits 101”", ThumbURL="/Images/meetups/20120918_01t.jpg", FullURL="/Images/meetups/20120918_01.jpg"},
            new ImageInfo() { Date=new DateTime(2012,10,2), Title="Check out the nerd joy on @zacheryschiller", ThumbURL="/Images/meetups/20121002_01t.jpg", FullURL="/Images/meetups/20121002_01.jpg"},
            new ImageInfo() { Date=new DateTime(2012,10,2), Title="Join us for some hardware hacking.", ThumbURL="/Images/meetups/20121002_02t.jpg", FullURL="/Images/meetups/20121002_02.jpg"},
            new ImageInfo() { Date=new DateTime(2013,1,8), Title="Big group at Books-A-Million", ThumbURL="/Images/meetups/20130108_01t.jpg", FullURL="/Images/meetups/20130108_01.jpg"},
            new ImageInfo() { Date=new DateTime(2013,2,5), Title="Collaborating at the Maine Discovery Museum", ThumbURL="/Images/meetups/20130205_01t.jpg", FullURL="/Images/meetups/20130205_01.jpg"},
            new ImageInfo() { Date=new DateTime(2013,2,5), Title="Checking out some exhibits", ThumbURL="/Images/meetups/20130205_02t.jpg", FullURL="/Images/meetups/20130205_02.jpg"},
            new ImageInfo() { Date=new DateTime(2013,3,5), Title="Drawing stuff", ThumbURL="/Images/meetups/20130305_01t.jpg", FullURL="/Images/meetups/20130305_01.jpg"},
            new ImageInfo() { Date=new DateTime(2013,3,5), Title="Aaron does some plumbing", ThumbURL="/Images/meetups/20130305_02t.jpg", FullURL="/Images/meetups/20130305_02.jpg"},
            new ImageInfo() { Date=new DateTime(2013,3,9), Title="First Hack Day", ThumbURL="/Images/meetups/20130309_01t.jpg", FullURL="/Images/meetups/20130309_01.jpg"},
        };

        public ActionResult Index()
        {
            ViewBag.Message = "Getting nerdy at biweekly meetings in Bangor";
            ViewBag.ActiveEvents = ActiveEvents;
            ViewBag.Images = Images.OrderByDescending(m=>m.Date);
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

        string meetupFrameReq = "https://api.meetup.com/oembed?key=3b7d431d2c7427116f41916f7d1226&sign=true&url=http://www.meetup.com/Hacker-Club/";

        [OutputCache(Duration=360)]
        public async Task<PartialViewResult> MeetupFrame()
        {
            var req = WebRequest.CreateHttp(meetupFrameReq);
            try
            {
                using (var r = await req.GetResponseAsync())
                {
                    var jsonSerializer = new JsonSerializer();
                    dynamic response = jsonSerializer.Deserialize(new JsonTextReader(new StreamReader(r.GetResponseStream())));

                    string html = response.html.Value;
                    html = html.Replace("<div id=\"meetup_oembed\" style=\"height:397px\">", "<div id=\"meetup_oembed\">");

                    return PartialView(new MvcHtmlString(html));
                }
            }
            catch
            {
                Response.StatusCode = 500;
                Response.StatusDescription = "Unable to retrieve data from Meetup.com";
                return null;
            }

        }

        public PartialViewResult MeetupProfile()
        {
            return PartialView();
        }
    }
}
