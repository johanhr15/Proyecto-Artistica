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
    public partial class EliminarUsuario : ContentPage
    {
        public EliminarUsuario()
        {
            InitializeComponent();
            btnEliminar.Clicked += BtnEliminar_Clicked;
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instancia.DeleteUser(Int32.Parse(txtId.Text));
        }
    }
}
