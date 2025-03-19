using ProjectTickets.Model;
using ProjectTickets.Model.Data;
using ProjectTickets.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для TicketsMap.xaml
    /// </summary>
    public partial class TicketsMap : Window
    {

        ApplicationContext context;
        TicketsManager ticketsManager;
        private int idFilm;
        Users currentuser;
        public TicketsMap(int idfilm, Users user)
        {
            this.WindowState = WindowState.Maximized;
            currentuser = user;
            InitializeComponent();
            idFilm = idfilm;
            context = new ApplicationContext();
            ticketsManager = new TicketsManager();
            DrowPlace();
            
        }
        private void BuyTicket(object sender, RoutedEventArgs e)
        {
            int id = 0;
            Button clickedButton = sender as Button; 
            if (clickedButton != null)
            {
               id = (int)clickedButton.Tag; 
                
                List<Tickets> tickets = ticketsManager.Tikcetbuying(id,currentuser);
            }
            MessageBox.Show("Ваш билет добавлен в корзину!");
            DrowPlace();

        }
        private void GoToMainMenu()
        {
            CinemaPage cinemaPage = new CinemaPage(currentuser);
            cinemaPage.Show();
            this.Close();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            GoToMainMenu();
        }
        private void DrowPlace()
        {
            wrappanel.Children.Clear();
            List<Tickets> ticketss = ticketsManager.LoadTickets(idFilm);
            foreach (var ticket in ticketss)
            {
                Button newButton = new Button();
                if (ticket.Place < 10)
                {
                    newButton.Content = "0" + ticket.Place;
                }
                else
                {
                    newButton.Content = ticket.Place;
                }
                newButton.Margin = new Thickness(4, 4, 4, 4);
                newButton.Width = 41;
                newButton.Height = 41;
                newButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#219ebc"));
                newButton.IsEnabled = ticket.IsSelling;


                if (newButton.IsEnabled)
                {
                    newButton.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    newButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#14213d"));
                }
                newButton.Tag = ticket.TicketId;
                newButton.Click += BuyTicket;
                wrappanel.Children.Add(newButton);
            }
        }
    }
}
