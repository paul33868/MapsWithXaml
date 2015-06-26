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
        public Coordenadas()
        {

        }

        public async Task<string> GetCoordenadas()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeout: 10000);

            return "Lat" + position.Latitude.ToString() + "Long" + position.Longitude.ToString();
        }

        public async Task<double> GetDistancia(string posUno, string posDos)
        {
            var positionsUno = (await (new Geocoder()).GetPositionsForAddressAsync(posUno)).ToList();
            if (!positionsUno.Any())
            {
                return -1.0;
            }

            var positionsDos = (await (new Geocoder()).GetPositionsForAddressAsync(posDos)).ToList();
            if (!positionsDos.Any())
            {
                return -1.0;
            }

            var pos1 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsUno.First().Latitude,
                Longitude = positionsUno.First().Longitude
                //Latitude = 48.4568664,
                //Longitude = 35.0352648
            };

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsDos.First().Latitude,
                Longitude = positionsDos.First().Longitude
                //Latitude = 48.3837615903,
                //Longitude = 35.0011338294
            };


            var distance = Xamarin.Forms.Labs.Services.Geolocation.PositionExtensions.DistanceFrom(pos1, pos2);

            return distance;

            //System.Diagnostics.Debug.WriteLine(distance);
        }

        public async Task<List<string>> GetListado()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));

            List<string> lista = new List<string>();

            foreach (var p in locationAddress)
            {
                lista.Add(p.ToString());
            }

            return lista;
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
