//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPcinema.Domains
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelCinemaContainer : DbContext
    {
        public ModelCinemaContainer()
            : base("name=ModelCinemaContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Film> FilmSet { get; set; }
        public virtual DbSet<Genre> GenreSet { get; set; }
        public virtual DbSet<AgeRating> AgeRatingSet { get; set; }
        public virtual DbSet<CinemaHall> CinemaHallSet { get; set; }
        public virtual DbSet<Seat> SeatSet { get; set; }
        public virtual DbSet<FilmSession> FilmSessionSet { get; set; }
        public virtual DbSet<SeatTicket> SeatTicketSet { get; set; }
    }
}
