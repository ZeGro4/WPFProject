using ProjectTickets.Model;
using ProjectTickets.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        Users user;
        TicketsManager _ticketsManager;
        public Profile(Users user)
        {
            this.WindowState = WindowState.Maximized;
            this.user = user;
            InitializeComponent();
            _ticketsManager = new TicketsManager();
            DataContext = user;
            dataGrid.ItemsSource = _ticketsManager.AllBuyingTicket(user);

        }
        private void cBack_Click(object sender, RoutedEventArgs e)
        {
            CinemaPage cinemaPage = new CinemaPage(user);
            cinemaPage.Show();
            Close();
        }
        private void BasketButton_Click(Object sender, RoutedEventArgs e)
        {
            OrdersList ordersList = new OrdersList(user);
            ordersList.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
