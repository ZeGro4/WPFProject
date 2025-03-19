using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey("CinemaHall")]
        public int HallId { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        public int Place { get; set; }
        public bool IsSelling { get; set; } = true; // по умолчанию true

        // Навигационные свойства для отношений
        public virtual Film Film { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }
    }
}
