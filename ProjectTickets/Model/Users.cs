using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTickets.Model
{
    public class Users : INotifyPropertyChanged
    {
        [Key]
        public int UserID { get; set; }
        public string NameUser{ get; set; }

        public string PasswordUser { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
