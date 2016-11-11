using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Robotics.Mobile.Core.Bluetooth.LE;
using Xamarin.Forms;
using FitSense.Dependencies;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using FitSense.Models;
using System.Diagnostics;

namespace FitSense.ViewModels
{
    public class SensorConnectViewModel : ViewModelBase
    {
        private const string startScanText = "Start Scan";
        private const string stopScanText = "Stop Scan";

        private IAdapter adapter;
        private INavigationService navigationService;

        public string ScanButtonText { get; private set; }
        public ObservableCollection<IDevice> Devices { get; private set; }
        
        public RelayCommand<object> ItemSelectedCommand { get; private set; }
        public RelayCommand ScanCommand { get; private set; }
        

        public SensorConnectViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            adapter = DependencyService.Get<IBluetoothService>().Adapter;
            this.Devices = new ObservableCollection<IDevice>();
            ScanButtonText = startScanText;

            InitializeAdapter();
            InitializeCommands();
        }

        private void InitializeAdapter()
        {
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs args) =>
            {
                Debug.WriteLine("anything");
                if (!Devices.Any(d => d.ID == args.Device.ID))
                {
                    Devices.Add(args.Device);
                }
            };

            adapter.ScanTimeoutElapsed += (object sender, EventArgs args) =>
            {
                StopScanning();
            };

         }

        private void InitializeCommands()
        {
            ItemSelectedCommand = new RelayCommand<object>(async (item) =>
            {
                IDevice device = (IDevice)item;
                ServiceLocator.Current.GetInstance<SensorDevice>().ConnectedDevice = device;
                StopScanning();
                await navigationService.PopAsync();
            });

            ScanCommand = new RelayCommand(() => StartScanning());
        }

        private void StartScanning()
        {
            Devices.Clear();
            adapter.StartScanningForDevices(Guid.Empty);
            ScanButtonText = stopScanText;
        }

        private void StopScanning()
        {
            if (adapter.IsScanning)
            {
                adapter.StopScanningForDevices();
                ScanButtonText = startScanText;
            }
        }
    }
}
