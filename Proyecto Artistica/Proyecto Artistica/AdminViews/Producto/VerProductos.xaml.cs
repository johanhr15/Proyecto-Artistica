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
    public partial class VerProductos : ContentPage
    {
        public VerProductos()
        {
            InitializeComponent();
            btnAct.Clicked += BtnAct_Clicked;
        }

        private void BtnAct_Clicked(object sender, EventArgs e)
        {
            var allProds = UserRepository.Instancia.GetAllProductos();
            productoList.ItemsSource = allProds;
        }
    }
}
