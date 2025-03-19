using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        [ForeignKey("CinemaHall")]
        public int HallID { get; set; }
        public string NameFilm { get; set; }

        public DateOnly DateFilm {  get; set; }
        public TimeSpan TimeFilm { get; set; }

        public float Price {  get; set; }

        public string PathImage { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }

    }
}
