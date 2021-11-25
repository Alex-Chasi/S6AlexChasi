using Newtonsoft.Json;
using S6AlexChasi.Ws;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

            //var mensaje = "mensaje xamarin";
            //DependencyService.Get<MensajeA>().longAlert(mensaje);


            //await Navigation.PushAsync(new viewInsertarA());

            //codigo clase s6 para cargar informacion con el boton
            
            var content = await client.GetStringAsync(Url);
            List<S6AlexChasi.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6AlexChasi.Ws.Datos>>(content);
            _post = new ObservableCollection<S6AlexChasi.Ws.Datos>(posts);
            MyListView.ItemsSource = _post;
        }


        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<S6AlexChasi.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6AlexChasi.Ws.Datos>>(content);
                _post = new ObservableCollection<S6AlexChasi.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR" + ex.Message, "Ok");
            }
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objEst = (Datos)e.SelectedItem;
            var item = objEst.codigo.ToString();
            int codEst = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new viewUpdate(codEst));
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private async void btnInsert_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertarA());

        }

        /*
        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            //aqui clase Datos lo puse publico para el actualizar el dato 
            
            Ws.Datos da = new Ws.Datos
            {
            };
            if (await DisplayAlert("Modificar", "esta seguro de modificar el registro", "Si", "No")) ;
            {

            }

        }*/

        /*
        //metodo parar actualizar consultado
        public async Task<HttpResponseMessage> updateU(int Codigo, string Nombre, string Apellido, string Edad) 
        {
            var client = new HttpClient();
            var model = new Datos 
            {
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad           
            
            };
            var json = JsonConvert.SerializeObject(model);
            StringContent body = new StringContent(json, Encoding.UTF8, "äpplication/json");
            var response = await client.PutAsync(Url + "estudiante/" + Codigo, body);
            return response;        
        }
        */
        /*
        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await.DisplayAlert("Confirmación", "esta seguro de eliminar el registro", "Si", "No");
                if (result)
                {                  


                }
                else
                {

                }
            });
        }
        */
        /*
        if (await DisplayAlert("Confirmación", "esta seguro de eliminar el registro", "Si", "No")) ;
        {                 

        }*/
    }
}

