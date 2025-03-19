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

namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для CinemaSettings.xaml
    /// </summary>
    public partial class CinemaSettings : Window
    {
        string path;

        CinemaManager cinemaManager;
        public CinemaSettings()
        {
            this.WindowState = WindowState.Maximized;
            cinemaManager = new CinemaManager();
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                HallCountComboBox.Items.Add((i + 1).ToString());
            }
            HallComboBox.Items.Add("Маленький зал");
            HallComboBox.Items.Add("Средний зал");
            HallComboBox.Items.Add("Большой зал");
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
            
            string hall = HallComboBox.Text;
            int countplace = 0;
            int counthall;
            Cinemas newcinema = new Cinemas();
            try
            {

                if (namecinema.Text.IsNullOrEmpty())
                {
                    throw new Exception("Заполните поле название кинотеатра");
                }
                if (addresscinema.Text.IsNullOrEmpty())
                {
                    throw new Exception("Заполните поле адреса");
                }
                if (ownercinema.Text.IsNullOrEmpty())
                {
                    throw new Exception("Заполните поле владелец кинотеатра");
                }
                bool hasPunctuation = Regex.IsMatch(namecinema.Text, @"[\p{P}]");

                if (hasPunctuation)
                {
                    throw new Exception("Заполните поле название фильма корректно");
                }

                bool hasPunctuation2 = Regex.IsMatch(ownercinema.Text, @"[\p{P}]");

                if (hasPunctuation2)
                {
                    throw new Exception("Заполните поле название фильма корректно");
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
                newcinema.Addres = addresscinema.Text;
                newcinema.NameCinema = namecinema.Text;
                newcinema.OwnerCinema = ownercinema.Text;
                newcinema.PathImage = path;
                try
                {
                    counthall = int.Parse(HallCountComboBox.Text);
                }
                catch (FormatException)
                {
                    throw new Exception("Введите число залов");

                }
                switch (hall)
                {
                    case "Маленький зал":
                        countplace = 60;
                        break;
                    case "Средний зал":
                        countplace = 90;
                        break;
                    case "Большой зал":
                        countplace = 120;
                        break;
                    default: countplace = 0; break;
                }
                if(countplace == 0)
                {
                    throw new Exception("Введите количество мест!");
                }
                cinemaManager.AddCinema(newcinema,counthall, countplace);
                MessageBox.Show("Вы добавили кинотеатр " + newcinema.NameCinema);
                LIstCinema lIstCinema = new LIstCinema();
                lIstCinema.Show();
                Close();
        } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
}

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            LIstCinema lIstCinema = new LIstCinema();
            lIstCinema.Show();
            Close();
        }
    }
}
