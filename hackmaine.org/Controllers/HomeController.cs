using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackmaine.org.Controllers
{
    public struct VenueInfo
    {
        public string Name;
        public string LocationDesc;
        public string LocationAddr;
        public string DirectURL;
        public string EmbedURL;
        public string LargerURL;
    }
    

    public class HomeController : Controller
    {
        public static readonly VenueInfo BAMInfo = new VenueInfo()
        {
            Name = "Books-A-Million",
            LocationDesc = "near the Bangor Mall in Bangor",
            LocationAddr = "116 Bangor Mall Blvd. Bangor, ME",
            DirectURL = "http://maps.google.com/maps?q=Books-A-Million&hl=en&sll=44.833246,-68.746305&sspn=0.011139,0.01678&t=m&z=16&iwloc=A",
            EmbedURL = "http://maps.google.com/maps?q=Books-A-Million&amp;hl=en&amp;sll=44.833246,-68.746305&amp;sspn=0.011139,0.01678&amp;t=h&amp;ie=UTF8&amp;hq=Books-A-Million&amp;hnear=&amp;cid=401696528683542693&amp;source=embed&amp;ll=44.840595,-68.745832&amp;spn=0.024344,0.051413&amp;z=14&amp;iwloc=A&amp;output=embed",
            LargerURL = "http://maps.google.com/maps?q=Books-A-Million&amp;hl=en&amp;sll=44.833246,-68.746305&amp;sspn=0.011139,0.01678&amp;t=h&amp;ie=UTF8&amp;hq=Books-A-Million&amp;hnear=&amp;cid=401696528683542693&amp;source=embed&amp;ll=44.840595,-68.745832&amp;spn=0.024344,0.051413&amp;z=14&amp;iwloc=A",
        };

        public static readonly VenueInfo MDMInfo = new VenueInfo()
        {
            Name = "Maine Discovery Museum",
            LocationDesc = "in Downtown Bangor",
            LocationAddr = "74 Main St, Bangor",
            DirectURL = "http://www.bing.com/local/details.aspx?lid=YN418x10189830&q=Maine+Discovery+Museum+Bangor+ME&FORM=LARE",
            EmbedURL = "https://maps.google.com/maps?hl=en&amp;q=Maine+Discovery+Museum+in+Downtown+Bangor&amp;ie=UTF8&amp;hq=Maine+Discovery+Museum&amp;hnear=Bangor,+Penobscot,+Maine&amp;t=m&amp;ll=44.803397,-68.76832&amp;spn=0.01218,0.025706&amp;z=15&amp;iwloc=A&amp;output=embed",
            LargerURL = "https://maps.google.com/maps?hl=en&amp;q=Maine+Discovery+Museum+in+Downtown+Bangor&amp;ie=UTF8&amp;hq=Maine+Discovery+Museum&amp;hnear=Bangor,+Penobscot,+Maine&amp;t=m&amp;ll=44.803397,-68.76832&amp;spn=0.01218,0.025706&amp;z=15&amp;iwloc=A&amp;source=embed",
        };

        public ActionResult Index()
        {
            ViewBag.Message = "Getting nerdy at biweekly meetings in Bangor";

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
