using JabCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabCMS.ViewModels
{
    public class LayoutViewModel
    {
        public ICollection<Category> Categories { get; set; }
    }
}