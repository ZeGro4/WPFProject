using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using ProjectTickets.Model;
using ProjectTickets.View_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для FilmSettings.xaml
    /// </summary>
    public partial class FilmSettings : Window
    {
        CinemaManager cinemaManager;
        TableManager tableManager;
        TicketsManager ticketsManager;
        string path;
        Cinemas Cinema;
        CinemaHall cinemasHall;
        bool isChange = false;
        Film editingFilm;
        public FilmSettings()
        {
            this.WindowState = WindowState.Maximized;
            cinemaManager = new CinemaManager();
            tableManager = new TableManager();
            ticketsManager = new TicketsManager();
            

            List<Cinemas> cinemas = cinemaManager.AllCinemas();
            
            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                minutesComboBox.Items.Add(i.ToString("D2")); // Формат с ведущим нулем
            }
            for (int i = 0; i < 24; i++)
            {
                hoursComboBox.Items.Add(i.ToString("D2")); 
            }
            foreach(var c in cinemas) 
            {
                CinemasComboBox.Items.Add(c.NameCinema); 
            }
            

        }

        public FilmSettings(Film film)
        {
            this.WindowState = WindowState.Maximized;
            cinemaManager = new CinemaManager();
            tableManager = new TableManager();
            ticketsManager = new TicketsManager();
            editingFilm = film;

            List<Cinemas> cinemas = cinemaManager.AllCinemas();

            double filmMinutes = film.TimeFilm.Minutes;
            double filmHours = film.TimeFilm.Hours;



       


            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                
                minutesComboBox.Items.Add(i.ToString("D2")); // Формат с ведущим нулем
                if (i == filmMinutes)
                {
                    minutesComboBox.SelectedIndex = i;
                }
            }
            for (int i = 0; i < 24; i++)
            {
                hoursComboBox.Items.Add(i.ToString("D2"));
                if (i == filmHours) {
                    hoursComboBox.SelectedIndex = i;

                }
            }

            pricefilm.Text = film.Price.ToString();
            datefilm.Text = film.DateFilm.ToString();
           

            namefilm.IsReadOnly = true;
            namefilm.Text = film.NameFilm;
            btnLoadImage.Visibility = Visibility.Hidden;
            lblimg.Visibility = Visibility.Hidden;
            isChange = true;
            lblcinema.Visibility = Visibility.Hidden;
            wpcinema.Visibility = Visibility.Hidden;
        }

        private void CinemasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            HallComboBox.Items.Clear(); 
            string selectedCinema = CinemasComboBox.SelectedItem.ToString();
            Cinema = cinemaManager.AllCinemas().Where(c => c.NameCinema == selectedCinema).FirstOrDefault();
           
            List<CinemaHall> hall = cinemaManager.HallCinemas()
                .Where(h => h.CinemaID == Cinema.CinemaID && h.HasFilm == false)
                .ToList();
            foreach (var h in hall)
            {
                HallComboBox.Items.Add(h.NumberHall);
            }
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                imgDisplay.Source = bitmap;
            }
            else
            {
                path = null;
                imgDisplay.Source = null;
            }
            path = openFileDialog.FileName;
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {

            if (!isChange)
            {
                Film newfilm = new Film();

                DateOnly selectedDateOnly;



                try
                {
                    float price = 0;
                    try
                    {
                        price = float.Parse(pricefilm.Text);
                    }
                    catch
                    {
                        new Exception("Неккоректная цена");
                    }
                    
                    if (namefilm.Text.IsNullOrEmpty())
                    {
                        throw new Exception("Введите поле имя");
                    }
                    bool hasPunctuation = Regex.IsMatch(namefilm.Text, @"[\p{P}]");

                    if (hasPunctuation)
                    {
                        throw new Exception("Заполните поле название фильма корректно");
                    }
                    if (pricefilm.Text.IsNullOrEmpty())
                    {
                        throw new Exception("Введите поле цена");
                    }

                    
                    if (price <= 0 || price > 1000)
                    {
                        throw new Exception("Введите коррекнтую цену от 0 до 1000(выше никто не купит)");
                    }
                    try
                    {
                        DateTime selectedDateTime = datefilm.SelectedDate.Value;
                        selectedDateOnly = DateOnly.FromDateTime(selectedDateTime);
                        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                        if (selectedDateOnly < currentDate)
                        {

                            throw new Exception("Введите коррекнтую дату, больше чем текущая");
                        }

                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Введите коррекнтую дату, больше чем текущая");
                    }


                    if (string.IsNullOrWhiteSpace(hoursComboBox.Text))
                    {
                        throw new Exception("Некоректное число  часов");

                    }

                    if (string.IsNullOrWhiteSpace(minutesComboBox.Text))
                    {
                        throw new Exception("Некоректное число  минут");
                        
                    }
                    if (string.IsNullOrWhiteSpace(CinemasComboBox.Text))
                    {
                        throw new Exception("Некоректное название кинотеатра");

                    }

                    if (string.IsNullOrWhiteSpace(HallComboBox.Text))
                    {
                        throw new Exception("Добавьте зал");

                    }
                    if (path == null)
                    {

                        throw new Exception("Добавьте фотографию");
                    }
                    else
                    {
                        if (path.Length == 0)
                        {
                            throw new Exception("Добавьте фотографию");
                        }
                    }

                    int numberhall = int.Parse(HallComboBox.Text);
                    cinemasHall = cinemaManager.HallCinemas()
                                                .FirstOrDefault(h => h.NumberHall == numberhall && h.CinemaID == Cinema.CinemaID); //Ищем выбранный холл



                    newfilm.NameFilm = namefilm.Text;
                    newfilm.Price = price;
                    newfilm.DateFilm = selectedDateOnly;
                    newfilm.TimeFilm = new TimeSpan(hours: int.Parse(hoursComboBox.Text), minutes: int.Parse(minutesComboBox.Text), seconds: 0);
                    newfilm.HallID = cinemasHall.HallID;
                    newfilm.PathImage = path;


                    tableManager.AddFilm(newfilm);
                    ticketsManager.AddTickets(newfilm.HallID, newfilm.FilmID, cinemasHall.CountPlaces);

                    cinemaManager.CloseHall(newfilm.HallID);
                    MessageBox.Show("Фильм успешно добавлен: " + newfilm.NameFilm);
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {

                Film film = editingFilm;
                DateOnly selectedDateOnly;
                try
                {


                    try
                    {
                        film.TimeFilm = new TimeSpan(hours: int.Parse(hoursComboBox.Text), minutes: int.Parse(minutesComboBox.Text), seconds: 0);
                    }
                    catch
                    {
                        throw new Exception("Неправильное время!");
                    }
                    try
                    {
                        float price = float.Parse(pricefilm.Text);
                        if (price <= 0 || price > 1000)
                        {
                            throw new Exception("Введите коррекнтую цену от 0 до 1000");
                        }
                        film.Price = price;
                    }
                    catch
                    {
                        throw new Exception("Неккоректная цена");
                    }


                    try
                    {
                        DateTime selectedDateTime = datefilm.SelectedDate.Value;
                        selectedDateOnly = DateOnly.FromDateTime(selectedDateTime);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Введите коррекнтую дату");
                    }



                    try
                    {
                        film.DateFilm = selectedDateOnly;
                    }
                    catch
                    {
                        throw new Exception("Неккоректная дата!");
                    }
                    tableManager.EditFilm(film);
                    MessageBox.Show("Успешно изменено!");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    this.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
}
