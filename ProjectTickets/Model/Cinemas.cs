using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class Cinemas
    {
        [Key]
        public  int CinemaID { get; set; }
        public string NameCinema { get; set; }
        public string Addres { get; set; }
        public string OwnerCinema { get; set; }
        public string PathImage { get; set; }
    }
}
