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
    public partial class CambiarPass : ContentPage
    {
        public CambiarPass(int userId,string codigo)
        {
            InitializeComponent();
            lblidUser.Text = userId.ToString();
            lblcodeUser.Text = codigo;
            btnActPass.Clicked += BtnActPass_Clicked;
        }

        private async void BtnActPass_Clicked(object sender, EventArgs e)
        {
            if (txtCode.Text.ToUpper().Equals(lblcodeUser.Text))
            {
                if (txtPass.Text.Equals("") || txtPass.Text.Equals(" "))
                {
                    await DisplayAlert("Error", "La contraseña no puede estar vacía!", "OK");

                }
                else
                {
                    UserRepository.Instancia.UpdatePass(Convert.ToInt32(lblidUser.Text), txtPass.Text);
                    await DisplayAlert("Confirmación", "Se cambió apropiadamente su contraseña. ", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                await DisplayAlert("Error", "El codigo que inserto no es el correcto!", "OK");
            }
        }
    }
}
