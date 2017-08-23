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

        //added
        public RelayCommand SimulatorCommand { get; private set; }
        

        public SensorConnectViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            adapter = ServiceLocator.Current.GetInstance<IBluetoothService>().Adapter;
            this.Devices = new ObservableCollection<IDevice>();
            ScanButtonText = startScanText;

            InitializeAdapter();
            InitializeCommands();
        }

        private void InitializeAdapter()
        {
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs args) =>
            {
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

            //added
            SimulatorCommand = new RelayCommand(() => AddEmulator());
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

        //added
        private void AddEmulator()
        {
            SensorDevice simulator = new SensorDevice();
            //simulator.ConnectedDevice = new Device();

            ServiceLocator.Current.GetInstance<SensorDevice>().ConnectedDevice = (IDevice) simulator;
            //Devices.Add(emulator);
            //Devices.Add(new SensorDevice());
        }
    }
}
