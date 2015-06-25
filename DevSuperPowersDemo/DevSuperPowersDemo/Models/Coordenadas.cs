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
using Xamarin.Forms.Labs.Services.Geolocation;
using Geolocator;
using Geolocator.Plugin;
using System.Collections.ObjectModel;

namespace DevSuperPowersDemo.Models
{
    public class Coordenadas
    {
        Map oneMap;
        Xamarin.Forms.Maps.Position myPos;

        public Coordenadas()
        {

        }

        public async Task<string> GetCoordenadas ()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeout: 10000);

            return "Lat" + position.Latitude.ToString() + "Long" + position.Longitude.ToString();
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

        public async Task<string> ShowMyAdress()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));

            return locationAddress.First().ToString();
        }
    }
}
