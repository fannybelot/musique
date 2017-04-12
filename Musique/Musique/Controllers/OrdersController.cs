using Musique.Models;
using Musique.Services;
using Musique.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Musique.Controllers
{
    [RequireHttps]
    [Authorize]
    public class OrdersController : Controller
    {
        private MusicDBContext db = new MusicDBContext();
        private OrdersService ordersService = new OrdersService();

        // GET: Orders
        public ActionResult Index()
        {
            OrdersResponseVM ordersVM = new OrdersResponseVM()
            {
                Orders = ordersService.GetOrdersByUserName(Membership.GetUser().UserName)
            };
            return View(ordersVM);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Validate()
        {
            return View();
        }

        // POST: Orders/Validate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validate()
        {
            if (Session["Musics"] == null)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
            List<Music> cartMusics = (List<Music>)Session["Musics"];
            foreach (var music in cartMusics)
            {
                Order order = new Order();
                order.MusicId = music.ID;
                order.UserName = Membership.GetUser().UserName;
                order.OrderDate = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
            }
            return Redirect("/Orders/Index");
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
