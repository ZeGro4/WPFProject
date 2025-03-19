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
using static System.Net.Mime.MediaTypeNames;

namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для CinemaPage.xaml
    /// </summary>
    public partial class CinemaPage : Window
    {
        TableManager tableManager;
        ApplicationContext context;// на время
        Users cuser;
        public CinemaPage(Users currentuser)
        {
            this.WindowState = WindowState.Maximized;
            tableManager = new TableManager();
            InitializeComponent();
            context = new ApplicationContext();
            cuser = currentuser;
            List<Film> Films = tableManager.TableView();
                filmsList.ItemsSource = Films;
                
        }

        private void bt_search_events(object sender, RoutedEventArgs e)
        {
            string searchtext = searchbox.Text;

            // Получаем выбранную дату из DatePicker
            DateTime? searchdate = datepick.SelectedDate;
            DateOnly? searchDateOnly = searchdate.HasValue ? DateOnly.FromDateTime(searchdate.Value) : (DateOnly?)null;

            

            // Установка источника данных для списка фильмов
            try
            {
                // Параметры для поиска
                float? minPrice = null;
                float? maxPrice = null;

                // Проверка и парсинг минимальной и максимальной цены
                if (!string.IsNullOrEmpty(minprice.Text))
                {
                    minPrice = float.Parse(minprice.Text);
                }

                if (!string.IsNullOrEmpty(maxprice.Text))
                {
                    maxPrice = float.Parse(maxprice.Text);
                }

                // Выполнение поиска с учетом всех параметров
                filmsList.ItemsSource = tableManager.SearchEvents(searchtext, searchDateOnly, minPrice, maxPrice);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введите корректные значения для цен.\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении поиска:\n" + ex.Message);
            }
        }

        private void SelectFilm(object sender, RoutedEventArgs e)
        {

            Film currentFilm = filmsList.SelectedItem as Film;
            if (currentFilm == null)
            {
                MessageBox.Show("Выберете фильм!");
            }
            else
            {
                TicketsMap map = new TicketsMap(currentFilm.FilmID, cuser);
                map.Show();
                this.Close();
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(cuser);
            profile.Show();
            Close();
        }
        private void BasketButton_Click(Object sender, RoutedEventArgs e)
        {
            OrdersList ordersList = new OrdersList(cuser);
            ordersList.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }

        
    }
}
