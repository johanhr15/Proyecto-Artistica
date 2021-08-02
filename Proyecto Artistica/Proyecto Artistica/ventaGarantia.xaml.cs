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
    public partial class ventaGarantia : ContentPage
    {
        public ventaGarantia(int idUser)
        {
            InitializeComponent();
            lblidUser.Text = idUser.ToString();
            var allProd = UserRepository.Instancia.GetAllVentas(idUser, DateTime.Now);
            garantiaList.ItemsSource = allProd;
            garantiaList.ItemSelected += GarantiaList_ItemSelected; ;
            tbCart.Clicked += TbCart_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
        }

        private async void GarantiaList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedVar = e.SelectedItem as Venta;
            await Navigation.PushAsync(new AplicarGarantia(Convert.ToInt32(lblidUser.Text), selectedVar.ventaId));
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