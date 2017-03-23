using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musique.Models
{
    public class Music
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public List<string> Formats { get; set; }
    }
}