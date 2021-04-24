using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarseNizami.Data
{
    public class Lecture
    {
        public string LectureID { get; set; }
        public string LectureTitle { get; set; }
        public string LectureDuration { get; set; }
        public string LectureName { get; set; }
        public string LectureSNo { get; set; }
        public string BlbID { get; set; }
        public int LastPlayed { get; set; }
    }
}
