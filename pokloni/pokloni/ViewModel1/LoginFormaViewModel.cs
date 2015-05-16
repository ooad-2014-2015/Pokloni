using pokloni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using pokloni.Models;

namespace pokloni.ViewModel1 {
    internal class LoginFormaViewModel : INotifyPropertyChanged {

        public string Username { get; set; }
        public ICommand Login { get; set; }

        public LoginFormaViewModel() {
            Login = new RelayCommand(login);
        }


        public void login(object param) {

            string userPassword = (param as PasswordBox).Password;
            try {
                ajdin_connection db = new ajdin_connection();
                var ld = db.tblLoginData.First(l => l.username == Username && l.password == userPassword);
                if(ld.tblOsoba.je_zensko)
                    global::System.Windows.MessageBox.Show(string.Format("Dobro dosla, {0}", ld.tblOsoba.ime.TrimEnd(' ')));
                else
                    global::System.Windows.MessageBox.Show(string.Format("Dobro dosao, {0}e", ld.tblOsoba.ime.TrimEnd(' ')));
                


                
            }
            catch (Exception) {
                global::System.Windows.MessageBox.Show("Pogresna kombinacija. Molimo pokušajte ponovo");
                Username = "";
                (param as PasswordBox).Password = "";                
            }
        }
        
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
