using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool mediaPlayerIsPlaying = false;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string url = "http://pcbstuou.w27.wh-2.com/webservices/3033/api/random/video";


            string json = new WebClient().DownloadString(url);

            Vid newVid = new Vid();

            newVid = JsonConvert.DeserializeObject<Vid>(json);



            var source = new Uri(newVid.url, UriKind.Absolute);
            VidPlayer.Source = source;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (mediaPlayerIsPlaying)
            {
                btnplay.Content = "Play";
                VidPlayer.Pause();
                mediaPlayerIsPlaying = false;
            }
            else
            {

                btnplay.Content = "Pause";
                VidPlayer.Play();
                mediaPlayerIsPlaying = true;
            } 
              


        }

        private void Btnstop_Click(object sender, RoutedEventArgs e)
        {
            VidPlayer.Stop();
            mediaPlayerIsPlaying = false;
            btnplay.Content = "Play";
        }
    }
}
