using JabCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JabCMS.ViewModels
{
    public class PostCreateViewModel
    {
        public Post Post { get; set; }
        public int SelectedAuthor { get; set; }
        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }

        public IList<AssignedPostCategory> SelectedCategories { get; set; }
    }
}