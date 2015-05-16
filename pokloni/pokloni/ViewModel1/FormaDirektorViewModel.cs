using pokloni.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivariableMetricVisualisation;
using System.ComponentModel;

namespace pokloni.ViewModel1 {
    class FormaDirektorViewModel : INotifyPropertyChanged {

        public ObservableCollection<tblKomentar> Komentari { get; set; }
        public ObservableCollection<tblUposlenik> Uposlenici { get; set; }
        public tblUposlenik Selektovani { get; set; }
        public Visualizer RadnikVisualizer { get; set; }

        public FormaDirektorViewModel() {

            ajdin_connection db = new ajdin_connection();

            Komentari = new ObservableCollection<tblKomentar>(db.tblKomentar.ToList());
            Uposlenici = new ObservableCollection<tblUposlenik>(db.tblUposlenik.ToList());
        }
        List<double> generateNRandoms(int n) {
            Random r = new Random();
            List<double> toReturn = new List<double>();
            for (int i = 0; i < n; i++) {
                toReturn.Add(r.NextDouble());
            }
            return toReturn;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                if (propertyName == "Selektovani") {
                    global::System.Windows.MessageBox.Show("changed");
                }
            }
        }
    }
}
