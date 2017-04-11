using Musique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Musique.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = new Cart();
            cart.CartMusics = new List<Music>();
            if (Session["Musics"] != null) {
                cart.CartMusics = (List<Music>)Session["Musics"];
            }
            return View(cart);
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        [HttpPost]
        public ActionResult Delete()
        {
            string id = Request["musicIDrm"];
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cart cart = new Cart();
            cart.CartMusics = new List<Music>();
            if (Session["Musics"] != null)
            {
                cart.CartMusics = (List<Music>)Session["Musics"];
            }

            if (cart.CartMusics == null)
            {
                return HttpNotFound();
            }
            else
            {
                cart.CartMusics.RemoveAll(c => c.ID == Int32.Parse(id));
            }
            return PartialView("_Remove");
        }
    }
}
