using ASPcinema.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPcinema.Models
{
    public class SessionsPageModel
    {
        public List<Film> Films { get; set; }

        public List<FilmSession> FilmSessions { get; set; }
    }
}