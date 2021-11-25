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
    public partial class viewUpdate : ContentPage
    {

        public int IdSeleccionado;
        public viewUpdate(int codEst)
        {

            IdSeleccionado = codEst;
            InitializeComponent();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.GetValues(IdSeleccionado);
                parametros.GetValues("nombre");
                parametros.GetValues("apellido");
                parametros.GetValues("edad");
                cliente.UploadValues("http://192.168.50.106:8084/moviles/post.php", "PUT", parametros);
                DisplayAlert("Mensaje", "Actualizado Correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.GetValues("codigo" + IdSeleccionado);
                cliente.UploadValues("http://192.168.50.106:8084/moviles/post.php", "DELETE", parametros);
                DisplayAlert("Mensaje", "Eliminado Correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "OK");
            }

        }
    }
}