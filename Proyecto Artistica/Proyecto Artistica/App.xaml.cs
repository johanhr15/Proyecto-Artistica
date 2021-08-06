using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Artistica.Models;

namespace Proyecto_Artistica
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UserRepository.Inicializador(filename);
            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.FromHex("#0E547C"), BarTextColor = Color.White};
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
