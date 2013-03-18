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

    public static string ToDateString(this DateTime date)
    {
        return string.Format("{0} {1} {2}", OrdinalSuffix(date.Day), date.MonthName(), date.Year);
    }

    public static string MonthName(this DateTime date)
    {
        return date.ToString("MMM");
    }

    public static string OrdinalSuffix(int number)
    {
        string suffix = String.Empty;

        int ones = number % 10;
        int tens = (int)Math.Floor(number / 10M) % 10;

        if (tens == 1)
        {
            suffix = "th";
        }
        else
        {
            switch (ones)
            {
                case 1:
                    suffix = "st";
                    break;

                case 2:
                    suffix = "nd";
                    break;

                case 3:
                    suffix = "rd";
                    break;

                default:
                    suffix = "th";
                    break;
            }
        }
        return String.Format("{0}{1}", number, suffix);
    }
}
