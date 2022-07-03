using ASPcinema.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPcinema.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ModelCinemaContainer _db;

        public HomeController()
        {
            
           _db = new ModelCinemaContainer();
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public int GetFilmsCount()
        {
            return _db.FilmSet.Count();
        }

        [HttpGet]
        public int GetFilmSessionsCount()
        {
            return _db.FilmSessionSet.Count();
        }

        [HttpGet]
        public int GetGenresCount()
        {
            return _db.GenreSet.Count();
        }
    }
}