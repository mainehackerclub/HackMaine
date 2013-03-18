using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackmaine.org.Models
{
    public class ImageInfo
    {
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string FullURL { get; set; }
        public string ThumbURL { get; set; }
    }
}