using ASPcinema.Domains;
using ASPcinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPcinema.Controllers
{
    
    public class ScheduleController : Controller
    {
        protected readonly ModelCinemaContainer _db;

        public ScheduleController()
        {
            _db = new ModelCinemaContainer();
        }

        // GET: Schedule
        public ActionResult Day()
        {
            DateTime day = DateTime.Now;

            return View(day);
        }

        public ActionResult Halls()
        {
            var model = new HallsModel()
            {
                Halls = _db.CinemaHallSet.AsEnumerable().ToList()
            };

            return View(model);
        }
    }
}