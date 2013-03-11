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
            EmbedURL = "http://maps.google.com/maps?q=Books-A-Million&amp;hl=en&amp;sll=44.833246,-68.746305&amp;sspn=0.011139,0.01678&amp;t=h&amp;ie=UTF8&amp;hq=Books-A-Million&amp;hnear=&amp;cid=401696528683542693&amp;source=embed&amp;ll=44.840595,-68.745832&amp;spn=0.024344,0.051413&amp;z=14&amp;iwloc=A&amp;output=embed",
            LargerURL = "http://maps.google.com/maps?q=Books-A-Million&amp;hl=en&amp;sll=44.833246,-68.746305&amp;sspn=0.011139,0.01678&amp;t=h&amp;ie=UTF8&amp;hq=Books-A-Million&amp;hnear=&amp;cid=401696528683542693&amp;source=embed&amp;ll=44.840595,-68.745832&amp;spn=0.024344,0.051413&amp;z=14&amp;iwloc=A",
            DirectURL = "http://maps.google.com/maps?q=Books-A-Million&hl=en&sll=44.833246,-68.746305&sspn=0.011139,0.01678&t=m&z=16&iwloc=A",
        };

        public static readonly VenueInfo MDMInfo = new VenueInfo("Maine Discovery Museum", "in Downtown Bangor", "74 Main St.", "Bangor")
        {
            Latitude = 44.800106,
            Longitude = -68.772003,
            EmbedURL = "https://maps.google.com/maps?hl=en&amp;q=Maine+Discovery+Museum+in+Downtown+Bangor&amp;ie=UTF8&amp;hq=Maine+Discovery+Museum&amp;hnear=Bangor,+Penobscot,+Maine&amp;t=m&amp;ll=44.803397,-68.76832&amp;spn=0.01218,0.025706&amp;z=15&amp;iwloc=A&amp;output=embed",
            LargerURL = "https://maps.google.com/maps?hl=en&amp;q=Maine+Discovery+Museum+in+Downtown+Bangor&amp;ie=UTF8&amp;hq=Maine+Discovery+Museum&amp;hnear=Bangor,+Penobscot,+Maine&amp;t=m&amp;ll=44.803397,-68.76832&amp;spn=0.01218,0.025706&amp;z=15&amp;iwloc=A&amp;source=embed",
            DirectURL = "http://www.bing.com/local/details.aspx?lid=YN418x10189830&q=Maine+Discovery+Museum+Bangor+ME&FORM=LARE",
        };

        public static readonly VenueInfo UnitedWayInfo = new VenueInfo("United Way", "Near the Bangor Mall", "24 Springer Drive, Suite 201", "Bangor");

        List<EventInfo> ActiveEvents = new List<EventInfo>()
        {
            new EventInfo("Next Meeting", MDMInfo, new DateTime(2013, 1, 8).AddHours(18), TimeSpan.FromHours(3.0), EventInfo.RepeatType.BiWeekly),
            new EventInfo("Hack Day", UnitedWayInfo, new DateTime(2013, 3, 9, 9, 30, 0), new DateTime(2013, 3, 9, 16, 0, 0), EventInfo.RepeatType.None)   
        };

        public ActionResult Index()
        {
            ViewBag.Message = "Getting nerdy at biweekly meetings in Bangor";
            ViewBag.ActiveEvents = ActiveEvents;

            return View();
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
