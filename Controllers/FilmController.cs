using ASPcinema.Domains;
using ASPcinema.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPcinema.Controllers
{
    public class FilmController : Controller
    {
        protected readonly ModelCinemaContainer _db;
        // GET: Film

        public FilmController()
        {
            _db = new ModelCinemaContainer();
        }

        public ActionResult List()
        {

            var model = new SessionsPageModel()
            {
                Films = _db.FilmSet.AsEnumerable().ToList(),
                FilmSessions = _db.FilmSessionSet.AsEnumerable().ToList()
            };
            return View(model);
        }

        public ActionResult Sessions()
        {

            var model = new SessionsPageModel()
            {
                Films = _db.FilmSet.AsEnumerable().ToList(),
                FilmSessions = _db.FilmSessionSet.AsEnumerable().ToList()
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var film = _db
                .FilmSet
                .FirstOrDefault(p => p.FilmID == id);

            if (film == null)
            {
                return View("NotFound");
            }

            var filmlol = _db.FilmSet.Where(f => f.FilmID == id).FirstOrDefault();
            var fslol = _db.FilmSessionSet.Where(f => f.Film.FilmID == filmlol.FilmID).AsEnumerable().ToList();


            List<SeatTicket> seatslol = new List<SeatTicket>();

            foreach (var item in fslol)
            {
                seatslol.AddRange(_db.SeatTicketSet.Where(t => t.FilmSession.FilmSessionID == item.FilmSessionID).AsEnumerable().ToList());
            }

            var model = new DetailsPageModel()
            {
                Film = filmlol,
                FilmSessions = fslol,
                Tickets = seatslol
            };

            return View(model);
        }

        public ActionResult Buy(int filmID, int sessionID)
        {
            var filmlol = _db.FilmSet.Where(f => f.FilmID == filmID).FirstOrDefault();
            var fslol = _db.FilmSessionSet.Where(f => f.FilmSessionID == sessionID).FirstOrDefault();


            List<SeatTicket> seatslol = new List<SeatTicket>();


            seatslol.AddRange(_db.SeatTicketSet.Where(t => t.FilmSession.FilmSessionID == fslol.FilmSessionID).AsEnumerable().ToList());


            var model = new BuyPageModel()
            {
                Film = filmlol,
                FilmSession = fslol,
                Tickets = seatslol,
                SelectedSeats = ""
            };

            return View(model);
        }

        public ActionResult Purchased(BuyPageModel model1)
        {
            var filmlol = _db.FilmSet.Where(f => f.FilmID ==
            model1.Film.FilmID).FirstOrDefault();

            var fslol = _db.FilmSessionSet.Where(f => f.FilmSessionID ==
            model1.FilmSession.FilmSessionID).FirstOrDefault();

            string[] selectedSeatsIDS = model1.SelectedSeats.Split(' ');
            selectedSeatsIDS = selectedSeatsIDS.Where(s => s != "").ToArray();

            List<Seat> seatslol = new List<Seat>();

            foreach (var item in selectedSeatsIDS)
            {
                int number = int.Parse(item);
                seatslol.Add(_db.SeatSet.Where(s => s.CinemaHall.CinemaHallID == fslol.CinemaHall.CinemaHallID).
                    Where(s => s.SeatNumber == number).FirstOrDefault());
                number = 3;
            }

            foreach (var item in seatslol)
            {
                var ticket = item.SeatTicket.Where(t => t.FilmSession.FilmSessionID ==
                model1.FilmSession.FilmSessionID).FirstOrDefault();
                ticket.Bought = true;
                _db.SaveChanges();
            }



            var model2 = new PurchaseViewModel()
            {
                Film = filmlol,
                FilmSession = fslol,
                SelectedSeats = seatslol
            };

            return View(model2);
        }

        public ActionResult Edit(int filmID)
        {
            var model = new EditPageModel()
            {
                Film = _db.FilmSet.Where(f => f.FilmID == filmID).FirstOrDefault(),
                Genres = _db.GenreSet.AsEnumerable().ToList(),
                AgeRatings = _db.AgeRatingSet.AsEnumerable().ToList(),
                SelectedAgeRating = null,
                SelectedGenre = null

            };

            return View(model);
        }

        public ActionResult Edited(EditPageModel model1)
        {
            var editedFilm = model1.Film;
            editedFilm.AgeRating = _db.AgeRatingSet.Where(r => r.Title == model1.SelectedAgeRating).FirstOrDefault();
            editedFilm.Genre = _db.GenreSet.Where(r => r.Title == model1.SelectedGenre).FirstOrDefault();


            var uneditedFilm = _db.FilmSet.Where(t => t.FilmID == editedFilm.FilmID).FirstOrDefault();

            #region params

            uneditedFilm.Title = editedFilm.Title;
            uneditedFilm.Country = editedFilm.Country;
            uneditedFilm.TimeLength = editedFilm.TimeLength;
            uneditedFilm.ImagePath = editedFilm.ImagePath;
            uneditedFilm.Description = editedFilm.Description;
            uneditedFilm.MoreGenres = editedFilm.MoreGenres;
            uneditedFilm.Actors = editedFilm.Actors;
            uneditedFilm.Producer = editedFilm.Producer;
            uneditedFilm.KinopoiskLink = editedFilm.KinopoiskLink;

            uneditedFilm.Genre = editedFilm.Genre;
            uneditedFilm.AgeRating = editedFilm.AgeRating;

            #endregion


            _db.SaveChanges();



            var model = new SessionsPageModel()
            {
                Films = _db.FilmSet.AsEnumerable().ToList(),
                FilmSessions = _db.FilmSessionSet.AsEnumerable().ToList()
            };

            return View("Sessions", model);
        }

        public ActionResult Add()
        {
            var model = new AddPageModel()
            {
                Film = new Film(),
                Genres = _db.GenreSet.AsEnumerable().ToList(),
                AgeRatings = _db.AgeRatingSet.AsEnumerable().ToList(),
                SelectedAgeRating = null,
                SelectedGenre = null
            };


            return View(model);
        }

        public ActionResult Added(AddPageModel model1)
        {
            var addedFilm = model1.Film;
            addedFilm.AgeRating = _db.AgeRatingSet.Where(r => r.Title == model1.SelectedAgeRating).FirstOrDefault();
            addedFilm.Genre = _db.GenreSet.Where(r => r.Title == model1.SelectedGenre).FirstOrDefault();
            addedFilm.ImagePath = "32ds";

            _db.FilmSet.Add(addedFilm);
            _db.SaveChanges();


            var model = new SessionsPageModel()
            {
                Films = _db.FilmSet.AsEnumerable().ToList(),
                FilmSessions = _db.FilmSessionSet.AsEnumerable().ToList()
            };

            return View("Sessions", model);
        }

        public ActionResult Delete(int filmID)
        {
            
            _db.FilmSet.Remove(_db.FilmSet.Where(f => f.FilmID == filmID).FirstOrDefault());
            _db.SaveChanges();

            var model = new SessionsPageModel()
            {
                Films = _db.FilmSet.AsEnumerable().ToList(),
                FilmSessions = _db.FilmSessionSet.AsEnumerable().ToList()
            };

            return View("Sessions", model);
        }
    }

}