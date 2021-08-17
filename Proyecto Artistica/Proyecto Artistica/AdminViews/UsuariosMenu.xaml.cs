using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Proyecto_Artistica
{
    public partial class UsuariosMenu : ContentPage
    {
        public UsuariosMenu()
        {
            InitializeComponent();
            btnAgregarUsuario.Clicked += BtnAgregarUsuario_Clicked;
            btnVerUsuario.Clicked += BtnVerUsuario_Clicked;
            btnEditarUsuario.Clicked += BtnEditarUsuario_Clicked;
            btnEliminarUsuario.Clicked += BtnEliminarUsuario_Clicked;
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

        private async void BtnEliminarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarUsuario());
        }

        private async void BtnEditarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarUsuario());
        }

        private async void BtnVerUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerUsuarios());
        }

        private async void BtnAgregarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearUsuarioAdmin());
        }
    }
}
