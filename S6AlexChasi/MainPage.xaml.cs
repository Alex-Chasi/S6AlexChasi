using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S6AlexChasi
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.50.106:8084/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<S6AlexChasi.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();

        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {

            //toast mensaje de visualizar

            var mensaje = "mensaje xamarin";
            DependencyService.Get<MensajeA>().longAlert(mensaje);


            await Navigation.PushAsync(new viewInsertarA());

            //codigo clase s6 para cargar informacion con el boton
            /*
            var content = await client.GetStringAsync(Url);
            List<S6AlexChasi.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6AlexChasi.Ws.Datos>>(content);
            _post = new ObservableCollection<S6AlexChasi.Ws.Datos>(posts);

            MyListView.ItemsSource = _post;*/

        }


        public async void get() {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<S6AlexChasi.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6AlexChasi.Ws.Datos>>(content);
                _post = new ObservableCollection<S6AlexChasi.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error","ERROR"+ex.Message,"Ok");
            }
        
        
        }


        private void btnPost_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
