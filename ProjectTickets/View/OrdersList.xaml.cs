using ProjectTickets.Model.Data;
using ProjectTickets.Model;
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
using ProjectTickets.View_Model;

namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersList.xaml
    /// </summary>
    public partial class OrdersList : Window
    {
        TicketsManager ticketsManager;
        Users user;
        List<TicketInfo> ticketInfos;
        float summary;
        public OrdersList(Users user)
        {
            this.WindowState = WindowState.Maximized;
            this.user = user;
            InitializeComponent();
            ticketsManager = new TicketsManager();
            ticketInfos = ticketsManager.InfoTickets(user.UserID);
            dataGrid.ItemsSource = ticketInfos;
            if (ticketInfos.Count > 0) {
                foreach (var ticket in ticketInfos)
                {
                    summary += ticket.FilmPrice;
                }
            }
            else
            {
                summary = 0;
            }
            pricetext.Text = "Сумма: " + summary;
        }

        private void cBack_Click(object sender, RoutedEventArgs e)
        {
            CinemaPage cinemaPage = new CinemaPage(user);
            cinemaPage.Show();
            Close();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            TicketInfo ticketInfo = dataGrid.SelectedItem as TicketInfo;
            if (ticketInfo != null) {
                summary = 0;

                ticketInfos = ticketsManager.DeleteTickets(user.UserID, ticketInfo.TicketId, ticketsManager.InfoTickets(user.UserID));
                dataGrid.ItemsSource = ticketInfos;
                if (ticketInfos.Count > 0)
                {
                    foreach (var ticket in ticketInfos)
                    {
                        summary += ticket.FilmPrice;
                    }
                }
                else
                {
                    summary = 0;
                }
                pricetext.Text = "Сумма: " + summary;

            }
            else
            {
                MessageBox.Show("Выберите билет");
            }
        }

        private void btBuy_Click(object sender, RoutedEventArgs e)
        {
            if (ticketInfos.Count == 0)
            {

                MessageBox.Show("У вас пустая корзина!");
            }
            else
            {

                ticketsManager.OrderToList(ticketInfos,user);
                ticketInfos = ticketsManager.DeleteFrombasket(ticketInfos, user);
                dataGrid.ItemsSource = ticketInfos;
                summary = 0;
                MessageBox.Show("Ваш заказ успешно формлен!");
                CinemaPage cinemaPage = new CinemaPage(user);
                cinemaPage.Show();
                Close();
            }
        }
    }
}
