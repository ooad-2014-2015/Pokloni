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
using pokloni.ViewModel1;
//using MultivariableMetricVisualisation;

namespace pokloni
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            DataContext = new FormaDirektorViewModel();

            //Visualizer uposlenikVisual = new Visualizer(6);

            //uposlenikVisual.ActualAtrributes = generateNRandoms(6);

            //uposlenikVisual.DrawMainPolygon();
            //uposlenikVisual.DrawActualAttributes();

            //cc.Content = uposlenikVisual;



        }

        List<double> generateNRandoms(int n) {
            Random r = new Random();
            List<double> toReturn = new List<double>();
            for (int i = 0; i < n; i++) {
                toReturn.Add(r.NextDouble());
            }
            return toReturn;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            tabCtrl.SelectedIndex = 3;
        }

    }
}
