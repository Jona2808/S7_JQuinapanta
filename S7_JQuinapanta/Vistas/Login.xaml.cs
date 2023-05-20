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
    public partial class Login : ContentPage
    {
        //variable de conexion
        private SQLiteAsyncConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion=DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("select * from Estudiante where Usuario =? and contrasena =?",usuario,contrasena);
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("ALERTA", "usuario o contraseña incorrecto", "cerrar");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}