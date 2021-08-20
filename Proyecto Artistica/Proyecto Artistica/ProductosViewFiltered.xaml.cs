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

namespace Proyecto_Artistica
{
    [DesignTimeVisible(false)]
    public partial class ProductosViewFiltered : ContentPage
    {
        public ProductosViewFiltered(int idUser, string categoria)
        {
            InitializeComponent();
            lblidUser.Text = idUser.ToString();
            lblcategoria.Text = categoria.ToString();
            var allProd = UserRepository.Instancia.GetAllProductosFiltered(lblcategoria.Text);
            productList.ItemsSource = allProd;
            productList.ItemSelected += ProductList_ItemSelected;
            tbCart.Clicked += TbCart_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
            
        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main(Convert.ToInt32(lblidUser.Text)));
        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private async void ProductList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectVar = e.SelectedItem as Producto;
            if(selectVar.Cantidad > 0)
                await Navigation.PushAsync(new ComprarProducto(selectVar, Convert.ToInt32(lblidUser.Text)));
            else
                await DisplayAlert("Error", "El artículo seleccionado no esta disponible...", "Cancelar");
        }
    }
}