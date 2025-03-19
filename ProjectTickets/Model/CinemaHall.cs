using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class CinemaHall
    {
        [Key]
        public int HallID { get; set; }
        public int NumberHall { get; set; }
        public int CountPlaces { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaID { get; set; }

        public bool HasFilm {get; set; }

        // Навигационное свойство
        public virtual Cinemas Cinema { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
