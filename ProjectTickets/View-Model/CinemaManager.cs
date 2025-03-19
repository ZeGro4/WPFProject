using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTickets.Model;
using ProjectTickets.Model.Data;
using ProjectTickets.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectTickets.View_Model
{
    class CinemaManager
    {
        ApplicationContext context;
        public CinemaManager() {
        
        context = new ApplicationContext();
        }


        public List<Cinemas> AllCinemas()
        {
            return context.Cinemas.ToList(); 
        }
        public List<CinemaHall> HallCinemas() { 
        
            return context.CinemaHall.ToList();
        }

        public void CloseHall(int hallID)
        {
            CinemaHall cinemaHall = context.CinemaHall
                  .Where(h => h.HallID == hallID)
                  .FirstOrDefault();
            cinemaHall.HasFilm = true;  
            context.SaveChanges();
           
        }
        public void AddCinema(Cinemas cinemas,int counthall, int sizehall)
        {
            int lastid = context.Cinemas
                .OrderBy(p=> p.CinemaID)
                .LastOrDefault()?.CinemaID ?? 0;
            if (lastid == null) {
                lastid = 0;
            }
            else
            {
                cinemas.CinemaID = lastid + 1;
            }

           
            context.Cinemas.Add(cinemas);
            int k = context.CinemaHall
                .OrderBy(p => p.HallID)
                .LastOrDefault()?.HallID ?? 0;
            for (int i = 1; i <= counthall; i++) {
                k = k + i;
                CinemaHall cinemaHall = new CinemaHall() {HallID = k, CinemaID = cinemas.CinemaID,CountPlaces = sizehall,NumberHall = i, HasFilm = false };
                context.CinemaHall .Add(cinemaHall);
            }
            context.SaveChanges();
        }
        public void DeleteCinema(int idCinema)
        {
            Cinemas cinemas = context.Cinemas.FirstOrDefault(c => c.CinemaID == idCinema);
            if (cinemas != null)
            {
                context.Database.ExecuteSqlRaw("EXEC DeleteCinemaById @CinemaID",
               new SqlParameter("@CinemaID", idCinema));
            }
            else
            {
                MessageBox.Show("Ошибка удаления...");
            }
        }
        public List<Cinemas> SearchEvents(string searchtext)
        {
            return context.Cinemas
                .Where(c => c.NameCinema.ToLower().Contains(searchtext.ToLower()))
                .ToList();
        }
    }
}
