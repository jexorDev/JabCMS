using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JabCMS.App_Start
{
    public class CategoryActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            JabCMS.DAL.JabCMSContext db = new JabCMS.DAL.JabCMSContext();

            filterContext.Controller.ViewBag.Categories = db.Categories;
        }
    }
}