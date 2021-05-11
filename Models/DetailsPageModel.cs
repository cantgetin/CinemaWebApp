using ASPcinema.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPcinema.Models
{
    public class DetailsPageModel
    {
        public Film Film { get; set; }
        public List<FilmSession> FilmSessions { get; set; }
        public List<SeatTicket> Tickets { get; set; }

    }
}