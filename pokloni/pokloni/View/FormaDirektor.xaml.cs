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
using MultivariableMetricVisualisation;
using System.IO;
using WebCam_Capture;
using pokloni.View;
using AForge.Video.DirectShow;
using WPFMediaKit.DirectShow.Controls;

namespace pokloni
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        Webcam webcam;
        VideoCaptureDevice v;
        VideoCaptureElement vv;

        public Window1() {
            InitializeComponent();
            DataContext = new FormaDirektorViewModel();
            imgVideo = new Image();
            webcam = new Webcam();
            webcam.InitializeWebCam(ref imgVideo);
            webcam.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            tabCtrl.SelectedIndex = 3;
        }

        private void ImePoklona_GotFocus(object sender, RoutedEventArgs e) {
            if (ImePoklona.Text.Equals("Unesite ime poklona")) {
                ImePoklona.Text = "";
            }
        }

        private void ImePoklona_LostFocus(object sender, RoutedEventArgs e) {
            if (ImePoklona.Text.Equals("")) {
                ImePoklona.Text = "Unesite ime poklona";
            }
        }

        private void OpisPoklona_GotFocus(object sender, RoutedEventArgs e) {
            if (OpisPoklona.Text.Equals("Unesite opis poklona")) {
                OpisPoklona.Text = "";
            }
        }

        private void OpisPoklona_LostFocus(object sender, RoutedEventArgs e) {
            if (OpisPoklona.Text.Equals("")) {
                OpisPoklona.Text = "Unesite opis poklona";
            }
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
        }

    }
}
