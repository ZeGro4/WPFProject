using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectTickets.Model
{
    public class TicketInfo
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string NameFilm { get; set; }
        public int Place { get; set; }
        public float FilmPrice { get; set; }
        
    
    }
}
