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
    using System.Collections.Generic;
    
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            this.FilmSession = new HashSet<FilmSession>();
        }
    
        public int FilmID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public System.TimeSpan TimeLength { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string MoreGenres { get; set; }
        public string Actors { get; set; }
        public string Producer { get; set; }
        public string KinopoiskLink { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual AgeRating AgeRating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmSession> FilmSession { get; set; }
    }
}
