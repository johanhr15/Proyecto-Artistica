using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Proyecto_Artistica
{
    public partial class EditarProducto : ContentPage
    {
        public EditarProducto()
        {
            InitializeComponent();
            btnEditar.Clicked += BtnEditar_Clicked;
        }

        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
