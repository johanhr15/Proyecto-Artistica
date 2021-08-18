using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Artistica
{
    [DesignTimeVisible(false)]
    public partial class Main : ContentPage
    {
        private const string monkeyUrl = "https://api.jsonbin.io/b/610e254cd5667e403a3ad8ca";
        private readonly HttpClient httpClient = new HttpClient();

        public ObservableCollection<Monkey> Monkeys { get; set; } = new ObservableCollection<Monkey>();

        

        public Main(int userId)
        {
            var images = new List<string> { "home1.JPG",
                                            "home2.JPG",
                                            "home3.JPG",
                                            "home4.JPG",
                                            "home5.JPG"};

            InitializeComponent();
            BindingContext = this;
            lblidUser.Text = userId.ToString();
            btnComprar.Clicked += BtnComprar_Clicked;
            btnAbonar.Clicked += BtnAbonar_Clicked;
            btnGarantia.Clicked += BtnGarantia_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;
            btnCompras.Clicked += BtnCompras_Clicked;
            btnHistorialCompras.Clicked += BtnHistorialCompras_Clicked;
            btnHistorialGarantia.Clicked += BtnHistorialGarantia_Clicked;
            btnHistorialPagos.Clicked += BtnHistorialPagos_Clicked;
            MainCarouselView.ItemsSource = images;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                MainCarouselView.Position = (MainCarouselView.Position + 1) % images.Count;
                return true;
            }));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var monkeyJson = await httpClient.GetStringAsync(monkeyUrl);
            var monkeys = JsonConvert.DeserializeObject<Monkey[]>(monkeyJson);

            Monkeys.Clear();

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }

        private async void BtnHistorialPagos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialPagosxaml(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnHistorialGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialGarantia(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnHistorialCompras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialVenta(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnCompras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Factura(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnGarantia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ventaGarantia(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnAbonar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Abonar(Convert.ToInt32(lblidUser.Text)));
        }

        private async void BtnComprar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductosView(Convert.ToInt32(lblidUser.Text)));
        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}