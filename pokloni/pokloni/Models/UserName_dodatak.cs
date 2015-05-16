using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokloni.Models;
using System.ComponentModel;

namespace pokloni.Models {
    partial class tblLoginData : INotifyPropertyChanged, IDataErrorInfo {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        static readonly string[] validateProperties =
        {
            "Username"
        };

        public bool IsValid {
            get {
                foreach (string property in validateProperties) {
                    if (getValidationError(property) != null) {
                        return false;
                    }
                }
                return true;
            }
        }

        string IDataErrorInfo.Error {
            get { return null; }
        }
        // ako je null, nema erroa
        string IDataErrorInfo.this[string propertyName] {
            get { return getValidationError(propertyName); }
        }

        string getValidationError(string propertyName) {
            string error = null;
            switch (propertyName) {
                case "BrojKreditneKartice":
                    error = validirajUsername();
                    break;
            }
            return error;
        }

        private string validirajUsername() {
            if (username == "") {
                return "Prazan string";
            }
            return null;
        }
    }
}
