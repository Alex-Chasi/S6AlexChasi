using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6AlexChasi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertarA : ContentPage
    {
        public viewInsertarA()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.50.106:8084/moviles/post.php", "POST", parametros);

                DisplayAlert("Mensaje", "Ingreso Correcto", "OK");
                Limpiar();


            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message,"OK");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());


        }

        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";

        }
    }
}