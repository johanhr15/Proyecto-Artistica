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
    public partial class CrearProducto : ContentPage
    {
        public CrearProducto()
        {
            InitializeComponent();
            btnCrear.Clicked += BtnCrear_Clicked;
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.AddNewProducto(txtNombre.Text, txtCat.Text, txtSalon.Text, Int32.Parse(txtCantidad.Text), Int32.Parse(txtPrecio.Text), txtProveedor.Text, txtImg.Text);
            clean();
        }
        private void clean()
        {
            txtNombre.Text = "";
            txtCat.Text = "";
            txtCantidad.Text = "";
            txtSalon.Text = "";
            txtProveedor.Text = "";
            txtPrecio.Text = "";
            txtImg.Text = "";
        }
    }
}
