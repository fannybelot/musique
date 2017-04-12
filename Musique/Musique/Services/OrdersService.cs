using Musique.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musique.Services
{
    public class OrdersService
    {
        private MusicDBContext db = new MusicDBContext();

        public List<Order> GetOrdersByUserName(string username)
        {
            List<Order> orders = new List<Order>();
            if (String.IsNullOrEmpty(username))
            {
                orders = db.Orders.Where(c => c.UserName == username).Include(c => c.Music).OrderByDescending(c => c.OrderDate).ToList();
            }

            return orders;
        }
    }
}