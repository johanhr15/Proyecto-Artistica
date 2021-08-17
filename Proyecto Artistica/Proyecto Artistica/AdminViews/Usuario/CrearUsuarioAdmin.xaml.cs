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
    public partial class CrearUsuarioAdmin : ContentPage
    {
        public CrearUsuarioAdmin()
        {
            InitializeComponent();
            StatusMessage.Text = "";
            btnCrear.Clicked += BtnCrear_Clicked;

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
            StatusMessage.Text = string.Empty;
            UserRepository.Instancia.AddNewUsuario(txtUsuario.Text, txtNombre.Text, txtApellidos.Text, txtEmail.Text, txtClave.Text, txtTipo.Text);
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            await DisplayAlert("Confirmacion", "Usuario Creado Correctamente!", "OK");
            await Navigation.PushAsync(new UsuariosMenu());

            if (StatusMessage.Text.Contains("Cantidad"))
            {
                clean();
                await Navigation.PushAsync(new UsuariosMenu());
            }

        }
        private void clean()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEmail.Text = "";
            txtClave.Text = "";
            StatusMessage.Text = "";
            txtTipo.Text =  "";
        }
    }
}
