using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackmaine.org.Models
{
    public class VenueInfo
    {
        public VenueInfo(string name, string locationBrief, string addrstreet, string addrcity, string addrstate = "ME", double? latitude = null, double? longitude = null, string url_web = null, string url_image = null)
        {
            Name = name;
            LocationDesc = locationBrief;
            LocationAddrStreet = addrstreet;
            LocationAddrLocality = addrcity;
            LocationAddrState = addrstate;

            Latitude = latitude;
            Longitude = longitude;
            URL_Web = url_web;
            URL_Image = url_image;
        }

        public string Name { get; set; }
        public string URL_Web { get; set; }
        public string URL_Image { get; set; }
        public string LocationDesc { get; set; }
        public string LocationAddrStreet { get; set; }
        public string LocationAddrLocality { get; set; }
        public string LocationAddrState { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string _LocationAddr = null;
        public string LocationAddr
        {
            set { _LocationAddr = value; }
            get
            {
                return _LocationAddr ?? (_LocationAddr = string.Format("{0} {1}, {2}", LocationAddrStreet, LocationAddrLocality, LocationAddrState));
            }
        }

        const string baseFormat = "http://maps.google.com/maps?q={0}&hl=en&sll={1},{2}&t=m&iwloc=A";
        const string embedFormat = baseFormat + "&z=14&output=embed";
        const string directFormat = baseFormat + "&z=16";
        const string largerFormat = directFormat;

        const double BangorLatitude = 44.803032;
        const double BangorLongitude = 68.76756;

        string _EmbedURL = null;
        public string EmbedURL
        {
            set { _EmbedURL = value; }
            get
            {
                return _EmbedURL ??
                    (_EmbedURL = BuildMapURL(embedFormat));
            }
        }

        string _DirectURL = null;
        public string DirectURL
        {
            set { _DirectURL = value; }
            get
            {
                return _DirectURL ??
                    (_DirectURL = BuildMapURL(directFormat));
            }
        }

        string _LargerURL = null;
        public string LargerURL
        {
            set { _LargerURL = value; }
            get
            {
                return _LargerURL ??
                    (_LargerURL = BuildMapURL(largerFormat));
            }
        }

        private string BuildMapURL(string format)
        {
            return string.Format(format, HasCoords ? Name : string.Format("{0}+{1}", Name, LocationAddr), Latitude ?? BangorLatitude, Longitude ?? BangorLongitude).Replace(' ', '+');
        }

        public bool HasCoords { get { return Latitude.HasValue && Longitude.HasValue; } }
    }

}