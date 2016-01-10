using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabCMS.ViewModels
{
    public class AssignedPostCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}