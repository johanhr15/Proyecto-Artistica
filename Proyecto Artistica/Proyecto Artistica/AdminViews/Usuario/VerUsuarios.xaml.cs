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
    public partial class VerUsuarios : ContentPage
    {
        public VerUsuarios()
        {
            InitializeComponent();
            btnAct.Clicked += BtnAct_Clicked;
        }

        private void BtnAct_Clicked(object sender, EventArgs e)
        {
            var allUsers = UserRepository.Instancia.GetAllUsuarios();
            listaUsuarios.ItemsSource = allUsers;
        }
    }
}
