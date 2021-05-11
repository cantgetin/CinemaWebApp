using ASPcinema.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPcinema.Models
{
    public class EditPageModel
    {
        public Film Film { get; set; }
        public List<Genre> Genres {get; set;}
        public List<AgeRating> AgeRatings { get; set; }
        public string SelectedGenre { get; set; }
        public string SelectedAgeRating { get; set; }
    }
}