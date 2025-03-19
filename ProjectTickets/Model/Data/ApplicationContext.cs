using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectTickets.Model.Data
{
    class ApplicationContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHall { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public Users currentUser { get; set; }
        public DbSet<BuyingTicket> BuyingTickets { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T2B09SP;Initial Catalog=TicketsDB;Integrated Security=True;TrustServerCertificate=Yes;");
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Ticket)
                .WithMany() // Убедитесь, что здесь указано правильное отношение
                .HasForeignKey(o => o.TicketsID);



            //      modelBuilder.Entity<Film>()
            //.HasOne(f => f.CinemaHall)
            //.WithMany() // Укажите коллекцию здесь
            //.HasForeignKey(f => f.HallID);

        }
    }
}
