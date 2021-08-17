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
    public partial class EditarUsuario : ContentPage
    {
        public EditarUsuario()
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
                UserRepository.Instancia.UpdateUsuario(Convert.ToInt32(txtActualizarId.Text), txtActualizarNombre.Text, txtActualizarApellidos.Text, txtActualizarUsuario.Text, txtActualizarEmail.Text, txtActualizarPassword.Text, txtActualizarType.Text);
                await DisplayAlert("Confirmacion", "Usuario Editado Correctamente!", "OK");
                StatusMessage.Text = "ID " + txtActualizarId.Text + " actualizado correctamente";
                StatusMessage.TextColor = Color.Green;
                clean();
            }
            
            catch (Exception)
            {

                StatusMessage.Text = "Error Actualizando Item";
                StatusMessage.TextColor = Color.Red;
            }
        }
        private void clean()
        {
            txtActualizarId.Text = "";
            txtActualizarNombre.Text = "";
            txtActualizarApellidos.Text = "";
            txtActualizarUsuario.Text = "";
            txtActualizarEmail.Text = "";
            txtActualizarPassword.Text = "";
            txtActualizarType.Text = "";
        }
    }
}
