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
        private MusicDBContext db = new MusicDBContext();

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

        // POST: Cart/AddToCart
        [HttpPost]
        public ActionResult AddToCart()
        {
            string id = Request["musicIDadd"];
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(Int32.Parse(id));

            if (music == null)
            {
                return HttpNotFound();
            }

            List<Music> cartMusics;
            if (Session["Musics"] == null)
            {
                cartMusics = new List<Music>();
            }
            else
            {
                cartMusics = (List<Music>)Session["Musics"];
            }

            if (/*cartMusics.Contains(music)*/Contient(cartMusics, id) == false)
            {
                cartMusics.Add(music);
                Session["Musics"] = cartMusics;
                return PartialView("_AddToCart", music);
            }
            Session["Musics"] = cartMusics;
            return PartialView("_AlreadyInCart", music);
        }

        public bool Contient(List<Music> cartMusics, string id)
        {
            foreach (var cartMusic in cartMusics)
            {
                if (cartMusic.ID == (Int32.Parse(id)))
                {
                    return true;
                }
            }
            return false;
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

            Music music = db.Musics.Find(Int32.Parse(id));
            if (cart.CartMusics == null)
            {
                return HttpNotFound();
            }
            else
            {
                cart.CartMusics.RemoveAll(c => c.ID == Int32.Parse(id));
            }
            return PartialView("_Remove", music);
        }
    }
}
