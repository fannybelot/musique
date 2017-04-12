using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musique.Models;
using System.Web.Security;

namespace Musique.Controllers
{
    [Authorize]
    [RequireHttps]
    public class CommentsController : Controller
    {
        private MusicDBContext db = new MusicDBContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content,Rating,MusicId")] Comment Comment)
        {
            Comment.CommentDate = DateTime.Now;
            Comment.UserName = Membership.GetUser().UserName;

            if (ModelState.IsValid)
            {
                db.Comments.Add(Comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
