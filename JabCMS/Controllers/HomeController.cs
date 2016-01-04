using JabCMS.DAL;
using JabCMS.Models;
using JabCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace JabCMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JabCMSContext db = new JabCMSContext();
            HomeIndexViewModel vm = new HomeIndexViewModel();

            vm.LatestPost = db.Posts.OrderByDescending(x => x.DateCreated).Include(x => x.Author).ToList().FirstOrDefault();
            //vm.LatestPost.Author = db.Authors.Where(x => x.AuthorId == db.Posts.OrderByDescending(y => y.DateCreated).Single().Author.AuthorId) as Author;
                                    
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}