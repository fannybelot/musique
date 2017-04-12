using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musique.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int MusicId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Content { get; set; }

        [Range(0,5)]
        public int Rating { get; set; }
    }
}