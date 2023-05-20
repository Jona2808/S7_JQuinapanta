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
    public partial class Registro : ContentPage
    {
        //variable de conexion
        private SQLiteAsyncConnection conexion;
        public Registro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datos = new Estudiante { 
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Contrasena = txtContrasena.Text,
                };

                conexion.InsertAsync(datos);

                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasena.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("alesta", ex.Message,"cerrar");
            }
        }
    }
}