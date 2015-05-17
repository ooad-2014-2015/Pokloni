using pokloni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using pokloni;
using System.Windows;
using System.Collections.ObjectModel;

namespace pokloni.ViewModel1
{
    internal class ProdavacFormaViewModel
    {
        
        public string imePoklona { get; set; }
        public int kolicina { get; set; }
        public ICommand prodaja { get; set; }
        public ObservableCollection<tblPoklon> listaPoklona{get; set;}
        ajdin_connection db = new ajdin_connection();
        public ObservableCollection<string> imenaPoklona { get; set; }

        public ProdavacFormaViewModel() {
            
                
            prodaja = new RelayCommand(Prodaja);
            listaPoklona = new ObservableCollection<tblPoklon>(db.tblPoklon.ToList());

            imenaPoklona = new ObservableCollection<string>();

            foreach (tblPoklon p in listaPoklona)
            {
                imenaPoklona.Add(p.naziv);
            }

        }

       

        public void Prodaja(object param)
        {
            try
            {
               
                if (db.tblPoklon.Count(p => p.naziv == imePoklona) >= kolicina)
                {
                    for (int i = 0; i < kolicina; i++)
                    {
                        var ld = db.tblPoklon.First(p => p.naziv == imePoklona);
                        db.tblPoklon.Remove(ld);
                        //dodati prodavacu prodan poklon?
                    }
                    global::System.Windows.MessageBox.Show(string.Format("Prodaja uspješno obavljena"));
                }
                else 
                {
                    global::System.Windows.MessageBox.Show(string.Format("Nema dovoljno zaliha biranog poklona na lageru"));
                }
                
                }
            catch (Exception)
            {
                global::System.Windows.MessageBox.Show(string.Format("Greska"));
            }
        }
          
    }
}
