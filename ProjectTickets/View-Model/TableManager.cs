using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTickets.Model;
using ProjectTickets.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTickets.View_Model
{

    public class TableManager
    {
        ApplicationContext context;


        
        public TableManager()
        {
            context = new ApplicationContext();
        }
        public List<Film> SearchEvents(string text, DateOnly? dateTime, float? minprice = 0, float? maxprice = 10000)
        {
            DateOnly dateOnly = dateTime ?? DateOnly.Parse("1970.01.01");
            float minPriceValue = minprice ?? 0;
            float maxPriceValue = maxprice ?? float.MaxValue;
            List<Film> films = context.Film.ToList();
            List<Film> searchrdlist = films
                .Where(p => p.NameFilm.ToLower().Contains(text.ToLower()))
                .Where(p => p.Price > minPriceValue &&  p.Price < maxPriceValue)
                .Where(p=> p.DateFilm >= dateOnly)
                .ToList();
        

            return searchrdlist;
        }
        public List<Film> SearchEvents(string text)
        {
            
            List<Film> films = context.Film.ToList();
            List<Film> searchrdlist = films
                .Where(p => p.NameFilm.ToLower().Contains(text.ToLower()))
                .ToList();


            return searchrdlist;
        }


        public List<Film> TableView()
        {
            List<Film> films = context.Film.ToList();

            return films;

        }

        public List<Film> DeleteFilm(int idfilm) { 
        
            Film deletefilm = context.Film.ToList().FirstOrDefault(f=> f.FilmID == idfilm);
            CinemaHall hall = context.CinemaHall.FirstOrDefault(h => h.HallID == deletefilm.HallID);

            try
            {
                context.Database.ExecuteSqlRaw("EXEC RemoveTicketsByHallAndFilm @hallId, @filmId",
            new SqlParameter("@hallId", hall.HallID),
             new SqlParameter("@filmId", deletefilm.FilmID));
                hall.HasFilm = false;
                context.Film.Remove(deletefilm);
                context.SaveChanges();

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

           
            return context.Film.ToList(); 
        
        }

        public void AddFilm(Film film) {

            int idfilm = context.Film.ToList().LastOrDefault()?.FilmID ?? 0;

            
            film.FilmID = idfilm + 1;
            context.Film.Add(film);
            
            context.SaveChanges();
        
        }
        public void EditFilm(Film film) {

            int filmId = film.FilmID;
            DateOnly newDateFilm = film.DateFilm;
            float newPrice = film.Price;
            TimeSpan newTimeFilm = film.TimeFilm;

            var result = context.Database.ExecuteSqlRaw(
                "EXEC UpdateFilmDetails @p0, @p1, @p2, @p3",
                filmId, newDateFilm, newPrice, newTimeFilm
            );
            context.SaveChanges();
        }
        
    }
    
}
