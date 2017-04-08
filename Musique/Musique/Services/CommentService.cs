using Musique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musique.Services
{
    public class CommentService
    {
        private MusicDBContext db = new MusicDBContext();

        public List<Comment> getCommentsByMusicId(int id)
        {
            return db.Comments.Where(c => c.MusicId == id).ToList();
        }
    }
}