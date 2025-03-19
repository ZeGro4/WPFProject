using ProjectTickets.Model;
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
    /// Логика взаимодействия для LIstCinema.xaml
    /// </summary>
    public partial class LIstCinema : Window
    {
        CinemaManager cinemamanager;
        public LIstCinema()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            cinemamanager = new CinemaManager();
            List<Cinemas> listcinemas = cinemamanager.AllCinemas();
            cinemaList.ItemsSource = listcinemas;
        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            CinemaSettings cinemaSettings = new CinemaSettings();
            cinemaSettings.Show();
            Close();
        }
        private void bt_search_cinema(object sender, RoutedEventArgs e)
        {
            string searchtext = searchbox.Text;
        
            cinemaList.ItemsSource = cinemamanager.SearchEvents(searchtext);
        }
        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
           Cinemas deletecinema = cinemaList.SelectedItem as Cinemas;
            if(deletecinema != null)
            {
                cinemamanager.DeleteCinema(deletecinema.CinemaID);
                MessageBox.Show("Вы удалили кинотеатр " + deletecinema.NameCinema);
                cinemaList.ItemsSource = cinemamanager.AllCinemas(); 
            }
            else
            {
                MessageBox.Show("Выберите кинотеатр для удаления!");
            }
        }

        private void btCinemas_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            Close();
        }
    }
}
