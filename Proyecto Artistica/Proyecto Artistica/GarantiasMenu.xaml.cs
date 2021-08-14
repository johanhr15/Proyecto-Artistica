using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Proyecto_Artistica
{
    public partial class GarantiasMenu : ContentPage
    {
        public GarantiasMenu()
        {
            InitializeComponent();
            btnAgregarGarantia.Clicked += BtnAgregarGarantia_Clicked;
            btnVerGarantia.Clicked += BtnVerGarantia_Clicked;
            btnEliminarGarantia.Clicked += BtnEliminarGarantia_Clicked;
            btnEditarGarantia.Clicked += BtnEditarGarantia_Clicked;
        }

        private async void BtnEditarGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarGarantias());
        }

        private async void BtnEliminarGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarGarantia());
        }

        private async void BtnVerGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminGarantias());
        }

        private async void BtnAgregarGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearGarantia());
        }
    }
}
