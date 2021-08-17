using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Artistica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Syncfusion.SfDataGrid.XForms;


namespace Proyecto_Artistica
{
    public partial class AdminGarantias : ContentPage
    {
        public ICommand RowTappedCommand { get; private set; }
        private ICommand _tapCommand;
        public AdminGarantias()
        {
            InitializeComponent();
            var allGarantias = UserRepository.Instancia.GetAllGarantias();
            listaGarantias.ItemsSource = allGarantias;
            tbHome.Clicked += TbHome_Clicked;
            tbLogout.Clicked += TbLogout_Clicked;

        }

        private void TbLogout_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void TbHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAdmin());
        }
    }
}
