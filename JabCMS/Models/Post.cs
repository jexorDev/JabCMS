using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabCMS.Models
{
    public class Post
    {
        int Id { get; set; }
        string Title { get; set; }
        Category Category { get; set; }
        DateTime DateCreated { get; set; }
        string Content { get; set; }
    }
}