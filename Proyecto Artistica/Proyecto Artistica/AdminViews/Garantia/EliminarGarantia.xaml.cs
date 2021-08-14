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
    public partial class EliminarGarantia : ContentPage
    {
        public EliminarGarantia()
        {
            InitializeComponent();
            btnEliminar.Clicked += BtnEliminar_Clicked;
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.DeleteGarantia(Int32.Parse(txtId.Text));
        }
    }
}
