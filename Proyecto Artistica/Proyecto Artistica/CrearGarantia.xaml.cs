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

        }

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.AddNewGarantia(Int32.Parse(txtVentaId.Text), Int32.Parse(txtProductoId.Text), Int32.Parse(txtFacturaId.Text), txtDescripcion.Text, txtEstado.Text,fecha.Date.Date);
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            if (StatusMessage.Text.Contains("Cantidad"))
            {
                clean();
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
