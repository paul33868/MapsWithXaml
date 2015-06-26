using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DevSuperPowersDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DevSuperPowersDemo.ViewModels
{
    public class BetterViewModel : INotifyPropertyChanged
    {
        private string _GetCoordsLabel;
        private string _AdressLabel;
        private string _GetAdressLabel;

        private List<string> _LvLista;
        private string _PosUno;
        private string _PosDos;
        private string _LblDistanciaMetros;
        private string _LblDistanciaKilometros;
        private string _LblDistanciaMillas;

        Coordenadas Coords;

        public string LblDistanciaMillas
        {
            get
            {
                return _LblDistanciaMillas;
            }
            set
            {
                _LblDistanciaMillas = value;
                OnPropertyChanged("LblDistanciaMillas");
            }
        }

        public string LblDistanciaKilometros
        {
            get
            {
                return _LblDistanciaKilometros;
            }
            set
            {
                _LblDistanciaKilometros = value;
                OnPropertyChanged("LblDistanciaKilometros");
            }
        }

        public string LblDistanciaMetros
        {
            get
            {
                return _LblDistanciaMetros;
            }
            set
            {
                _LblDistanciaMetros = value;
                OnPropertyChanged("LblDistanciaMetros");
            }
        }

        public string PosUno
        {
            get
            {
                return _PosUno;
            }
            set
            {
                _PosUno = value;
                OnPropertyChanged("PosUno");
            }
        }

        public string PosDos
        {
            get
            {
                return _PosDos;
            }
            set
            {
                _PosDos = value;
                OnPropertyChanged("PosDos");
            }
        }

        public string MyAdress { get; set; }

        public List<string> LvDatos
        {
            get
            {
                return _LvLista;
            }
            set
            {
                _LvLista = value;
                OnPropertyChanged("LvDatos");
            }
        }

        public string GetCoordsLabel
        {
            get { return _GetCoordsLabel; }
            set
            {
                _GetCoordsLabel = value;
                OnPropertyChanged("GetCoordsLabel");
            }
        }

        public string AdressLabel
        {
            get { return _AdressLabel; }
            set
            {
                _AdressLabel = value;
                OnPropertyChanged("AdressLabel");
            }
        }

        public string GetAdressLabel
        {
            get { return _GetAdressLabel; }
            set
            {
                _GetAdressLabel = value;
                OnPropertyChanged("GetAdressLabel");
            }
        }

        public ICommand GetCoords { get; set; }
        public ICommand GetAdress { get; set; }
        public ICommand Rellenador { get; set; }
        public ICommand Distancia_Clicked { get; set; }

        public BetterViewModel()
        {
            Coords = new Coordenadas();
            MyAdress = "Enter your adress here";

            GetCoords = new Command(GetCoordsEvent);
            GetAdress = new Command(GetandShowAdress);
            Rellenador = new Command(GetRellenar);
            Distancia_Clicked = new Command(GetDistancia);
        }

        private async void GetDistancia()
        {
            double dMtrs = await Coords.GetDistancia(PosUno, PosDos);
            LblDistanciaMetros = "La distancia en metros es: " + dMtrs.ToString();

            double dKm = dMtrs / 1000.0;
            LblDistanciaKilometros = "La distancia en kilometros es: " + dKm.ToString();

            double dMillas = dMtrs * 0.000621371192;
            LblDistanciaMillas = "La distancia en millas es: " + dMillas.ToString();
        }

        private async void GetRellenar()
        {
            var listado = await Coords.GetListado();
            LvDatos = listado;
        }

        private async void GetCoordsEvent()
        {
            var rta = await Coords.GetCoordenadas();
            GetCoordsLabel = "You're on " + rta;
        }

        private async void GetandShowAdress()
        {
            var rta = await Coords.ShowMyAdress();
            GetAdressLabel = "You're looking for " + rta;
        }

        #region INPC
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
