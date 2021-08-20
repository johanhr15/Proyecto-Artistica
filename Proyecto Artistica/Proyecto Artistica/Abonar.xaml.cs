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
    public partial class Abonar : ContentPage
    {
        public Abonar(int idUser)
        {
            InitializeComponent();
            lblidUser.Text = idUser.ToString();
            var allProd = UserRepository.Instancia.GetAllPagos(idUser);
            pagosList.ItemsSource = allProd;
            pagosList.ItemSelected += PagosList_ItemSelected;
            tbCart.Clicked += TbCart_Clicked;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
        }

        private async void PagosList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectVar = e.SelectedItem as Pago;
            bool answer = await DisplayAlert("Confirmación", "Seguro que desea realizar este abono?", "Si", "No");
            if (answer) 
            {
                if (UserRepository.Instancia.UpdatePago(selectVar.pagoId))
                {
                    var allProd = UserRepository.Instancia.GetAllPagos(Convert.ToInt32(lblidUser.Text));
                    pagosList.ItemsSource = allProd;
                    String asunto = "Reporte Abono La Artística";
                    String cuerpo = "Su abono se realizó con éxito.\nLa Artistica S.A.";
                    UserRepository.Instancia.enviarCorreo(asunto, cuerpo, UserRepository.Instancia.GetCorreoById(Convert.ToInt32(lblidUser.Text)));
                    
                    await DisplayAlert("Abono", "Abono realizado con exito...", "OK");
                }
                else 
                {
                    await DisplayAlert("Error", "Error al procesar el abono...", "OK");
                    return;
                }
            }
        }

        private async void TbCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main(Convert.ToInt32(lblidUser.Text)));
        }
    }
}