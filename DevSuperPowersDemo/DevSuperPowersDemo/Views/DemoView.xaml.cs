using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DevSuperPowersDemo.Views
{
    public partial class DemoView : ContentPage
    {

        public DemoView()
        {
            InitializeComponent();
        }

        private void GetDir_OnClicked(object sender, EventArgs e)
        {
            GetDireccion(MyAdress.Text, MyMap);
        }

        public async Task GetDireccion(string addressQuery, Map map)
        {
            var positions = (await (new Geocoder()).GetPositionsForAddressAsync(addressQuery)).ToList();
            if (!positions.Any())
                return;

            var position = positions.First();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position,
            Distance.FromMiles(0.1)));
            map.Pins.Add(new Pin
            {
                Label = addressQuery,
                Position = position,
                Address = addressQuery
            });
        }  
    }
}
