using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPcinema.Controllers
{
    
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Day()
        {
            DateTime day = DateTime.Now;
            if (day == null)
            {
                day = DateTime.Now;
                return View(day);
            }

            return View(day);
        }
    }
}