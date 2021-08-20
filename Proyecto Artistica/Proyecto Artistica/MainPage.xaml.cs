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


namespace Proyecto_Artistica
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;

        public MainPage()
        {
            InitializeComponent();
            btnCrear.Clicked += BtnCrear_Clicked;
            btnIniciarSesion.Clicked += BtnIniciarSesion_Clicked;
            btnEnviarClave.Clicked += BtnEnviarClave_Clicked;
            lblError.Text = "";
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnEnviarClave_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarPass());
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (UserRepository.Instancia.GetUsuario(txtUsuario.Text, txtClave.Text) != 0)
            {
                if (revisarAdmin(UserRepository.Instancia.GetPermiso(txtUsuario.Text, txtClave.Text)))
                {
                    await Navigation.PushAsync(new MenuAdmin());
                }
                else
                await Navigation.PushAsync(new Main(UserRepository.Instancia.GetUsuario(txtUsuario.Text, txtClave.Text))); 
            }
            else 
            {
                lblError.Text = "Credenciales Inválidas";
            }
          
          
        }
        private bool revisarAdmin(string tipo)
        {
            if (tipo.Equals("A"))
            {
                return true;
            }
            else { return false;}
        }

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateUsuario());
        }
    }
}
