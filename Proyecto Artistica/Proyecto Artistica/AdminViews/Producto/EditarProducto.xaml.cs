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
    public partial class EditarProducto : ContentPage
    {
        public EditarProducto()
        {
            InitializeComponent();
            btnEditar.Clicked += BtnEditar_Clicked;
        }

        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                StatusMessage.Text = string.Empty;
                UserRepository.Instancia.UpdateProductoAdmin(Convert.ToInt32(txtID.Text), txtNombre.Text, txtCat.Text, txtSalon.Text, Int32.Parse(txtCantidad.Text), Int32.Parse(txtPrecio.Text), txtProveedor.Text, txtImg.Text);
                StatusMessage.Text = "ID " + txtID.Text + " actualizado correctamente";
                StatusMessage.TextColor = Color.Green;
            }
            catch (Exception)
            {

                StatusMessage.Text = "Error Actualizando Item";
                StatusMessage.TextColor = Color.Red;
            }
        }
        private void clean()
        {
            txtID.Text = "";
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
