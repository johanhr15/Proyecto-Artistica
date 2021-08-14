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
    public partial class EditarGarantias : ContentPage
    {
        public EditarGarantias()
        {
            InitializeComponent();
            btnUpdate.Clicked += BtnUpdate_Clicked;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                StatusMessage.Text = string.Empty;
                UserRepository.Instancia.UpdateGarantia(Convert.ToInt32(txtActualizar.Text), txtResolucionNueva.Text,txtEstado.Text);
                StatusMessage.Text = "ID " + txtActualizar.Text + " actualizado correctamente!";
                StatusMessage.TextColor = Color.Green;
            }
            catch (Exception)
            {

                StatusMessage.Text = "Error Actualizando Item";
                StatusMessage.TextColor = Color.Red;
            }
        }
    }
}
