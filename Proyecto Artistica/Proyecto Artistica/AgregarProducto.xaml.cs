using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Artistica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Artistica
{
    [DesignTimeVisible(false)]
    public partial class AgregarProducto : ContentPage
    {
        public AgregarProducto(int userId)
        {
            InitializeComponent();
            lblidUser.Text = userId.ToString();
            btnCrear.Clicked += BtnCrear_Clicked;
            tbCart.Clicked += TbCart_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main(Convert.ToInt32(lblidUser.Text)));
        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            try {
                Convert.ToInt32(txtCantidad.Text);
                Convert.ToDecimal(txtPrecio.Text);
            } catch(Exception ex) 
            {
                StatusMessage.Text = "El valor de cantidad y precio deben de ser numéricos...";
                return;
            }
            UserRepository.Instancia.AddNewProducto(txtNombre.Text,txtCategoria.Text, txtSalon.Text, Convert.ToInt32(txtCantidad.Text),Convert.ToDecimal(txtPrecio.Text),txtProveedor.Text,"");
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            if (StatusMessage.Text.Contains("Cantidad"))
            {
                //clean();
                //await Navigation.PushAsync(new Main());
            }
        }
    }
}