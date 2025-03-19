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
using System.Windows.Navigation;
using Microsoft.IdentityModel.Tokens;

namespace ProjectTickets.View
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
     public partial class Authorization : Window
    {
        Users users1 = new Users();
        Registration registration;
        private bool isName;
        private bool isPassword;
        DataManager dataManager;

        enum AuthorizationCheck
        {
            HasName,
            isAdmin,
            noRegistr,
            secsessful
        }
        AuthorizationCheck authorizationCheck;
        public Authorization()
        {
           
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            registration = new Registration();
            dataManager = new DataManager();
            authorizationCheck = AuthorizationCheck.noRegistr;
        }
        private void Button_ClickEnter(object sender, RoutedEventArgs e)
        {
            users1.NameUser = txt_login.Text;
            users1.PasswordUser = txt_password.Password;


            try
            {
                if (users1.NameUser.IsNullOrEmpty())
                {
                    throw new Exception("Введите логин");
                }
                if (users1.PasswordUser.IsNullOrEmpty())
                {
                    throw new Exception("Введите пароль");
                }
                List<Users> users = dataManager.AllUsers();

                if (users1.NameUser.ToLower() == "admin" && users1.PasswordUser.ToLower() == "admin")
                {
                    AdminPanel page = new AdminPanel();
                    page.Show();
                    authorizationCheck = AuthorizationCheck.isAdmin;
                    Close();
                }

                foreach (var user in users)
                {
                    
                    if (users1.NameUser.ToLower() == user.NameUser.ToLower())
                    {
                        authorizationCheck = AuthorizationCheck.HasName;
                        if (users1.PasswordUser == user.PasswordUser)
                        {
                            CinemaPage page = new CinemaPage(user);
                            page.Show();
                            this.Close();
                            authorizationCheck = AuthorizationCheck.secsessful;
                        }

                    }

                }
                switch (authorizationCheck)
                {
                    case AuthorizationCheck.HasName: MessageBox.Show("Неправильный пароль, попробуйте снова!");
                        authorizationCheck = AuthorizationCheck.noRegistr;
                        break;
                    case AuthorizationCheck.noRegistr:
                        MessageBox.Show("Такого пользователя не существует!");
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

              

            
        }

        private void bt_register_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            registration.Show();
        }
    }
}
