using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Artistica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Artistica
{
    [DesignTimeVisible(false)]
    public partial class garantiaForm : ContentPage
    {
        public garantiaForm(int idUser, int idVenta, int idProducto, int idFactura)
        {
            InitializeComponent();
            lblidUser.Text = idUser.ToString();
            lblidFactura.Text = idFactura.ToString();
            lblidProducto.Text = idProducto.ToString();
            lblidVenta.Text = idVenta.ToString();
            tbCart.Clicked += TbCart_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
            btnCrear.Clicked += BtnCrear_Clicked;
        }

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.AddNewGarantia(Convert.ToInt32(lblidVenta.Text), Convert.ToInt32(lblidProducto.Text), Convert.ToInt32(lblidFactura.Text), txtDescripcion.Text,"P",DateTime.Now);
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            if (StatusMessage.Text.Contains("Cantidad"))
            {
                StatusMessage.Text = "";
                await DisplayAlert("Garantía", "Proceso de garantía solicitado con exito...", "OK");
                await Navigation.PushAsync(new AplicarGarantia(Convert.ToInt32(lblidUser.Text), Convert.ToInt32(lblidVenta.Text)));
            }
        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main(Convert.ToInt32(lblidUser.Text)));
        }
    }
}