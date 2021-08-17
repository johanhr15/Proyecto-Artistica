using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Proyecto_Artistica
{
    public partial class MenuAdmin : ContentPage
    {
        public MenuAdmin()
        {
            InitializeComponent();
            btnMenuGarantia.Clicked += BtnMenuGarantia_Clicked;
            btnMenuProductos.Clicked += BtnMenuProductos_Clicked;
            btnMenuUsuarios.Clicked += BtnMenuUsuarios_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;

        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void BtnMenuUsuarios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuariosMenu());
        }

        private async void BtnMenuProductos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductosMenu());
        }

        private async void BtnMenuGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GarantiasMenu());
        }
    }
}
