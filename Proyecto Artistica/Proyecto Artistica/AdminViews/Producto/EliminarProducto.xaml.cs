using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using System.Net;
using System.Xml.Serialization;
using Proyecto_Artistica.Models;
using SQLite;
using System.Data;
using Proyecto_Artistica;
namespace Proyecto_Artistica
{
    public partial class EliminarProducto : ContentPage
    {
        public EliminarProducto()
        {
            InitializeComponent();
            btnEliminar.Clicked += BtnEliminar_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;

        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAdmin());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.DeleteProduct(Int32.Parse(txtId.Text));
            await DisplayAlert("Confirmacion", "Producto Eliminado Correctamente!", "OK");
            await Navigation.PushAsync(new ProductosMenu());
        }
    }
}
