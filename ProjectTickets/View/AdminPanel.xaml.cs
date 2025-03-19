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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        TableManager tableManager;
        
        public AdminPanel()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            tableManager = new TableManager();
            List<Film> Films = tableManager.TableView();
            filmsList.ItemsSource = Films;
        }
        private void bt_search_events(object sender, RoutedEventArgs e)
        {
            string searchtext = searchbox.Text;
                // Выполнение поиска с учетом всех параметров
                filmsList.ItemsSource = tableManager.SearchEvents(searchtext);          
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            Film selectedfilm = filmsList.SelectedItem as Film;

            if (selectedfilm != null) {
                filmsList.ItemsSource = tableManager.DeleteFilm(selectedfilm.FilmID);
                MessageBox.Show("Вы удалили фильм: " + selectedfilm.NameFilm);

            }
            else
            {
                MessageBox.Show("Выберете фильм для удаления");
            }
        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            FilmSettings filmSettings = new FilmSettings();
            filmSettings.Show();
            this.Close();
        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {
            Film selectedfilm = filmsList.SelectedItem as Film;

            if (selectedfilm != null)
            {
                FilmSettings filmSettings = new FilmSettings(selectedfilm);
                filmSettings.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Выберете фильм");
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }

        private void btCinemas_Click(object sender, RoutedEventArgs e)
        {
            LIstCinema lIstCinema = new LIstCinema();
            lIstCinema.Show();
            Close();
        }
    }
}
