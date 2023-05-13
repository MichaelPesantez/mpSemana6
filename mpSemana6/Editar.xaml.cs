using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mpSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar(string codigo, string nombre, string apellido, string edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad;
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(await DisplayAlert("Confirmacion", "Esta Seguro de Editar los Datos", "SI", "NO"))    
                {
                    WebClient cliente = new WebClient();
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    cliente.UploadValues("http://192.168.27.104/moviles/post.php?codigo="+txtCodigo.Text+"&nombre="+txtNombre.Text+
                        "&apellido="+txtApellido.Text+"&edad="+txtEdad.Text, "PUT", parametros);

                    await Navigation.PushAsync(new Consultar());
                }
                
            }
            catch(Exception ex) 
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}