using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mpSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consultar : ContentPage
    {
        private const string Url = "http://192.168.27.104/moviles/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<mpSemana6.WS.Datos> post;
        public Consultar()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<mpSemana6.WS.Datos> posts = JsonConvert.DeserializeObject<List<mpSemana6.WS.Datos>>(content);
            post = new ObservableCollection<WS.Datos>(posts);
            lista.ItemsSource = post;
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage()); 
        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}