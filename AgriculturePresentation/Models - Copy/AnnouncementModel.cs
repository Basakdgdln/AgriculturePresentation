using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Models___Copy
{
    public class AnnouncementModel
    {
        public int AnnouncemenetID { get; set; }
        public string AnnouncemenetTitle { get; set; }
        public string AnnouncemenetDescription { get; set; }
        public DateTime AnnouncemenetDate { get; set; }
        public bool AnnouncemenetStatus { get; set; }
    }
}
