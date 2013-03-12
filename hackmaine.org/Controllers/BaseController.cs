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
    public static class DateTimeExtensions
    {
        public static string ToISOString(this DateTime date)
        {
            return XmlConvert.ToString(date, XmlDateTimeSerializationMode.Local);
        }
    }

    public class BaseController : Controller
    {
    }
}
