using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

public static class DateTimeExtensions
{
    public static string ToISOString(this DateTime date)
    {
        return XmlConvert.ToString(date, XmlDateTimeSerializationMode.Local);
    }

    public static string ToISODateUTCString(this DateTime date)
    {
        string calDateFormat = "yyyyMMddTHHmmssZ";
        return date.ToUniversalTime().ToString(calDateFormat);
    }
}
