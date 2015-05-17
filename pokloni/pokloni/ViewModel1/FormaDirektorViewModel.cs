using pokloni.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultivariableMetricVisualisation;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace pokloni.ViewModel1 {
    class FormaDirektorViewModel : INotifyPropertyChanged {

        public ObservableCollection<tblKomentar> Komentari { get; set; }
        public ObservableCollection<tblUposlenik> Uposlenici { get; set; }
        public ObservableCollection<tblPoklon> Pokloni { get; set; }
        public tblUposlenik Selektovani {
            get { return sel; }
            set {
                sel = value;
                OnPropertyChanged();
            }
        }
        public ICommand ShowSelUser { get; set; }
        public Visualizer UposlenikVisual { get; set; }
        public ICommand DodajPoklon { get; set; }
        public ICommand Reset { get; set; }
        public tblPoklon Temp { get; set; }
        

        private tblUposlenik sel;
        private Dictionary<long, List<double>> att;

        public FormaDirektorViewModel() {

            ajdin_connection db = new ajdin_connection();

            try {

                Komentari = new ObservableCollection<tblKomentar>(db.tblKomentar.ToList());
                Uposlenici = new ObservableCollection<tblUposlenik>(db.tblUposlenik.ToList());
                Pokloni = new ObservableCollection<tblPoklon>(db.tblPoklon.ToList());
                ShowSelUser = new RelayCommand(showuser);
                DodajPoklon = new RelayCommand(dodajPoklon);
                Reset = new RelayCommand(reset);
                Temp = new tblPoklon();
            }
            catch (Exception e) {
                global::System.Windows.MessageBox.Show(e.Message);
            }

            UposlenikVisual = new Visualizer(6);

            att = new Dictionary<long, List<double>>();
        }

        private void reset(object obj) {
            Temp = new tblPoklon();
        }

        private void dodajPoklon(object obj) {
            if (Temp.cijena > 0 && Temp.opis != "" && Temp.naziv != "") {
                try {
                    Temp.proizveo = 3;
                    Temp.slika = "Untitled-1.jpg";
                    ajdin_connection db = new ajdin_connection();
                    Temp.poklon_id = db.tblPoklon.Max(p => p.poklon_id) + 1;
                    db.tblPoklon.Add(Temp);
                    db.SaveChanges();
                }
                catch(Exception e) {
                    global::System.Windows.MessageBox.Show(e.InnerException.Message);
                }
            }
        }

        private void showuser(object obj) {
            global::System.Windows.MessageBox.Show(Selektovani.tblOsoba.ime);
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
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName == "Selektovani") {
                    
                    UposlenikVisual.DrawMainPolygon();
                    UposlenikVisual.ActualAtrributes = generateNRandoms(6);
                    UposlenikVisual.DrawActualAttributes();
                }
                if (propertyName == "Pokloni") {
                }
            }
        }
    }
}
