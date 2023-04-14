using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laboratorio3.Models;

namespace laboratorio3.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            var song = GetSongInfo();
            ViewBag.MainTitle = "A Very Good Song :)";
            return View(song);
        }

        private SongModel GetSongInfo()
        {
            SongModel song = new SongModel();
            song.SongName = "Sale el Sol";
            song.Artists = "Young Miko";
            song.Genre = "HipHop/Trap";
            song.Album = "None";
            song.ReleaseDate = "2022, 12, 5";
            return song;
        }
    }
}
