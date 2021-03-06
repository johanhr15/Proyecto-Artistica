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
    public partial class CrearGarantia : ContentPage
    {
        public CrearGarantia()
        {
            InitializeComponent();
            btnCrear.Clicked += BtnCrear_Clicked;
            StatusMessage.Text = "";

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

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.AddNewGarantiaAdmin(Int32.Parse(txtVentaId.Text), Int32.Parse(txtProductoId.Text), Int32.Parse(txtFacturaId.Text), txtDescripcion.Text, txtEstado.Text,fecha.Date.Date,txtresolucion.Text);
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            if (StatusMessage.Text.Contains("Cantidad"))
            {
                clean();
                await DisplayAlert("Confirmacion", "Garantia Creada Correctamente!", "OK");
                await Navigation.PushAsync(new GarantiasMenu());
            }
        }



        private void clean()
        {
            txtVentaId.Text = "";
            txtProductoId.Text = "";
            txtDescripcion.Text = "";
            txtFacturaId.Text = "";
            StatusMessage.Text = "";
        }
    }
}
