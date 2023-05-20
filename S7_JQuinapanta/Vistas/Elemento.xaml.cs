using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7_JQuinapanta.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;
        public Elemento(int id, string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasena.Text = contrasena;

            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }

        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("delete from Estudiante where id= ?", id);
        }

        public static IEnumerable<Estudiante> Actualizar (SQLiteConnection db,  string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("update Estudiante set Nombre = ? , Usuario = ?, Contrasena = ? where id = ?", nombre, usuario, contrasena, id);
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("alerta", ex.Message, "cerrar");
            }
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("alerta", ex.Message, "cerrar");
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}