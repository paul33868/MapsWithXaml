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

        Coordenadas Coords;
    
        public string MyAdress { get; set; }        

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

        public BetterViewModel()
        {            
            Coords = new Coordenadas();
            MyAdress = "Enter your adress here";

            GetCoords = new Command(GetCoordsEvent);
            GetAdress = new Command(GetandShowAdress);
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
