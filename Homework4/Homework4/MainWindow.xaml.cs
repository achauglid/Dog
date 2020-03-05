using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            String dogBreed = txtDogBreed.Text;
            
            String url = "https://dog.ceo/api/breed//images/random";
            String adjustedUrl = url.Insert(26, dogBreed.ToLower());         // puts user input into api formatted url


            try
            {

                string json = new WebClient().DownloadString(adjustedUrl);

                dog newDog = new dog();

                newDog = JsonConvert.DeserializeObject<dog>(json);      // storing data in dog class


                var bi = new BitmapImage();             // prints image in from message varible
                bi.BeginInit();
                bi.UriSource = new Uri(newDog.message);
                bi.EndInit();


                picDog.Source = bi;


            }
            catch (WebException ex)             // handles 404 errors and tells user to input a valid breed
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse resp = ex.Response as HttpWebResponse;
                    if (resp != null && resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Enter valid dog breed please!");
                        txtDogBreed.Clear();
                    }
                    else
                        throw;
                }
                else
                    throw;
            }





        }
    }
}
