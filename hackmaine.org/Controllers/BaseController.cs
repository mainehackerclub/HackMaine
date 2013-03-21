using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;

namespace hackmaine.org.Controllers
{

    public class BaseController : Controller
    {

        public static string rss_forums_Active { get { return "http://www.hackmaine.org/forums/feed.php?mode=topics_active"; } }
        public static string rss_forums_News { get { return "http://www.hackmaine.org/forums/feed.php?mode=news"; } }
        public static string rss_forums_All { get { return "http://www.hackmaine.org/forums/feed.php?mode=all"; } }

    }
}
