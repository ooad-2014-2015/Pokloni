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
using OOAD_Bank;
using NationalStandard;
using System.Threading;

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
        public ObservableCollection<int> kolicinePoklona { get; set; }
        public bool naAdresu { get; set; }


        public ProdavacFormaViewModel() {
            
                
            prodaja = new RelayCommand(Prodaja);
            listaPoklona = new ObservableCollection<tblPoklon>(db.tblPoklon.ToList());

            imenaPoklona = new ObservableCollection<string>();

            kolicinePoklona = new ObservableCollection<int>();
            foreach (tblPoklon p in listaPoklona)
            {
                imenaPoklona.Add(p.naziv);
            }
            for (int i = 0; i < 5; i++) {
                kolicinePoklona.Add(i+1);
            }

        }
        Isporuka isp;
        public class Isporuka : IShippment {

            bool allGood = false;
            public bool RegisterTransaction() {
                Thread.Sleep(1000);
                allGood = true;
                return true;
            }

            public DateTime GetShippmentETA(int a) {
                return DateTime.Now;
            }

        };


        public void RegistujIsporuku() {
            isp = new Isporuka();
            isp.RegisterTransaction();
        }

        public void RegistrujPlacanje() {
            OOADTransaction t = new OOADTransaction("recipient", "sender", 100.0m, 2);
            //banka obavlja svoje
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
                    Thread t_banka = new Thread(RegistrujPlacanje);
                    Thread t_isporuka = new Thread(RegistujIsporuku);
                    t_banka.Start();
                    t_isporuka.Start();
                    if (isp.RegisterTransaction())
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
