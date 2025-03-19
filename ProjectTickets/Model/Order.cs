using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int TicketsID { get; set; }

        public virtual Users User { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
