using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Controls;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Geolocation; //It's not used rigth now, but it might in the near future
using Geolocator;
using Geolocator.Plugin;
using System.Collections.ObjectModel;

namespace DevSuperPowersDemo.Models
{
    public class Coordenadas
    {
        
        public async Task<string> GetCoordenadas ()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeout: 10000);

            //var positions = (await (new Geocoder()).GetPositionsForAddressAsync(addressQuery)).ToList();
            //if (!positions.Any())
            //return "No coords found";

            //var position = positions.First();
            //return position.ToString();

            return "Lat" + position.Latitude.ToString() + "Long" + position.Longitude.ToString();
        }    
    }
}
