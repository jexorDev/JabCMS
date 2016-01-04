using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabCMS.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string BriefBio { get; set; }
    }
}