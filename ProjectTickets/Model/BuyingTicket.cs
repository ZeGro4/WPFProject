using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model.Data
{
    public class BuyingTicket
    {
        [Key]
        public int BuyID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public string NameFilm { get; set; }
        public float Price { get; set; } 
        public int Place { get; set; }

        public virtual Users User { get; set; }
    }
}
