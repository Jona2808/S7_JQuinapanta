using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7_JQuinapanta.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            ObtenerEstudiantes();
        }

        public async void ObtenerEstudiantes(){
            var ResultadoEstudiante = await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(ResultadoEstudiante);
            listaEstudiantes.ItemsSource = tablaEstudiante;
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            var ItemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId);
            string nombre = objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string contrasena = objetoEstudiante.Contrasena.ToString();

            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasena));

        }
    }
}