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
    public partial class RecuperarPass : ContentPage
    {
        public RecuperarPass()
        {
            InitializeComponent();
            btnsendmail.Clicked += Btnsendmail_Clicked;
        }

        private async void Btnsendmail_Clicked(object sender, EventArgs e)
        {
            String asunto = "Recuperación de Contraseña La Artística";
            String codigo = RandomString(6);
            String cuerpo = "Su codigo de recuperacion es:"+codigo+" \nLa Artistica S.A.";
            lblidUser.Text = UserRepository.Instancia.GetUserbyMail(txtUsuario.Text).ToString();
            UserRepository.Instancia.enviarCorreo(asunto, cuerpo, UserRepository.Instancia.GetCorreoById(Convert.ToInt32(lblidUser.Text)));
            await DisplayAlert("Confirmación", "Se envió un codigo de recuperación a su correo. ", "OK");
            await Navigation.PushAsync(new CambiarPass(Convert.ToInt32(lblidUser.Text),codigo));
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
 