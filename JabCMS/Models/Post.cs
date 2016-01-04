﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JabCMS.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}