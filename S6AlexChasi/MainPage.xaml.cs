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
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<S6AlexChasi.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6AlexChasi.Ws.Datos>>(content);
            _post = new ObservableCollection<S6AlexChasi.Ws.Datos>(posts);

            MyListView.ItemsSource = _post;

        }
    }
}
