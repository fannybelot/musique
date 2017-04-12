using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Musique.Models
{
    public class MusicDBContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}