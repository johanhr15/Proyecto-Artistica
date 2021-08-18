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
    public partial class ComprarProducto : ContentPage
    {
        public ComprarProducto(Producto producto, int idUser)
        {
            InitializeComponent();
            txtIdUser.Text = idUser.ToString();
            txtId.Text = producto.productoId.ToString();
            txtNombre.Text = producto.Nombre;
            txtCategoria.Text = producto.Categoria;
            txtPrecio.Text = producto.Precio.ToString();
            txtProveedor.Text = producto.Proveedor;
            txtSalon.Text = producto.Salon;
            txtCantidad.Text = producto.Cantidad.ToString();
            txtimage.Text = producto.Image;
            var images = new List<string> { string.Concat(txtimage.Text)};
            MainCarouselView.ItemsSource = images;
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
            await Navigation.PushAsync(new Main(Convert.ToInt32(txtIdUser.Text)));
        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(txtIdUser.Text)));
        }

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (UserRepository.Instancia.GetCarritoUserProd(Convert.ToInt32(txtIdUser.Text), Convert.ToInt32(txtId.Text)) == null)
                {
                    UserRepository.Instancia.AddNewCarrito(Convert.ToInt32(txtIdUser.Text), Convert.ToInt32(txtId.Text), txtNombre.Text, 1, Convert.ToDecimal(txtPrecio.Text));
                }
                else
                {
                    var carrito = UserRepository.Instancia.GetCarritoUserProd(Convert.ToInt32(txtIdUser.Text), Convert.ToInt32(txtId.Text));
                    UserRepository.Instancia.UpdateCarrito(carrito, carrito.Precio + Convert.ToDecimal(txtPrecio.Text), carrito.Cantidad + 1);

                }
                StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
                if (StatusMessage.Text.Contains("Cantidad"))
                {
                    var producto = UserRepository.Instancia.GetProducto(Convert.ToInt32(txtId.Text));
                    producto.Cantidad = producto.Cantidad - 1;
                    UserRepository.Instancia.UpdateProducto(producto);
                    if (StatusMessage.Text.Contains("Cantidad"))
                    {
                        StatusMessage.Text = "";
                        await DisplayAlert("Compra", "Item agregado correctamente...", "OK");
                        await Navigation.PushAsync(new ProductosView(Convert.ToInt32(txtIdUser.Text)));

                    }
                    
                }
            }
            catch (Exception)
            {

                StatusMessage.Text = "Sucedió un error inesperado...";
            }
           
        }
    }
}