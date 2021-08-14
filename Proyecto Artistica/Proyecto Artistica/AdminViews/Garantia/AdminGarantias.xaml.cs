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
            btnAct.Clicked += BtnAct_Clicked;
        }

        private void BtnAct_Clicked(object sender, EventArgs e)
        {
            var allGarantias = UserRepository.Instancia.GetAllGarantias();
            listaGarantias.ItemsSource = allGarantias;
        }

        /*
         * <Grid.GestureRecognizers>
                                    <TapGestureRecognizer Tapped="OnTapped"/>
                                </Grid.GestureRecognizers>
         * 
         * void OnTapped(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("alert","you have been alerted","ok");
        }*/
    }
}
