using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JabCMS.Models;
using JabCMS.ViewModels;
using JabCMS.DAL;

namespace JabCMS.Controllers
{
    public class PostController : Controller
    {
        private JabCMSContext db = new JabCMSContext();

        // GET: /Post/
        public ActionResult Index(string orderBy, string searchString)
        {
            var posts = db.Posts.Include(x => x.Author)
                                .Include(x => x.Categories)
                                .ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(x => x.Title.Contains(searchString) ||
                                         x.Author.Name.Contains(searchString)).ToList();
            }

            if (orderBy == null)
                posts.OrderBy(x => x.Title);
            else 
                posts.OrderBy(x => x.DateCreated);

            return View(posts);
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            PostCreateViewModel vm = new PostCreateViewModel();
            vm.AuthorSelectList = new SelectList(db.Authors, "AuthorId", "Name");

            //ViewBag.AllCategories = db.Categories();
            vm.SelectedCategories = new List<AssignedPostCategory>(); 

            foreach(var category in db.Categories)
            {
                vm.SelectedCategories.Add(new AssignedPostCategory()
                    {
                        CategoryId = category.Id,
                        Name = category.Name,
                        Assigned = false
                    });
            }

            return View(vm);
        }

        
        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel vm)
        {
            vm.Post.Author = db.Authors.Where(x => x.AuthorId == vm.SelectedAuthor).Single();
            
            if (ModelState.IsValid)
            {
                db.Posts.Add(vm.Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,DateCreated,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
