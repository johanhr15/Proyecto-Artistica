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
    public partial class ProductosMenu : ContentPage
    {
        public ProductosMenu()
        {
            InitializeComponent();
            btnAgregarProducto.Clicked += BtnAgregarProducto_Clicked;
            btnEditarProducto.Clicked += BtnEditarProducto_Clicked;
            btnEliminarProducto.Clicked += BtnEliminarProducto_Clicked;
            btnVerProducto.Clicked += BtnVerProducto_Clicked;
        }

        private async void BtnVerProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerProductos());
        }

        private async void BtnEliminarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarProducto());
        }

        private async void BtnEditarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarProducto());
        }

        private async void BtnAgregarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearProducto());
        }
    }
}
