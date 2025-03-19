using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectTickets.Model;
using ProjectTickets.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;

namespace ProjectTickets.View_Model
{

    public class TicketsManager
    {
        ApplicationContext context;
        

        public TicketsManager()
        {
            context = new ApplicationContext();
           
        }
        public List<Tickets> LoadTickets(int idFilm)
        {
            List<Tickets> tickets = context.Tickets.ToList().Where(t => t.FilmId == idFilm).ToList();

            return tickets;

        }
        public List<Tickets> Tikcetbuying(int id,Users user)
        {
            List<Order> orders = context.Orders.ToList();
            int newOrderId;

            if (orders.Any())
            {
                newOrderId = orders.Last().OrderID + 1;
            }
            else
            {
                newOrderId = 1; 
            }
            Order neworder = new Order() { OrderID = newOrderId, TicketsID = id, UserID = user.UserID};
            context.Orders.Add(neworder);
            List<Tickets> tickets = context.Tickets.ToList();
            foreach (var ticket in tickets)
            {
                if (ticket.TicketId == id)
                {
                    ticket.IsSelling = false;


                    context.SaveChanges(); 
                }
            }
            return tickets;
        }
        public List<TicketInfo> InfoTickets(int iduser)
        {

            List<TicketInfo> ticketInfos = new List<TicketInfo>();

            ticketInfos = (from t in context.Tickets
                           join o in context.Orders on t.TicketId equals o.TicketsID
                           join f in context.Film on t.FilmId equals f.FilmID
                           select new TicketInfo
                           {
                               UserId = o.UserID,
                               TicketId = t.TicketId,
                               NameFilm = f.NameFilm,
                               Place = t.Place,
                               FilmPrice = f.Price,
                           })
                           .Where(t => t.UserId == iduser)
                           .ToList();

            return ticketInfos;
        }
        public List<TicketInfo> DeleteTickets(int userid,int idticket,List<TicketInfo> tickets)
        {

            List<TicketInfo> ticketInfos = tickets;


            var ticket = context.Tickets.SingleOrDefault(t => t.TicketId == idticket);
            TicketInfo ticketInfo = ticketInfos.FirstOrDefault(t => t.TicketId == idticket);
            var order = context.Orders.SingleOrDefault( o => o.UserID == userid && o.TicketsID == idticket);
            if (ticket != null)
            {
               
                ticket.IsSelling = true;
                context.Orders.Remove(order);
                context.SaveChanges();

                ticketInfos.Remove(ticketInfo);
            }
            else
            {
                MessageBox.Show("Error tickets not found");
            }

            return ticketInfos;

        }

        public void AddTickets(int hallid, int filmid, int countplace)
        {
            context.Database.ExecuteSqlRaw("EXEC AddTickets @hallId, @filmId, @ticketCount",
                new SqlParameter("@hallId", hallid),
                new SqlParameter("@filmId", filmid),
                new SqlParameter("@ticketCount", countplace));
        }
        public  List<BuyingTicket> AllBuyingTicket(Users user)
        {
            return context.BuyingTickets
                .Where(t=> t.UserID == user.UserID)
                .ToList();
        }

        public List<TicketInfo> DeleteFrombasket(List<TicketInfo> infticket, Users user)
        {
            // Создаем копию списка билетов, чтобы избежать изменения коллекции во время итерации
            List<TicketInfo> ticketInfos = infticket.ToList();

            // Получаем все заказы пользователя
            List<Order> orders = context.Orders
                .Where(o => o.UserID == user.UserID)
                .ToList();

            // Удаляем билеты из исходного списка
            foreach (var ticket in ticketInfos)
            {
                infticket.Remove(ticket);
            }

            // Удаляем заказы из контекста
            foreach (var order in orders)
            {
                context.Orders.Remove(order);
            }

            context.SaveChanges();

            return infticket;
        }

        public void OrderToList(List<TicketInfo> infticket, Users user)
        {
            int nextId = LastIDBuyingTicket();
            string message = "";
            string film = "";
            string places = "";
            foreach (TicketInfo itick in infticket)
            {
                BuyingTicket ticket = new BuyingTicket
                {
                    BuyID = nextId++,
                    UserID = itick.UserId,
                    Price = itick.FilmPrice,
                    NameFilm = itick.NameFilm,
                    Place = itick.Place
                };
                
                places = ticket.Place.ToString();
                if(film != ticket.NameFilm)
                {
                    film = ticket.NameFilm;
                    message += "фильм " + film + " места "  + places + ", "; 
                }
                else
                {
                    message += places + ", ";
                }
                context.BuyingTickets.Add(ticket);
            }
            SendMail(user, message);
            context.SaveChanges();
        }


        private int LastIDBuyingTicket()
        {
            int lastId = context.BuyingTickets.Max(ticket => (int?)ticket.BuyID) ?? 0;
            return lastId + 1;
        }
        private void SendMail(Users user, string masseg)
        {

            var mailFrom = new MailAddress("send_ticket@mail.ru", "Kino");
            var mailTo = new MailAddress(user.Email, " userSignedIn.Login");
            var message = new MailMessage(mailFrom, mailTo);
            message.Body = $"Здравствуйте {user.NameUser} вы купили билет на {masseg}";
            message.Subject = "Сообщение от Kino";

            var client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587; //587 465
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mailFrom.Address, "4kxhSwGSRnkLnQxbauvw"); // Не забудьте про безопасность пароля
            //pGc6dpR2DrPK8QikixBu
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                // Обработайте возможные ошибки отправки письма
                MessageBox.Show($"Ошибка при отправке письма: {ex.Message}");
            }
        }
    }
}
