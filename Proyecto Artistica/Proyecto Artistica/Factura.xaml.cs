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
    public partial class Factura : ContentPage
    {
        public Factura(int idUser)
        {
            InitializeComponent();
            lblidUser.Text = idUser.ToString();
            var allProd = UserRepository.Instancia.GetAllCarrito(idUser);
            carritoList.ItemsSource = allProd;
            tbCart.Clicked += TbCart_Clicked;
            btnCrear.Clicked += BtnCrear_Clicked;
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

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            try
            {
                string action = await DisplayActionSheet("Seleccionar Plan de Pago:", "Cancelar",
                    null, "3 meses 6% interés", "6 meses 9% interés", "9 meses 12% interés");
                int pago = 0;
                decimal interes = 0;
                decimal total = 0;
                decimal monto = 0;
                if (action.Equals("3 meses 6% interés"))
                {
                    pago = 3;
                    interes = 6;
                }
                else if (action.Equals("6 meses 9% interés"))
                {
                    pago = 6;
                    interes = 9;
                }
                else if (action.Equals("9 meses 12% interés"))
                {
                    pago = 9;
                    interes = 12;
                }
                else
                {
                    return;
                }

                var carrito = UserRepository.Instancia.GetAllCarrito(Convert.ToInt32(lblidUser.Text));
                if (carrito != null)
                    foreach (var aux in carrito)
                    {
                        total = total + aux.Precio;
                    }
                else
                {
                    await DisplayAlert("Error", "Error al procesar compra...", "OK");
                    return;
                }
                monto = ((total * (interes / 100))+total) / pago;
                UserRepository.Instancia.AddNewVenta(Convert.ToInt32(lblidUser.Text),DateTime.Now,total,monto,pago,interes);
                if (StatusMessage.Text.Equals(""))
                {
                    int ventaId = UserRepository.Instancia.GetVenta(Convert.ToInt32(lblidUser.Text));
                    if (ventaId > 0)
                    {
                        if (UserRepository.Instancia.UpdateCarrito(Convert.ToInt32(lblidUser.Text), ventaId))
                        {
                            await DisplayAlert("Compra", "Compra realizada con exito...", "OK");
                            for (int i = 0; i < pago; i++)
                            {
                                UserRepository.Instancia.AddNewPago(ventaId, monto, i + 1, DateTime.Now.AddMonths(i + 1));
                            }
                            var allProd = UserRepository.Instancia.GetAllCarrito(Convert.ToInt32(lblidUser.Text));
                            carritoList.ItemsSource = allProd;
                        }
                        else
                        {
                            await DisplayAlert("Error", "Error al procesar compra...", "OK");
                            return;
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Error al procesar compra...", "OK");
                        return;
                    }
                }
                else 
                {
                    await DisplayAlert("Error", "Error al procesar compra...", "OK");
                    return;
                }
             }
            catch (Exception ex) 
            {
                await DisplayAlert("Error", "Error al procesar compra...", "OK");
            }
            



        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            var button = sender as Button;
            var carrito = button.BindingContext as Carrito;
            
            UserRepository.Instancia.DeleteCarrito(carrito);

            if (StatusMessage.Text.Equals(""))
            {
                var producto = UserRepository.Instancia.GetProducto(Convert.ToInt32(carrito.productoId.ToString()));
                producto.Cantidad = producto.Cantidad + carrito.Cantidad;
                UserRepository.Instancia.UpdateProducto(producto);
                await DisplayAlert("Eliminar", "Item elimnado correctamente...", "OK");
                var allProd = UserRepository.Instancia.GetAllCarrito();
                carritoList.ItemsSource = allProd;
            }
            else
            {
                await DisplayAlert("Error", "Error al eliminar...", "OK");
            }
        }
    }
}