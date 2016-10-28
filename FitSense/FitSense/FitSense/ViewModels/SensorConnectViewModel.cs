using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Robotics.Mobile.Core.Bluetooth.LE;
using Xamarin.Forms;
using FitSense.Dependencies;

namespace FitSense.ViewModels
{
    public class SensorConnectViewModel : ViewModelBase
    {
        private IAdapter adapter;

        public RelayCommand itemSelectedCommand;
        
        public SensorConnectViewModel()
        {
            adapter = DependencyService.Get<IBluetoothService>().Adapter;
        }





    }
}
