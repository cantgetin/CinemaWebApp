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
    
    public partial class FilmSession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FilmSession()
        {
            this.SesstionTickets = new HashSet<SeatTicket>();
        }
    
        public int FilmSessionID { get; set; }
        public System.DateTime SessionDateTime { get; set; }
        public int TicketPrice { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeatTicket> SesstionTickets { get; set; }
    }
}
