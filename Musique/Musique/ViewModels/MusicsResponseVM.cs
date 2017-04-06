using Musique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musique.ViewModels
{
    public class MusicsResearch
    {
        public string MusicGenre { get; set; }
        public string MusicTitle { get; set; }
        public string MusicArtist { get; set; }
        public List<Format> MusicFormatsResearch { get; set; }
    }
    public class MusicsResponseVM
    {
        public List<Format> MusicFormats { get; set;  }
        public List<string> MusicGenres { get; set; }
        public List<Music> Musics { get; set; }
        public int MusicsCounter { get; set; }
        public int FilteredMusicsCounter { get; set; }
        public List<MusicsResearch> MusicResearch { get; set; }
    }
}