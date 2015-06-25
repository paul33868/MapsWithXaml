using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using DevSuperPowersDemo.Models;

namespace DevSuperPowersDemo.Views
{
    public partial class DemoView : ContentPage
    {
        Coordenadas Coor;

        public DemoView()
        {
            InitializeComponent();
            Coor = new Coordenadas();
        }

        private async void GetDir_OnClicked(object sender, EventArgs e)
        {
            await Coor.GetDireccion(MyAdress.Text, MyMap);
        }
    }
}
