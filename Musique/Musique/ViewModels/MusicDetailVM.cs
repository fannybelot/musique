using Musique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musique.ViewModels
{
    public class MusicDetailVM
    {
        public Music Music { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}