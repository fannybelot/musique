using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musique.Models
{
    public class Order
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int MusicId { get; set; }

        [Required]
        public System.DateTime OrderDate { get; set; }

        public virtual Music Music { get; set; }
    }
}