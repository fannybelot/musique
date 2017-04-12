using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Musique.Models;
using Musique.ViewModels;
using Musique.Services;
using System.IO;

namespace Musique.Controllers
{
    [RequireHttps]
    public class MusicsController : Controller
    {
        private MusicDBContext db = new MusicDBContext();
        private CommentsService commentsService = new CommentsService();

        // GET: Musics
        [HttpGet]
        public ActionResult Index(MusicsResearch filters)
        {
            var musics = db.Musics.ToList();
            var filteredMusics = new List<Music>();
            filteredMusics = musics;

            if (!string.IsNullOrEmpty(filters.MusicTitle))
            {
                filteredMusics = db.Musics.Where(c => c.Title.StartsWith(filters.MusicTitle)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.MusicGenre))
            {
                filteredMusics = filteredMusics.Where(c => c.Genre == filters.MusicGenre).ToList();
            }

            List<string> DiffFormats = new List<string>() { "mp3", "m4a", "wma", "wav" };

            if (filters.MusicFormatsResearch != null) {
                List<string> musiques = new List<string>();
                foreach (string f in filters.MusicFormatsResearch)
                {
                    foreach (var file in Directory.GetFiles("C:/Users/Fanny/Source/Repos/musique/Musique/Musique/Data", "*." + f))
                    {
                        musiques.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }
                filteredMusics = filteredMusics.Where(c => musiques.Contains(c.Title)).ToList();
            }


            MusicsResponseVM musicsResponseVM = new MusicsResponseVM()
            {
                FilteredMusicsCounter = filteredMusics.Count(),
                MusicsCounter = musics.Count(),
                Musics = filteredMusics,
                MusicGenres = db.Musics.Select(c => c.Genre).Distinct().ToList(),
                MusicFormats = DiffFormats
            };

            return View(musicsResponseVM);
        }

        // GET: Musics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicDetailVM musicDetail = new MusicDetailVM() {
                Music = db.Musics.Find(id),
                Comments = commentsService.GetCommentsByMusicId(id)
            };
            if (musicDetail.Music == null)
            {
                return HttpNotFound();
            }
            return View(musicDetail);
        }

        // GET: Musics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musics/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Artist,Album,Genre,Price,Formats")] Music music)
        {
            if (Request.Files.Count > 0)
            {
                for (int i=0; i<Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(file.FileName);
                        string format = extension.Substring(1);
                        List<string> DiffFormats = new List<string>() { "mp3", "m4a", "wma", "wav" };
                        if (DiffFormats.Contains(format))
                        {
                            string fileName = Request["ID"] + extension;
                            var path = Path.Combine(Server.MapPath("../Data"), fileName);
                            file.SaveAs(path);
                        }
                        else
                        {
                            throw new System.ArgumentException("Format non accepté", "extension");
                        }
                    }
                }               
            }
            if (ModelState.IsValid)
            {
                db.Musics.Add(music);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(music);
        }

        // GET: Musics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        // POST: Musics/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Artist,Album,Genre,Price")] Music music)
        {
            if (ModelState.IsValid)
            {
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {
            string id = Request["musicID2"];
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(Int32.Parse(id));

            if (music == null)
            {
                return HttpNotFound();
            }
            db.Musics.Remove(music);
            db.SaveChanges();
            return PartialView("_Delete", music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
