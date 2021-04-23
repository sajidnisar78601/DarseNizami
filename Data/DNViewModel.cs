using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarseNizami.Data
{
    public class DNViewModel
    {
        public string BundleID { get; set; }
        public string BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookYear { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string TeacherName { get; set; }
        public string LanguageName { get; set; }
        public string FunNameArabic { get; set; }
        public string FunNameEng { get; set; }
        public string DarajaNameArabic { get; set; }
        public string DarajaNameEng { get; set; }
        public string Duration { get; set; }
        public string WatchFlag { get; set; }
        public string RevisionMark { get; set; }
        public string RevisionComments { get; set; }
        public string BookImagePath { get; set; }
    }
}
