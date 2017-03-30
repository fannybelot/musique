using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musique.Models
{
    public enum Format { mp3, flac, wma, wav };
    public class Music
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Range(1000, 3000)]
        public int ReleaseDate { get; set; }

        [Required]
        [StringLength(60)]
        public string Artist { get; set; }

        [Required]
        [StringLength(60)]
        public string Album { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public List<Format> Formats { get; set; }
    }
}