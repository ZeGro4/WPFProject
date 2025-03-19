using Microsoft.IdentityModel.Tokens;
using ProjectTickets.View_Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DataManager _dataManager;
        bool isValidate;
        public Registration()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            _dataManager = new DataManager();

        }
         private void bt_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string uname = txt_login.Text;
                string upass = txt_password.Password;

                if(uname.ToLower() == "admin")
                {
                    throw new Exception("Нельзя тебе!");
                }

                foreach (var usr in _dataManager.AllUsers())
                {
                    if (uname.ToLower() == usr.NameUser.ToLower())
                    {
                        throw new Exception("Пользователь уже существует!");
                    }

                }
                if (uname.IsNullOrEmpty()) {

                    throw new Exception("Введите имя");
                }
                if (upass.IsNullOrEmpty())
                {

                    throw new Exception("Введите пароль");
                }
                string uemail;
                int uage;
                
                if (IsValidEmail(txt_email.Text))
                {
                    uemail = txt_email.Text;
                }

                else
                {
                    throw new Exception("Неккоректный email");
                }

                foreach (var usr in _dataManager.AllUsers())
                {
                    if (uemail.ToLower() == usr.Email.ToLower())
                    {
                        throw new Exception("Пользователь с такой почтой уже существует!");
                    }

                }
                try
                {
                    uage = int.Parse(txt_age.Text);
                    if (uage < 0 || uage > 100)
                    {
                        throw new Exception("Пожалуйста, введите корректное число для возраста.");
                    }
                    
                }
                catch (FormatException)
                {
                    throw new Exception("Пожалуйста, введите корректное число для возраста.");
                }
              

                if (_dataManager.AddNewUser(uname, upass, uemail, uage))
                {
                    MessageBox.Show("Вы зарегестрировались!", "Registration", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Authorization authorization = new Authorization();
                    authorization.Show();
                    this.Close();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
