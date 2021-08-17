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
    public partial class EditarGarantias : ContentPage
    {
        public EditarGarantias()
        {
            InitializeComponent();
            btnEditar.Clicked += btnEditar_Clicked;
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

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                StatusMessage.Text = string.Empty;
                UserRepository.Instancia.UpdateGarantia(Convert.ToInt32(txtID.Text), Int32.Parse(txtVentaId.Text), Int32.Parse(txtProductoId.Text), Int32.Parse(txtFacturaId.Text), txtDescripcion.Text, txtEstado.Text, fecha.Date.Date, txtresolucion.Text);
                await DisplayAlert("Confirmacion", "Garantia Editada Correctamente!", "OK");

            }
            catch (Exception)
            {

                StatusMessage.Text = "Error Actualizando Item";
                StatusMessage.TextColor = Color.Red;
            }
        }
    }
}
