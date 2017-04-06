using Musique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musique.Services
{
    public class CommentsService
    {
        private MusicDBContext db = new MusicDBContext();

        public List<Comment> GetCommentsByMusicId(int? id)
        {
            List<Comment> comments = new List<Comment>();
            if (id != null)
            {
                comments = db.Comments.Where(c => c.MusicId == id).ToList();
            }

            return comments;
        }
    }
}