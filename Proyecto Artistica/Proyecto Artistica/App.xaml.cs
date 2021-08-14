using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Artistica.Models;

namespace Proyecto_Artistica
{
    public partial class App : Application
    {
        public App(string filename)
        {
            DateTime ThisDay = DateTime.Today;
            InitializeComponent();
            UserRepository.Inicializador(filename);
            //string nombre, string categoria, string salon, int cantidad, decimal precio, string proveedor, string image
            //UserRepository.Instancia.AddNewProducto("AAA","mueble","a",10,11,"rodeo","TEST");

            //int ventaid, int productoId,int facturaId,string descripcion, string estado, DateTime fecha
            //UserRepository.Instancia.AddNewGarantia(1,1,1,"testing","moroso",ThisDay);

            //UserRepository.Instancia.AddNewUsuario("admin", "admin", "admin", "testulacit@gmail.com", "admin", "A");

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.FromHex("#0E547C"), BarTextColor = Color.White};
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
