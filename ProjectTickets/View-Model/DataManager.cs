using Microsoft.EntityFrameworkCore;
using ProjectTickets.Model;
using ProjectTickets.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTickets.View_Model
{
    class DataManager
    {
        ApplicationContext context;

        public DataManager()
        {
            context = new ApplicationContext();
            context.Users.Load();
        }
        public bool AddNewUser(string username, string password, string email, int age)
        {
            try
            {
               
                foreach (var user in context.Users) {

                    if (user.NameUser.ToLower() == username.ToLower()) {

                        MessageBox.Show("Пользователь с таким именем уже зарегистрирован!");
                        return false;
                    }
                    if (user.Email == email)
                    {

                        MessageBox.Show("Пользователь с такой почтой уже зарегистрирован!");
                        return false;
                    }
                }

                int lastid = context.Users.ToList().LastOrDefault()?.UserID ?? 0;
                
                
                Users newUser = new Users() { UserID = lastid + 1, NameUser = username, PasswordUser = password, Email = email, Age = age };

                context.Users.Add(newUser);
                context.Users.FromSqlRaw($"insert into Users values ({newUser.UserID},{newUser.NameUser},{newUser.PasswordUser},{newUser.Email},{newUser.Age})");
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message,"Warning",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }

        }

        public List<Users> AllUsers() {

            return context.Users.ToList();
        
        }
        

    }
}
