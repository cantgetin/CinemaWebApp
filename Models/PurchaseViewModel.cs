using ASPcinema.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPcinema.Models
{
    public class PurchaseViewModel
    {
        public Film Film { get; set; }
        public FilmSession FilmSession { get; set; }
        public List<Seat> SelectedSeats { get; set; }
    }
}